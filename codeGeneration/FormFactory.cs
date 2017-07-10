using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace codeGeneration
{
    class FormFactory
    {
        internal static void createForm(string path, string package,string basePackage, string tableName, string comment, string className, DataTable dt)
        {
            string[] packages = basePackage.Split('.');
            string packageComBase = "";
            for (int i = 0; i < 2; i++)
            {
                packageComBase += packages[i] + ".";
            }
            string firstClassName = className.Substring(0, 1).ToLower() + className.Substring(1);
            StringBuilder sb = new StringBuilder();
            sb.Append("package ").Append(package).Append(";").Append("\r\n\r\n");

            sb.Append("import ").Append(basePackage).Append(".entity.").Append(className).Append(";").Append("\r\n");
            sb.Append("import ").Append(packageComBase).Append("base.form.BaseForm;").Append("\r\n");
            sb.Append("import ").Append(packageComBase).Append("base.page.PageResult;").Append("\r\n");
            sb.Append("import ").Append(basePackage).Append(".dto.").Append(className).Append("Condition;").Append("\r\n");
            //sb.Append("/**").Append("\r\n");
            //sb.Append(" * ").Append(comment).Append("\r\n");
            //sb.Append(" * @creator 赵志豪\r\n");
            //sb.Append(" * @create-time ").Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")).Append("\r\n");
            //sb.Append(" * @email ").Append("490875647@qq.com").Append("\r\n");
            //sb.Append(" * @version 1.0").Append("\r\n");
            //sb.Append(" */").Append("\r\n");

            sb.Append("public class ").Append(className).Append("Form ").Append("extends BaseForm<").Append(className).Append(">{").Append("\r\n\r\n");
            sb.Append("\t").Append("private String").Append(" selIds;") .Append("\r\n\r\n");
            sb.Append("\t").Append("private ").Append(className).Append(" item = new ").Append(className).Append("();").Append("\r\n\r\n");
            sb.Append("\t").Append("private ").Append(className).Append("Condition condition = new ").Append(className).Append("Condition();").Append("\r\n\r\n");


            //getitem
            sb.Append("\t").Append("public String").Append(" getSelIds(){").Append("\r\n");
            sb.Append("\t\t").Append("return selIds;").Append("\r\n");
            sb.Append("\t").Append("}").Append("\r\n");
            //setitem
            sb.Append("\t").Append("public ").Append("void").Append(" setSelIds").Append("(String").Append(" selIds){").Append("\r\n");
            sb.Append("\t\t").Append("this.selIds").Append(" = selIds;").Append("\r\n");
            sb.Append("\t").Append("}").Append("\r\n\r\n");

            //getitem
            sb.Append("\t").Append("public ").Append(className).Append(" getItem(){").Append("\r\n");
            sb.Append("\t\t").Append("return item;").Append("\r\n");
            sb.Append("\t").Append("}").Append("\r\n");
            //setitem
            sb.Append("\t").Append("public ").Append("void").Append(" setItem").Append("(").Append(className).Append(" item){").Append("\r\n");
            sb.Append("\t\t").Append("this.item").Append(" = item;").Append("\r\n");
            sb.Append("\t").Append("}").Append("\r\n\r\n");


            //getcondition
            sb.Append("\t").Append("public ").Append(className).Append("Condition").Append(" getCondition(){").Append("\r\n");
            sb.Append("\t\t").Append("return condition;").Append("\r\n");
            sb.Append("\t").Append("}").Append("\r\n\r\r\n");

            //setcondition
            sb.Append("\t").Append("public ").Append("void").Append(" setCondition").Append("(").Append(className).Append("Condition").Append(" condition){").Append("\r\n");
            sb.Append("\t\t").Append("this.condition").Append(" = condition;").Append("\r\n");
            sb.Append("\t").Append("}").Append("\r\n\r\n");
            sb.Append("}").Append("\r\n\r\n");
            CodeGenerationFactory.write(path + "\\" + className + "Form.java",path,sb.ToString());
        }
    }
}
