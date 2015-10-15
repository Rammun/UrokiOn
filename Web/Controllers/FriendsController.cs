using Domain;
using Domain.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace Web.Controllers
{
    public class FriendsController : BaseController
    {
        UserManager<ApplicationUser> userManager;

        public FriendsController()
        {
            userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(dbContext));
        }

        public ActionResult Index(int? page)
        {
            IEnumerable<UserProfile> friends = null;
            bool flag = false;

            try
            {
                friends = userManager.FindByName(User.Identity.Name).UserProfile.FriendUsers.Select(x => x.UserProfile);
            }
            catch (NullReferenceException)
            {
                flag = true;
            }
            ViewBag.Friends = flag ? null : friends.ToPagedList(page ?? 1, 3);
            return Request.IsAjaxRequest() ? (ActionResult)PartialView("_FriendsPartial") : View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && userManager != null)
            {
                userManager.Dispose();
                userManager = null;
            }

            base.Dispose(disposing);
        }
    }
}