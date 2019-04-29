using Proje.Common.Entities.Domain;
using Proje.Common.Response;
using Proje.Data.BasketData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.Business.Services
{
    public class BasketService
    {
        BasketDal basketDal = new BasketDal();
        public GetBasketResponse GetBasketItemsOfUser(int id)
        {
            return basketDal.GetProductsOfUser(id);
        }

        public RemoveResponse RemoveProductFromBasket(Basket basket)
        {
            return basketDal.RemoveProductFromBasket(basket);
        }
    }
}
