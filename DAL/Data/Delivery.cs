using DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class Delivery
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now; 
        public string Status { get; set; } //  New,Scheduled,Done

        public int CustomerId { get; set; } 
        public Customer Customer { get; set; }

        [ForeignKey("DeliveryPersonId")]
        public string DeliveryPersonId { get; set; }
        public DeliveryPersons DeliveryPersons { get; set; }
        
        [ForeignKey("ManagerId")]
        public string ManagerId { get; set; }
        public Manager Manager { get; set; }

        public List<Comment> Comment { get; set; }
        public List<DeliveryProducts> DeliveryProducts { get; set; }
        public List<Product> Products { get; set; }

    }
}
