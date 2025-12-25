using Microsoft.AspNetCore.Mvc;

namespace WarriorFightClub.WebUI.Controllers
{
    public class TrainerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
