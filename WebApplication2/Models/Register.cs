using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace mvcregister.Models
{
    public class Register
    {
        [Required(ErrorMessage ="please Enter Uniquename", AllowEmptyStrings =false)]
        public string Uniquename { get; set; }

        [Required(ErrorMessage = "please Enter Last Name", AllowEmptyStrings = false)]
        public string Last_Name { get; set; }

        [Required(ErrorMessage = "please Enter Email", AllowEmptyStrings = false)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)=[a-zA-Z]{2,6}$", ErrorMessage= "email id is Not in a correct format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "please Enter Pass Word", AllowEmptyStrings = false)]
        public string Password { get; set; }
       
        [StringLength(100,ErrorMessage ="Password Should Be Atleast 8 Characters", MinimumLength =8)]

        [Compare("password", ErrorMessage ="password do not match")]
        public string cnfpassword { get; set; }

        [Required(ErrorMessage = "please Enter Mobile No", AllowEmptyStrings = false)]
        [StringLength(20,ErrorMessage ="minimum 10 digit", MinimumLength =10)]
        public string MobileNo { get; set; }

    }
}