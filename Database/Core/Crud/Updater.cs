using Moble_Yacht_Game.Database.Core;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Moble_Yacht_Game.Database.Core.Crud
{
    /// <summary>
    /// 데이터베이스의 데이터를 수정하는(UPDATE) 기능만을 담당하는 정적 클래스입니다.
    /// </summary>
    public static class Updater
    {
        /// <summary>
        /// UPDATE 쿼리를 실행하고, 영향을 받은 행의 수를 반환합니다.
        /// </summary>
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
            catch (Exception ex)
            {
                MessageBox.Show($"데이터 수정 중 오류 발생: {ex.Message}");
                return -1;
            }
        }
    }
}
