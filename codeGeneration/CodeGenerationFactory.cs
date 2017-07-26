using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.IO;
namespace codeGeneration
{
    class CodeGenerationFactory
    {
        public static void javaCodeFactory(string path) { 
        
        }

        public static void javaCodeFactory(string path, string package, DataGridViewSelectedRowCollection selectedRows)
        {
            string basePath = path;
            DataSourceDLL dll = new DataSourceDLL();
            path += "\\src";
            foreach (string item in package.Split('.'))
            {
                path += "\\" + item;
            }
            //StringBuilder sb = new StringBuilder();
            foreach (DataGridViewRow row in selectedRows)
            {
                //StringBuilder sbBegin = new StringBuilder();
                //StringBuilder sbEnd = new StringBuilder();
               DataTable dt = dll.getTableFeildInfo(row.Cells["tableName"].Value.ToString(), row.Cells["dbName"].Value.ToString());
               createJavaCode(path,package,row,dt);
               //sbBegin.Append("INSERT INTO ").Append(row.Cells["tableName"].Value.ToString()).Append("(");
               //sbEnd.Append(" SELECT ");
               //foreach(DataRow tempRow in dt.Rows){
               //   string columnName = tempRow["columnName"].ToString();
               //    if(!columnName.ToLower().Equals("id")){
               //        sbBegin.Append(columnName).Append(",");
               //        sbEnd.Append("o.").Append(columnName).Append(",");
               //    }
               //}
               //sbBegin = sbBegin.Remove(sbBegin.Length-1,1);
               //sbBegin.Append(")");
               //sbEnd = sbEnd.Remove(sbEnd.Length - 1, 1);
               //sbEnd.Append(" FROM data_center_origin.").Append(row.Cells["tableName"].Value.ToString()).Append(" o WHERE o.p_client_id NOT IN (SELECT p_client_id FROM data_center_origin.t_error_info)");
               //sb.Append(sbBegin.ToString()).Append(sbEnd.ToString()).Append("\r\n\r\n");
            }
            //write("F:\\test\\newSQL.sql","F:\\test",sb.ToString());
            createSqlmapConfig(basePath, path, package, selectedRows, null);
        }

        private static void createSqlmapConfig(string basePath,string path,string package,DataGridViewSelectedRowCollection selectRows,DataGridViewRow row){

            StringBuilder sb = new StringBuilder();
            sb.Append("<?xml version=\"1.0\" encoding=\"UTF-8\" ?>").Append("\r\n");
            sb.Append("<!DOCTYPE mapper PUBLIC \"-//mybatis.org//DTD Mapper 3.0//EN\"\"http://mybatis.org/dtd/mybatis-3-mapper.dtd\">").Append("\r\n");
            sb.Append("<configuration>").Append("\r\n");
            sb.Append("\t").Append("<properties>").Append("\r\n");
            sb.Append("\t\t").Append("<property name=\"dialect\" value=\"mysql\" />").Append("\r\n");
            sb.Append("\t").Append("</properties>").Append("\r\n");
            sb.Append("\t").Append("<typeAliases>").Append("\r\n");
            if (null == row)
            {
                foreach (DataGridViewRow viewRow in selectRows)
                {
                    string className = viewRow.Cells["className"].Value.ToString();
                    string firstClassName = className.Substring(0, 1).ToLower() + className.Substring(1);
                    sb.Append("\t\t\t").Append("<typeAlias alias=\""+firstClassName+"\" type=\""+ package + ".entity."+className+"\" />").Append("\r\n");
                }


            }
            else 
            {
                string className = row.Cells["className"].Value.ToString();
                string firstClassName = className.Substring(0, 1).ToLower() + className.Substring(1);
                sb.Append("\t\t\t").Append("<typeAlias alias=\"" + firstClassName + "\" type=\"" + package + ".entity." + className + "\" />").Append("\r\n");
                
            }
            sb.Append("\t").Append("</typeAliases>").Append("\r\n");
            write(basePath + "\\sqlmap-config.xml",basePath,sb.ToString());

        }
        private static void createJavaCode(string path, string package, DataGridViewRow row, DataTable dt)
        {
            //生成controller
            ControllerFactory.createController(path + "\\controller", package + ".controller",package,row.Cells["tableName"].Value.ToString(), row.Cells["tableComment"].Value.ToString(), row.Cells["className"].Value.ToString(), dt);
            //生成vo对象
            VoFactory.createVo(path + "\\controller\\vo", package + ".controller.vo", package, row.Cells["tableName"].Value.ToString(), row.Cells["tableComment"].Value.ToString(),row.Cells["className"].Value.ToString(), dt);
            //生成dto
            DtoFactory.createDto(path + "\\dto", package + ".dto",package, row.Cells["tableName"].Value.ToString(), row.Cells["tableComment"].Value.ToString(), row.Cells["className"].Value.ToString(), dt);
            //生成dao
            DaoFactory.createDao(path + "\\dao", package + ".dao",package, row.Cells["tableName"].Value.ToString(), row.Cells["tableComment"].Value.ToString(), row.Cells["className"].Value.ToString(), dt);
            ////生成form
            //FormFactory.createForm(path + "\\form", package + ".form",package, row.Cells["tableName"].Value.ToString(), row.Cells["tableComment"].Value.ToString(), row.Cells["className"].Value.ToString(), dt);
            //生成pojo
            PojoFactory.createPojo(path + "\\entity", package + ".entity",package, row.Cells["tableName"].Value.ToString(), row.Cells["tableComment"].Value.ToString(), row.Cells["className"].Value.ToString(), dt);
            //生成mapper
            MapperFactory.createMapper(path + "\\mapper", package + ".dao",package, row.Cells["tableName"].Value.ToString(), row.Cells["tableComment"].Value.ToString(), row.Cells["className"].Value.ToString(), dt);
            //生成service
            ServiceFactory.createService(path + "\\service", package + ".service",package, row.Cells["tableName"].Value.ToString(), row.Cells["tableComment"].Value.ToString(), row.Cells["className"].Value.ToString(), dt);
            //生成serviceImpl
            ServiceImplFactory.createServiceImpl(path + "\\service\\impl", package + ".service.impl",package, row.Cells["tableName"].Value.ToString(), row.Cells["tableComment"].Value.ToString(), row.Cells["className"].Value.ToString(), dt);
            

        }
        public static void javaCodeFactory(string path, string package, DataGridViewRow dataGridViewRow, DataGridViewRowCollection rows)
        {
            string basePath = path;
            path += "\\src";
            foreach (string item in package.Split('.'))
            {
                path += "\\" + item;
            }
           DataTable dt = new DataTable();
           dt.Columns.Add("columnName");
           dt.Columns.Add("dataType");
           dt.Columns.Add("comment");
           dt.Columns.Add("fieldName");
           foreach (DataGridViewRow viewRow in rows)
           {
               DataRow row = dt.NewRow();
               row["columnName"] = viewRow.Cells["columnName"].Value;
               row["dataType"] = viewRow.Cells["dataType"].Value;
               row["comment"] = viewRow.Cells["comment"].Value;
               row["fieldName"] = viewRow.Cells["fieldName"].Value;
               dt.Rows.Add(row);
            }
            //生成controoler
           createJavaCode(path, package, dataGridViewRow, dt);

           createSqlmapConfig(basePath, path, package, null, dataGridViewRow);
        }

        /** 写入文件 */ 
        public static void write(string fileName,string path, string source)
        {
            if(!Directory.Exists(path)){
                Directory.CreateDirectory(path);
            }
            FileStream fs = new FileStream(fileName, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(source);
            sw.Flush();
            sw.Close();
            fs.Close();
        }
    }
}
