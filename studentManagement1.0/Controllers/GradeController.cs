using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Newtonsoft.Json;
using StudentMDataAccess;
using DBHelper;
namespace studentManagement1._0.Controllers
{
    public class GradeController : Controller
    {
        // GET: Grade
        public ActionResult ShowGradeInfo()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ActionResult AddGradeInfo()
        {
            string id = System.Web.HttpContext.Current.Request.Params["id"];
            string type = System.Web.HttpContext.Current.Request.Params["type"];
            ViewBag.ID = id;
            ViewBag.type = type;
            return View("AddGradeInfo");
        }
        public string GetListAdo()
        {
            string myData = System.Web.HttpContext.Current.Request.Params["jsonFilter"];
            GradeDataAccess dac = new GradeDataAccess();
            DataTable dt;
            if (myData != null)
            {
                //Grade grade = Newtonsoft.Json.JsonConvert.DeserializeObject<Grade>(myData);
                Grade grade = Newtonsoft.Json.JsonConvert.DeserializeObject<Grade>(myData);
                
                dt = dac.SelectData(grade);
            }
            else
            {
                dt = dac.GetListAdo();
            }
            string str = JsonConvert.SerializeObject(dt);
            string data = "{total: " + dt.Rows.Count.ToString() + ", items: " + str + "}";
            return data;
        }
        public void PostData()
        {
            string myData = System.Web.HttpContext.Current.Request.Params["data"];
            Grade grade = Newtonsoft.Json.JsonConvert.DeserializeObject<Grade>(myData);
            GradeDataAccess dac = new GradeDataAccess();
            dac.PostData(grade);
        }

        public string GetStuId()
        {
            GradeDataAccess dac = new GradeDataAccess();
            DataTable dt = dac.GetStuId();
            string str = JsonConvert.SerializeObject(dt);
            string data = "{total: " + dt.Rows.Count.ToString() + ", items: " + str + "}";
            return data;
        }
        public string GetCouKch()
        {

            GradeDataAccess dac = new GradeDataAccess();
            DataTable dt = dac.GetCouKch();
            string str = JsonConvert.SerializeObject(dt);
            string data = "{total: " + dt.Rows.Count.ToString() + ", items: " + str + "}";
            return data;
        }

        public ActionResult AddGradeView()
        {
            string id = System.Web.HttpContext.Current.Request.Params["id"];
            string type = System.Web.HttpContext.Current.Request.Params["type"];
            ViewBag.ID = id;
            ViewBag.type = type;
            return View("AddGradeView");
        }
        public string PostDataGet()
        {
            string id = System.Web.HttpContext.Current.Request.Params["id"];
            GradeDataAccess dac = new GradeDataAccess();
            DataTable dt = dac.PostDataGet(id);
            string str = JsonConvert.SerializeObject(dt);
            return str;
        }
        public void AlterData()
        {
            string myData = System.Web.HttpContext.Current.Request.Params["data"];
            string id = System.Web.HttpContext.Current.Request.Params["id"];
            Grade grade = Newtonsoft.Json.JsonConvert.DeserializeObject<Grade>(myData);
            GradeDataAccess dac = new GradeDataAccess();
            dac.AlterData(grade, id);
        }
        public void PostDataDel()
        {
            string id = System.Web.HttpContext.Current.Request.Params["id"];
            GradeDataAccess dac = new GradeDataAccess();
            dac.PostDataDel(id);
        }


    }
}