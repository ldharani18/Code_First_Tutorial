using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Code_First_Tutorial.ViewModel
{
    public class LoginFormViewModel
    {
        //Creating Custom Properties in ViewModel
        [Required(ErrorMessage = "User Name is Required")]
        [Display(Name = "User Name")]
        [StringLength(20)]
        [MaxLength(20)]
        public string UserName { get; set; }



        [Required(ErrorMessage = "Password is Required")]
        [Display(Name = "Password")]
        [StringLength(20)]
        [MaxLength(20)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}