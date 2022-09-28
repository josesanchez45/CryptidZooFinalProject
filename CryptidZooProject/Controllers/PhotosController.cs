using Microsoft.AspNetCore.Mvc;

namespace CryptidZooProject.Controllers
{
    public class PhotosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
