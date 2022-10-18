using DataAccessLayer.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemoBlog.Controllers
{
    [AllowAnonymous]
    public class DashboardController : Controller
    { 
        public IActionResult Index()
        {
            Context c = new Context();
            var username = User.Identity.Name;
            ViewBag.veri = username;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerid=c.Writers.Where(x=>x.WriterMail==usermail) .Select(y=>y.WriterId).FirstOrDefault();        
            ViewBag.v1= c.Blog.Count().ToString();
            ViewBag.v2=c.Blog.Where(x => x.WriterId == writerid).Count();
            ViewBag.v3=c.Categories.Count();
            return View();
        }
       
    }
}
