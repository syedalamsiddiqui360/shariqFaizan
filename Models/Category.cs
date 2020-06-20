using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace shariqFaizan.Models
{
    public class Category
    {
        
        public int ct_id { get; set; }

        [Required(ErrorMessage="Name is requied")]
        public string ct_name { get; set; }
    }
}