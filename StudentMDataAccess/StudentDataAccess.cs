using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DBHelper;

namespace StudentMDataAccess
{
    public class StudentDataAccess
    {
        public DataTable GetListAdo()
        {
            string sql = "select * from stuInfo";
            DataTable dt = DBUtil.GetDataTable(sql);
            return dt;
        }

        public void PostData(Stu stu)
        {
            string sql = "insert into stuInfo values('" + stu.id + "','" + stu.name + "','" + stu.sex + "','" + stu.bir + "','" + stu.cls + "','" + stu.adr + "','" + stu.note + "')";
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
            string sql = "select * from stuInfo where((id = '"+stu.id+"' or '"+stu.id+ "'='') and (name = '" + stu.name + "' or '" + stu.name + "'='') and (sex = '" + stu.sex + "' or '" + stu.sex + "'='') and (bir = '" + stu.bir + "' or '" + stu.bir + "'='') and (cls = '" + stu.cls + "' or '" + stu.cls + "'='') and (adr = '" + stu.adr + "' or '" + stu.adr + "'='') and (note = '" + stu.note + "' or '" + stu.note + "'='') )";
            DataTable dt = DBUtil.GetDataTable(sql);
            return dt;
        }        

    }

    public class Stu
    {
        public string id { get; set; }
        public string name { get; set; }
        public string sex { get; set; }
        public string bir { get; set; }
        public string cls { get; set; }
        public string adr { get; set; }
        public string note { get; set; }
        
    }
}
