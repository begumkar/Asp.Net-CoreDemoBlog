


using Microsoft.AspNetCore.Mvc;

namespace CoreDemoBlog.ViewComponents
{
    public class CommentList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
  
}
