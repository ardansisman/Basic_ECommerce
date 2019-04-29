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
    public class ProductController : ApiController
    {
        ProductService service = new ProductService();

        [Route("api/Product/List")]
        public object ProductList()
        {
            return service.GetProducts();
        }

        [Route("api/Product/Detail")]
        public object Detail(Product product)
        {
            return service.ProductDetail(product);
        }

        [Route("api/Product/AddtoBasket")]
        public  object AddtoBasket(Basket basket)
        {
            return service.AddtoBasketProduct(basket);
        }
    }
}
