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
        /// </summary>
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
                return cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"데이터 조회 중 오류 발생: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// SELECT COUNT(*) 와 같이 단일 값을 반환하는 쿼리를 실행합니다.
        /// </summary>
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
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"데이터 조회 중 오류 발생: {ex.Message}");
                return null;
            }
        }
    }
}

