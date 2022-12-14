using Microsoft.AspNetCore.Mvc;

namespace CryptidZooProject.Controllers
{
    public class CryptidsController : Controller
    {
        private readonly ICryptidsRepository repo;

        public CryptidsController (ICryptidsRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            var cryptid = repo.GetAllCryptids();
            return View(cryptid);
        }
        public IActionResult ViewCryptid (int id)
        {
            var cryptid = repo.GetCryptid(id);
            return View(cryptid);
        }
    }
}
