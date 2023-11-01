using CarServiceBL.IRepository;
using CarServiceBL.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarServiceUI.ViewComponents
{
    public class TechnicianViewComponent:ViewComponent
    {
        public IBaseRepository<Technician> baseRepository;
        public TechnicianViewComponent(IBaseRepository<Technician> _baseRepository)
        {
            baseRepository = _baseRepository;
        }
        public IViewComponentResult Invoke()
        {
            return View(baseRepository.GetAll().OrderByDescending(x => x.TechnicianId));
        }
    }
}
