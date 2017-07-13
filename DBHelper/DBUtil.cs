using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DBHelper
{
    public class DBUtil
    {
        //private static string connStr = System.Configuration.ConfigurationManager.AppSettings["connectStr"];
        private static string connStr = "Initial Catalog=stuManage; Integrated Security=SSPI";
        //string connSQL = "Initial Catalog=StuManage; Integrated Security=SSPI";//构造连接字符串

        //DbUtil是干啥的？
        public void DbUtil()
        {

        }


        //测试数据库连接
        public bool connectTestW()
        {
            bool result = false;
            //获取数据库连接字符串
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connStr;
            //创建连接对象          
            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    Console.WriteLine("连接成功！");
                    result = true;
                }
                else
                {
                    Console.WriteLine("连接失败！");
                }
            }
            catch
            {
                Console.WriteLine("连接失败！");
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
     

        //第一个是ExecuteNonQuery()方法，主要用来提交无查询结果的SQL语句，如UPDATE，INSERT，DELETE等语句，其返回值为数据库中被SQL语句影响的行数，
        //第二个是ExecuteReader()方法，主要用来提交SELECT语句，返回值是一个数据流，里面是SELECT语句的查询结果，可以用SqlDataReader对象来接收，然后调用其Read()方法来逐行读出查询结果
        //第三个是ExexuteScalar()方法，主要也是用来提交SELECT语句，但是其返回值是查询结果的第一行第一列，所以适用于例如COUNT等聚合查询。
        public static DataTable GetDataTable(string sqlStr)
        {                    
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connStr;
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand mycmd = new SqlCommand(sqlStr, conn);
                SqlDataAdapter ad = new SqlDataAdapter(mycmd);
                ad.Fill(dt);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        public static string GetString(string sqlStr)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connStr;
            string s = null;
            try
            {
                conn.Open();
                SqlCommand mycmd = new SqlCommand(sqlStr, conn);
                //mycmd.EndExecuteNonQuery();//delete和update
                s = mycmd.ExecuteScalar().ToString(); //select id from student
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return s;       
        }

        public static void GetNull(string sqlStr)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connStr;
            //string s = null;
            try
            {
                conn.Open();
                SqlCommand mycmd = new SqlCommand(sqlStr, conn);
                mycmd.ExecuteNonQuery();//delete和update返回受影响的行数    返回操作所影响的记录条数         
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            
        }




    }
}
