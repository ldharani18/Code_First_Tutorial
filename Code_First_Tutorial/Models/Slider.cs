using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Code_First_Tutorial.Models
{
    public class Slider
    {
        public int Id { get; set; }
        public string ImageName{ get; set; }
        public string ImageTitle { get; set; }
        public string FilePath { get; set; }
        public string Description { get; set; }


    }
}