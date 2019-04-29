using Proje.Common.Entities.Domain;
using Proje.Common.Response;
using Proje.Common.SystemConstant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Proje.WebUI.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5006/");
            HttpResponseMessage result = client.PostAsJsonAsync("api/Login/Login", new User
            {
                Password = Security.sha512encrypt(user.Password).Substring(0,40),
                Email = user.Email,
            }).Result;

            if (result.StatusCode == HttpStatusCode.OK)
            {
                string resultString = result.Content.ReadAsStringAsync().Result;
                if (resultString != "{\"User\":null}")
                {
                    LoginResponse login = Newtonsoft.Json.JsonConvert.DeserializeObject<LoginResponse>(resultString);
                    if (login.Code == 1)
                    {
                        HttpCookie cookie = new HttpCookie("Auth", login.Token.Value);
                        cookie.Expires = login.Token.ExpireDate;
                        HttpContext.Response.Cookies.Add(cookie);

                        Session["User"] = login.User;
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUpComplete(User user)
        {
            user.ValidationKey = RandomSfr.Generate(30);
            user.Password = Security.sha512encrypt(user.Password).Substring(0,40);
            user.Address = user.Address;
            user.Phone = user.Phone;
            user.isActive = false;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5006/");
            HttpResponseMessage result = client.PostAsJsonAsync("api/Login/SignUp", user).Result;

            if (result.StatusCode == HttpStatusCode.OK)
            {
                string resultString = result.Content.ReadAsStringAsync().Result;
                if (resultString != "{\"Code\":0}")
                {
                    SignUpRespone login = Newtonsoft.Json.JsonConvert.DeserializeObject<SignUpRespone>(resultString);
                    if (login.Code == 1)
                    {
                       TempData["Success"] = "Kayıt İşlemi Başarılı Mail Kutunuzu Kontrol Edin!";
                        return RedirectToAction("Index", "Login");
                    }
                }
            }
            TempData["Error"] = "Bazı  şeyler ters gitti tekrar deneyin!!";
            return RedirectToAction("SignUp", "Login");
        }

        public ActionResult Activate(string email, string valKey)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(SystemConstants.webApiBaseAddress);
            HttpResponseMessage result = client.PostAsJsonAsync("api/Login/Activate", new User
            {
                Email = email,
                ValidationKey = valKey
            }).Result;

            if (result.StatusCode == HttpStatusCode.OK)
            {
                string resultString = result.Content.ReadAsStringAsync().Result;
                if (resultString != "{\"Code\":0}")
                {
                    ActivateResponse activate = Newtonsoft.Json.JsonConvert.DeserializeObject<ActivateResponse>(resultString);
                    if (activate.Code == 1)
                    {
                        return RedirectToAction("Index", "Login");
                    }
                }
            }
            return RedirectToAction("Index", "Login");
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            HttpCookie cookie = new HttpCookie("Auth");
            cookie.Expires = DateTime.Now;
            Response.Cookies.Add(cookie);
            return RedirectToAction("Index", "Home");
        }
    }
}