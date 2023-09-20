using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLL.Model
{
    public class ProductModel
    {
        public int Id { get; set; }
        //[Required(ErrorMessage ="name is missing")]
        public string Name { get; set; }

        //public double Price { get; set; }
        //public int Stock { get; set; }
        //public string Discription { get; set; }
        //public int CategoryId { get; set; }


    }
}
