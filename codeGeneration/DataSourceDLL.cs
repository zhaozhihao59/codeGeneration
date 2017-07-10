using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace codeGeneration
{
    class DataSourceDLL
    {
        public DataTable getTablesInfo(DataModel model) {
            string sql = string.Format("select o.TABLE_NAME as 'tableName',o.TABLE_COMMENT as 'tableComment' from information_schema.`TABLES` o where o.TABLE_SCHEMA = '{0}'", model.DbName);
            DataTable dt = DBHelper.getDataTable(sql);
            dt.Columns.Add("className");
            dt.Columns.Add("dbName");
            foreach(DataRow row in dt.Rows){
                string className = row["tableName"].ToString();
                
                row["className"] = convertFeildName(className,true);
                row["dbName"] = model.DbName;
            }
            return dt;

        }


        public DataTable getTableFeildInfo(string tableName,string dbName) {
            string sql = string.Format("select o.COLUMN_NAME as 'columnName',o.DATA_TYPE as 'dataType',o.COLUMN_COMMENT as 'comment' from information_schema.`COLUMNS` o where  o.TABLE_NAME = '{0}' and o.TABLE_SCHEMA = '{1}'", tableName,dbName);

            DataTable dt = DBHelper.getDataTable(sql);
            dt.Columns.Add("fieldName");
            foreach (DataRow row in dt.Rows)
            {
                string dbFeild = row["columnName"].ToString();
                row["fieldName"] = convertFeildName(dbFeild,false);
            }
            return dt;
        }

        public string convertFeildName(string str,bool flag) {

            str = str.ToLower();
            StringBuilder sb = new StringBuilder();
            char[] charArr = str.ToCharArray();
            if (charArr[1] == '_')
            {
                for (int i = 1; i < charArr.Length; i++)
                {
                    if (charArr[i] == '_')
                    {
                        if (charArr[i + 1] >= 65 && charArr[i + 1] < 91)
                        {
                            sb.Append(charArr[i + 1]);
                        }
                        else if (charArr[i + 1] >= 97 && charArr[i + 1] < 123)
                        {
                            sb.Append((char)(charArr[i + 1] - 32));
                        }
                        i++;
                    }
                    else
                    {
                        sb.Append(charArr[i]);
                    }
                }
            }
            else
            {
                if ((charArr[0] >= 65 && charArr[0] < 91) || !flag)
                {
                    sb.Append(charArr[0]);
                }
                else if (charArr[0] >= 97 && charArr[0] < 123 && flag)
                {
                    sb.Append((char)(charArr[0] - 32));
                }
                for (int i = 1; i < charArr.Length; i++)
                {
                    if (charArr[i] == '_')
                    {
                        if (charArr[i + 1] >= 65 && charArr[i + 1] < 91)
                        {
                            sb.Append(charArr[i + 1]);
                        }
                        else if (charArr[i + 1] >= 97 && charArr[i + 1] < 123)
                        {
                            sb.Append((char)(charArr[i + 1] - 32));
                        }
                        else {
                            sb.Append(charArr[i + 1]);
                        }
                        i++;
                    }
                    else
                    {
                        sb.Append(charArr[i]);
                    }
                }
            }
            return sb.ToString();
        }
    }
}
