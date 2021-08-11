using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using proyecto_mascotas.Models;

namespace proyecto_mascotas.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDBContext _context;
        public HomeController(AppDBContext context)  
        {  
            _context = context;  
            
        }  
        
        public IActionResult Index()
        {
            
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
