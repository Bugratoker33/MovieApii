using Microsoft.AspNetCore.Mvc;

namespace MoviApi.Web.Uı.Controllers
{
    public class UserWebUILayoutController : Controller
    {
        public IActionResult LayoutUI()
        {
            return View();
        }
    }
}
