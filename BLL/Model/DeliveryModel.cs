using DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Model
{
    public class DeliveryModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string Status { get; set; } //  New,Scheduled,Done

        public int CustomerId { get; set; }
        public CustomerModel Customer { get; set; }

        public string DeliveryPersonId { get; set; }
        public UserDataModel DeliveryPersons { get; set; }
        //[ForeignKey("Manager")]
        public string ManagerId { get; set; }
        public UserDataModel Manager { get; set; }

        //public List<Comment> Comment { get; set; }
        public List<DeliveryProductsModel> DeliveryProductsModel { get; set; }
        public List<ProductDetail> ProductsModel { get; set; }
    }
}

//{
//    "status": "string",
//  "customerId": 1,
//  "deliveryPersonId": "0cde4c93-2546-4e39-ac57-8f8b8f66ad58",
//  "managerId": "0cde4c93-2546-4e39-ac57-8f8b8f66ad58",
//  "ProductsModel": [
//    {
//        "id": 0,
//      "name": "string",
//      "amount": 0
//    }
//  ]
//}
