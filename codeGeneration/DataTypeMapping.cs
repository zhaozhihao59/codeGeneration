using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codeGeneration
{
    class DataTypeMapping
    {
        private static Dictionary<string, string> dataMap = new Dictionary<string, string>();

        public static void initDataMap() {
            dataMap.Clear();
            //整数类型
            dataMap.Add("tinyint", "Integer");
            dataMap.Add("smallint", "Integer");
            dataMap.Add("mediumint", "Integer");
            dataMap.Add("int", "Integer");
            dataMap.Add("bigint", "Long");
            dataMap.Add("bit", "Integer");
            //浮点类型
            dataMap.Add("float", "Double");
            dataMap.Add("double", "Double");
            dataMap.Add("decimal", "Double");
            //字符串类型
            dataMap.Add("char","String");
            dataMap.Add("varchar", "String");
            dataMap.Add("tinytext", "String");
            dataMap.Add("text", "String");
            dataMap.Add("mediumtext", "String");
            dataMap.Add("longtext", "String");
            //日期类型
            dataMap.Add("date", "Date");
            dataMap.Add("time", "Date");
            dataMap.Add("year", "Date");
            dataMap.Add("datetime", "Date");
            dataMap.Add("timestamp", "Date");
        }

        public static string getDataType(string key) {
            if (dataMap.ContainsKey(key))
            {
                return dataMap[key];
            }
            else 
            {
                return "String";
            }
        }
    }
}
