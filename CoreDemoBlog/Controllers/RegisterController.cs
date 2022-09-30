using BusinnesLayer.Concreate;
using BusinnesLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemoBlog.Controllers
{
    public class RegisterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Writer p)
        {
            WriterValidator wv = new WriterValidator();
           
            p.WriterStatus = true;
            p.WriterAbout = "Deneme Test";
            wm.WriterAdd(p);
            return RedirectToAction("Index","Blog");
        }
    }
}
