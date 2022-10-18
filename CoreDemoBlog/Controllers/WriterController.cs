using BusinnesLayer.Concreate;
using BusinnesLayer.ValidationRules;
using CoreDemoBlog.Models;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemoBlog.Controllers
{
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        private readonly UserManager<AppUser> _userManager;

        public WriterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [Authorize]
        public IActionResult Index()
        {
            var usermail = User.Identity.Name;
            ViewBag.v=usermail;
            return View();
        }
        public IActionResult WriterProfile()
        {
            return View();
        }
        public IActionResult WriterMail()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult WriterNavbarPartial() 
        {
            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }
  
        [HttpGet]
        public async Task<IActionResult> WriterEditProfile()
        {
             Context c = new Context();
            var username = User.Identity.Name;
              
             var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            UserManager userManager = new UserManager(new EfUserRepository());
            //    var writervalues = wm.TGetById(writerID);
            //    return View(writervalues);  

            //var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var id=c.Users.Where(x=>x.Email == usermail).Select(y=>y.Id).FirstOrDefault();
            var values = userManager.TGetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult WriterEditProfile(AppUser p) 
        {
        
                UserManager userManager = new UserManager(new EfUserRepository());
                userManager.TUpdate(p);
                return RedirectToAction("Index", "Dashboard");
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage p)
        {
            Writer w= new Writer();
            if(p.WriterImage !=null)
            {
                var extension=Path.GetExtension(p.WriterImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location=Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newimagename);
                var stream= new FileStream(location,FileMode.Create);   
                p.WriterImage.CopyTo(stream);
                w.WriterImage = newimagename;
            }
            w.WriterMail = p.WriterMail;
            w.WriterPassword = p.WriterPassword;
            w.WriterName = p.WriterName;
            w.WriterStatus = true;
            w.WriterAbout = p.WriterAbout;
            wm.TAdd(w);
            return RedirectToAction("Index","Dashboard");
        }


    }
}
