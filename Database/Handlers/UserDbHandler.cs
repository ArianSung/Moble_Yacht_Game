using Moble_Yacht_Game.Database.Core.Crud;
using Moble_Yacht_Game.Database.DataModels;
using MySql.Data.MySqlClient;
using System;

namespace Moble_Yacht_Game.Database.Handlers
{
    /// <summary>
    /// '유저'와 관련된 실제 로직(비즈니스 로직)을 처리하는 정적 클래스입니다.
    /// UI 계층은 이 클래스를 통해 데이터베이스 작업을 요청합니다.
    /// </summary>
    public static class UserDbHandler
    {
        #region === User Login and Registration ===

        /// <summary>
        /// 사용자의 로그인을 시도합니다.
        /// </summary>
        /// <param name="username">사용자가 입력한 아이디</param>
        /// <param name="password">사용자가 입력한 비밀번호</param>
        /// <returns>로그인 성공 시 UserData 객체, 실패 시 null을 반환합니다.</returns>
        public static UserData LoginUser(string username, string password)
        {
            // TODO: password는 해시된 값과 비교해야 합니다.
            string query = "SELECT user_id, nickname, rank_score, wins, losses, profile_image_url FROM Users WHERE username = @username AND password = @password";
            MySqlParameter[] parameters = { new MySqlParameter("@username", username), new MySqlParameter("@password", password) };

            using (var reader = Reader.ExecuteQuery(query, parameters))
            {
                if (reader != null && reader.Read())
                {
                    return new UserData
                    {
                        UserId = reader.GetInt64("user_id"),
                        Nickname = reader.GetString("nickname"),
                        RankScore = reader.GetInt32("rank_score"),
                        Wins = reader.GetInt32("wins"),
                        Losses = reader.GetInt32("losses"),
                        // DB의 값이 NULL일 수 있으므로, 안전하게 확인 후 가져옵니다.
                        ProfileImageUrl = reader.IsDBNull(reader.GetOrdinal("profile_image_url")) ? null : reader.GetString("profile_image_url")
                    };
                }
            }
            return null;
        }

        /// <summary>
        /// 새로운 사용자를 데이터베이스에 등록(회원가입)합니다.
        /// </summary>
        /// <param name="username">생성할 아이디</param>
        /// <param name="password">생성할 비밀번호</param>
        /// <param name="nickname">사용할 닉네임</param>
        /// <param name="email">사용할 이메일</param>
        /// <param name="profileImageUrl">Azure Blob Storage에 업로드된 프로필 이미지 URL (선택 사항)</param>
        /// <returns>회원가입 성공 시 true, 실패(중복 포함) 시 false를 반환합니다.</returns>
        public static bool RegisterUser(string username, string password, string nickname, string email, string profileImageUrl = null)
        {
            // UI가 아닌 핸들러 단에서 최종적으로 중복 여부를 한번 더 체크합니다.
            if (IsUsernameExists(username) || IsNicknameExists(nickname))
            {
                return false;
            }

            // TODO: password는 해시하여 저장해야 합니다.
            string query = "INSERT INTO Users (username, password, nickname, email, profile_image_url, created_at) VALUES (@username, @password, @nickname, @email, @profileImageUrl, NOW())";
            MySqlParameter[] parameters =
            {
                new MySqlParameter("@username", username),
                new MySqlParameter("@password", password),
                new MySqlParameter("@nickname", nickname),
                new MySqlParameter("@email", email),
                // profileImageUrl 값이 null이면 DB에 NULL 값을, 아니면 URL 문자열을 저장합니다.
                new MySqlParameter("@profileImageUrl", (object)profileImageUrl ?? DBNull.Value)
            };

            return Creator.ExecuteNonQuery(query, parameters) > 0;
        }

        #endregion

        #region === User Validation ===

        /// <summary>
        /// 주어진 아이디가 데이터베이스에 이미 존재하는지 확인합니다.
        /// </summary>
        /// <param name="username">확인할 아이디</param>
        /// <returns>존재하면 true, 존재하지 않거나 오류 발생 시 false</returns>
        public static bool IsUsernameExists(string username)
        {
            string query = "SELECT COUNT(*) FROM Users WHERE username = @username";
            MySqlParameter[] parameters = { new MySqlParameter("@username", username) };
            object result = Reader.ExecuteScalar(query, parameters);
            // 결과가 null이 아니고, 0보다 크다면 (즉, 1 이상이라면) 중복된 아이디가 존재한다는 의미입니다.
            return result != null && Convert.ToInt32(result) > 0;
        }

        /// <summary>
        /// 주어진 닉네임이 데이터베이스에 이미 존재하는지 확인합니다.
        /// </summary>
        /// <param name="nickname">확인할 닉네임</param>
        /// <returns>존재하면 true, 존재하지 않거나 오류 발생 시 false</returns>
        public static bool IsNicknameExists(string nickname)
        {
            string query = "SELECT COUNT(*) FROM Users WHERE nickname = @nickname";
            MySqlParameter[] parameters = { new MySqlParameter("@nickname", nickname) };
            object result = Reader.ExecuteScalar(query, parameters);
            return result != null && Convert.ToInt32(result) > 0;
        }

        #endregion
    }
}

