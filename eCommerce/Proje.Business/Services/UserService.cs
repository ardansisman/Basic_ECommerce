using Proje.Common.Entities;
using Proje.Common.Entities.Domain;
using Proje.Common.Response;
using Proje.Common.SystemConstant;
using Proje.Data.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.Business.UserService
{
    public class UserService
    {
        UserDal userDal = new UserDal();
        public LoginResponse GetUserWithEmailAndPassword(string email, string password)
        {
            
            return userDal.GetUserForLogin(email, password);
        }
        public SignUpRespone UserSignUp(User user)
        {
            return userDal.UserSignUp(user);
        }
        public ActivateResponse Activate(User user)
        {
            return userDal.ActivateUser(user);
        }
    }
}
