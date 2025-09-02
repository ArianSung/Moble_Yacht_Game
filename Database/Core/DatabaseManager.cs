using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

// 이 네임스페이스는 데이터베이스의 핵심 기능(연결, CRUD의 기반)을 담고 있습니다.
namespace Moble_Yacht_Game.Database.Core
{
    /// <summary>
    /// 데이터베이스 연결을 관리하는 클래스입니다.
    /// 프로그램 전체에서 단 하나의 연결 객체만 존재하도록 '싱글톤(Singleton)' 패턴으로 설계되었습니다.
    /// 이 클래스는 오직 '연결'과 '해제'라는 책임만 가집니다.
    /// </summary>
    public class DatabaseManager
    {
        // --- 싱글톤 패턴 구현 ---
        // _instance: DatabaseManager의 유일한 객체를 저장할 변수입니다.
        // private static으로 선언하여 외부에서 직접 접근하는 것을 막습니다.
        private static DatabaseManager _instance;

        // Instance: 외부에서 DatabaseManager 객체를 사용하고 싶을 때 호출하는 속성(Property)입니다.
        // 만약 _instance가 아직 생성되지 않았다면(null), 새로운 객체를 생성하여 할당합니다.
        // 이미 생성되어 있다면, 기존의 객체를 그대로 반환합니다.
        // 이를 통해 프로그램 어디서든 DatabaseManager.Instance 로 항상 동일한 객체를 참조할 수 있습니다.
        public static DatabaseManager Instance => _instance ??= new DatabaseManager();
        // --- 싱글톤 패턴 구현 끝 ---

        // MySqlConnection: 실제 데이터베이스와의 연결을 담당하는 객체입니다.
        private MySqlConnection conn;

        // connectionString: 데이터베이스에 연결하기 위한 정보(주소, 아이디, 비밀번호, DB이름 등)를 담는 문자열입니다.
        // 보안을 위해 실제 코드에서는 별도의 설정 파일에 저장하는 것이 좋습니다.
        // TODO: 아래 Server, Uid, Pwd, Database 값을 본인의 Azure MySQL 정보로 반드시 수정해야 합니다.
        private readonly string connectionString = "Server=서버주소.mysql.database.azure.com;Port=3306;Database=yacht_db;Uid=관리자ID;Pwd=비밀번호;SslMode=Required;";

        // 생성자(Constructor): DatabaseManager 객체가 처음 생성될 때 호출되는 부분입니다.
        // private으로 선언하여 외부에서 new DatabaseManager()로 새 객체를 만드는 것을 원천적으로 차단합니다. (싱글톤 유지)
        private DatabaseManager() { }

        /// <summary>
        /// 데이터베이스와의 연결을 시작합니다.
        /// 프로그램 시작 시 단 한 번만 호출하는 것을 권장합니다.
        /// </summary>
        /// <returns>연결 성공 시 true, 실패 시 false를 반환합니다.</returns>
        public bool Connect()
        {
            // try-catch: 예외(오류)가 발생할 가능성이 있는 코드를 안전하게 실행하기 위한 구문입니다.
            try
            {
                // 이미 연결이 되어있는 상태에서 또 연결을 시도하는 것을 방지합니다.
                if (conn != null && conn.State == System.Data.ConnectionState.Open)
                {
                    return true;
                }

                // 연결 문자열 정보를 바탕으로 MySqlConnection 객체를 생성합니다.
                conn = new MySqlConnection(connectionString);
                // 실제 데이터베이스 서버에 연결을 시도합니다.
                conn.Open();
                return true;
            }
            // catch: try 블록 안에서 오류가 발생했을 때 실행되는 부분입니다.
            catch (Exception ex)
            {
                // 어떤 오류가 발생했는지 메시지 박스로 사용자에게 알려줍니다.
                MessageBox.Show($"데이터베이스 연결 실패: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// 데이터베이스와의 연결을 종료합니다.
        /// 프로그램이 종료될 때 반드시 호출하여 자원을 반환해야 합니다.
        /// </summary>
        public void Disconnect()
        {
            // 연결 객체가 존재하고, 실제로 연결이 열려있는 상태인지 확인합니다.
            if (conn != null && conn.State == System.Data.ConnectionState.Open)
            {
                // 데이터베이스 연결을 닫습니다.
                conn.Close();
            }
        }

        /// <summary>
        /// 현재 활성화된 데이터베이스 연결 객체를 반환합니다.
        /// 다른 클래스(Creator, Reader 등)들이 이 함수를 통해 연결을 얻어 작업을 수행합니다.
        /// </summary>
        /// <returns>MySqlConnection 객체를 반환합니다.</returns>
        public MySqlConnection GetConnection()
        {
            return conn;
        }
    }
}

