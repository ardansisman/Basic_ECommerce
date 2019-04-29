using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.Common.Entities.Domain
{
    public class ImageGallery
    {
        public int ID { get; set; }

        public string Path { get; set; }
        public Product Product { get; set; }
    }
}
