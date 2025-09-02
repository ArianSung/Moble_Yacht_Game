// 이 네임스페이스에 있는 클래스들을 '사용'하겠다는 선언입니다.
using Moble_Yacht_Game.Database.Core.Crud;    // Creator, Reader 등의 도구를 사용하기 위해
using Moble_Yacht_Game.Database.DataModels; // UserData 라는 데이터 그릇을 사용하기 위해
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Moble_Yacht_Game.Database.Handlers
{
    /// <summary>
    /// '유저'와 관련된 실제 로직(비즈니스 로직)을 처리하는 정적 클래스입니다.
    /// UI(LoginControl 등)는 이 클래스에게 "로그인 시켜줘" 라고 요청만 하면 되고,
    /// 이 클래스가 Core/Crud의 도구들을 사용하여 실제 DB 작업을 어떻게 처리할지 결정합니다.
    /// </summary>
    public static class UserDbHandler
    {

        #region === User Login and Registration ===

        /// <summary>
        /// 사용자의 로그인을 시도합니다.
        /// 이 메서드는 데이터베이스에 저장된 사용자 정보와 일치하는지 확인합니다.
        /// </summary>
        /// <param name="username">
        /// [string] 사용자가 로그인 창에 입력한 아이디입니다.
        /// </param>
        /// <param name="password">
        /// [string] 사용자가 로그인 창에 입력한 비밀번호입니다. (보안을 위해 실제로는 암호화된 값이 처리되어야 합니다.)
        /// </param>
        /// <returns>
        /// [UserData 객체]: 로그인에 성공하면, 해당 유저의 ID, 닉네임, 점수 등의 정보가 담긴 UserData 객체를 반환합니다.
        /// [null]: 로그인에 실패하면(아이디나 비밀번호가 틀리면) null을 반환합니다.
        /// </returns>
        public static UserData LoginUser(string username, string password)
        {
            // --- 1. 실행할 SQL 쿼리 준비 ---
            string query = "SELECT user_id, nickname, rank_score, wins, losses FROM Users WHERE username = @username AND password = @password";

            // --- 2. SQL 파라미터 준비 ---
            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("@username", username),
                new MySqlParameter("@password", password)
            };

            // --- 3. Reader 도구를 사용하여 쿼리 실행 ---
            using (MySqlDataReader reader = Reader.ExecuteQuery(query, parameters))
            {
                // --- 4. 결과 처리 ---
                if (reader != null && reader.Read())
                {
                    return new UserData
                    {
                        UserId = reader.GetInt64("user_id"),
                        Nickname = reader.GetString("nickname"),
                        RankScore = reader.GetInt32("rank_score"),
                        Wins = reader.GetInt32("wins"),
                        Losses = reader.GetInt32("losses")
                    };
                }
            }
            return null;
        }


        /// <summary>
        /// 새로운 사용자를 데이터베이스에 등록(회원가입)합니다.
        /// 이 메서드는 아이디/닉네임 중복 체크 후, 문제가 없으면 새로운 사용자 정보를 DB에 저장합니다.
        /// </summary>
        /// <param name="username">
        /// [string] 회원가입 시 사용자가 생성할 아이디.
        /// </param>
        /// <param name="password">
        /// [string] 회원가입 시 사용자가 생성할 비밀번호.
        /// </param>
        /// <param name="nickname">
        /// [string] 게임 내에서 사용할 사용자의 닉네임.
        /// </param>
        /// <param name="email">
        /// [string] 계정 분실 등을 위해 사용할 이메일 주소.
        /// </param>
        /// <returns>
        /// [true]: 회원가입에 성공했을 경우 true를 반환합니다.
        /// [false]: 아이디/닉네임 중복 등의 이유로 회원가입에 실패하면 false를 반환합니다.
        /// </returns>
        public static bool RegisterUser(string username, string password, string nickname, string email)
        {
            // --- 1. 아이디 또는 닉네임이 이미 존재하는지 중복 체크 ---
            string checkQuery = "SELECT COUNT(*) FROM Users WHERE username = @username OR nickname = @nickname";
            MySqlParameter[] checkParams = new MySqlParameter[]
            {
                new MySqlParameter("@username", username),
                new MySqlParameter("@nickname", nickname)
            };

            if (Convert.ToInt32(Reader.ExecuteScalar(checkQuery, checkParams)) > 0)
            {
                MessageBox.Show("이미 사용 중인 아이디 또는 닉네임입니다.");
                return false;
            }

            // --- 2. 중복이 없으면, 실제 사용자 정보를 데이터베이스에 삽입 ---
            string insertQuery = "INSERT INTO Users (username, password, nickname, email, created_at) VALUES (@username, @password, @nickname, @email, NOW())";
            MySqlParameter[] insertParams = new MySqlParameter[]
            {
                new MySqlParameter("@username", username),
                new MySqlParameter("@password", password),
                new MySqlParameter("@nickname", nickname),
                new MySqlParameter("@email", email)
            };

            return Creator.ExecuteNonQuery(insertQuery, insertParams) > 0;
        }

        #endregion

        // 여기에 나중에 유저 랭킹을 가져오는 함수 등을 위한 새로운 region을 추가할 수 있습니다.
        // #region === User Ranking ===
        // ... 랭킹 관련 함수들 ...
        // #endregion
    }
}

