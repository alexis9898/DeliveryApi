﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Delivery> Deliveries { get; set; }
        public List<DeliveryProducts> DeliveryProducts  { get; set; }


    }
}
