using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CRUD.Models
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }

        [DisplayName("Employee Name")]
        [Required(ErrorMessage = "Please enter employee Name")]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Please enter proper Username")]
        public string EmployeeName { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Please enter email address")]
        [EmailAddress(ErrorMessage = "Please enter valid email address")]
        public string Email { get; set; }


        [DisplayName("Country")]
        [Required(ErrorMessage = "Please enter Country Name")]    
        public string Country { get; set; }

        [DisplayName("Age")]
        [Required(ErrorMessage = "Please enter Age")]
        [Range(18, 45, ErrorMessage = "Please enter value betweeb 18 to 45")]
        public int Age { get; set; }

        [DisplayName("Resume")]
        [Required(ErrorMessage = "Please upload your resume")]
        //[RegularExpression(@"^([a-zA-Z0-9\s_\\.\-:])+(.doc|.docx|.pdf)$", ErrorMessage = "Only doc and pdf files allowed")]
        public string Resume { get; set; }
    }
}