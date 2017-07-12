using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Newtonsoft.Json;
using StudentMDataAccess;

namespace studentManagement1._0.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult ShowStudentInfo()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AddStudentInfo()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public string GetListAdo()
        {
            string myData = System.Web.HttpContext.Current.Request.Params["jsonFilter"];
            StudentDataAccess dac = new StudentDataAccess();
            DataTable dt;
            if (myData != null)
            {
                //序列化：把一个对象序列化成json格式的字符串
                Stu stu = Newtonsoft.Json.JsonConvert.DeserializeObject<Stu>(myData);
                dt = dac.SelectData(stu);
            }
            else
            {
                dt = dac.GetListAdo();
            }
            string str = JsonConvert.SerializeObject(dt);
            string data = "{total: " + dt.Rows.Count.ToString() + ",items:" + str + "}";
            return data;

        }

        public void AlterData()
        {
            string myData = System.Web.HttpContext.Current.Request.Params["data"];
            string id = System.Web.HttpContext.Current.Request.Params["id"];
            Stu stu = Newtonsoft.Json.JsonConvert.DeserializeObject<Stu>(myData);
            StudentDataAccess dac = new StudentDataAccess();
            dac.AlertData(stu, id);

        }

        public void PostDataDel()
        {
            string id = System.Web.HttpContext.Current.Request.Params["id"];
            StudentDataAccess dac = new StudentDataAccess();
            dac.PostDataDel(id);
        }

        public string SelectData()
        {
            string myData = System.Web.HttpContext.Current.Request.Params["data"];
            Stu stu = Newtonsoft.Json.JsonConvert.DeserializeObject<Stu>(myData);
            StudentDataAccess dac = new StudentDataAccess();
            DataTable dt = dac.SelectData(stu);
            string str = JsonConvert.SerializeObject(dt);
            string data2 = "{total: " + dt.Rows.Count.ToString() + ",items:" + str + "}";
            return data2;
        }

        public string PostDataGet()
        {
            string id = System.Web.HttpContext.Current.Request.Params["id"];
            StudentDataAccess dac = new StudentDataAccess();
            DataTable dt = dac.PostDataGet(id);
            string str = JsonConvert.SerializeObject(dt);
            return str;
        }



    }
}