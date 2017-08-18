using System.Web.Mvc;
using System.Data;
using Newtonsoft.Json;
using StudentMDataAccess;

namespace studentManagement1._0.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult ShowCourseInfo()
        {
            ViewBag.Message = "Your contact page.";
            return View("ShowCourseInfo");
        }

        public ActionResult AddCourseInfo()
        {
            string id = System.Web.HttpContext.Current.Request.Params["id"];
            string type = System.Web.HttpContext.Current.Request.Params["type"];
            ViewBag.ID = id;
            ViewBag.type = type;
            ViewBag.Message = "Your contact page.";
            return View("AddCourseInfo");
        }

        public string GetListAdo()
        {
            string myData = System.Web.HttpContext.Current.Request.Params["jsonFilter"];
            CourseDataAccess dac = new CourseDataAccess();
            DataTable dt;
            if (myData != null)
            {
                Cou cou = Newtonsoft.Json.JsonConvert.DeserializeObject<Cou>(myData);
                dt = dac.SelectData(cou);
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
            Cou cou = Newtonsoft.Json.JsonConvert.DeserializeObject<Cou>(myData);
            CourseDataAccess dac = new CourseDataAccess();
            dac.PostData(cou);
        }
        public void AlterData()
        {
            string myData = System.Web.HttpContext.Current.Request.Params["data"];
            string id = System.Web.HttpContext.Current.Request.Params["id"];
            Cou cou = Newtonsoft.Json.JsonConvert.DeserializeObject<Cou>(myData);
            CourseDataAccess dac = new CourseDataAccess();
            dac.AlterData(cou, id);
        }
        public void PostDataDel()
        {
            string kch = System.Web.HttpContext.Current.Request.Params["kch"];
            CourseDataAccess dac = new CourseDataAccess();
            dac.PostDataDel(kch);
        }
        public string PostDataGet()
        {
            string id = System.Web.HttpContext.Current.Request.Params["id"];
            CourseDataAccess dac = new CourseDataAccess();
            DataTable dt = dac.PostDataGet(id);
            string str = JsonConvert.SerializeObject(dt);
            return str;
        }

    }
}