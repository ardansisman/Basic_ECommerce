using Proje.Common.Entities;
using Proje.Common.Entities.Domain;
using Proje.Common.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.Data.ProductData
{
    public class ProductDal
    {
        public ProductListResponse GetProductList()
        {
            ProductListResponse response = new ProductListResponse();
            using (MyDb db = new MyDb())
            {
                try
                {
                    response.Products = db.Products.ToList();
                    if (response.Products == null)
                        response.SetError(Common.SystemConstant.SystemConstants.ERRORS.NOTFOUND);
                    else
                        response.SetError(Common.SystemConstant.SystemConstants.ERRORS.SUCCESSFUL);
                }
                catch (Exception ex)
                {
                    response.SetError(Common.SystemConstant.SystemConstants.ERRORS.SYSTEMERROR);
                }
                return response;
            }
        }
        public ProductDetailResponse GetProductDetail(Product product)
        {
            ProductDetailResponse response = new ProductDetailResponse();
            using (MyDb db = new MyDb())
            {
                try
                {
                    response.Product = db.Products.FirstOrDefault(x => x.ID == product.ID);
                    if (response.Product == null)
                        response.SetError(Common.SystemConstant.SystemConstants.ERRORS.NOTFOUND);
                    else
                    {


                        try
                        {
                            response.productImageGalleries = db.ImageGalleries.Where(x => x.Product.ID == product.ID).ToList();
                            if (response.productImageGalleries != null)
                                response.SetError(Common.SystemConstant.SystemConstants.ERRORS.SUCCESSFUL);
                            else
                                response.SetError(Common.SystemConstant.SystemConstants.ERRORS.NOTFOUND);
                        }catch(Exception ex)
                        {
                            response.SetError(Common.SystemConstant.SystemConstants.ERRORS.SYSTEMERROR);
                        }
                    }
                }
                catch (Exception ex)
                {
                    response.SetError(Common.SystemConstant.SystemConstants.ERRORS.SYSTEMERROR);
                }
                return response;
            }
        }
        public AddtoBasketResponse AddtoBasketProduct(Basket basket)
        {
            AddtoBasketResponse response = new AddtoBasketResponse();
            using (MyDb db = new MyDb())
            {
                try
                {
                    db.Baskets.Add(basket);
                    db.SaveChanges();
                    response.SetError(Common.SystemConstant.SystemConstants.ERRORS.SUCCESSFUL);
                }
                catch(Exception ex)
                {
                    response.SetError(Common.SystemConstant.SystemConstants.ERRORS.SYSTEMERROR);
                }
                
            }
            return response;
        }
        
    }
}
