using Code_First_Tutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Code_First_Tutorial.ViewModel
{
    public class ProductFromViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}