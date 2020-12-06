using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PGDIT_TPS.Models.Account
{
    public class Account
    {
        [DisplayName("Student ID")]
        [Required(ErrorMessage = "This field is required.")]
        public string Studentid { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field is required.")]
        public string Password { get; set; }
        //public string LoginErrorMessage { get; set; }
        public string Studentname { get; set; }
        public string fathername { get; set; }
        public string mothername { get; set; }
        public string address { get; set; }
        public string contactno { get; set; }
        public string nid { get; set; }
        public string email { get; set; }
        //public int genderid { get; set; }
        public int accountno { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-mm-yyyy}")]        
        public DateTime dob { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-mm-yyyy}")]
        public DateTime issuedate { get; set; }
        public HttpFileCollection image { get; set; }
        //public Nullable<int> genderid { get; set; }
        public string gender { get; set; }
        public string religion { get; set; }
        public string bankreceiptno { get; set; }
        public string program { get; set; }
        public string department { get; set; }
        public int batchno { get; set; }
        public decimal cgpa { get; set; }
        public string sessionyear { get; set; }

        //public virtual Gender genders { get; set; }

    }    
}