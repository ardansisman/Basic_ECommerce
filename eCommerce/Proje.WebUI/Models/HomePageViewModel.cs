using Proje.Common.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proje.WebUI.Models
{
    public class HomePageViewModel
    {
        public ProductDetailResponse ProductDetailResponse { get; set; }
        public GetBasketResponse BasketResponse{ get; set; }
        public ProductListResponse ProductList { get; set; }
    }
}