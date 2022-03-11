using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Code_First_Tutorial.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Display(Name="Category")]
        public string Name { get; set; }
    }
}