﻿using BusinnesLayer.Concreate;
using BusinnesLayer.ValidationRules;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreDemoBlog.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        Context c = new Context();


        public IActionResult Index()
        {
            var values = bm.GetBlogListWithCategory();
            return View(values);
        }
        //[AllowAnonymous]
        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id;
            var values = bm.GetBlogByID(id);
            return View(values);
        }
        public IActionResult BlogListByWriter()
        {
            
            var usermail = User.Identity.Name;
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterId).FirstOrDefault();

            var values =  bm.GetlistWithCategoryByWriterBm(writerID);
            return View(values); 
        }
        [HttpGet]
        public IActionResult BlogAdd()
        {
           
            List<SelectListItem> categoryvalues = (from x in cm.GetList() select new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.CategoryID.ToString()
            }).ToList();
            ViewBag.cv = categoryvalues;
            return View();
        }


        [HttpPost]
        public IActionResult BlogAdd(Blog p)
        {
            var usermail = User.Identity.Name;
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterId).FirstOrDefault();

            BlogValidator bv = new BlogValidator();
            ValidationResult result = bv.Validate(p);
            if (result.IsValid)
            {
                p.BlogStatus = true;
                p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.WriterId=writerID;
                bm.TAdd(p);
                return RedirectToAction("BlogListByWriter", "Blog");


            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }
        public IActionResult DeleteBlog(int id)
        {
            var blogvalue=bm.TGetById(id);
            bm.TDelete(blogvalue);
            return RedirectToAction("BlogListByWriter");

        }

        
        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var blogvalue = bm.TGetById(id);
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues;
            return View(blogvalue);
         
        }

        [HttpPost]
        public IActionResult EditBlog(Blog p)
        {
            var usermail = User.Identity.Name;
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterId).FirstOrDefault();

            p.WriterId = writerID;
            p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.BlogStatus = true;
            bm.TUpdate(p);
            return RedirectToAction("BlogListByWriter");

        }
    }
}
