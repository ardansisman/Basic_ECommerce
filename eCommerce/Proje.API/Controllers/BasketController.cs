using Proje.Business.Services;
using Proje.Common.Entities.Domain;
using Proje.Common.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Proje.API.Controllers
{
    [EnableCors(origins: "http://localhost:6868/", headers: "*", methods: "*")]
    public class BasketController : ApiController
    {
        BasketService service = new BasketService();
        [Route("api/Basket/List")]
        public GetBasketResponse List(User user)
        {
            return service.GetBasketItemsOfUser(user.ID);
        }
        [Route("api/Basket/RemoveProduct")]
        public RemoveResponse RemoveProduct(Basket basket)
        {
            return service.RemoveProductFromBasket(basket);
        }
    }
}
