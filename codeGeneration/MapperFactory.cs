using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace codeGeneration
{
    class MapperFactory
    {
        internal static void createMapper(string path, string package,string basePackage, string tableName, string comment, string className, DataTable dt)
        {
            string firstClassName = className.Substring(0, 1).ToLower() + className.Substring(1);
            string entityPackage = package.Substring(0,package.LastIndexOf(".")) + ".entity.";

            StringBuilder sb = new StringBuilder();
            sb.Append("<?xml version=\"1.0\" encoding=\"UTF-8\" ?>").Append("\r\n");
            sb.Append("<!DOCTYPE mapper PUBLIC \"-//mybatis.org//DTD Mapper 3.0//EN\" ").Append("\"http://mybatis.org/dtd/mybatis-3-mapper.dtd\">").Append("\r\n");
            sb.Append("<mapper namespace=\""+package+".I"+className+"Dao\">").Append("\r\n");
            sb.Append("\t").Append("<resultMap type=\"" + entityPackage + className + "\" id=\"" + firstClassName + "ResultMap\" >").Append("\r\n");
            foreach (DataRow row in dt.Rows) {
                string fieldName = row["fieldName"].ToString();
                string firstFieldName = fieldName.Substring(0, 1).ToLower() + fieldName.Substring(1);
                sb.Append("\t\t").Append("<!-- "+row["comment"]+" -->").Append("\r\n");
                sb.Append("\t\t").Append("<result property=\"" + firstFieldName + "\" column=\"" + row["columnName"].ToString() + "\" />").Append("\r\n");
            }
            sb.Append("\t").Append("</resultMap>").Append("\r\n\r\n\r\n");
            sb.Append("\t").Append("<sql id=\"allColumnSql\">").Append("\r\n");
            for (int i = 0; i < dt.Rows.Count - 1; i ++ )
            {
                sb.Append("\t\t").Append("o." + dt.Rows[i]["columnName"].ToString() + ",").Append("\r\n");
            }
            sb.Append("\t\t").Append("o." + dt.Rows[dt.Rows.Count  - 1]["columnName"].ToString()).Append("\r\n");
            
            sb.Append("\t").Append("</sql>").Append("\r\n\r\n\r\n");

            sb.Append("\t").Append("<sql id=\"searchConditionSql\">").Append("\r\n");
            foreach (DataRow row in dt.Rows)
            {
                string dataTypeResult = DataTypeMapping.getDataType(row["dataType"].ToString());
                if (dataTypeResult == "String")
                {
                    string fieldName = row["fieldName"].ToString();
                    string firstFieldName = fieldName.Substring(0, 1).ToLower() + fieldName.Substring(1);

                    sb.Append("\t\t").Append("<if test=\"condition."+firstFieldName+" != null and condition."+firstFieldName+" != ''\">").Append("\r\n");

                    sb.Append("\t\t\t").Append("AND o.").Append(row["columnName"].ToString()).Append(" like '%${condition.").Append(firstFieldName).Append("}%'").Append("\r\n");
                    sb.Append("\t\t").Append("</if>").Append("\r\n");
                }
            }
            sb.Append("\t").Append("</sql>").Append("\r\n\r\n");
            //查询全部
            sb.Append("\t").Append("<select id=\"list" + className + "All\" resultMap=\"" + firstClassName + "ResultMap\">").Append("\r\n");
            sb.Append("\t\t").Append("SELECT <include refid=\"allColumnSql\"/>").Append("\r\n");
            sb.Append("\t\t").Append("FROM "+tableName+" o").Append("\r\n");
            sb.Append("\t").Append("</select>").Append("\r\n\r\n");

            //查询总数
            sb.Append("\t").Append("<select id=\"get" + className + "ByPageCount\" resultType=\"int\">").Append("\r\n");
            sb.Append("\t\t").Append("SELECT count(1)").Append("\r\n");
            sb.Append("\t\t").Append("FROM " + tableName + " o").Append("\r\n");
            sb.Append("\t\t").Append("WHERE 1=1 <include refid=\"searchConditionSql\"/>").Append("\r\n");
            sb.Append("\t").Append("</select>").Append("\r\n\r\n");

            //查询数据
            sb.Append("\t").Append("<select id=\"list" + className + "ByPage\" resultMap=\"" + firstClassName + "ResultMap\">").Append("\r\n");
            sb.Append("\t\t").Append("SELECT <include refid=\"allColumnSql\"/>").Append("\r\n");
            sb.Append("\t\t").Append("FROM " + tableName + " o").Append("\r\n");
            sb.Append("\t\t").Append("WHERE 1=1 <include refid=\"searchConditionSql\"/>").Append("\r\n");
            sb.Append("\t").Append("</select>").Append("\r\n\r\n");
            

            //根据ID获取数据

            sb.Append("\t").Append("<select id=\"get" + className + "ById\" resultMap=\"" + firstClassName + "ResultMap\">").Append("\r\n");
            sb.Append("\t\t").Append("SELECT <include refid=\"allColumnSql\"/>").Append("\r\n");
            sb.Append("\t\t").Append("FROM " + tableName + " o").Append("\r\n");
            sb.Append("\t\t").Append("WHERE o.ID = #{id}").Append("\r\n");
            sb.Append("\t").Append("</select>").Append("\r\n\r\n");

            //新增

            sb.Append("\t").Append("<insert id=\"add\" parameterType=\"" + entityPackage + className + "\"").Append(" useGeneratedKeys=\"true\" keyProperty=\"id\">").Append("\r\n");
            sb.Append("\t\t").Append("INSERT INTO ").Append(tableName).Append("\r\n");
            sb.Append("\t\t").Append("(").Append("\r\n");
            sb.Append("\t\t").Append("<trim suffixOverrides=\",\"").Append(">").Append("\r\n");
            for (int i = 1; i < dt.Rows.Count ;i++ )
            {
                DataRow row = dt.Rows[i];
                string fielName = row["fieldName"].ToString();
                string firstFielName = fielName.Substring(0, 1).ToLower() + fielName.Substring(1);
                sb.Append("\t\t").Append("<if test=\"" + firstFielName + " != null \">").Append("\r\n");
                sb.Append("\t\t").Append(row["columnName"].ToString()).Append(",").Append("\r\n");
                sb.Append("\t\t").Append("</if>").Append("\r\n");
            }
            sb.Append("\t\t").Append("</trim>").Append("\r\n");
            
            sb.Append("\t\t").Append(")").Append("\r\n");
            sb.Append("\t\t").Append("VALUES").Append("\r\n");
            sb.Append("\t\t").Append("(").Append("\r\n");
            sb.Append("\t\t").Append("<trim suffixOverrides=\",\"").Append(">").Append("\r\n");
            for (int i = 1; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                string fielName = row["fieldName"].ToString();
                string firstFielName = fielName.Substring(0,1).ToLower() + fielName.Substring(1);
                sb.Append("\t\t").Append("<if test=\"" + firstFielName + " != null \">").Append("\r\n");
                sb.Append("\t\t").Append("#{").Append(firstFielName).Append("}").Append(",").Append("\r\n");
                sb.Append("\t\t").Append("</if>").Append("\r\n");
            }
            sb.Append("\t\t").Append("</trim>").Append("\r\n");
            string fielNameLast = dt.Rows[dt.Rows.Count - 1]["fieldName"].ToString();
            string firstFielNameLast = fielNameLast.Substring(0,1).ToLower() + fielNameLast.Substring(1);
            
            sb.Append("\t\t").Append(")").Append("\r\n");
            sb.Append("\t").Append("</insert>").Append("\r\n\r\n");
            //批量新增
            sb.Append("\t").Append("<insert id=\"batchInsert\" >").Append("\r\n");
            sb.Append("\t\t").Append("INSERT INTO ").Append(tableName).Append("\r\n");
            sb.Append("\t\t").Append("(").Append("\r\n");
            for (int i = 1; i < dt.Rows.Count - 1; i++)
            {
                DataRow row = dt.Rows[i];
                sb.Append("\t\t").Append(row["columnName"].ToString()).Append(",").Append("\r\n");
            }
            sb.Append("\t\t").Append(dt.Rows[dt.Rows.Count - 1]["columnName"].ToString()).Append("\r\n");
            sb.Append("\t\t").Append(")").Append("\r\n");
            sb.Append("\t\t").Append("VALUES").Append("\r\n");
            sb.Append("\t\t").Append("<foreach collection=\"list\" index=\"index\" item=\"item\" separator=\",\">").Append("\r\n");
            sb.Append("\t\t").Append("(").Append("\r\n");
            for (int i = 1; i < dt.Rows.Count - 1; i++)
            {
                DataRow row = dt.Rows[i];
                string fielName = row["fieldName"].ToString();
                string firstFielName = fielName.Substring(0,1).ToLower() + fielName.Substring(1);
                sb.Append("\t\t").Append("#{item.").Append(firstFielName).Append("}").Append(",").Append("\r\n");
            }
            fielNameLast = dt.Rows[dt.Rows.Count - 1]["fieldName"].ToString();
            firstFielNameLast = fielNameLast.Substring(0,1).ToLower() + fielNameLast.Substring(1);
            sb.Append("\t\t").Append("#{item.").Append(firstFielNameLast).Append("}").Append("\r\n");
            sb.Append("\t\t").Append(")").Append("\r\n");
            sb.Append("\t\t").Append("</foreach>").Append("\r\n"); ;
            sb.Append("\t").Append("</insert>").Append("\r\n\r\n");

            //修改
            sb.Append("\t").Append("<update id=\"update\" parameterType=\"" + entityPackage + className + "\">").Append("\r\n");
            sb.Append("\t\t").Append("UPDATE ").Append(tableName).Append("\r\n");
            sb.Append("\t\t").Append("<trim prefix=\"set\" suffixOverrides=\",\">").Append("\r\n");
            for (int i = 1; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                string fielName = row["fieldName"].ToString();
                string firstFielName = fielName.Substring(0, 1).ToLower() + fielName.Substring(1);
                sb.Append("\t\t").Append("<if test=\""+firstFielName+" != null \">").Append("\r\n");
                sb.Append("\t\t").Append(row["columnName"].ToString()).Append(" = ").Append("#{" + firstFielName + "}").Append(",").Append("\r\n");
                sb.Append("\t\t").Append("</if>").Append("\r\n");
            }
            sb.Append("\t\t").Append("</trim>").Append("\r\n");
            sb.Append("\t\t").Append("WHERE ID = #{id}").Append("\r\n");
            sb.Append("\t").Append("</update>").Append("\r\n\r\n");

            //删除
            sb.Append("\t").Append("<delete id=\"delByIds\">").Append("\r\n");
            sb.Append("\t\t").Append("DELETE FROM ").Append(tableName).Append("\r\n");
            
            sb.Append("\t\t").Append("WHERE ID IN").Append("\r\n");
            sb.Append("\t\t").Append("<foreach collection=\"list\" index=\"index\" item=\"item\" open=\"(\" separator=\",\" close=\")\">").Append("\r\n");
            sb.Append("\t\t\t").Append("#{item}").Append("\r\n"); ;
            sb.Append("\t\t").Append("</foreach>").Append("\r\n"); ;
            sb.Append("\t").Append("</delete>").Append("\r\n\r\n");
            sb.Append("</mapper>");

            CodeGenerationFactory.write(path + "\\I" + className + "Mapper.xml",path,sb.ToString());

        }
    }
}
