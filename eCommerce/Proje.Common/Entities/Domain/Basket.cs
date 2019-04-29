using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.Common.Entities.Domain
{
    public class Basket
    {
        public int ID { get; set; }
        public int Product_ID { get; set; }
        public int User_ID { get; set; }
        public int Quantity { get; set; }
        public string Color { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }
    }
}
