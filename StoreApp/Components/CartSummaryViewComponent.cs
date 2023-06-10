using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Infrastructure.Extensions;

namespace StoreApp.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        //private readonly Cart _cart;

        //public CartSummaryViewComponent(Cart cart)
        //{
        //    //_cart = cart;
        //}

        public string Invoke()
        {

            //return _cart.Lines.Count().ToString();

            if (HttpContext.Session.GetJson<Cart>("cart") is not null)
            {
                return HttpContext.Session.GetJson<Cart>("cart").Lines.Count().ToString();
            }

            else return "0";

        }

    }
}
