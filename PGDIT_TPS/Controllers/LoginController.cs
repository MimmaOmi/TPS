using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PGDIT_TPS.Models.Account;
using Oracle.ManagedDataAccess.Client; // Oracle Client Library
using System.Configuration;// To Access App Config Attributes
using Oracle.ManagedDataAccess.Types;
using System.Data;

namespace PGDIT_TPS.Controllers
{
    public class LoginController : Controller
    {
        //OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["Entities"].ConnectionString);
        //OracleCommand cmd = new OracleCommand();
        //OracleDataReader dr;
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
  //      void conStr()
  //      {
  //          con.ConnectionString = "DATA SOURCE = (DESCRIPTION ="+
  //  "(ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))"+
  //  "(CONNECT_DATA ="+
  //  "(SERVER = DEDICATED)"+
  //    "(SERVICE_NAME = Textile)"+
  //  ")"+
  //"); User Id=c##PgditTPS20; password=Tps;";


  //      }
        [HttpPost]
        public ActionResult Verify(Account acc)
        {
            string con1 = ConfigurationManager.ConnectionStrings["Entities"].ConnectionString;
            OracleConnection con = new OracleConnection(con1);
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "select * from T_Student where studentid='" + acc.Studentid + "' and password='" + acc.Password + "'";
            cmd.Connection = con;           
            con.Open();
            OracleDataReader dr = cmd.ExecuteReader();
            string stuid = null;
            string stupass = null;
            //string error = null;
            string stuname = null;           
            while (dr.Read())
            {
                 stuid = dr["studentid"].ToString();
                 stupass = dr["password"].ToString();
                 stuname = dr["Studentname"].ToString();
            }
            if (stuid ==null && stupass==null)
            {
                //error = "Wrong Student ID or Password.";
                //acc.LoginErrorMessage = error;
                return RedirectToAction("Login", "Login");
            }
            else
            {
                Session["USERID"] = acc.Studentid;           
                Session["Studentname"] = stuname;
                con.Close();
                return RedirectToAction("Index", "Home");              
            }            
           
        }
        public ActionResult Logout()
        {
            string stuid = (string)Session["USERID"];
            Session.Abandon();
            return RedirectToAction("Login", "Login");
        }
    }
}