using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DBHelper;

namespace StudentMDataAccess
{
    public class CourseDataAccess
    {
        public DataTable GetListAdo()
        {
            string sql = "select * from courseInfo";
            DataTable dt = DBUtil.GetDataTable(sql);
            return dt;
        }
        public void PostData(Cou cou)
        {
            string sql = "insert into courseInfo values ('" + cou.kch + "','" + cou.kcm + "','" + cou.ach + "','" + cou.remarks + "')";
            DBUtil.GetNull(sql);
        }

        public void AlterData(Cou cou, string kch)
        {
            string sql = "update courseInfo set kch ='" + cou.kch + "',kcm='" + cou.kcm + "',ach='" + cou.ach + "',remarks='" + cou.remarks + "'where kch = '" + kch + "'";
            DBUtil.GetNull(sql);
        }
        public void PostDataDel(string kch)
        {
            string sql = "delete from courseInfo where kch = '" + kch + "'";
            DBUtil.GetNull(sql);
        }
        public DataTable PostDataGet(string kch)
        {
            string sql = "select * from courseInfo where kch = '" + kch + "'";
            DataTable dt = DBUtil.GetDataTable(sql);
            return dt;
        }

        public DataTable SelectData(Cou cou)
        {
            string sql = "select * from courseInfo where(( kch = '" + cou.kch + "'or '" + cou.kch + "' = '') and (kcm = '" + cou.kcm + "'or '" + cou.kcm + "' = '') and (ach = '" + cou.ach + "'or '" + cou.ach + "' =  0))";
            DataTable dt = DBUtil.GetDataTable(sql);
            return dt;
        }
    }

    public class Cou
    {
        public string kch { get; set; }
        public string kcm { get; set; }
        public int ach { get; set; }
        public string remarks { get; set; }
    }
}
