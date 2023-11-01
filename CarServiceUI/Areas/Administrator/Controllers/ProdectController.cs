using CarServiceBL.IRepository;
using CarServiceBL.Models;
using CarServiceEF.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace CarServiceUI.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class ProdectController : Controller
    {
        #region Config 
        public IBaseRepository<Prodect> prorepo;
        public IHostingEnvironment _hosting;
        private AppDbContext db;
        public ProdectController(IBaseRepository<Prodect> _prorepo, IHostingEnvironment hosting, AppDbContext _db)
        {
            prorepo = _prorepo;
            _hosting = hosting;
            db = _db;
        }
        #endregion
        public IActionResult Index()
        {
            ViewBag.IsDeleted = prorepo.GetAll().Where(x => x.IsDeleted == true).Count();
            
            var result = prorepo.GetAll().OrderByDescending(x => x.ProdectId).Where(x => x.IsDeleted == false);
            return View(result);
        }

        public IActionResult Create()
        {
           
            return View();
        }
        [HttpPost]
        public IActionResult Create(Prodect pro)
        {
            if (pro.Image != null)
            {
                string ImageFile = Path.Combine(_hosting.WebRootPath, "img");
                string ImgPath = Path.Combine(ImageFile, pro.Image.FileName);
                pro.Image.CopyTo(new FileStream(ImgPath, FileMode.Create));
                pro.ImagePath = pro.Image.FileName;
            }
            prorepo.Add(pro);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete()
        {

            return View();
        }
        [HttpPost]
        public IActionResult  Delete(int id)
        {
            prorepo.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            return View(prorepo.GetById(id));
        }
        [HttpPost]
        public IActionResult Edit(Prodect pro, int id)
        {
            prorepo.UPdate(id, pro);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult SoftDelete(int id)
        {

            var sof = prorepo.GetById(id);
            sof.IsDeleted = true;
            prorepo.SaveData();
            return RedirectToAction("Index");
        }
        public IActionResult ViewAllDeleted()
        {
            return View(prorepo.GetAll().Where(x => x.IsDeleted == true));

        }
        public IActionResult Restore(int id)
        {
            var edata = prorepo.GetById(id);
            edata.IsDeleted = false;
            prorepo.SaveData();
            return RedirectToAction("Index");
        }
    }
}
