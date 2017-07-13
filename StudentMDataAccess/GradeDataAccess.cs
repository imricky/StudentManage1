using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DBHelper;

namespace StudentMDataAccess
{
    public class GradetDataAccess
    {
        public DataTable GetListAdo()
        {
            string sql = "select stuInfo.id as 'id',stuInfo.name as 'name',sum(case courseInfo.kch when '1' then gradeInfo.ach else 0 end) as 'ach1',sum(case courseInfo.kch when '2' then gradeInfo.ach else 0 end) as 'ach2',sum(case courseInfo.kch when '3' then gradeInfo.ach else 0 end) as 'ach3',sum(case courseInfo.kch when '4' then gradeInfo.ach else 0 end) as 'ach4',sum(case courseInfo.kch when '5' then gradeInfo.ach else 0 end) as 'ach5' from gradeInfo,studentInfo,courseInfo where (gradeInfo.id = studentInfo.id) and (gradeInfo.kch = courseInfo.kch) group by studentInfo.id,studentInfo.name";
            DataTable dt = DBUtil.GetDataTable(sql);
            return dt;
        }

        public void PostData(Grade grade)
        {
            string sql = "insert into gradeInfo values('" + grade.id + "','" + grade.kch + "','" + grade.ach + "','" + grade.remarks + "')";
            DBUtil.GetNull(sql);
        }

        public void AlertData(Stu stu, string id)
        {
            string sql = "update stuInfo set id ='" + stu.id + "',name='" + stu.name + "',sex='" + stu.sex + "',bir='" + stu.bir + "',cls='" + stu.cls + "',adr='" + stu.adr + "',note='" + stu.note + "where id = '" + id + "'";
            DBUtil.GetNull(sql);
        }
        //public void PostDataDel(string id)
        //{
        //    //string sql = "update stuInfo set id ='" + stu.id + "',name='" + stu.name + "',sex='" + stu.sex + "',bir='" + stu.bir + "',cls='" + stu.cls + "',adr='" + stu.adr + "',note='" + stu.note + "where id = '" + id + "'";
        //    string sql = "delete from stuInfo where id = '" + id + "'";
        //    DBUtil.GetNull(sql);
        //}
        public void PostDataDel(string id)
        {
            //string sql = "update stuInfo set id ='" + stu.id + "',name='" + stu.name + "',sex='" + stu.sex + "',bir='" + stu.bir + "',cls='" + stu.cls + "',adr='" + stu.adr + "',note='" + stu.note + "where id = '" + id + "'";
            string sql = "delete from stuInfo where id = '" + id + "'";
            DBUtil.GetNull(sql);

        }


        public DataTable PostDataGet(string id)
        {
            string sql = "select * from stuInfo where id = '" + id + "'";
            DataTable dt = DBUtil.GetDataTable(sql);
            return dt;
        }

        public DataTable SelectData(Stu stu)
        {
            string sql = "select * from stuInfo where((id = '" + stu.id + "' or '" + stu.id + "'='') and (name = '" + stu.name + "' or '" + stu.name + "'='') and (sex = '" + stu.sex + "' or '" + stu.sex + "'='') and (bir = '" + stu.bir + "' or '" + stu.bir + "'='') and (cls = '" + stu.cls + "' or '" + stu.cls + "'='') and (adr = '" + stu.adr + "' or '" + stu.adr + "'='') and (note = '" + stu.note + "' or '" + stu.note + "'='') )";
            DataTable dt = DBUtil.GetDataTable(sql);
            return dt;
        }

    }

    public class Grade
    {
        public string kch { get; set; }
        public string id { get; set; }
        public string ach { get; set; }
        public string remarks { get; set; }
        public string achhigh { get; set; }
        public string achlow { get; set; }
        

    }
}
