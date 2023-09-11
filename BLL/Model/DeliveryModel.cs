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
        public UserModel DeliveryPersons { get; set; }
        //[ForeignKey("Manager")]
        public string ManagerId { get; set; }
        public UserModel Manager { get; set; }

        //public List<Comment> Comment { get; set; }
        public List<ProductDetail> Products { get; set; }
    }
}
