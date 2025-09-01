using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Moble_Yacht_Game.Database.Core
{
    /// <summary>
    /// 데이터베이스 연결과 해제만을 전담하는 싱글톤 클래스입니다.
    /// </summary>
    public class DatabaseManager
    {
        #region 싱글톤 구현
        private static DatabaseManager instance = null;
        private DatabaseManager() { }
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

        private MySqlConnection connection;
        private string connectionString = "Server=yacht-game-db-server.mysql.database.azure.com;" +
                                        "Database=yacht_db;" +
                                        "Uid=yacht_admin@yacht-game-db-server;" +
                                        "Pwd=moble1234!;";

        public MySqlConnection GetConnection()
        {
            return connection;
        }

        public bool Connect()
        {
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                Console.WriteLine("데이터베이스 연결 성공.");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"데이터베이스 연결 실패: {ex.Message}");
                return false;
            }
        }

        public void Disconnect()
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
                Console.WriteLine("데이터베이스 연결 해제.");
            }
        }
    }
}

