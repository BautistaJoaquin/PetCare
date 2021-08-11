using System;
using Microsoft.AspNetCore.Mvc;
using proyecto_mascotas.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using System.IO; 
using Microsoft.AspNetCore.Http;

namespace proyecto_mascotas.Controllers
{
    public class ForumController : Controller
    {
        private readonly AppDBContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;
      
        public ForumController(AppDBContext context,IWebHostEnvironment hostEnvironment)  
        {  
            _context = context;  
            webHostEnvironment = hostEnvironment;
      
        }  
 
        public async Task<IActionResult> Index()
        {
           
            return View(await _context.foro.ToListAsync());
        }
  
        // GET: Forum/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Forum/Create
        [HttpPost]
        public IActionResult Create(IFormFile files, ForumViewModel model)
        {
            if (files != null)
            {
                if (files.Length > 0)
                {
                    //Getting FileName
                    var fileName = Path.GetFileName(files.FileName);
                    //Getting file Extension
                    var fileExtension = Path.GetExtension(fileName);
                    // concatenating  FileName + FileExtension
                    var myUniqueFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);

                    // Obtenemos la ruta para guardar la imagen.
                    string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Foro");
                    string filepath = Path.Combine(uploadsFolder,fileName); 
                    using (FileStream fs = System.IO.File.Create(filepath))
                    {
                        files.CopyTo(fs);
                        fs.Flush();
                    }
                   
                    var objfiles = new ForumViewModel()
                    {
                        Idposteo = 0,
                        Tittle = model.Tittle,
                        Desc = model.Desc,
                        FileName = fileName,
                        Ruta = filepath,
                        FechaDate = DateTime.Now,
                        HoraTime = DateTime.Now,
                    };

                    _context.foro.Add(objfiles);

                    _context.SaveChanges();

                    return RedirectToAction("Index","Forum");
                }
            }
            return View(model);
        }

    }
}
