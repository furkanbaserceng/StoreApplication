using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StoreApp.Pages
{
    public class SessionDemoModel : PageModel
    {

        public String? FullName => HttpContext?.Session?.GetString("name") ?? "Session verisi yok";

        public void OnGet()
        {
        }
        public void OnPost([FromForm] string name)
        {
            HttpContext.Session.SetString("name", name);
        }
    }
}
