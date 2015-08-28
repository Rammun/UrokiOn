﻿using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Domain.Entities;
using System.Net;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index(int? page)
        {
            var group = db.Groups.FirstOrDefault(x => x.Name == "Админы");
            ViewBag.News = group == null ? null : group.GroupNewses.Where(x => x.Status).Select(x =>
            {
                return new GroupNewse()
                {
                    Title = x.Title,
                    CreateDate = x.CreateDate,
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

        public ActionResult GroupNewsAjax(List<GroupNewse> groupNews)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}

            return PartialView("_GroupNewsPartial", groupNews);
        }
    }
}