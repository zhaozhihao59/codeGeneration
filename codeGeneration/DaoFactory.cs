using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace codeGeneration
{
    class DaoFactory
    {
        public static void createDao(string path, string package,string basePackage,string tableName, string comment, string className, DataTable dt)
        {
            string firstClassName = className.Substring(0, 1).ToLower() + className.Substring(1);
            StringBuilder sb = new StringBuilder();
            sb.Append("package ").Append(package).Append(";").Append("\r\n\r\n");    
            sb.Append("import ").Append("java.util.List;").Append("\r\n");
            sb.Append("import ").Append("org.apache.ibatis.annotations.Param;").Append("\r\n");
            sb.Append("import ").Append("org.apache.ibatis.session.RowBounds;").Append("\r\n");
            sb.Append("import ").Append("org.springframework.stereotype.Repository;").Append("\r\n\r\n");
            
            sb.Append("import ").Append(basePackage).Append(".entity.").Append(className).Append(";").Append("\r\n");
            sb.Append("import ").Append(basePackage).Append(".model.").Append(className).Append("Condition;").Append("\r\n");
            //sb.Append("/**").Append("\r\n");
            //sb.Append(" * ").Append(comment).Append("\r\n");
            //sb.Append(" * @creator 赵志豪\r\n");
            //sb.Append(" * @create-time ").Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")).Append("\r\n");
            //sb.Append(" * @email ").Append("490875647@qq.com").Append("\r\n");
            //sb.Append(" * @version 1.0").Append("\r\n");
            //sb.Append(" */").Append("\r\n");
            sb.Append("@Repository(\"" + firstClassName + "DaoImpl\")").Append("\r\n");
            sb.Append("public interface I").Append(className).Append("Dao{").Append("\r\n\r\n");

            //查询所有数据
            sb.Append("\t/**").Append("\r\n");
            sb.Append("\t * 查询所有").Append(comment).Append("\r\n");
            sb.Append("\t */").Append("\r\n");
            sb.Append("\t").Append("List<").Append(className).Append("> list"+className+"All();").Append("\r\n\r\n");
            
            //查询总数
            sb.Append("\t/**").Append("\r\n");
            sb.Append("\t * 查询总数").Append("\r\n");
            sb.Append("\t *").Append("@param condition 查询条件类").Append("\r\n");
            sb.Append("\t *").Append("@return 总条数").Append("\r\n");
            sb.Append("\t */").Append("\r\n");
            sb.Append("\t").Append("int get"+className+"ByPageCount").Append("(@Param(\"condition\") "+className+"Model condition);").Append("\r\n\r\n");

            //查询分页数据
            sb.Append("\t/**").Append("\r\n");
            sb.Append("\t * 分页查询").Append("\r\n");
            sb.Append("\t *").Append("@param bounds RowBounds对象").Append("\r\n");
            sb.Append("\t *").Append("@param condition 查询条件类").Append("\r\n");
            sb.Append("\t *").Append("@return 总条数").Append("\r\n");
            sb.Append("\t */").Append("\r\n");
            sb.Append("\t").Append("List<").Append(className).Append("> list").Append(className).Append("ByPage(@Param(\"condition\") ").Append(className).Append("Model condition").Append(",RowBounds bounds);").Append("\r\n\r\n");
            string resultDataType = "Long";
            foreach (DataRow row in dt.Rows)
            {
                string fieldName = row["fieldName"].ToString().Substring(0, 1).ToUpper() + row["fieldName"].ToString().Substring(1);
                if (fieldName == "Id")
                {
                    resultDataType = DataTypeMapping.getDataType(row["dataType"].ToString());
                    break;
                }
            }
            //根据ID查询
            sb.Append("\t/**").Append("\r\n");
            sb.Append("\t * 根据ID查询").Append("\r\n");
            sb.Append("\t *").Append("@param id 主键").Append("\r\n");
            sb.Append("\t *").Append("@return ").Append(comment).Append("\r\n");;
            sb.Append("\t */").Append("\r\n");
            sb.Append("\t").Append(className).Append(" get" + className + "ById").Append("(@Param(\"id\") " + resultDataType + " id);").Append("\r\n\r\n");
            
            //新增
            sb.Append("\t/**").Append("\r\n");
            sb.Append("\t * 新增").Append("\r\n");
            sb.Append("\t *").Append("@param item ").Append(comment).Append("\r\n");
            sb.Append("\t */").Append("\r\n");
            sb.Append("\t").Append("void add(").Append(className).Append(" item);").Append("\r\n\r\n");
            
            //批量新增
            sb.Append("\t/**").Append("\r\n");
            sb.Append("\t * 批量新增").Append("\r\n");
            sb.Append("\t *").Append("@param List ").Append("\r\n");
            sb.Append("\t */").Append("\r\n");
            sb.Append("\t").Append("void batchInsert(").Append("List<"+className+"> arrayList);").Append("\r\n\r\n");


            //修改
            sb.Append("\t/**").Append("\r\n");
            sb.Append("\t * 修改").Append("\r\n");
            sb.Append("\t *").Append("@param item ").Append(comment).Append("\r\n");
            sb.Append("\t */").Append("\r\n");
            sb.Append("\t").Append("void update(").Append(className).Append(" item);").Append("\r\n\r\n");

            //删除
            sb.Append("\t/**").Append("\r\n");
            sb.Append("\t * 删除").Append("\r\n");
            sb.Append("\t *").Append("@param item ").Append(comment).Append("\r\n");
            sb.Append("\t */").Append("\r\n");
            sb.Append("\t").Append("void delByIds(").Append("List<"+resultDataType+"> ids);").Append("\r\n\r\n");
            sb.Append("}").Append("\r\n");
            //生成
            CodeGenerationFactory.write(path + "\\I"+className+ "Dao.java",path,sb.ToString());

        }


        //public static void createDao(string path, string package, string basePackage, string tableName, string comment, string className, DataTable dt)
        //{
        //    string firstClassName = className.Substring(0, 1).ToLower() + className.Substring(1);
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("package ").Append(package).Append(";").Append("\r\n\r\n");
        //    sb.Append("import ").Append("java.util.List;").Append("\r\n");
        //    sb.Append("import ").Append("org.apache.ibatis.annotations.Param;").Append("\r\n");
        //    sb.Append("import ").Append("org.apache.ibatis.session.RowBounds;").Append("\r\n");
        //    sb.Append("import ").Append("org.springframework.stereotype.Repository;").Append("\r\n\r\n");

        //    sb.Append("import ").Append(basePackage).Append(".entity.").Append(className).Append(";").Append("\r\n");
        //    sb.Append("import ").Append(basePackage).Append(".dto.").Append(className).Append("Condition;").Append("\r\n");
        //    sb.Append("/**").Append("\r\n");
        //    sb.Append(" * ").Append(comment).Append("\r\n");
        //    sb.Append(" * @creator 赵志豪\r\n");
        //    sb.Append(" * @create-time ").Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")).Append("\r\n");
        //    sb.Append(" * @email ").Append("490875647@qq.com").Append("\r\n");
        //    sb.Append(" * @version 1.0").Append("\r\n");
        //    sb.Append(" */").Append("\r\n");
        //    sb.Append("@Repository(\"" + firstClassName + "DaoImpl\")").Append("\r\n");
        //    sb.Append("public interface I").Append(className).Append("Dao{").Append("\r\n\r\n");

        //    //查询所有数据
        //    sb.Append("\t/**").Append("\r\n");
        //    sb.Append("\t * 查询所有").Append(comment).Append("\r\n");
        //    sb.Append("\t */").Append("\r\n");
        //    sb.Append("\t").Append("List<").Append(className).Append("> list" + className + "All();").Append("\r\n\r\n");

        //    //查询总数
        //    sb.Append("\t/**").Append("\r\n");
        //    sb.Append("\t * 查询总数").Append("\r\n");
        //    sb.Append("\t *").Append("@param condition 查询条件类").Append("\r\n");
        //    sb.Append("\t *").Append("@return 总条数").Append("\r\n");
        //    sb.Append("\t */").Append("\r\n");
        //    sb.Append("\t").Append("int get" + className + "ByPageCount").Append("(@Param(\"condition\") " + className + "Condition condition);").Append("\r\n\r\n");

        //    //查询分页数据
        //    sb.Append("\t/**").Append("\r\n");
        //    sb.Append("\t * 分页查询").Append("\r\n");
        //    sb.Append("\t *").Append("@param bounds RowBounds对象").Append("\r\n");
        //    sb.Append("\t *").Append("@param condition 查询条件类").Append("\r\n");
        //    sb.Append("\t *").Append("@return 总条数").Append("\r\n");
        //    sb.Append("\t */").Append("\r\n");
        //    sb.Append("\t").Append("List<").Append(className).Append("> list").Append(className).Append("ByPage(RowBounds bounds,@Param(\"condition\") ").Append(className).Append("Condition condition);").Append("\r\n\r\n");

        //    string resultDataType = "Long";
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        string fieldName = row["fieldName"].ToString().Substring(0, 1).ToUpper() + row["fieldName"].ToString().Substring(1);
        //        if (fieldName == "Id")
        //        {
        //            resultDataType = DataTypeMapping.getDataType(row["dataType"].ToString());
        //            break;
        //        }
        //    }
        //    //根据ID查询
        //    sb.Append("\t/**").Append("\r\n");
        //    sb.Append("\t * 根据ID查询").Append("\r\n");
        //    sb.Append("\t *").Append("@param id 主键").Append("\r\n");
        //    sb.Append("\t *").Append("@return ").Append(comment).Append("\r\n"); ;
        //    sb.Append("\t */").Append("\r\n");
        //    sb.Append("\t").Append(className).Append(" get" + className + "ById").Append("(@Param(\"id\") " + resultDataType + " id);").Append("\r\n\r\n");

        //    //新增
        //    sb.Append("\t/**").Append("\r\n");
        //    sb.Append("\t * 新增").Append("\r\n");
        //    sb.Append("\t *").Append("@param item ").Append(comment).Append("\r\n");
        //    sb.Append("\t */").Append("\r\n");
        //    sb.Append("\t").Append("void add(").Append(className).Append(" item);").Append("\r\n\r\n");

        //    //批量新增
        //    sb.Append("\t/**").Append("\r\n");
        //    sb.Append("\t * 批量新增").Append("\r\n");
        //    sb.Append("\t *").Append("@param List ").Append("\r\n");
        //    sb.Append("\t */").Append("\r\n");
        //    sb.Append("\t").Append("void batchInsert(").Append("List<" + className + "> arrayList);").Append("\r\n\r\n");


        //    //修改
        //    sb.Append("\t/**").Append("\r\n");
        //    sb.Append("\t * 修改").Append("\r\n");
        //    sb.Append("\t *").Append("@param item ").Append(comment).Append("\r\n");
        //    sb.Append("\t */").Append("\r\n");
        //    sb.Append("\t").Append("void update(").Append(className).Append(" item);").Append("\r\n\r\n");

        //    //删除
        //    sb.Append("\t/**").Append("\r\n");
        //    sb.Append("\t * 删除").Append("\r\n");
        //    sb.Append("\t *").Append("@param item ").Append(comment).Append("\r\n");
        //    sb.Append("\t */").Append("\r\n");
        //    sb.Append("\t").Append("void delByIds(").Append("String[] ids);").Append("\r\n\r\n");
        //    sb.Append("}").Append("\r\n");
        //    //生成
        //    CodeGenerationFactory.write(path + "\\I" + className + "Dao.java", path, sb.ToString());

        //}
    }
}
