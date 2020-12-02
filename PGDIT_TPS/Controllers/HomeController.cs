using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Oracle.ManagedDataAccess;
using PGDIT_TPS.Models.Account;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;


namespace PGDIT_TPS.Controllers
{
    public class HomeController : Controller
    {
        private OracleConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["Entities"].ToString();
            con = new OracleConnection(constring);
        }
        OracleCommand cmd = new OracleCommand();
        //Account acc = new Account();
        //string stuname = null;
        //string fathername =null;
        //string mothername = null;
        //string address = null;
        //string contactno = null;
        //string stuid = null;
        //string email = null;
        //string nid = null;
        //string dob = null;
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Profile()
        {
            connection();
            cmd.CommandText = "select * from T_Student where studentid='pgdit2005'";
            cmd.Connection = con;
            con.Open();
            OracleDataReader dr = cmd.ExecuteReader();
            dr.Read();            
            string stuname = dr["Studentname"].ToString();
            string fathername = dr["fathername"].ToString();
            string mothername = dr["mothername"].ToString();
            string address = dr["address"].ToString();
            string contactno = dr["contactno"].ToString();
            string stuid = dr["Studentid"].ToString();
            string email = dr["email"].ToString();
            string nid = dr["nid"].ToString();
            string dob = Convert.ToDateTime(dr["dob"]).ToString();
            //DateTime dob = dr.GetDateTime(9);
            Account acc = new Account();
            acc.Studentname = stuname;
            acc.Studentid = stuid;
            acc.fathername = fathername;
            acc.mothername = mothername;
            acc.address = address;
            acc.email = email;
            acc.contactno = contactno;
            acc.nid = nid;
            acc.dob = DateTime.Parse(dob);
            //acc.dob = DateTime.ParseExact("dob", "MM/dd/yyyy",acc.dob); ;
            return View(acc);
        }
        public ActionResult Update()
        {
            string con1 = ConfigurationManager.ConnectionStrings["Entities"].ConnectionString;
            OracleConnection con = new OracleConnection(con1);
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "select * from T_Student where studentid='pgdit2005'";
            cmd.Connection = con;
            con.Open();
            OracleDataReader dr = cmd.ExecuteReader();
            dr.Read();
            string stuname = dr["Studentname"].ToString();
            string fathername = dr["fathername"].ToString();
            string mothername = dr["mothername"].ToString();
            string address = dr["address"].ToString();
            string contactno = dr["contactno"].ToString();
            string stuid = dr["Studentid"].ToString();
            string email = dr["email"].ToString();
            string nid = dr["nid"].ToString();
            string dob = Convert.ToDateTime(dr["dob"]).ToString();
            //DateTime dob = dr.GetDateTime(9);
            Account acc = new Account();
            acc.Studentname = stuname;
            acc.Studentid = stuid;
            acc.fathername = fathername;
            acc.mothername = mothername;
            acc.address = address;
            acc.email = email;
            acc.contactno = contactno;
            acc.nid = nid;
            acc.dob = DateTime.Parse(dob);
            //acc.dob = DateTime.ParseExact("dob", "MM/dd/yyyy",acc.dob); ;
            return View(acc);
            
        }
        [HttpPost]
        public ActionResult UpdateDetails(Account acc)
        {
            connection();
            cmd = new OracleCommand("UpdateStudentDetails", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;            
            cmd.Parameters.Add("pStdname", acc.Studentname);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return View("Update",acc);
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Programs()
        {
            return View();
        }
        public ActionResult Research()
        {
            return View();
        }        
        public ActionResult Register(Account acc)
        {            
            return View();
        }      
        public ActionResult Contact()
        {
            return View();
        }
    }
}