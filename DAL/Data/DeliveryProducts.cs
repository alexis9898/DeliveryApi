using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class DeliveryProducts
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int DeliveryId { get; set; }
        public Delivery Delivery { get; set; }

    }
}


