using Proje.Common.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.Common.Response
{
   public class LoginResponse:BaseResponse
    {
        public User User { get; set; }
        public Token Token { get; set; }
    }
}
