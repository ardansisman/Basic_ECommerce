using Proje.Common.Entities.Domain;
using Proje.Common.Response;
using Proje.Data.ProductData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.Business.Services
{
    public class ProductService
    {
        ProductDal productDal = new ProductDal();
        public ProductListResponse GetProducts()
        {
            return productDal.GetProductList();
        }

        public ProductDetailResponse ProductDetail(Product product)
        {
            return productDal.GetProductDetail(product);
        }

        public AddtoBasketResponse AddtoBasketProduct(Basket basket)
        { 
            return productDal.AddtoBasketProduct(basket);
        }
    }
}
