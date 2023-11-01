using CarServiceBL.IRepository;
using CarServiceBL.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarServiceUI.Areas.Administrator.ViewComponents
{
    public class BookingViewComponent:ViewComponent
    {
        public IBaseRepository<Booking> baseRepository;
        public BookingViewComponent(IBaseRepository<Booking> _baseRepository)
        {
            baseRepository = _baseRepository;
        }
        public IViewComponentResult Invoke()
        {
            return View(baseRepository.GetAll());
        }
    }
}
