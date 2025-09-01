using Moble_Yacht_Game.Database.Core.Crud;
using Moble_Yacht_Game.Database.DataModels;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Moble_Yacht_Game.Database.Handlers
{
    /// <summary>
    /// '유저'와 관련된 데이터베이스 로직을 처리하는 정적 클래스입니다.
    /// Core/Crud 클래스들을 사용하여 실제 작업을 수행합니다.
    /// </summary>
    public static class UserDbHandler
    {
        /// <summary>
        /// 사용자의 로그인을 시도하고, 성공 시 사용자 정보를 반환합니다.
        /// </summary>
        public static UserData LoginUser(string username, string password)
        {
            // 중요: 실제로는 해시된 비밀번호를 비교해야 합니다.
            string query = "SELECT user_id, nickname, rank_score, wins, losses FROM Users WHERE username = @username AND password = @password";

            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("@username", username),
                new MySqlParameter("@password", password)
            };

            using (MySqlDataReader reader = Reader.ExecuteQuery(query, parameters))
            {
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
        /// 새로운 사용자를 데이터베이스에 등록합니다.
        /// </summary>
        public static bool RegisterUser(string username, string password, string nickname, string email)
        {
            // 1. 아이디 또는 닉네임 중복 체크 (Reader 사용)
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

            // 2. 사용자 정보 삽입 (Creator 사용)
            // 중요: 실제로는 해시된 비밀번호를 저장해야 합니다.
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
    }
}

