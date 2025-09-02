using Moble_Yacht_Game.Database.Core;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Moble_Yacht_Game.Database.Core.Crud
{
    /// <summary>
    /// 데이터베이스에 새로운 데이터를 생성(INSERT)하는 기능만을 담당하는 정적 클래스입니다.
    /// 이 클래스는 어떤 데이터를 넣는지는 전혀 모르고, 오직 '넣는 행위' 자체에만 집중합니다.
    /// </summary>
    public static class Creator
    {
        /// <summary>
        /// INSERT, UPDATE, DELETE 같이 데이터를 반환하지 않는 쿼리를 실행합니다.
        /// </summary>
        /// <param name="query">실행할 SQL 쿼리 문장 (예: "INSERT INTO ...")</param>
        /// <param name="parameters">SQL 인젝션 공격을 방지하기 위한 파라미터 배열</param>
        /// <returns>쿼리로 인해 영향을 받은 행(row)의 개수를 반환합니다. (성공 시 1 이상)</returns>
        public static int ExecuteNonQuery(string query, MySqlParameter[] parameters = null)
        {
            try
            {
                // DatabaseManager로부터 현재 활성화된 DB 연결을 가져옵니다.
                MySqlConnection conn = DatabaseManager.Instance.GetConnection();

                // MySqlCommand: SQL 쿼리와 DB 연결 정보를 담는 '명령서' 객체입니다.
                MySqlCommand cmd = new MySqlCommand(query, conn);

                // 파라미터가 제공되었다면, 명령서에 파라미터들을 추가합니다.
                // 이는 'SQL Injection'이라는 해킹 공격을 방어하는 가장 중요한 부분입니다.
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                // 명령서를 데이터베이스에 보내 실행하고, 그 결과(영향받은 행의 수)를 반환합니다.
                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                // UI 요소를 제거하고, 오류 발생 시 -1을 반환합니다.
                return -1;
            }
        }
    }
}

