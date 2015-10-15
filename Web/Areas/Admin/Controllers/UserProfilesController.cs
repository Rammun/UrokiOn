using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using DAL.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Web.Areas.Admin.Controllers
{
    public class UserProfilesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        UserManager<ApplicationUser> userManager;

        public UserProfilesController()
        {
            userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
        }

        // GET: Admin/UserProfiles
        public async Task<ActionResult> Index()
        {
            var userProfiles = db.UserProfiles.Include(u => u.City).Include(u => u.Country).Include(u => u.Region).Include(u => u.User).Include(u => u.WallOfUser);
            return View(await userProfiles.ToListAsync());
        }

        // GET: Admin/UserProfiles/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProfile userProfile = await db.UserProfiles.FindAsync(id);
            if (userProfile == null)
            {
                return HttpNotFound();
            }
            return View(userProfile);
        }

        // GET: Admin/UserProfiles/Create
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name");
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name");
            ViewBag.RegionId = new SelectList(db.Regions, "Id", "Name");
            ViewBag.Id = new SelectList(userManager.Users, "Id", "Email");
            ViewBag.WallOfUserId = new SelectList(db.WallOfUsers, "Id", "Text");
            return View();
        }

        // POST: Admin/UserProfiles/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Surname,MiddleName,CityId,RegionId,CountryId,WallOfUserId")] UserProfile userProfile)
        {
            if (ModelState.IsValid)
            {
                db.UserProfiles.Add(userProfile);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", userProfile.CityId);
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name", userProfile.CountryId);
            ViewBag.RegionId = new SelectList(db.Regions, "Id", "Name", userProfile.RegionId);
            ViewBag.Id = new SelectList(userManager.Users, "Id", "Email", userProfile.Id);
            ViewBag.WallOfUserId = new SelectList(db.WallOfUsers, "Id", "Text", userProfile.WallOfUserId);
            return View(userProfile);
        }

        // GET: Admin/UserProfiles/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProfile userProfile = await db.UserProfiles.FindAsync(id);
            if (userProfile == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", userProfile.CityId);
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name", userProfile.CountryId);
            ViewBag.RegionId = new SelectList(db.Regions, "Id", "Name", userProfile.RegionId);
            ViewBag.Id = new SelectList(userManager.Users, "Id", "Email", userProfile.Id);
            ViewBag.WallOfUserId = new SelectList(db.WallOfUsers, "Id", "Text", userProfile.WallOfUserId);
            return View(userProfile);
        }

        // POST: Admin/UserProfiles/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Surname,MiddleName,CityId,RegionId,CountryId,WallOfUserId")] UserProfile userProfile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userProfile).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", userProfile.CityId);
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name", userProfile.CountryId);
            ViewBag.RegionId = new SelectList(db.Regions, "Id", "Name", userProfile.RegionId);
            ViewBag.Id = new SelectList(userManager.Users, "Id", "Email", userProfile.Id);
            ViewBag.WallOfUserId = new SelectList(db.WallOfUsers, "Id", "Text", userProfile.WallOfUserId);
            return View(userProfile);
        }

        // GET: Admin/UserProfiles/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProfile userProfile = await db.UserProfiles.FindAsync(id);
            if (userProfile == null)
            {
                return HttpNotFound();
            }
            return View(userProfile);
        }

        // POST: Admin/UserProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            UserProfile userProfile = await db.UserProfiles.FindAsync(id);
            db.UserProfiles.Remove(userProfile);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
