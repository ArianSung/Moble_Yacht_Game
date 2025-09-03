using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.IO;

namespace Moble_Yacht_Game.Database.Core
{
    /// <summary>
    /// 데이터베이스 연결을 관리하는 클래스입니다.
    /// appsettings.json에서 연결 정보를 안전하게 읽어오며, 오류 발생 시 UI와 독립적으로 예외를 발생시킵니다.
    /// </summary>
    public class DatabaseManager
    {
        // --- 싱글톤 패턴 구현 ---
        private static DatabaseManager _instance;
        public static DatabaseManager Instance => _instance ??= new DatabaseManager();
        // --- 싱글톤 패턴 구현 끝 ---

        private MySqlConnection conn;
        private readonly string connectionString;

        /// <summary>
        /// 생성자에서 appsettings.json 파일로부터 안전하게 데이터베이스 연결 문자열을 불러옵니다.
        /// </summary>
        private DatabaseManager()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        /// <summary>
        /// 데이터베이스와의 연결을 시작합니다.
        /// </summary>
        /// <exception cref="Exception">데이터베이스 연결에 실패할 경우, 원본 오류 메시지를 포함한 예외를 발생시킵니다.</exception>
        public void Connect()
        {
            try
            {
                if (conn != null && conn.State == System.Data.ConnectionState.Open)
                {
                    return;
                }
                conn = new MySqlConnection(connectionString);
                conn.Open();
            }
            catch (Exception ex)
            {
                // UI 계층에서 오류를 처리할 수 있도록 예외를 다시 던집니다. (역할 분리)
                throw new Exception($"데이터베이스 연결에 실패했습니다. (원본 오류: {ex.Message})");
            }
        }

        /// <summary>
        /// 데이터베이스와의 연결을 안전하게 종료합니다.
        /// </summary>
        public void Disconnect()
        {
            if (conn != null && conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 현재 활성화된 데이터베이스 연결 객체를 반환합니다.
        /// </summary>
        /// <returns>활성화된 MySqlConnection 객체를 반환합니다.</returns>
        /// <exception cref="Exception">데이터베이스가 연결되어 있지 않은 경우 예외를 발생시킵니다.</exception>
        public MySqlConnection GetConnection()
        {
            if (conn == null || conn.State != System.Data.ConnectionState.Open)
            {
                throw new Exception("데이터베이스가 연결되어 있지 않습니다.");
            }
            return conn;
        }
    }
}

