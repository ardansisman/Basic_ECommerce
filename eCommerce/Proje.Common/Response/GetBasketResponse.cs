using Proje.Common.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.Common.Response
{
    public class GetBasketResponse:BaseResponse
    {
        public int Count { get; set; }
        public int Quantity { get; set; }
        public string Color { get; set; }
        public List<Basket> Baskets{ get; set; }
    }
}
