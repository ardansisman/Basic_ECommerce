using Proje.Common.Entities.Domain;
using Proje.Common.Response;
using Proje.Common.SystemConstant;
using Proje.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Proje.WebUI.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Detail(int id)
        {
            HomePageViewModel model = new HomePageViewModel();

            HttpClient client2 = new HttpClient();
            client2.BaseAddress = new Uri(SystemConstants.webApiBaseAddress);
            HttpResponseMessage result2 = client2.PostAsJsonAsync("api/Basket/List", (Session["User"] as User) == null ? new User { ID = 0 } : (Session["User"] as User)).Result;
            if (result2.StatusCode == HttpStatusCode.OK)
            {
                string resultString = result2.Content.ReadAsStringAsync().Result;
                if (resultString != "{\"Products\":null}")
                {
                    GetBasketResponse basketResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<GetBasketResponse>(resultString);
                    if (basketResponse.Code == 1 || basketResponse.Code == 2)
                    {
                        model.BasketResponse = basketResponse;
                    }
                    else
                        return View("SystemError");
                }
            }

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(SystemConstants.webApiBaseAddress);
            HttpResponseMessage result = client.PostAsJsonAsync("api/Product/Detail", new Product
            {
                ID = id
            }).Result;
            if (result.StatusCode == HttpStatusCode.OK)
            {
                string resultString = result.Content.ReadAsStringAsync().Result;
                if (resultString != "{\"Product\":null}")
                {
                    ProductDetailResponse product = Newtonsoft.Json.JsonConvert.DeserializeObject<ProductDetailResponse>(resultString);
                    model.ProductDetailResponse = product;
                    if (product.Code == 1)
                        return View("Detail", model);
                    if (product.Code == 2)
                        return View("NotFound");
                }
            }
            return View("SystemError");
        }

        public ActionResult AddtoBasket(int id)
        {
            if (Session["User"] != null)
            {
                int Quantity = Convert.ToInt32(Request.QueryString["Quantity"]) == 0 ? 1 : Convert.ToInt32(Request.QueryString["Quantity"]);
                string Color = Request.QueryString["Color"] == null ? "Siyah" : Request.QueryString["Color"];
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(SystemConstants.webApiBaseAddress);
                HttpResponseMessage result = client.PostAsJsonAsync("api/Product/AddtoBasket", new Basket
                {
                    User_ID = (Session["User"] as User).ID,
                    Product_ID = id,
                    Color = Color,
                    Quantity = Quantity
                }).Result;
                if (result.StatusCode == HttpStatusCode.OK)
                {
                    string resultString = result.Content.ReadAsStringAsync().Result;
                    if (resultString != "{\"Product\":null}")
                    {
                        AddtoBasketResponse basket = Newtonsoft.Json.JsonConvert.DeserializeObject<AddtoBasketResponse>(resultString);
                        if (basket.Code == 1)
                            return RedirectToAction("Index", "Home");
                    }
                }
                return View("SystemError");
            }
            else
                return RedirectToAction("Index", "Login");
        }

        public ActionResult RemoveProduct(int pid, int uid)
        {
            if (Session["User"] != null)
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(SystemConstants.webApiBaseAddress);
                HttpResponseMessage result = client.PostAsJsonAsync("api/Basket/RemoveProduct", new Basket
                {
                    User_ID = uid,
                    Product_ID = pid,
                }).Result;
                if (result.StatusCode == HttpStatusCode.OK)
                {
                    string resultString = result.Content.ReadAsStringAsync().Result;
                    if (resultString != "{\"Code\":0}")
                    {
                        AddtoBasketResponse basket = Newtonsoft.Json.JsonConvert.DeserializeObject<AddtoBasketResponse>(resultString);
                        if (basket.Code == 1)
                            return RedirectToAction("Index", "Home");
                    }
                }
                return View("SystemError");
            }
            else
                return RedirectToAction("Index", "Login");
        }
    }
}