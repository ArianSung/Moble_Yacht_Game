using Moble_Yacht_Game.Database.Core;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Moble_Yacht_Game.Database.Core.Crud
{
    /// <summary>
    /// 데이터베이스의 기존 데이터를 삭제(DELETE)하는 기능만을 담당하는 정적 클래스입니다.
    /// </summary>
    public static class Deleter
    {
        /// <summary>
        /// DELETE 쿼리를 실행하여 데이터를 삭제합니다.
        /// 내부 로직은 Creator.ExecuteNonQuery와 완전히 동일하지만,
        /// 역할과 의미를 명확히 구분하기 위해 별도의 클래스로 분리했습니다.
        /// </summary>
        /// <param name="query">실행할 DELETE 쿼리 문장</param>
        /// <param name="parameters">SQL 인젝션 공격을 방지하기 위한 파라미터 배열</param>
        /// <returns>쿼리로 인해 영향을 받은 행(row)의 개수를 반환합니다.</returns>
        public static int ExecuteNonQuery(string query, MySqlParameter[] parameters = null)
        {
            try
            {
                MySqlConnection conn = DatabaseManager.Instance.GetConnection();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
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

