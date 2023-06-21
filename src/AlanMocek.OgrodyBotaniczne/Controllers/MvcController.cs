using Microsoft.AspNetCore.Mvc;

namespace AlanMocek.OgrodyBotaniczne.Controllers
{
    public class MvcController : Controller
    {
        [Route("")]
        public IActionResult Main()
        {
            return View();
        }
    }
}
