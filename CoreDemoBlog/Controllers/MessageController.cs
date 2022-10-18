using BusinnesLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CoreDemoBlog.Controllers
{
    [AllowAnonymous]
    public class MessageController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        Message2Manager mm = new Message2Manager(new EfMessage2Repository());
     
        public IActionResult Inbox()
        {
           int id = 2;
            var values = mm.GetInboxListByWriter(id);
            return View(values);    
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult MessageDetails(int id)
        {
            var value = mm.TGetById(id);
          
            return View(value);

        }
        [HttpPost]
        public IActionResult EditBlog(Blog p)
        {
            p.WriterId = 1;
            p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.BlogStatus = true;
            bm.TUpdate(p);
            return RedirectToAction("BlogListByWriter");

        }
    }
}
