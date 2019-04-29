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
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {

            HomePageViewModel model = new HomePageViewModel();
            if (Session["User"] != null)
            {
                HttpClient client2 = new HttpClient();
                client2.BaseAddress = new Uri(SystemConstants.webApiBaseAddress);
                HttpResponseMessage result2 = client2.PostAsJsonAsync("api/Basket/List", (Session["User"] as User)).Result;
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
                HttpResponseMessage result = client.PostAsync("api/Product/List", null).Result;
                if (result.StatusCode == HttpStatusCode.OK)
                {
                    string resultString = result.Content.ReadAsStringAsync().Result;
                    if (resultString != "{\"Products\":null}")
                    {
                        ProductListResponse product = Newtonsoft.Json.JsonConvert.DeserializeObject<ProductListResponse>(resultString);
                        if (product.Code == 1 || product.Code == 2)
                        {
                            model.ProductList = product;
                            return View(model);
                        }
                    }
                }
                return View("SystemError");
            }
            else
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(SystemConstants.webApiBaseAddress);
                HttpResponseMessage result = client.PostAsync("api/Product/List", null).Result;
                if (result.StatusCode == HttpStatusCode.OK)
                {
                    string resultString = result.Content.ReadAsStringAsync().Result;
                    if (resultString != "{\"Products\":null}")
                    {
                        ProductListResponse product = Newtonsoft.Json.JsonConvert.DeserializeObject<ProductListResponse>(resultString);
                        if (product.Code == 1 || product.Code == 2)
                        {
                            model.ProductList = product;
                            return View(model);
                        }
                        return View("SystemError");
                    }
                }
                return RedirectToAction("Index", "Home");
            }

        }

    }
}