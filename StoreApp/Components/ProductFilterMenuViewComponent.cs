using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Components
{
    public class ProductFilterMenuViewComponent : ViewComponent
    {

       

        public IViewComponentResult Invoke()
        {

            return View();

        }

    }
}
