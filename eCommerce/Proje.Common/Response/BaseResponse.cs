using Proje.Common.SystemConstant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.Common.Response
{
   public class BaseResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public void SetError (SystemConstants.ERRORS error)
        {
            Code = (int)error;
            Message = SystemConstants.SystemErrors[Code];
        }
    }
}
