using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Entities
{
    public class Product
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string SKU { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string ImgUrl { get; set; }
    }
}
