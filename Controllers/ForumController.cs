using System.Net.Http;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using proyecto_mascotas.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using System.IO; 
using Microsoft.AspNetCore.Http;
using proyecto_mascotas.ViewModels;


namespace proyecto_mascotas.Controllers
{
    public class ForumController : Controller
    {
        private readonly AppDBContext dbcontext;
        private readonly IWebHostEnvironment webHostEnvironment;

        private readonly IHttpContextAccessor _httpContextAccessor;

       
        public ForumController(AppDBContext context,IWebHostEnvironment hostEnvironment, IHttpContextAccessor httpContextAccessor)  
        {  
            dbcontext = context;  
            webHostEnvironment = hostEnvironment;
            _httpContextAccessor = httpContextAccessor;
        }  
 
        public async Task<IActionResult> Index()
        {
           
            return View(await dbcontext.Forum.ToListAsync());
        }
  
        // GET: Forum/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Forum/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ForumViewModel model)
        {
            
            
            if (ModelState.IsValid)  
            {
                var userName = TempData["userName"];  
                string uniqueFileName = ProcessUploadedFile(model);
                    Forum post = new Forum
                    {
                        ForumId  = 0,
                        Post_by = (string) userName,
                        Imagen = uniqueFileName,
                        Tittle = model.Tittle,
                        Desc = model.Desc,
                        FechaDate = DateTime.Now,
                        HoraTime = DateTime.Now
                    };
                    
                    dbcontext.Add(post);  
                    await dbcontext.SaveChangesAsync();  

                    var userIds = TempData["userId"];     

                    var forumUser = new ForumUser();
                    forumUser.ForumId = post.ForumId;
                    forumUser.UserId = (int) userIds;

                    dbcontext.Add(forumUser);  
                    await dbcontext.SaveChangesAsync();  

                    // var query = dbcontext.Forum.Include(b => b.ForumUser).ThenInclude(p => p.ForumId).ToList();
                    return RedirectToAction("Index","Forum");
            }
            return View();
        }
          
        public IActionResult Delete(int? id)
        {
            Forum post = dbcontext.Forum.Find(id);

            if (post.Imagen != null)
            {
                //Borrar Imagen desde carpeta
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img\\Foro", post.Imagen);

                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                //Borrar Data
                var del = (from Forum in dbcontext.Forum where Forum.ForumId == id select Forum).FirstOrDefault();
                dbcontext.Forum.Remove(del);
                dbcontext.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                //Delete Data
                var del = (from Forum in dbcontext.Forum where Forum.ForumId == id select Forum).FirstOrDefault();
                dbcontext.Forum.Remove(del);
                dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foro = await dbcontext.Forum.FindAsync(id);

            if (foro == null)
            {
                return NotFound();
            }
            
            var ForumViewModel = new ForumViewModel()
            {
                Id = foro.ForumId,
                Tittle = foro.Tittle,
                Desc = foro.Desc,
                Imagen = foro.Imagen
            };

            
            return View(ForumViewModel);
        }

        [HttpPost]  
        [ValidateAntiForgeryToken]  
        public async Task<IActionResult> Edit(int id, ForumViewModel fvm)  
        {  
            
            if (ModelState.IsValid)  
            {  
                var foro = await dbcontext.Forum.FindAsync(fvm.Id);  
                foro.Tittle = fvm.Tittle;  
                foro.Desc = fvm.Desc;  
                  
                if (fvm.ForumImage != null)  
                {  
                    if (fvm.Imagen != null)  
                    {  
                        string filePath = Path.Combine(webHostEnvironment.WebRootPath, "img/Foro/", fvm.Imagen);
                        System.IO.File.Delete(filePath);  
                    }    
                       
                    foro.Imagen = ProcessUploadedFile(fvm);  
                }  
                dbcontext.Update(foro);  
                await dbcontext.SaveChangesAsync();  

        
                return RedirectToAction(nameof(Index));  
            }  
            return View();  
        }  
         private string ProcessUploadedFile(ForumViewModel model)
        {
            string uniqueFileName = null;

            if (model.ForumImage != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "img/Foro");
                
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ForumImage.FileName;
                
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ForumImage.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
    }
}
