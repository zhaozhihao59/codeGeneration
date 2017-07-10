using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace codeGeneration
{
    class DBHelper
    {
        public static string constr = "server={0};User Id={1};password={2};Database={3}";

        public static MySqlConnection myconn = null;

        public static String testLink(DataModel data){
            string tempStr = string.Format(constr, data.Host, data.UserName, data.Password, data.DbName);
            myconn = new MySqlConnection(tempStr);
            try {
                myconn.Open();
                return "success";
            }
            catch (Exception ex) {
                
                return ex.Message;
            }
        }

        public static DataTable getDataTable(string sql) {
            DataTable dt = new DataTable();
            MySqlDataAdapter dap = new MySqlDataAdapter(sql,myconn);
            dap.Fill(dt);
            return dt;
        }
        
    }
}
