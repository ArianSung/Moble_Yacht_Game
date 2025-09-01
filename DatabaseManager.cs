using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Moble_Yacht_Game
{
    /// <summary>
    /// Azure MySQL 데이터베이스와의 모든 통신을 관리하는 싱글톤 클래스입니다.
    /// </summary>
    public class DatabaseManager
    {
        #region 싱글톤 구현
        // 클래스의 유일한 인스턴스를 저장하기 위한 정적 변수
        private static DatabaseManager instance = null;

        // 다른 클래스에서 'new DatabaseManager()'를 호출하지 못하도록 private으로 생성자를 선언
        private DatabaseManager() { }

        /// <summary>
        /// DatabaseManager의 전역 인스턴스에 접근하기 위한 속성입니다.
        /// </summary>
        public static DatabaseManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DatabaseManager();
                }
                return instance;
            }
        }
        #endregion

        // 데이터베이스 연결 객체
        private MySqlConnection connection;

        // Azure DB 연결 정보 (본인의 정보로 반드시 수정해야 합니다!)
        private string connectionString = "Server=yacht-game-db-server.mysql.database.azure.com;Database=yacht_db;Uid=yacht_admin@yacht-game-db-server;Pwd=your_password;";

        /// <summary>
        /// 데이터베이스에 비동기적으로 연결을 시도합니다.
        /// </summary>
        /// <returns>연결 성공 시 true, 실패 시 false를 반환합니다.</returns>
        public bool Connect()
        {
            try
            {
                // 연결 문자열을 사용하여 MySqlConnection 객체 생성
                connection = new MySqlConnection(connectionString);
                // 데이터베이스 연결 열기
                connection.Open();
                Console.WriteLine("데이터베이스 연결에 성공했습니다.");
                return true;
            }
            catch (Exception ex)
            {
                // 오류 발생 시 메시지 박스로 사용자에게 알림
                MessageBox.Show($"데이터베이스 연결 실패: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// 데이터베이스 연결을 종료합니다.
        /// </summary>
        public void Disconnect()
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
                Console.WriteLine("데이터베이스 연결을 해제했습니다.");
            }
        }

        /// <summary>
        /// 사용자의 로그인을 시도하고, 성공 시 사용자 정보를 반환합니다.
        /// </summary>
        /// <param name="username">사용자가 입력한 아이디</param>
        /// <param name="password">사용자가 입력한 비밀번호</param>
        /// <returns>로그인 성공 시 UserData 객체, 실패 시 null을 반환합니다.</returns>
        public UserData LoginUser(string username, string password)
        {
            // 중요: 실제 프로젝트에서는 비밀번호를 반드시 해시(Hash)하여 비교해야 합니다!
            //       이 코드는 개발 초기 단계를 위한 예시입니다.
            try
            {
                string query = "SELECT user_id, nickname, rank_score, wins, losses FROM Users WHERE username = @username AND password = @password";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password); // 실제로는 해시된 비밀번호를 비교해야 함

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // 로그인 성공, 사용자 정보를 UserData 객체에 담아 반환
                        UserData user = new UserData
                        {
                            UserId = reader.GetInt64("user_id"),
                            Nickname = reader.GetString("nickname"),
                            RankScore = reader.GetInt32("rank_score"),
                            Wins = reader.GetInt32("wins"),
                            Losses = reader.GetInt32("losses")
                        };
                        return user;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"로그인 중 오류 발생: {ex.Message}");
            }

            // 로그인 실패
            return null;
        }

        /// <summary>
        /// 새로운 사용자를 데이터베이스에 등록합니다.
        /// </summary>
        /// <param name="username">생성할 아이디</param>
        /// <param name="password">생성할 비밀번호</param>
        /// <param name="nickname">생성할 닉네임</param>
        /// <param name="email">생성할 이메일</param>
        /// <returns>회원가입 성공 시 true, 실패 시 false를 반환합니다.</returns>
        public bool RegisterUser(string username, string password, string nickname, string email)
        {
            // 중요: 실제 프로젝트에서는 비밀번호를 해시하여 저장해야 합니다!
            try
            {
                // 아이디 또는 닉네임 중복 체크
                string checkQuery = "SELECT COUNT(*) FROM Users WHERE username = @username OR nickname = @nickname";
                MySqlCommand checkCmd = new MySqlCommand(checkQuery, connection);
                checkCmd.Parameters.AddWithValue("@username", username);
                checkCmd.Parameters.AddWithValue("@nickname", nickname);

                if (Convert.ToInt32(checkCmd.ExecuteScalar()) > 0)
                {
                    MessageBox.Show("이미 사용 중인 아이디 또는 닉네임입니다.");
                    return false;
                }

                // 사용자 정보 삽입
                string insertQuery = "INSERT INTO Users (username, password, nickname, email, created_at) VALUES (@username, @password, @nickname, @email, NOW())";
                MySqlCommand insertCmd = new MySqlCommand(insertQuery, connection);
                insertCmd.Parameters.AddWithValue("@username", username);
                insertCmd.Parameters.AddWithValue("@password", password); // 실제로는 해시된 비밀번호를 저장해야 함
                insertCmd.Parameters.AddWithValue("@nickname", nickname);
                insertCmd.Parameters.AddWithValue("@email", email);

                int rowsAffected = insertCmd.ExecuteNonQuery();

                // 1개 이상의 행이 영향을 받았다면 성공
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"회원가입 중 오류 발생: {ex.Message}");
                return false;
            }
        }
    }
}
