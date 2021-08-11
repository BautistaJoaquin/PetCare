using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using proyecto_mascotas.Models;

namespace proyecto_mascotas.Controllers
{
    public class AboutController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

    }
}
