using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace studentManagement1._0.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Mainpage()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult he()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


    }

    //学生信息控制器
    //public class StudentController : Controller {
    //    public ActionResult ShowStudentInfo()
    //    {
    //        ViewBag.Message = "Your contact page.";

    //        return View();
    //    }

    //    public ActionResult AddStudentInfo()
    //    {
    //        ViewBag.Message = "Your contact page.";

    //        return View();
    //    }
    //}

    //课程控制器
    public class CourseController : Controller
    {
        public ActionResult ShowCourseInfo()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ActionResult AddCourseInfo()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }


    //成绩信息控制器
    public class GradeController : Controller
    {
        public ActionResult ShowGradeInfo()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ActionResult AddGradeInfo()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }


}