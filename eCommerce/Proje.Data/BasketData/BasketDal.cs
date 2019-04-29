using Proje.Common.Entities;
using Proje.Common.Entities.Domain;
using Proje.Common.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.Data.BasketData
{
    public class BasketDal
    {
        public GetBasketResponse GetProductsOfUser(int id)
        {
            GetBasketResponse response = new GetBasketResponse();
            using (MyDb db = new MyDb())
            {
                try
                {
                    List<Basket> basket = db.Baskets.Where(x => x.User_ID == id).ToList();
                    foreach (var item in basket)
                    {
                        item.Product = db.Products.FirstOrDefault(x => x.ID == item.Product_ID);
                    }
                    response.Baskets = basket;
                    response.Count = basket.Count;
                    if (response.Baskets == null)
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

        public RemoveResponse RemoveProductFromBasket(Basket basket)
        {
            RemoveResponse response = new RemoveResponse();
            using (MyDb db = new MyDb())
            {
                try
                {
                    basket = db.Baskets.FirstOrDefault(x => x.Product_ID == basket.Product_ID && x.User_ID == basket.User_ID);
                    db.Entry(basket).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                    response.SetError(Common.SystemConstant.SystemConstants.ERRORS.SUCCESSFUL);
                }
                catch (Exception ex)
                {
                    response.SetError(Common.SystemConstant.SystemConstants.ERRORS.SYSTEMERROR);
                }
                return response;
            }
        }
    }
}
