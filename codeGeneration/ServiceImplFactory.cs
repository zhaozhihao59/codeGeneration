using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace codeGeneration
{
    class ServiceImplFactory
    {
        internal static void createServiceImpl(string path, string package, string basePackage, string tableName, string comment, string className, DataTable dt)
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
            sb.Append("import ").Append("java.util.List;").Append("\r\n");
            sb.Append("import javax.annotation.Resource;").Append("\r\n");
            sb.Append("import org.springframework.stereotype.Service;").Append("\r\n"); ;
            sb.Append("import org.springframework.transaction.annotation.Transactional;").Append("\r\n\r\n");
            sb.Append("import org.apache.ibatis.session.RowBounds;").Append("\r\n");
            sb.Append("import ").Append(packageComBase).Append("base.page.PageResult;").Append("\r\n");
            sb.Append("import ").Append(basePackage).Append(".service.").Append("I").Append(className).Append("Service;").Append("\r\n");
            sb.Append("import ").Append(basePackage).Append(".entity.").Append(className).Append(";").Append("\r\n");
            sb.Append("import ").Append(basePackage).Append(".dto.").Append(className).Append("Dto;").Append("\r\n");
            sb.Append("import ").Append(basePackage).Append(".dao.").Append("I").Append(className).Append("Dao;").Append("\r\n");
            //sb.Append("/**").Append("\r\n");
            //sb.Append(" * ").Append(comment).Append("\r\n");
            //sb.Append(" * @creator 赵志豪\r\n");
            //sb.Append(" * @create-time ").Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")).Append("\r\n");
            //sb.Append(" * @email ").Append("490875647@qq.com").Append("\r\n");
            //sb.Append(" * @version 1.0").Append("\r\n");
            //sb.Append(" */").Append("\r\n");
            sb.Append("@Service(\"" + firstClassName + "ServiceImpl\")").Append("\r\n");
            sb.Append("@Transactional(value = \"transactionManager\")").Append("\r\n");
            sb.Append("public class ").Append(className).Append("ServiceImpl implements I").Append(className).Append("Service{").Append("\r\n\r\n");
            sb.Append("\t@Resource(name = \"" + firstClassName + "DaoImpl\")").Append("\r\n");
            sb.Append("\tprivate I").Append(className).Append("Dao ").Append(firstClassName).Append("Dao;").Append("\r\n\r\n\r\n\r\n");
            //查询所有数据
            sb.Append("\t/**").Append("\r\n");
            sb.Append("\t * 查询所有").Append(comment).Append("\r\n");
            sb.Append("\t */").Append("\r\n");
            sb.Append("\t@Override").Append("\r\n");
            sb.Append("\t").Append("public List<").Append(className).Append("> list" + className + "All(){").Append("\r\n");
            sb.Append("\t\t").Append("return ").Append(firstClassName).Append("Dao.list").Append(className).Append("All();").Append("\r\n");
            sb.Append("\t").Append("}").Append("\r\n\r\n");

            //根据条件查询
            sb.Append("\t/**").Append("\r\n");
            sb.Append("\t * 根据条件查询").Append(comment).Append("\r\n");
            sb.Append("\t */").Append("\r\n");
            sb.Append("\t@Override").Append("\r\n");
            sb.Append("\t").Append("public ").Append("List<").Append(className).Append("> list" + className + "ByCondition").Append("(" + className + "Dto condition){").Append("\r\n");
            sb.Append("\t\t").Append("return ").Append(firstClassName).Append("Dao.list").Append(className).Append("ByPage(condition,null);").Append("\r\n");
            sb.Append("\t}").Append("\r\n");

            //查询总数
            sb.Append("\t/**").Append("\r\n");
            sb.Append("\t * 查询总数").Append("\r\n");
            sb.Append("\t *").Append("@param condition 查询条件类").Append("\r\n");
            sb.Append("\t *").Append("@return 总条数").Append("\r\n");
            sb.Append("\t */").Append("\r\n");
            sb.Append("\t@Override").Append("\r\n");
            sb.Append("\t").Append("public int get" + className + "ByPageCount").Append("(" + className + "Dto condition){").Append("\r\n");
            sb.Append("\t\t").Append("return ").Append(firstClassName).Append("Dao.get").Append(className).Append("ByPageCount(condition);").Append("\r\n");
            sb.Append("\t").Append("}").Append("\r\n\r\n");

            //分页方法
            sb.Append("\t/**").Append("\r\n");
            sb.Append("\t * 分页查询").Append("\r\n");
            sb.Append("\t *").Append("@param pageResult 分页对象").Append("\r\n");
            sb.Append("\t *").Append("@param condition 查询条件类").Append("\r\n");
            sb.Append("\t */").Append("\r\n");
            sb.Append("\t@Override").Append("\r\n");
            sb.Append("\t").Append("public void list").Append(className).Append("ByPage(").Append(className).Append("Dto condition){").Append("\r\n");
            sb.Append("\t\t").Append("int rows = ").Append(firstClassName).Append("Dao.get").Append(className).Append("ByPageCount(condition);").Append("\r\n");
            sb.Append("\t\t").Append("pageResult.setRows(rows);").Append("\r\n");
            sb.Append("\t\t").Append("RowBounds rowBounds = new RowBounds(condition.pageResult.getCurrentPageIndex(),condition.pageResult.getPageSize());").Append("\r\n");
            sb.Append("\t\t").Append("List<").Append(className).Append("> list = ").Append(firstClassName).Append("Dao.list").Append(className).Append("ByPage(condition,rowBounds);").Append("\r\n");
            sb.Append("\t\t").Append("pageResult.setResult(list);").Append("\r\n");
            sb.Append("\t").Append("}").Append("\r\n\r\n");


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
            sb.Append("\t *").Append("@return ").Append(comment).Append("\r\n"); ;
            sb.Append("\t */").Append("\r\n");
            sb.Append("\t@Override").Append("\r\n");
            sb.Append("\t").Append("public ").Append(className).Append(" get" + className + "ById").Append("(" + resultDataType + " id){").Append("\r\n");
            sb.Append("\t\t").Append("return ").Append(firstClassName).Append("Dao.get").Append(className).Append("ById(id);").Append("\r\n");
            sb.Append("\t").Append("}").Append("\r\n\r\n");


            //新增
            sb.Append("\t/**").Append("\r\n");
            sb.Append("\t * 新增").Append("\r\n");
            sb.Append("\t *").Append("@param item ").Append(comment).Append("\r\n");
            sb.Append("\t */").Append("\r\n");
            sb.Append("\t@Override").Append("\r\n");
            sb.Append("\t").Append("public ").Append(className).Append(" add(").Append(className).Append(" item){").Append("\r\n");
            sb.Append("\t\t").Append(firstClassName).Append("Dao.add(item);").Append("\r\n");
            sb.Append("\t\t").Append("return item;").Append("\r\n");
            sb.Append("\t").Append("}").Append("\r\n\r\n");


            //批量新增
            sb.Append("\t/**").Append("\r\n");
            sb.Append("\t * 批量新增").Append("\r\n");
            sb.Append("\t *").Append("@param List ").Append("\r\n");
            sb.Append("\t */").Append("\r\n");
            sb.Append("\t@Override").Append("\r\n");
            sb.Append("\t").Append("public void").Append(" batchInsert(").Append("List<" + className + "> arrayList){").Append("\r\n\r\n");
            sb.Append("\t\t").Append(firstClassName).Append("Dao.batchInsert(arrayList);").Append("\r\n");
            sb.Append("\t").Append("}").Append("\r\n\r\n");

            //修改
            sb.Append("\t/**").Append("\r\n");
            sb.Append("\t * 修改").Append("\r\n");
            sb.Append("\t *").Append("@param item ").Append(comment).Append("\r\n");
            sb.Append("\t */").Append("\r\n");
            sb.Append("\t@Override").Append("\r\n");
            sb.Append("\t").Append("public ").Append(className).Append(" update(").Append(className).Append(" item){").Append("\r\n");
            sb.Append("\t\t").Append(firstClassName).Append("Dao.update(item);").Append("\r\n");
            sb.Append("\t\t").Append("return item;").Append("\r\n");
            sb.Append("\t").Append("}").Append("\r\n\r\n");


            //删除
            sb.Append("\t/**").Append("\r\n");
            sb.Append("\t * 删除").Append("\r\n");
            sb.Append("\t *").Append("@param item ").Append(comment).Append("\r\n");
            sb.Append("\t */").Append("\r\n");
            sb.Append("\t@Override").Append("\r\n");
            sb.Append("\t").Append("public void").Append(" delByIds(List<" + resultDataType + "> ids){").Append("\r\n");
            sb.Append("\t\t").Append(firstClassName).Append("Dao.delByIds(ids);").Append("\r\n");
            sb.Append("\t").Append("}").Append("\r\n\r\n");
            sb.Append("}");
            CodeGenerationFactory.write(path + "\\" + className + "ServiceImpl.java", path, sb.ToString());
        }



        //internal static void createServiceImpl(string path, string package, string basePackage, string tableName, string comment, string className, DataTable dt)
        //{
        //    string[] packages = basePackage.Split('.');
        //    string packageComBase = "";
        //    for (int i = 0; i < 2; i++)
        //    {
        //        packageComBase += packages[i] + ".";
        //    }
        //    string firstClassName = className.Substring(0, 1).ToLower() + className.Substring(1);
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("package ").Append(package).Append(";").Append("\r\n\r\n");
        //    sb.Append("import ").Append("java.util.List;").Append("\r\n");
        //    sb.Append("import javax.annotation.Resource;").Append("\r\n");
        //    sb.Append("import org.springframework.stereotype.Service;").Append("\r\n"); ;
        //    sb.Append("import org.springframework.transaction.annotation.Transactional;").Append("\r\n\r\n");
        //    sb.Append("import org.apache.ibatis.session.RowBounds;").Append("\r\n");
        //    sb.Append("import ").Append(packageComBase).Append("base.page.PageResult;").Append("\r\n");
        //    sb.Append("import ").Append(basePackage).Append(".service.").Append("I").Append(className).Append("Service;").Append("\r\n");
        //    sb.Append("import ").Append(basePackage).Append(".entity.").Append(className).Append(";").Append("\r\n");
        //    sb.Append("import ").Append(basePackage).Append(".dto.").Append(className).Append("Condition;").Append("\r\n");
        //    sb.Append("import ").Append(basePackage).Append(".dao.").Append("I").Append(className).Append("Dao;").Append("\r\n");
        //    //sb.Append("/**").Append("\r\n");
        //    //sb.Append(" * ").Append(comment).Append("\r\n");
        //    //sb.Append(" * @creator 赵志豪\r\n");
        //    //sb.Append(" * @create-time ").Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")).Append("\r\n");
        //    //sb.Append(" * @email ").Append("490875647@qq.com").Append("\r\n");
        //    //sb.Append(" * @version 1.0").Append("\r\n");
        //    //sb.Append(" */").Append("\r\n");
        //    sb.Append("@Service(\"" + firstClassName + "ServiceImpl\")").Append("\r\n");
        //    sb.Append("@Transactional(value = \"transactionManager\")").Append("\r\n");
        //    sb.Append("public class ").Append(className).Append("ServiceImpl implements I").Append(className).Append("Service{").Append("\r\n\r\n");
        //    sb.Append("\t@Resource(name = \"" + firstClassName + "DaoImpl\")").Append("\r\n");
        //    sb.Append("\tprivate I").Append(className).Append("Dao ").Append(firstClassName).Append("Dao;").Append("\r\n\r\n\r\n\r\n");
        //    //查询所有数据
        //    sb.Append("\t/**").Append("\r\n");
        //    sb.Append("\t * 查询所有").Append(comment).Append("\r\n");
        //    sb.Append("\t */").Append("\r\n");
        //    sb.Append("\t").Append("public List<").Append(className).Append("> list" + className + "All(){").Append("\r\n");
        //    sb.Append("\t\t").Append("return ").Append(firstClassName).Append("Dao.list").Append(className).Append("All();").Append("\r\n");
        //    sb.Append("\t").Append("}").Append("\r\n\r\n");


        //    //查询总数
        //    sb.Append("\t/**").Append("\r\n");
        //    sb.Append("\t * 查询总数").Append("\r\n");
        //    sb.Append("\t *").Append("@param condition 查询条件类").Append("\r\n");
        //    sb.Append("\t *").Append("@return 总条数").Append("\r\n");
        //    sb.Append("\t */").Append("\r\n");
        //    sb.Append("\t").Append("public int get" + className + "ByPageCount").Append("(" + className + "Condition condition){").Append("\r\n");
        //    sb.Append("\t\t").Append("return ").Append(firstClassName).Append("Dao.get").Append(className).Append("ByPageCount(condition);").Append("\r\n");
        //    sb.Append("\t").Append("}").Append("\r\n\r\n");

        //    //分页方法
        //    sb.Append("\t/**").Append("\r\n");
        //    sb.Append("\t * 分页查询").Append("\r\n");
        //    sb.Append("\t *").Append("@param pageResult 分页对象").Append("\r\n");
        //    sb.Append("\t *").Append("@param condition 查询条件类").Append("\r\n");
        //    sb.Append("\t */").Append("\r\n");
        //    sb.Append("\t").Append("public void list").Append(className).Append("ByPage(").Append("PageResult<").Append(className).Append("> pageResult,").Append(className).Append("Condition condition){").Append("\r\n");
        //    sb.Append("\t\t").Append("int rows = ").Append(firstClassName).Append("Dao.get").Append(className).Append("ByPageCount(condition);").Append("\r\n");
        //    sb.Append("\t\t").Append("pageResult.setRows(rows);").Append("\r\n");
        //    sb.Append("\t\t").Append("RowBounds rowBounds = new RowBounds(pageResult.getCurrentPageIndex(),pageResult.getPageSize());").Append("\r\n");
        //    sb.Append("\t\t").Append("List<").Append(className).Append("> list = ").Append(firstClassName).Append("Dao.list").Append(className).Append("ByPage(rowBounds,condition);").Append("\r\n");
        //    sb.Append("\t\t").Append("pageResult.setResult(list);").Append("\r\n");
        //    sb.Append("\t").Append("}").Append("\r\n\r\n");


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
        //    sb.Append("\t").Append("public ").Append(className).Append(" get" + className + "ById").Append("(" + resultDataType + " id){").Append("\r\n");
        //    sb.Append("\t\t").Append("return ").Append(firstClassName).Append("Dao.get").Append(className).Append("ById(id);").Append("\r\n");
        //    sb.Append("\t").Append("}").Append("\r\n\r\n");


        //    //新增
        //    sb.Append("\t/**").Append("\r\n");
        //    sb.Append("\t * 新增").Append("\r\n");
        //    sb.Append("\t *").Append("@param item ").Append(comment).Append("\r\n");
        //    sb.Append("\t */").Append("\r\n");
        //    sb.Append("\t").Append("public ").Append(className).Append(" add(").Append(className).Append(" item){").Append("\r\n");
        //    sb.Append("\t\t").Append(firstClassName).Append("Dao.add(item);").Append("\r\n");
        //    sb.Append("\t\t").Append("return item;").Append("\r\n");
        //    sb.Append("\t").Append("}").Append("\r\n\r\n");


        //    //批量新增
        //    sb.Append("\t/**").Append("\r\n");
        //    sb.Append("\t * 批量新增").Append("\r\n");
        //    sb.Append("\t *").Append("@param List ").Append("\r\n");
        //    sb.Append("\t */").Append("\r\n");
        //    sb.Append("\t").Append("public void").Append(" batchInsert(").Append("List<" + className + "> arrayList){").Append("\r\n\r\n");
        //    sb.Append("\t\t").Append(firstClassName).Append("Dao.batchInsert(arrayList);").Append("\r\n");
        //    sb.Append("\t").Append("}").Append("\r\n\r\n");

        //    //修改
        //    sb.Append("\t/**").Append("\r\n");
        //    sb.Append("\t * 修改").Append("\r\n");
        //    sb.Append("\t *").Append("@param item ").Append(comment).Append("\r\n");
        //    sb.Append("\t */").Append("\r\n");
        //    sb.Append("\t").Append("public ").Append(className).Append(" update(").Append(className).Append(" item){").Append("\r\n");
        //    sb.Append("\t\t").Append(firstClassName).Append("Dao.update(item);").Append("\r\n");
        //    sb.Append("\t\t").Append("return item;").Append("\r\n");
        //    sb.Append("\t").Append("}").Append("\r\n\r\n");


        //    //删除
        //    sb.Append("\t/**").Append("\r\n");
        //    sb.Append("\t * 删除").Append("\r\n");
        //    sb.Append("\t *").Append("@param item ").Append(comment).Append("\r\n");
        //    sb.Append("\t */").Append("\r\n");
        //    sb.Append("\t").Append("public void").Append(" delByIds(String[] ids){").Append("\r\n");
        //    sb.Append("\t\t").Append(firstClassName).Append("Dao.delByIds(ids);").Append("\r\n");
        //    sb.Append("\t").Append("}").Append("\r\n\r\n");
        //    sb.Append("}");
        //    CodeGenerationFactory.write(path + "\\" + className + "ServiceImpl.java", path, sb.ToString());
        //}
    }
}
