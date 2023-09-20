using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Model
{
    public class CommentModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string UserId { get; set; }
        public UserDataModel User { get; set; }
        public int DeliveryId { get; set; }
    }
}
