using Car_ServicesBL.IRepository;
using Car_ServicesBL.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Car_ServiceUI.ViewComponents
{
    public class ServiceViewComponent : ViewComponent
    {
        public IBaseRepository<Service> baseRepository;
        public ServiceViewComponent(IBaseRepository<Service> _baseRepository )
        {
            baseRepository = _baseRepository;
        }
        public IViewComponentResult Invoke()
        {
            return View(baseRepository.GetAll().OrderByDescending(x=>x.ServiceId));
        }
    }
}
