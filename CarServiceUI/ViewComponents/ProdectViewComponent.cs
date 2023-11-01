using CarServiceBL.IRepository;
using CarServiceBL.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarServiceUI.ViewComponents
{
    public class ProdectViewComponent:ViewComponent

    {
        public IBaseRepository<Prodect> baseRepository;
        public ProdectViewComponent(IBaseRepository<Prodect> _baseRepository)
        {
            baseRepository = _baseRepository;
        }
        public IViewComponentResult Invoke()
        {
            return View(baseRepository.GetAll().OrderByDescending(x => x.ProdectId));
        }

    }
}
