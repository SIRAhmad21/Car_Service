using Car_ServicesBL.IRepository;
using Car_ServicesBL.Models;
using Car_ServicesEF.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Car_ServiceUI.ViewComponents
{
    public class TECHNICIANViewComponent  : ViewComponent
    {
        public IBaseRepository<TECHNICIAN> tecrepo;
        public TECHNICIANViewComponent(IBaseRepository<TECHNICIAN> _tecrepo)
        {
            tecrepo = _tecrepo;   
        }
        public IViewComponentResult Invoke()
        {
            return View(tecrepo.GetAll());
                
        }
    }
}

