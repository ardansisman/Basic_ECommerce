using Proje.Common.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proje.WebUI.Models
{
    public class ProductDetailViewModel
    {
        public Product Product { get; set; }
        public List<ImageGallery> productImageGalleries { get; set; }
    }
}