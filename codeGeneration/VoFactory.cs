using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace codeGeneration
{
   public class VoFactory
    {
       internal static void createVo(string path, string package, string basePackage, string tableName, string comment, string className, DataTable dt)
       {
           string firstClassName = className.Substring(0, 1).ToLower() + className.Substring(1);
           StringBuilder sb = new StringBuilder();
           sb.Append("package ").Append(package).Append(";").Append("\r\n\r\n");
           sb.Append("import ").Append("java.io.Serializable;").Append("\r\n");
           sb.Append("import com.fasterxml.jackson.databind.annotation.JsonSerialize;").Append("\r\n");
           sb.Append("import io.swagger.annotations.ApiModel;").Append("\r\n");
           sb.Append("import lombok.AllArgsConstructor;").Append("\r\n");
           sb.Append("import lombok.Builder;").Append("\r\n");
           sb.Append("import lombok.Data;").Append("\r\n");
           sb.Append("import lombok.NoArgsConstructor;").Append("\r\n");
           sb.Append("import lombok.Builder;").Append("\r\n");
           sb.Append("import io.swagger.annotations.ApiModelProperty;");
           //sb.Append("/**").Append("\r\n");
           //sb.Append(" * ").Append(comment).Append("\r\n");
           //sb.Append(" * @creator 赵志豪\r\n");
           //sb.Append(" * @create-time ").Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")).Append("\r\n");
           //sb.Append(" * @email ").Append("490875647@qq.com").Append("\r\n");
           //sb.Append(" * @version 1.0").Append("\r\n");
           //sb.Append(" */").Append("\r\n");
           sb.Append("@Builder").Append("\r\n");
           sb.Append("@Data").Append("\r\n");
           sb.Append("@NoArgsConstructor").Append("\r\n");
           sb.Append("@AllArgsConstructor").Append("\r\n");
           sb.Append("@JsonSerialize(include = JsonSerialize.Inclusion.NON_NULL)").Append("\r\n");
           sb.Append("@ApiModel").Append("\r\n");
           sb.Append("public class ").Append(className).Append("Vo ").Append(" implements Serializable {").Append("\r\n");
           sb.Append("\t").Append("private static final long serialVersionUID = 7904053207325003853L;").Append("\r\n\r\n");
           foreach (DataRow row in dt.Rows)
           {
               string dataTypeResult = DataTypeMapping.getDataType(row["dataType"].ToString());
               //if(dataTypeResult == "String"){
               string fieldName = row["columnName"].ToString();
               
               sb.Append("\t").Append("/** ").Append(row["comment"].ToString()).Append(" */").Append("\r\n");
               sb.Append("\t").Append("@ApiModelProperty(value = ").Append("\"" + row["comment"].ToString() + "\")").Append("\r\n");
               sb.Append("\t").Append("private ").Append(dataTypeResult).Append(" ").Append(fieldName).Append(";").Append("\r\n"); ;
               //}
           }
           sb.Append("\r\n");
           
           sb.Append("}");
           CodeGenerationFactory.write(path + "\\" + className + "Vo.java", path, sb.ToString());

       }
    }
}
