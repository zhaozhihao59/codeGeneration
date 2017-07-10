using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace codeGeneration
{
    class ControllerFactory
    {
        
       

        public static void createController(string path, string package,string basePackage,string tableName, string comment, string className, DataTable dt)
        {
            string mapping = "";
            string[] packages = basePackage.Split('.');
            string packageComBase = "";
            for (int i = 0; i < 2; i++)
            {
                packageComBase +=  packages[i] + ".";
            }
            if(packages.Length > 2){
                for (int i = 2; i < packages.Length; i ++ )
                {
                    mapping += "/" + packages[i];
                }
            }
            char[] tableChar = tableName.ToCharArray();
            if (tableChar[1] == '_')
            {   
                tableName = tableName.ToLower().Substring(2);
                string[] names = tableName.Split('_');
                foreach(string item in names){
                    mapping += "/" + item;
                }
            }
            else 
            {
                tableName = tableName.ToLower();
                string[] names = tableName.Split('_');
                foreach (string item in names)
                {
                    mapping += "/" + item;
                }
            }
            string firstClassName = className.Substring(0, 1).ToLower() + className.Substring(1);
            StringBuilder sb = new StringBuilder();
            sb.Append("package ").Append(package).Append(";").Append("\r\n\r\n");
            sb.Append("import ").Append("java.util.Map;").Append("\r\n");
            sb.Append("import ").Append("java.util.List;").Append("\r\n");
            sb.Append("import ").Append("javax.annotation.Resource;").Append("\r\n");
            sb.Append("import ").Append("javax.servlet.http.HttpServletRequest;").Append("\r\n");
            sb.Append("import ").Append("javax.servlet.http.HttpServletResponse;").Append("\r\n");
            sb.Append("import ").Append("javax.servlet.http.HttpSession;").Append("\r\n");
            sb.Append("import ").Append("org.apache.commons.lang3.StringUtils;").Append("\r\n");
            sb.Append("import ").Append("com.alibaba.fastjson.JSONObject;").Append("\r\n");
            sb.Append("import ").Append("org.springframework.stereotype.Controller;").Append("\r\n");
            sb.Append("import ").Append("org.springframework.validation.BindingResult;").Append("\r\n");
            sb.Append("import ").Append("org.springframework.validation.DataBinder;").Append("\r\n");
            sb.Append("import ").Append("org.springframework.web.bind.annotation.InitBinder;").Append("\r\n");
            sb.Append("import ").Append("org.springframework.web.bind.annotation.ModelAttribute;").Append("\r\n");
            sb.Append("import ").Append("org.springframework.web.bind.annotation.RequestMapping;").Append("\r\n");
            sb.Append("import ").Append("org.springframework.web.bind.annotation.RequestMethod;").Append("\r\n");
            sb.Append("import ").Append("org.springframework.web.servlet.ModelAndView;").Append("\r\n");

            sb.Append("import ").Append(packageComBase).Append("adp.web.framework.controller.BaseController;").Append("\r\n");
            sb.Append("import ").Append(basePackage).Append(".service.").Append("I").Append(className).Append("Service;").Append("\r\n");
            sb.Append("import ").Append(basePackage).Append(".entity.").Append(className).Append(";").Append("\r\n");
            sb.Append("import ").Append(basePackage).Append(".model.").Append(className).Append("Form;").Append("\r\n\r\n");


            //sb.Append("/**").Append("\r\n");
            //sb.Append(" * ").Append(comment).Append("\r\n");
            //sb.Append(" * @creator 赵志豪\r\n");
            //sb.Append(" * @create-time ").Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")).Append("\r\n");
            //sb.Append(" * @email ").Append("490875647@qq.com").Append("\r\n");
            //sb.Append(" * @version 1.0").Append("\r\n");
            //sb.Append(" */").Append("\r\n");
            String lastMappingName =   mapping.Substring(mapping.LastIndexOf("/"));
            sb.Append("@Controller(\"" + firstClassName + "Controller\")").Append("\r\n");
            sb.Append("@Api(value = ").Append("\""+lastMappingName+"\" , description = ").Append("\""+comment+"\")").Append("\r\n");
            sb.Append("@RequestMapping(\""+mapping+"\")").Append("\r\n");
            sb.Append("public class ").Append(className).Append("Controller extends BaseController {").Append("\r\n\r\n");
            sb.Append("\t@Resource(name = \"" + firstClassName + "ServiceImpl\")").Append("\r\n");
            sb.Append("\tprivate I").Append(className).Append("Service ").Append(firstClassName).Append("Service;").Append("\r\n\r\n\r\n\r\n");
           

            //分页查询
            //首页
            sb.Append("\t/**").Append("\r\n");
            sb.Append("\t * 分页查询").Append("\r\n");
            sb.Append("\t * @return ").Append("\r\n");
            sb.Append("\t */").Append("\r\n");
            sb.Append("\t@RequestMapping(value = \"/listDataByPage\", method = RequestMethod.GET)").Append("\r\n");
            sb.Append("\t@ApiOperation(value = ").Append("\"查询" + comment + "\")").Append("\r\n");
            sb.Append("\t").Append("public Response listDataByPage(@ModelAttribute " + className + "Model model){").Append("\r\n");
            
            sb.Append("\t\t").Append(firstClassName).Append("Service.list").Append(className).Append("ByPage(model);").Append("\r\n");
            sb.Append("\t\t").Append("JSONObject root = model.getPageResult().toPageJson();").Append("\r\n");
            sb.Append("\t\t").Append("return Response.SUCCESS(root.toJSONString())").Append("\r\n");
            
            sb.Append("\t").Append("}").Append("\r\n\r\n");

           

            //保存
            sb.Append("\t/**").Append("\r\n");
            sb.Append("\t * 保存").Append(comment).Append("\r\n");
            sb.Append("\t * @return ").Append("\r\n");
            sb.Append("\t */").Append("\r\n");
            sb.Append("\t@ApiOperation(value = ").Append("\"保存" + comment + "\")").Append("\r\n");
            sb.Append("\t@RequestMapping(value = \"/save\", method = RequestMethod.PUT)").Append("\r\n");
            sb.Append("\tpublic Response save(@ModelAttribute " + className + "Entity model){").Append("\r\n");
            sb.Append("\t\t").Append("if(null == model.getId()){").Append("\r\n");
            sb.Append("\t\t\t").Append(firstClassName).Append("Service.add(model);").Append("\r\n");
            sb.Append("\t\t").Append("}else{").Append("\r\n");
            sb.Append("\t\t\t").Append(firstClassName).Append("Service.update(model);").Append("\r\n");
            sb.Append("\t\t").Append("}").Append("\r\n");
            sb.Append("\t\t").Append("return Response.SUCCESS(true);").Append("\r\n");
           
            sb.Append("\t").Append("}").Append("\r\n\r\n");


            //删除
            sb.Append("\t/**").Append("\r\n");
            sb.Append("\t * 删除").Append(comment).Append("\r\n");
            sb.Append("\t * @return ").Append("\r\n");
            sb.Append("\t */").Append("\r\n");
            sb.Append("\t@ApiOperation(value = ").Append("\"删除" + comment + "\")").Append("\r\n");
            sb.Append("\t@RequestMapping(value = \"/del\", method = RequestMethod.DELETE)").Append("\r\n");
            sb.Append("\tpublic Response del(@ModelAttribute " + className + "Model model){").Append("\r\n");
            sb.Append("\t\t").Append("if(model.getSelIds() == null || model.getSelIds().size() == 0)").Append("\r\n");
            sb.Append("\t\t\t").Append("throw new ServiceException(UpCoopExceptionCode.SYSTEM_ERROR)").Append("\r\n");
            sb.Append("\t\t").Append(firstClassName).Append("Service.delByIds(model.getSelIds());").Append("\r\n");
            sb.Append("\t\t").Append("return Response.SUCCESS(true);").Append("\r\n");
            sb.Append("\t").Append("}").Append("\r\n");
            sb.Append("}").Append("\r\n");

            CodeGenerationFactory.write(path + "\\" + className + "Controller.java",path,sb.ToString());
        }



        //public static void createController(string path, string package, string basePackage, string tableName, string comment, string className, DataTable dt)
        //{
        //    string mapping = "";
        //    string[] packages = basePackage.Split('.');
        //    string packageComBase = "";
        //    for (int i = 0; i < 2; i++)
        //    {
        //        packageComBase += packages[i] + ".";
        //    }
        //    if (packages.Length > 2)
        //    {
        //        for (int i = 2; i < packages.Length; i++)
        //        {
        //            mapping += "/" + packages[i];
        //        }
        //    }
        //    char[] tableChar = tableName.ToCharArray();
        //    if (tableChar[1] == '_')
        //    {
        //        tableName = tableName.ToLower().Substring(2);
        //        string[] names = tableName.Split('_');
        //        foreach (string item in names)
        //        {
        //            mapping += "/" + item;
        //        }
        //    }
        //    else
        //    {
        //        tableName = tableName.ToLower();
        //        string[] names = tableName.Split('_');
        //        foreach (string item in names)
        //        {
        //            mapping += "/" + item;
        //        }
        //    }
        //    string firstClassName = className.Substring(0, 1).ToLower() + className.Substring(1);
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("package ").Append(package).Append(";").Append("\r\n\r\n");
        //    sb.Append("import ").Append("java.util.Map;").Append("\r\n");
        //    sb.Append("import ").Append("java.util.List;").Append("\r\n");
        //    sb.Append("import ").Append("javax.annotation.Resource;").Append("\r\n");
        //    sb.Append("import ").Append("javax.servlet.http.HttpServletRequest;").Append("\r\n");
        //    sb.Append("import ").Append("javax.servlet.http.HttpServletResponse;").Append("\r\n");
        //    sb.Append("import ").Append("javax.servlet.http.HttpSession;").Append("\r\n");
        //    sb.Append("import ").Append("org.apache.commons.lang3.StringUtils;").Append("\r\n");
        //    sb.Append("import ").Append("org.springframework.context.annotation.Scope;").Append("\r\n");
        //    sb.Append("import ").Append("com.alibaba.fastjson.JSONObject;").Append("\r\n");
        //    sb.Append("import ").Append("org.springframework.stereotype.Controller;").Append("\r\n");
        //    sb.Append("import ").Append("org.springframework.validation.BindingResult;").Append("\r\n");
        //    sb.Append("import ").Append("org.springframework.validation.DataBinder;").Append("\r\n");
        //    sb.Append("import ").Append("org.springframework.web.bind.annotation.InitBinder;").Append("\r\n");
        //    sb.Append("import ").Append("org.springframework.web.bind.annotation.ModelAttribute;").Append("\r\n");
        //    sb.Append("import ").Append("org.springframework.web.bind.annotation.RequestMapping;").Append("\r\n");
        //    sb.Append("import ").Append("org.springframework.web.bind.annotation.RequestMethod;").Append("\r\n");
        //    sb.Append("import ").Append("org.springframework.web.servlet.ModelAndView;").Append("\r\n");

        //    sb.Append("import ").Append(packageComBase).Append("base.controller.BaseController;").Append("\r\n");
        //    sb.Append("import ").Append(basePackage).Append(".service.").Append("I").Append(className).Append("Service;").Append("\r\n");
        //    sb.Append("import ").Append(basePackage).Append(".entity.").Append(className).Append(";").Append("\r\n");
        //    sb.Append("import ").Append(basePackage).Append(".form.").Append(className).Append("Form;").Append("\r\n");
        //    sb.Append("import ").Append(basePackage).Append(".dto.").Append(className).Append("Condition;").Append("\r\n");
        //    sb.Append("import ").Append("org.springframework.web.servlet.ModelAndView;").Append("\r\n\r\n\r\n\r\n");


        //    //sb.Append("/**").Append("\r\n");
        //    //sb.Append(" * ").Append(comment).Append("\r\n");
        //    //sb.Append(" * @creator 赵志豪\r\n");
        //    //sb.Append(" * @create-time ").Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")).Append("\r\n");
        //    //sb.Append(" * @email ").Append("490875647@qq.com").Append("\r\n");
        //    //sb.Append(" * @version 1.0").Append("\r\n");
        //    //sb.Append(" */").Append("\r\n");
        //    sb.Append("@Controller(\"" + firstClassName + "Controller\")").Append("\r\n");
        //    sb.Append("@Scope(\"prototype\")").Append("\r\n");
        //    sb.Append("@RequestMapping(\"" + mapping + "\")").Append("\r\n");
        //    sb.Append("public class ").Append(className).Append("Controller extends BaseController {").Append("\r\n\r\n");
        //    sb.Append("\t@Resource(name = \"" + firstClassName + "ServiceImpl\")").Append("\r\n");
        //    sb.Append("\tprivate I").Append(className).Append("Service ").Append(firstClassName).Append("Service;").Append("\r\n\r\n\r\n\r\n");
        //    //首页
        //    sb.Append("\t/**").Append("\r\n");
        //    sb.Append("\t * 首页").Append("\r\n");
        //    sb.Append("\t * @return ").Append("\r\n");
        //    sb.Append("\t */").Append("\r\n");
        //    sb.Append("\t@RequestMapping(value = \"/index.htm\", method = RequestMethod.GET)").Append("\r\n");
        //    sb.Append("\tpublic ModelAndView index(@ModelAttribute " + className + "Form model,HttpServletRequest request,HttpServletResponse response,HttpSession session){").Append("\r\n");
        //    sb.Append("\t\tModelAndView view = new ModelAndView();").Append("\r\n");
        //    sb.Append("\t\tview.setViewName(\"/" + tableName + "_index\");").Append("\r\n");
        //    sb.Append("\t\treturn view;").Append("\r\n");
        //    sb.Append("\t}\r\n\r\n");

        //    //分页查询
        //    //首页
        //    sb.Append("\t/**").Append("\r\n");
        //    sb.Append("\t * 分页查询").Append("\r\n");
        //    sb.Append("\t * @return ").Append("\r\n");
        //    sb.Append("\t */").Append("\r\n");
        //    sb.Append("\t@RequestMapping(value = \"/listDataByPage.htm\", method = RequestMethod.POST)").Append("\r\n");
        //    sb.Append("\t").Append("public void listDataByPage(@ModelAttribute " + className + "Form model,HttpServletRequest request,HttpServletResponse response,HttpSession session){").Append("\r\n");
        //    sb.Append("\t\t").Append("try{").Append("\r\n");
        //    sb.Append("\t\t\t").Append(firstClassName).Append("Service.list").Append(className).Append("ByPage(model.getPageResult(),model.getCondition());").Append("\r\n");
        //    sb.Append("\t\t\t").Append("JSONObject root = toPageJson(model.getPageResult());").Append("\r\n");
        //    sb.Append("\t\t\t").Append("ajaxPageResult(root,response);").Append("\r\n");
        //    sb.Append("\t\t").Append("} catch (Exception e) {").Append("\r\n");
        //    sb.Append("\t\t\t").Append("String msg = \"查询" + comment + "分也时发生异常：\" + e.getMessage();").Append("\r\n");
        //    sb.Append("\t\t\t").Append("logger.error(msg, e);").Append("\r\n");
        //    sb.Append("\t\t").Append("}").Append("\r\n");
        //    sb.Append("\t").Append("}").Append("\r\n\r\n");

        //    //保存
        //    sb.Append("\t/**").Append("\r\n");
        //    sb.Append("\t * 保存").Append(comment).Append("\r\n");
        //    sb.Append("\t * @return ").Append("\r\n");
        //    sb.Append("\t */").Append("\r\n");
        //    sb.Append("\t@RequestMapping(value = \"/edit.htm\", method = RequestMethod.POST)").Append("\r\n");
        //    sb.Append("\tpublic ModelAndView edit(@ModelAttribute " + className + "Form model,HttpServletRequest request,HttpServletResponse response,HttpSession session){").Append("\r\n");

        //    sb.Append("\t\tModelAndView view = new ModelAndView();").Append("\r\n");
        //    sb.Append("\t\tview.setViewName(\"/" + tableName + "_add\");").Append("\r\n");
        //    sb.Append("\t\tMap<String,Object> data = view.getModel();").Append("\r\n");
        //    sb.Append("\t\tif(null != model.getItem().getId()){").Append("\r\n");
        //    sb.Append("\t\t\t").Append(className).Append(" item = ").Append(firstClassName).Append("Service.get").Append(className).Append("ById(model.getItem().getId());").Append("\r\n");
        //    sb.Append("\t\t\t").Append("data.put(\"item\", item);").Append("\r\n");
        //    sb.Append("\t\t").Append("}").Append("\r\n");
        //    sb.Append("\t\t").Append("return view;").Append("\r\n");
        //    sb.Append("\t}\r\n\r\n");

        //    //保存
        //    sb.Append("\t/**").Append("\r\n");
        //    sb.Append("\t * 保存").Append(comment).Append("\r\n");
        //    sb.Append("\t * @return ").Append("\r\n");
        //    sb.Append("\t */").Append("\r\n");
        //    sb.Append("\t@RequestMapping(value = \"/save.htm\", method = RequestMethod.POST)").Append("\r\n");
        //    sb.Append("\tpublic ModelAndView save(@ModelAttribute " + className + "Form model,HttpServletRequest request,HttpServletResponse response,HttpSession session){").Append("\r\n");
        //    sb.Append("\t\t").Append("try{").Append("\r\n");
        //    sb.Append("\t\t\t").Append("if(null != model.getItem().getId()){").Append("\r\n");
        //    sb.Append("\t\t\t\t").Append(firstClassName).Append("Service.add(model.getItem());").Append("\r\n");
        //    sb.Append("\t\t\t").Append("}else{").Append("\r\n");
        //    sb.Append("\t\t\t\t").Append(firstClassName).Append("Service.update(model.getItem());").Append("\r\n");
        //    sb.Append("\t\t\t").Append("}").Append("\r\n");
        //    sb.Append("\t\t\t").Append("return ajaxJSON(Status.success,\"保存成功\");").Append("\r\n");
        //    sb.Append("\t\t").Append("} catch (Exception e) {").Append("\r\n");
        //    sb.Append("\t\t\t").Append("String msg = \"保存" + comment + "时发生异常：\" + e.getMessage();").Append("\r\n");
        //    sb.Append("\t\t\t").Append("logger.error(msg, e);").Append("\r\n");
        //    sb.Append("\t\t\t").Append("return ajaxJSON(Status.error,\"保存失败，请稍后重试\");").Append("\r\n");
        //    sb.Append("\t\t").Append("}").Append("\r\n");
        //    sb.Append("\t").Append("}").Append("\r\n\r\n");


        //    //删除
        //    sb.Append("\t/**").Append("\r\n");
        //    sb.Append("\t * 删除").Append(comment).Append("\r\n");
        //    sb.Append("\t * @return ").Append("\r\n");
        //    sb.Append("\t */").Append("\r\n");
        //    sb.Append("\t@RequestMapping(value = \"/del.htm\", method = RequestMethod.POST)").Append("\r\n");
        //    sb.Append("\tpublic ModelAndView del(@ModelAttribute " + className + "Form model,HttpServletRequest request,HttpServletResponse response,HttpSession session){").Append("\r\n");
        //    sb.Append("\t\t").Append("try{").Append("\r\n");

        //    sb.Append("\t\t\t").Append(firstClassName).Append("Service.delByIds(model.getSelIds().split(\",\"));").Append("\r\n");
        //    sb.Append("\t\t\t").Append("return ajaxJSON(Status.success,\"删除成功\");").Append("\r\n");
        //    sb.Append("\t\t").Append("} catch (Exception e) {").Append("\r\n");
        //    sb.Append("\t\t\t").Append("String msg = \"保存" + comment + "时发生异常：\" + e.getMessage();").Append("\r\n");
        //    sb.Append("\t\t\t").Append("logger.error(msg, e);").Append("\r\n");
        //    sb.Append("\t\t\t").Append("return ajaxJSON(Status.error,\"删除失败，请稍后重试\");").Append("\r\n");
        //    sb.Append("\t\t").Append("}").Append("\r\n");
        //    sb.Append("\t").Append("}").Append("\r\n");
        //    sb.Append("}").Append("\r\n");

        //    CodeGenerationFactory.write(path + "\\" + className + "Controller.java", path, sb.ToString());
        //}
    }
}
