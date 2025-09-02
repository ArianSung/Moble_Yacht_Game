using Moble_Yacht_Game.Database.Core;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Moble_Yacht_Game.Database.Core.Crud
{
    /// <summary>
    /// 데이터베이스에서 데이터를 읽는(SELECT) 기능만을 담당하는 정적 클래스입니다.
    /// </summary>
    public static class Reader
    {
        /// <summary>
        /// SELECT 쿼리를 실행하고, 그 결과를 MySqlDataReader로 반환합니다.
        /// MySqlDataReader는 조회된 데이터를 한 줄(row)씩 순차적으로 읽을 수 있게 해주는 '판독기'입니다.
        /// </summary>
        /// <param name="query">실행할 SELECT 쿼리 문장</param>
        /// <param name="parameters">SQL 인젝션 공격을 방지하기 위한 파라미터 배열</param>
        /// <returns>조회 결과를 담고 있는 MySqlDataReader 객체. 오류 시 null.</returns>
        public static MySqlDataReader ExecuteQuery(string query, MySqlParameter[] parameters = null)
        {
            try
            {
                MySqlConnection conn = DatabaseManager.Instance.GetConnection();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                // ExecuteReader()는 SELECT 쿼리 실행에 사용되며, 결과 데이터를 읽을 수 있는 판독기를 반환합니다.
                return cmd.ExecuteReader();
            }
            catch (Exception)
            {
                // UI 요소를 제거하고, 오류 발생 시 null을 반환합니다.
                return null;
            }
        }

        /// <summary>
        /// SELECT COUNT(*) 와 같이 테이블 전체가 아닌, 단일 값(스칼라 값) 하나만을 반환하는 쿼리를 실행합니다.
        /// (예: "현재 유저가 총 몇 명인가?")
        /// </summary>
        /// <param name="query">실행할 SELECT 쿼리 문장</param>
        /// <param name="parameters">SQL 인젝션 공격을 방지하기 위한 파라미터 배열</param>
        /// <returns>쿼리 결과의 첫 번째 행, 첫 번째 열에 있는 값. 오류 시 null.</returns>
        public static object ExecuteScalar(string query, MySqlParameter[] parameters = null)
        {
            try
            {
                MySqlConnection conn = DatabaseManager.Instance.GetConnection();
                MySqlCommand cmd = new MySqlCommand(query, conn);

                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                // ExecuteScalar()는 단 하나의 값을 빠르고 효율적으로 가져올 때 사용합니다.
                return cmd.ExecuteScalar();
            }
            catch (Exception)
            {
                // UI 요소를 제거하고, 오류 발생 시 null을 반환합니다.
                return null;
            }
        }
    }
}

