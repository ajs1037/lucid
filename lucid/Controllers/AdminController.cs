using System.Linq;
using lucid.Data;
using lucid.Services;
using Microsoft.AspNetCore.Mvc;

namespace lucid.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
