using Car_ServicesBL.IRepository;
using Car_ServicesBL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Car_ServiceUI.ViewComponents
{
    public class NavbarViewComponent:ViewComponent
    {
        public IBaseRepository<Navbar> baseRepository;
        public NavbarViewComponent(IBaseRepository<Navbar> _baseRepository)
        {
            baseRepository = _baseRepository;
        }
        public IViewComponentResult Invoke(int id)
        {
            return View(baseRepository.GetAll().OrderByDescending(x => x.NavparId));
        }
    }
}
