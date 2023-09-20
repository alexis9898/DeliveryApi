using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Model
{
    public class DeliveryProductsModel
    {
        public int ProductId { get; set; }
        //public ProductModel Product { get; set; }

        public int DeliveryId { get; set; }
        //public DeliveryModel Delivery { get; set; }

        public int Amount { get; set; } = 1;

    }
}
