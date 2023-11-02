using CarServiceBL.IRepository;
using CarServiceBL.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarServiceUI.ViewComponents
{
    public class CommentViewComponent:ViewComponent
    {
        public IBaseRepository<Comment> baseRepository;
        public CommentViewComponent(IBaseRepository<Comment> _baseRepository)
        {
            baseRepository = _baseRepository;
        }
        public IViewComponentResult Invoke()
        {
            return View(baseRepository.GetAll().OrderByDescending(x => x.Commentid));
        }
    }
}
