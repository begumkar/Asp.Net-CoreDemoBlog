using CoreDemoBlog.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CoreDemoBlog.ViewComponents
{
    public class CommentList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var commentvalues = new List<UserComment>
            {
                new UserComment
                {
                    ID = 1,
                    Username = "Begüm"
                },
                new UserComment
                {
                    ID = 2,
                    Username ="Mesut"
                }

            };
            return View(commentvalues);
        }
    }
}
