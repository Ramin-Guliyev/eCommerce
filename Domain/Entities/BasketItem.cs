﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BasketItem
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string CustomerEmail { get; set; } 
        public int Quantity { get; set; }
        public string ImgUrl { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
