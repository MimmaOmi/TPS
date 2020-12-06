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
using System.IO;
using System.Threading.Tasks;
using System.Data;

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
        Account acc = new Account();
        //string stuname = null;
        //string fathername = null;
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
        public ActionResult Profile(string Studentid)
        {
            connection();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM t_student a,t_gender b,t_religion c,t_provideddocument d,t_program e,t_department f where a.genderid = b.genderid and a.religionid=c.religionid and a.studentid=d.studentid and a.programid=e.programid and f.departmentid=e.departmentid  and a.studentid = '"+ Studentid + "'";
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
            string gender = dr["gender"].ToString();
            string religion = dr["religion"].ToString();
            string bankrecno = dr["BANKRECEIPTNO"].ToString();
            string program = dr["program"].ToString();
            string department = dr["department"].ToString();
            decimal cgpa = decimal.Parse(dr["cgpa"].ToString());
            int batchno = Convert.ToInt16(dr["batchno"]);
            string sessionyear = dr["sessionyear"].ToString();
            int accountno = Convert.ToInt32(dr["accountno"]);
            //DateTime dob = dr.GetDateTime(9);
            //Account acc = new Account();
            acc.Studentname = stuname;
            acc.Studentid = stuid;
            acc.fathername = fathername;
            acc.mothername = mothername;
            acc.address = address;
            acc.email = email;
            acc.contactno = contactno;
            acc.nid = nid;
            acc.dob = DateTime.Parse(dob);
            acc.gender = gender;
            acc.religion = religion;
            acc.program = program;
            acc.department = department;
            acc.cgpa = cgpa;
            acc.batchno = batchno;
            acc.sessionyear = sessionyear;
            acc.bankreceiptno = bankrecno;
            acc.accountno = accountno;
            //acc.dob = DateTime.ParseExact("dob", "MM/dd/yyyy",acc.dob); ;
            //List<Gender> genderlist = db.Departments.ToList();
            //ViewBag.selectDept = new SelectList(genderlist, "genderid", "gender");
            
            return View(acc);
        }
        //[HttpPost]
        //public ActionResult Update()
        //{
        //    return View();
        //}
        public ActionResult Update(string Studentid)
        {
            connection();            
            cmd.CommandText = "select * from T_Student where studentid='"+ Studentid + "'";
            cmd.Connection = con;
            con.Open();
            OracleDataReader dr = cmd.ExecuteReader();
            dr.Read();
            //AccountID accid = new AccountID(dr["studentid"].ToString());
            //cmd.CommandText = "select * from T_Student where studentid='" + accid + "'";
            string stuname = dr["STUDENTNAME"].ToString();
            string fathername = dr["fathername"].ToString();
            string mothername = dr["mothername"].ToString();
            string address = dr["address"].ToString();
            string contactno = dr["contactno"].ToString();
            string stuid = dr["Studentid"].ToString();
            string email = dr["email"].ToString();
            string nid = dr["nid"].ToString();
            string dob = Convert.ToDateTime(dr["dob"]).ToString();
            //DateTime dob = dr.GetDateTime(9);
            //Account acc = new Account();
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
            return View("Update",acc);
            
        }
        public ActionResult edit()
        {
            cmd.CommandText = "select * from T_Student where studentid='pgdit2005'";
            cmd.Connection = con;
            con.Open();
            OracleDataAdapter da =new OracleDataAdapter();
            System.Data.DataSet dt=new System.Data.DataSet();
            da.Fill(dt);
            

            return View();
        }

        [HttpPost]
        public JsonResult UpdateDetails(Account acc,string Studentid)
        {

            connection();
            cmd.Connection = con;
            cmd.CommandText = "UpdateStudentDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("pstdname", acc.Studentname);
            cmd.Parameters.Add("pstdid", OracleDbType.Varchar2).Value = Studentid;
            //cmd.Parameters.Add("paddress", acc.address);
            //cmd.Parameters.Add("pStdid", acc.Studentid);
            //cmd.Parameters.Add("pemail", acc.email);
            //cmd.Parameters.Add("pfathername", acc.fathername);
            //cmd.Parameters.Add("pMothername", acc.mothername);            
            //cmd.Parameters.Add("pContactno", acc.contactno);           
            //cmd.Parameters.Add("pDob", acc.dob);
            //cmd.Parameters.Add("pNid", acc.nid);
            cmd.Parameters.Add("pAccno", acc.accountno);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            //return View("Update",acc);
            return Json(new { success = true, data = acc });


         }
        [HttpPost]
        public JsonResult UpdateStudent(Account acc)
        {
            string str = acc.Studentname;
            //connection();
            //con.Open();
            //cmd = new OracleCommand("update T_STUDENT SET"+
            //                "STUDENTNAME=pStdname"
            //                + ",FATHERNAME=pFathername"
            //                //+ ",MOTHERNAME='" + acc.mothername + "'"
            //                + ",ADDRESS=pAddress"
            //                //+ ",NID='" + acc.nid + "'"
            //                //+ ",EMAIL='" + acc.email + "'"
            //                //+ ",CONTACTNO='" + acc.contactno + "'"
            //                + "WHERE studentid='pgdit2005'", con);
            //cmd.Parameters.Add("pStdname", acc.Studentname);
            //cmd.Parameters.Add("pAddress", acc.address);
            //cmd.Parameters.Add("pStdid", acc.Studentid);
            //acc.Studentname = stuname;
            //cmd.Parameters.Add("pFathername", acc.fathername);           
            //cmd.ExecuteNonQuery();
            //con.Close();
            //return Json(new { success = true, data = acc });
            return null;

        }
        public ActionResult BrowseImage(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                    file.SaveAs(_path);
                }
                ViewBag.Message = "File Uploaded Successfully!!";
                return View("Update");
            }
            catch
            {
                ViewBag.Message = "File upload failed!!";
                return View("Update");
            }
        }
        public ActionResult Genderlookup()
        {
            connection();
            con.Open();
            cmd.CommandText = "select * from t_gender";
            var sql = cmd.CommandText;
            List<Gender> gender = new List<Gender>();
            foreach (var item in gender)
            {
                gender.Add(new Gender { genderid = item.genderid, gender = item.gender});
            }
            Genderlookup model = new Genderlookup();
            model.gender = gender;
            return View(model);
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