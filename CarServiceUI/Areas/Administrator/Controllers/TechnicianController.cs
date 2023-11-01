using CarServiceBL.IRepository;
using CarServiceBL.Models;
using CarServiceEF.Repositories;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace CarServiceUI.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class TechnicianController : Controller
    {
        public IBaseRepository<Technician> tecrepo;
        public IHostingEnvironment _hosting;
        public TechnicianController(IBaseRepository<Technician> _tecrepo,IHostingEnvironment hosting)
        {
            tecrepo = _tecrepo;  
            _hosting = hosting;
        }

        public IActionResult Index()
        {
            ViewBag.IsDeleted = tecrepo.GetAll().Where(x => x.IsDeleted == true).Count();
            var result = tecrepo.GetAll().Where(x => x.IsDeleted == false);
            return View(result);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Create(Technician tec)
        {
           
                if (tec.Image!=null ) {
                    string ImageFile = Path.Combine(_hosting.WebRootPath, "img");
                    string ImgPath = Path.Combine(ImageFile,tec.Image.FileName);
                    tec.Image.CopyTo(new FileStream(ImgPath, FileMode.Create));
                   tec.ImagePath = tec.Image.FileName;
                } 
            tecrepo.Add(tec);
            return RedirectToAction(nameof(Index));
          
           
        }
       [HttpGet]
       public IActionResult Delete()
       {
            
            return View();
       }
    [HttpPost]
    public IActionResult Delete(int id )
    {
            tecrepo.Delete(id);
            return RedirectToAction(nameof(Index));
    }
     public IActionResult SoftDelete(int id)
     {

         var sof = tecrepo.GetById(id);
         sof.IsDeleted = true;
         tecrepo.SaveData();
         return RedirectToAction("Index");
     }
       public IActionResult ViewAllDeleted()
       {
           return View(tecrepo.GetAll().Where(x => x.IsDeleted == true)); 

       }
      public IActionResult Restore(int id)
      {
          var edata = tecrepo.GetById(id);
          edata.IsDeleted = false;
          tecrepo.SaveData();
          return RedirectToAction("Index");
      }

        public IActionResult Edit(int id)
        {
            return View(tecrepo.GetById(id));
        }
        [HttpPost]


        public IActionResult Edit(Technician em, int id)
        {
            //if (em.Image != null)
            //{
            //    string ImageFile = Path.Combine(_hosting.WebRootPath, "img");
            //    string ImgPath = Path.Combine(ImageFile, em.Image.FileName);

            //    string oldImagePath = tecrepo.GetById(id).ImagePath;
            //    string fulloldImagePath = Path.Combine(ImageFile, oldImagePath);
            //    if (System.IO.File.Exists(oldImagePath))
            //    {
            //        System.IO.File.Delete(oldImagePath);
            //    }
            //    em.Image.CopyTo(new FileStream(ImgPath, FileMode.Create));
            //    em.ImagePath = em.Image.FileName; }
                tecrepo.UPdate(id, em);
                return RedirectToAction(nameof(Index));
           
        }
    }
}
