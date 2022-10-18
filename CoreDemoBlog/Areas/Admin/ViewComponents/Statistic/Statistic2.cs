using DataAccessLayer.Concreate;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemoBlog.Areas.Admin.Views.Shared.Components.Statistic1
{
    public class Statistic2 : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = c.Blog.OrderByDescending(x => x.BlogID).Select(x => x.BlogTitle).Take(2).FirstOrDefault();
            ViewBag.v3 = c.Comments.Count();
            return View();
        }
    }
}
