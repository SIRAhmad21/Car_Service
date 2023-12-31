﻿using CarServiceBL.IRepository;
using CarServiceBL.Models;
using CarServiceEF.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace CarServiceUI.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        #region Config 
        public IBaseRepository<Comment> comrepo;
        public IHostingEnvironment _hosting;
       
        public CommentController(IBaseRepository<Comment> _comrepo, IHostingEnvironment hosting )
        {
            comrepo = _comrepo;
            _hosting = hosting;
            
        }
        #endregion
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var result = comrepo.GetAll().OrderByDescending(x => x.Commentid);
            return View(result);
        }
        [Authorize(Roles = "User")]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [Authorize(Roles = "User")]
        public IActionResult Create(Comment com)
        {
            if (com.Image != null)
            {
                string ImageFile = Path.Combine(_hosting.WebRootPath, "img");
                string ImgPath = Path.Combine(ImageFile, com.Image.FileName);
                com.Image.CopyTo(new FileStream(ImgPath, FileMode.Create));
                com.ImagePath = com.Image.FileName;
            }
            comrepo.Add(com);
            return RedirectToAction("Index", "Home");
        }
        [Authorize(Roles = "User,Admin")]
        public IActionResult Delete()
        {

            return View();
        }
        [HttpPost]
        [Authorize(Roles = "User,Admin")]
        public IActionResult Delete(int id)
        {
            comrepo.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
