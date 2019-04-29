using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.Common.Entities.Domain
{
   public class Order
    {
        public int ID { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public decimal Price { get; set; }
        public User User { get; set; }
    }
}
