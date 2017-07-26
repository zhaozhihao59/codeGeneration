using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace codeGeneration
{
    class DtoFactory
    {

        internal static void createDto(string path, string package,string basePackage, string tableName, string comment, string className, DataTable dt)
        {
            string firstClassName = className.Substring(0, 1).ToLower() + className.Substring(1);
            StringBuilder sb = new StringBuilder();
            sb.Append("package ").Append(package).Append(";").Append("\r\n\r\n");
            sb.Append("import ").Append("java.io.Serializable;").Append("\r\n");
            
            //sb.Append("/**").Append("\r\n");
            //sb.Append(" * ").Append(comment).Append("\r\n");
            //sb.Append(" * @creator 赵志豪\r\n");
            //sb.Append(" * @create-time ").Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")).Append("\r\n");
            //sb.Append(" * @email ").Append("490875647@qq.com").Append("\r\n");
            //sb.Append(" * @version 1.0").Append("\r\n");
            //sb.Append(" */").Append("\r\n");
            
            sb.Append("public class ").Append(className).Append("Dto extends BaseDto<"+className+">").Append(" implements Serializable {").Append("\r\n");
            sb.Append("\t").Append("private static final long serialVersionUID = 7904053207325003853L;").Append("\r\n\r\n");
            foreach (DataRow row in dt.Rows) {
                string dataTypeResult = DataTypeMapping.getDataType(row["dataType"].ToString());
                //if(dataTypeResult == "String"){
                    string fieldName = row["fieldName"].ToString();
                    string firstFieldName = fieldName.Substring(0,1).ToLower() + fieldName.Substring(1);
                    
                    sb.Append("\t").Append("/** ").Append(row["comment"].ToString()).Append(" */").Append("\r\n");
                    sb.Append("\t").Append("private ").Append(dataTypeResult).Append(" ").Append(firstFieldName).Append(";").Append("\r\n"); ;
                //}
            }
            sb.Append("\r\n");
            //get set 封装
            foreach (DataRow row in dt.Rows)
            {
                string dataTypeResult = DataTypeMapping.getDataType(row["dataType"].ToString());
                //if (dataTypeResult == "String")
                //{
                    string fieldName = row["fieldName"].ToString();
                    string firstFieldName = fieldName.Substring(0, 1).ToLower() + fieldName.Substring(1);
                    //get
                    sb.Append("\t").Append("/** ").Append(row["comment"].ToString()).Append(" */").Append("\r\n");
                    sb.Append("\t").Append("public ").Append(dataTypeResult).Append(" get").Append(fieldName).Append("(){").Append("\r\n");
                    sb.Append("\t\t").Append("return this.").Append(firstFieldName).Append(";").Append("\r\n");
                    sb.Append("\t").Append("}").Append("\r\n\r\n");

                    //set
                    sb.Append("\t").Append("/** ").Append(row["comment"].ToString()).Append(" */").Append("\r\n");
                    sb.Append("\t").Append("public ").Append("void").Append(" set").Append(fieldName).Append("(String ").Append(firstFieldName).Append("){").Append("\r\n");
                    sb.Append("\t\t").Append("this.").Append(firstFieldName).Append(" = ").Append(firstFieldName).Append(";").Append("\r\n");
                    sb.Append("\t").Append("}").Append("\r\n\r\n");
                //}
            }
            sb.Append("}");
            CodeGenerationFactory.write(path + "\\" + className + "Dto.java",path,sb.ToString());

        }
    }
}
