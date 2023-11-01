using CarServiceBL.IRepository;
using CarServiceBL.Models;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace CarServiceUI.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class ServiceController : Controller
    {

        public IBaseRepository<Service> serrepo;
        public IHostingEnvironment _hosting;
        public ServiceController(IBaseRepository<Service> _serrepo,IHostingEnvironment hosting)
        {
            serrepo = _serrepo; 
            _hosting = hosting; 
        }

        public IActionResult Index()
        {
            ViewBag.IsDeleted = serrepo.GetAll().Where(x => x.IsDeleted == true).Count();
            var result = serrepo.GetAll().Where(x => x.IsDeleted == false);
            return View(result);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Create(Service ser)
        {
            if (ser.Image != null)
            {
                string ImageFile = Path.Combine(_hosting.WebRootPath, "img");
                string ImgPath = Path.Combine(ImageFile, ser.Image.FileName);
                ser.Image.CopyTo(new FileStream(ImgPath, FileMode.Create));
                ser.ImagePath = ser.Image.FileName;
            }
            serrepo.Add(ser);

            return RedirectToAction(nameof(Index));
        }
       [HttpGet]
       public IActionResult Delete()
       {

           return View();
       }
       [HttpPost]
       public IActionResult Delete(int id)
       {
           serrepo.Delete(id);
           return RedirectToAction(nameof(Index));
       }
       public IActionResult SoftDelete(int id)
       {

           var sof = serrepo.GetById(id);
           sof.IsDeleted = true;
           serrepo.SaveData();
           return RedirectToAction("Index");
       }
       public IActionResult ViewAllDeleted()
       {
           return View(serrepo.GetAll().Where(x => x.IsDeleted == true));
       
       }
       public IActionResult Restore(int id)
       {
           var edata = serrepo.GetById(id);
           edata.IsDeleted = false;
           serrepo.SaveData();
           return RedirectToAction("Index");
       }

         public IActionResult Edit(int id)
         {
             return View(serrepo.GetById(id));
         }
         [HttpPost]
         public IActionResult Edit(Service ser, int id)
         {
             serrepo.UPdate(id, ser);
             return RedirectToAction(nameof(Index));
         }
    }
}
