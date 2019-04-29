using Proje.Common.Entities;
using Proje.Common.Entities.Domain;
using Proje.Common.Response;
using Proje.Common.SystemConstant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.Data.UserData
{
    public class UserDal
    {
        public LoginResponse GetUserForLogin(string email, string password)
        {
            LoginResponse loginResponse = new LoginResponse();
            using (MyDb db = new MyDb())
            {

                try
                {
                    loginResponse.User = db.Users.FirstOrDefault(x => x.Email == email && x.Password == password && x.isActive == true);
                    if (loginResponse.User == null)
                    {
                        loginResponse.SetError(Common.SystemConstant.SystemConstants.ERRORS.NOTFOUND);

                    }
                    else
                    {
                        Token token = new Token();
                        token.Value = RandomSfr.Generate(50);
                        token.ExpireDate = DateTime.Now.AddDays(1);
                        loginResponse.Token = token;
                        loginResponse.SetError(Common.SystemConstant.SystemConstants.ERRORS.SUCCESSFUL);
                    }
                }
                catch (Exception)
                {
                    loginResponse.SetError(Common.SystemConstant.SystemConstants.ERRORS.SYSTEMERROR);
                }


            }
            return loginResponse;
        }

        public SignUpRespone UserSignUp(User user)
        {
            SignUpRespone response = new SignUpRespone();
            try
            {
                using (MyDb db = new MyDb())
                {
                    db.Entry(user).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();
                    response.SetError(SystemConstants.ERRORS.SUCCESSFUL);
                }
            }
            catch (Exception ex)
            {
                response.SetError(SystemConstants.ERRORS.SYSTEMERROR);
            }
            return response;
        }
        public ActivateResponse ActivateUser(User user)
        {
            ActivateResponse response = new ActivateResponse();

            using (MyDb db = new MyDb())
            {
                try
                {
                    User user2 = db.Users.FirstOrDefault(t => t.Email == user.Email);
                    if (user.ValidationKey == Security.sha512encrypt(user2.ValidationKey))
                    {
                        user2.isActive = true;
                        db.Entry(user2).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        response.SetError(SystemConstants.ERRORS.SUCCESSFUL);
                    }
                    else
                        response.SetError(SystemConstants.ERRORS.NOTFOUND);

                }
                catch (Exception ex)
                {
                    response.SetError(SystemConstants.ERRORS.SYSTEMERROR);
                }
                return response;
            }
        }
    }
}
