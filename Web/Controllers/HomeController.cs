﻿using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Domain.Entities;
using System.Net;
using System.Configuration;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index(int? page)
        {
<<<<<<< HEAD
            var group = dbContext.Groups.FirstOrDefault(x => x.Name == ConfigurationManager.AppSettings["AdminGroupName"]);
            ViewBag.Article = group == null ? null : group.Articles.Where(x => x.Status).Select(x =>
=======
            var group = db.Groups.FirstOrDefault(x => x.Name == "Админы");
            ViewBag.News = group == null ? null : group.GroupNewses.Where(x => x.Status).Select(x =>
>>>>>>> parent of 543bc28... Подправил контроллы для BaseControll
                {
                    return new Article()
                    {
                        Id = x.Id,
                        Title = x.Title,
                        CreateDate = x.CreateDate,
                        CountReader = x.CountReader,
                        Text = x.Text.Length > 200 ? x.Text.Remove(x.Text.LastIndexOf(' ', 200)) + "..." : x.Text
                    };
                }).ToPagedList(page ?? 1, 3);
            return Request.IsAjaxRequest() ? (ActionResult)PartialView("_GroupNewsPartial") : View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ReadNews(int id)
        {
<<<<<<< HEAD
            dbContext.Articles.Find(id).CountReader++;
            dbContext.SaveChanges();
            return View(dbContext.Articles.Find(id));
=======
            db.GroupNewses.Find(id).CountReader++;
            db.SaveChanges();
            return View(db.GroupNewses.Find(id));
>>>>>>> parent of 543bc28... Подправил контроллы для BaseControll
        }

        public ActionResult GroupNewsAjax(List<Article> groupNews)
        {
            return PartialView("_GroupNewsPartial", groupNews);
        }
    }
}