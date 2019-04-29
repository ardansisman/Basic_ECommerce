using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.Common.Entities.Domain
{
  public  class Token
    {
        public int ID { get; set; }
        public string Value { get; set; }
        public DateTime ExpireDate { get; set; }

        public User User { get; set; }
    }
}
