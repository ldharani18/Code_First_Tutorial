using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Code_First_Tutorial.Models
{
    public class Product
    {
        public int Id { get; set; }//automatically taken as primary key
        [Required(ErrorMessage ="Product Name is Required")]
        [StringLength(50)]
        public string Name { get; set; }
        [Display(Name = "Category")]
        public int CategoryId { get; set; }//Foreign Key

        //Load Products with their categories-->Navigation Property
        public Category Category { get; set; }

        public decimal Price { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
    }
}