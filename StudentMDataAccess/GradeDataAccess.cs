using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DBHelper;

namespace StudentMDataAccess
{
    public class GradeDataAccess
    {
        public DataTable GetListAdo()
        {
            //string sql = "select stuInfo.id as 'id',stuInfo.name as 'name',sum(case courseInfo.kch when '1' then gradeInfo.ach else 0 end) as 'ach1',sum(case courseInfo.kch when '2' then gradeInfo.ach else 0 end) as 'ach2',sum(case courseInfo.kch when '3' then gradeInfo.ach else 0 end) as 'ach3',sum(case courseInfo.kch when '4' then gradeInfo.ach else 0 end) as 'ach4',sum(case courseInfo.kch when '5' then gradeInfo.ach else 0 end) as 'ach5' from gradeInfo,studentInfo,courseInfo where (gradeInfo.id = studentInfo.id) and (gradeInfo.kch = courseInfo.kch) group by stuInfo.id,stuInfo.name";
            string sql = "select stuInfo.id as 'id',stuInfo.name as 'name',sum(case courseInfo.kch when '1' then gradeInfo.ach else 0 end) as 'ach1',sum(case courseInfo.kch when '2' then gradeInfo.ach else 0 end) as 'ach2', sum(case courseInfo.kch when '3' then gradeInfo.ach else 0 end) as 'ach3', sum(case courseInfo.kch when '4' then gradeInfo.ach else 0 end) as 'ach4',sum(gradeInfo.ach) as 'ach5' from gradeInfo, stuInfo, courseInfo  where(gradeInfo.id = stuInfo.id) and(gradeInfo.kch = courseInfo.kch)  group by stuInfo.id,stuInfo.name";
            DataTable dt = DBUtil.GetDataTable(sql);
            return dt;
        }

        public void PostData(Grade grade)
        {
            string sql = "insert into gradeInfo values('" + grade.id + "','" + grade.kch + "','" + grade.ach + "','" + grade.remarks + "')";
            DBUtil.GetNull(sql);
        }

        public DataTable GetStuId()
        {
            string sql = "select id from stuInfo";
            return DBUtil.GetDataTable(sql);
        }

        public DataTable GetCouKch()
        {
            string sql = "select kch from courseInfo";
            return DBUtil.GetDataTable(sql);
        }
        public DataTable PostDataGet(string id)
        {
            string sql = "select * from gradeInfo where id = '" + id + "'";
            DataTable dt = DBUtil.GetDataTable(sql);
            return dt;
        }

        //修改更新
        public void AlterData(Grade grade, string id)
        {
            string sql = "update gradeInfo set ach=" + grade.ach + ",remarks='" + grade.remarks + "'where (id = '" + id + "' and kch = '" + grade.kch + "')";
            DBUtil.GetNull(sql);
        }
        //删除
        public void PostDataDel(string id)
        {
            string sql = "delete from gradeInfo where id = '" + id + "'";
            DBUtil.GetNull(sql);
        }


        public DataTable SelectData(Grade grade)
        {
            string sql;
            if (grade.kch == null)
            {
                sql = "select stuInfo.id as 'id',stuInfo.name as 'name'," +
                    "sum(case course.kch when '1' then grade.ach else 0 end) as 'ach1'," +
                    "sum(case course.kch when '2' then grade.ach else 0 end) as 'ach2', " +
                    "sum(case course.kch when '3' then grade.ach else 0 end) as 'ach3', " +
                    "sum(case course.kch when '4' then grade.ach else 0 end) as 'ach4'," +
                    "sum(grade.ach) as 'ach5'" +
                    "from gradeInfo, stuInfo, courseInfo" +
                    "where(grade.id = student.id) and((grade.id = '" + grade.id + "')or('" + grade.id + "' = null)) and(grade.kch = course.kch)and" +
                    "(grade.id in" +
                    "(select id from grade" +
                    "where ((ach >= " + grade.achlow + ")and(ach <= " + grade.achhigh + "))))" +
                    "group by student.id,student.name";
            }
            else
            {
                sql = "select student.id as 'id',student.name as 'name'," +
                    "sum(case course.kch when '1' then grade.ach else 0 end) as 'ach1'," +
                    "sum(case course.kch when '2' then grade.ach else 0 end) as 'ach2', " +
                    "sum(case course.kch when '3' then grade.ach else 0 end) as 'ach3', " +
                    "sum(case course.kch when '4' then grade.ach else 0 end) as 'ach4'," +
                    "sum(grade.ach) as 'ach5'" +
                    "from grade, student, course" +
                    "where(grade.id = student.id) and((grade.id = '" + grade.id + "')or('" + grade.id + "' = null)) and(grade.kch = course.kch)and" +
                    "(grade.id in" +
                    "(select id from grade" +
                    "where ((ach >= " + grade.achlow + ")and(ach <= " + grade.achhigh + ")and (grade.kch = '" + grade.kch + "'))))" +
                    "group by student.id,student.name";
            }
            // string sql = "select * from student where(( id = '" + stu.id + "'or '" + stu.id + "' = '') and (name = '" + stu.name + "'or '" + stu.name + "' = '') and (sex = '" + stu.sex + "'or '" + stu.sex + "' =  0) and (bir = '" + stu.bir + "'or '" + stu.bir + "' = '') and (cla ='" + stu.cla + "'or '" + stu.cla + "' = '') and (adr ='" + stu.adr + "'or '" + stu.adr + "' = ''))";
            DataTable dt = DBUtil.GetDataTable(sql);
            return dt;
        }



    }

    public class Grade
    {
        public string kch { get; set; }
        public string id { get; set; }
        public int ach { get; set; }
        public string remarks { get; set; }

        public int achhigh { get; set; }

        public int achlow { get; set; }
    }
}
