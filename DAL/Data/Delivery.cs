using DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class Delivery
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public Status Status { get; set; } // arrive/in-the-way/done.
        public List<string> Comment { get; set; }
        public int CustomerId { get; set; } //For
        public Customer Customer { get; set; }
        public int DeliveryPersonId { get; set; }
        public DeliveryPersons DeliveryPersons { get; set; }
        public int ManagerId { get; set; }
        public Manager Manager { get; set; }

        public List<Product> Products { get; set; }
    }
}
