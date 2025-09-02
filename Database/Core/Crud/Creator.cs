using Moble_Yacht_Game.Database.Core;
using MySql.Data.MySqlClient;
using System;

namespace Moble_Yacht_Game.Database.Core.Crud
{
    /// <summary>
    /// 데이터베이스에 새로운 데이터를 생성(INSERT)하는 기능만을 담당하는 정적 클래스입니다.
    /// </summary>
    public static class Creator
    {
        /// <summary>
        /// INSERT, UPDATE, DELETE 같이 데이터를 반환하지 않는 쿼리를 실행합니다.
        /// </summary>
        /// <param name="query">실행할 SQL 쿼리 문장</param>
        /// <param name="parameters">SQL 인젝션 공격을 방지하기 위한 파라미터 배열</param>
        /// <returns>쿼리로 인해 영향을 받은 행의 개수를 반환합니다. 오류 발생 시 -1을 반환합니다.</returns>
        public static int ExecuteNonQuery(string query, MySqlParameter[] parameters = null)
        {
            try
            {
                MySqlConnection conn = DatabaseManager.Instance.GetConnection();
                using MySqlCommand cmd = new MySqlCommand(query, conn);

                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                // 오류 발생을 명확히 알리기 위해 -1을 반환합니다.
                return -1;
            }
        }
    }
}

