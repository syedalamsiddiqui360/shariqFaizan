using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace shariqFaizan.Models
{
    public class Product
    {
        public int id { get; set; }
        public String name { get; set; }
        public String description { get; set; }
        public double price { get; set; }
        public int unit_in_stock { get; set; }

        [DisplayName("Upload File")]
        public String picture { get; set; }
        public String path { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }

        
        public int c_id { get; set; }

    }
}