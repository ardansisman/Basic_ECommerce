using Proje.Business.UserService;
using Proje.Common.Entities.Domain;
using Proje.Common.Response;
using Proje.Common.SystemConstant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Proje.API.Controllers
{
    [EnableCors(origins: "http://localhost:6868/", headers: "*", methods: "*")]
    public class LoginController : ApiController
    {
        UserService userService = new UserService();
        [Route("api/Login/Login")]
        public object Login(User user)
        {
            return userService.GetUserWithEmailAndPassword(user.Email, user.Password);
        }

        [Route("api/Login/SignUp")]
        public async Task<object> SignUp(User user)
        {
            SignUpRespone response = new SignUpRespone();
            response = userService.UserSignUp(user);
            if (response.Code == 1)
            {
                string link = "<a href='http://localhost:6868/Login/Activate?email=" + user.Email + "&valKey=" + Security.sha512encrypt(user.ValidationKey) + "'>";
                string subjectName = "Ardan Ticaret Aktivasyon İşlemi";
                //todo image işi ayarlanacak.
                string image = "";
                string body = "Kayıt işlemini tamamlamak için lütfen linke " + link + "tıklayınız.</a>" + image;
                await MailOperations.SendMailForSignUp(subjectName, body, user.Email);

            }
            return response;
        }

        [Route("api/Login/Activate")]
        public object Activate(User user)
        {
            return userService.Activate(user);
        }
    }
}
