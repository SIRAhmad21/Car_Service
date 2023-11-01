using CarServiceBL.IRepository;
using CarServiceBL.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarServiceUI.ViewComponents
{
    public class ServiceViewComponent :ViewComponent
    {
        public IBaseRepository<Service> baseRepository;
        public ServiceViewComponent(IBaseRepository<Service> _baseRepository)
        {
            baseRepository = _baseRepository;
        }
        public IViewComponentResult Invoke()
        {
            return View(baseRepository.GetAll().OrderByDescending(x => x.ServiceId));
        }
    }
}
