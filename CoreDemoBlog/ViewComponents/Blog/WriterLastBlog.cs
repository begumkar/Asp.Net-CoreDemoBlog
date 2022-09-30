using BusinnesLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemoBlog.ViewComponents.Blog
{
    public class WriterLastBlog : ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());


        public IViewComponentResult Invoke()
        {
            var values = bm.GetBlogListByWriter(1);
            return View(values);
        }
    }
}
