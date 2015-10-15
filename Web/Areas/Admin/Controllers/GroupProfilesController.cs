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

namespace Web.Areas.Admin.Controllers
{
    public class GroupProfilesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/GroupProfiles
        public async Task<ActionResult> Index()
        {
            var groupProfiles = db.GroupProfiles.Include(g => g.City).Include(g => g.Country).Include(g => g.Group).Include(g => g.Region);
            return View(await groupProfiles.ToListAsync());
        }

        // GET: Admin/GroupProfiles/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupProfile groupProfile = await db.GroupProfiles.FindAsync(id);
            if (groupProfile == null)
            {
                return HttpNotFound();
            }
            return View(groupProfile);
        }

        // GET: Admin/GroupProfiles/Create
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name");
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name");
            ViewBag.Id = new SelectList(db.Groups, "Id", "Name");
            ViewBag.RegionId = new SelectList(db.Regions, "Id", "Name");
            return View();
        }

        // POST: Admin/GroupProfiles/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,GroupId,Name,Description,CountryId,RegionId,CityId")] GroupProfile groupProfile)
        {
            if (ModelState.IsValid)
            {
                db.GroupProfiles.Add(groupProfile);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", groupProfile.CityId);
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name", groupProfile.CountryId);
            ViewBag.Id = new SelectList(db.Groups, "Id", "Name", groupProfile.Id);
            ViewBag.RegionId = new SelectList(db.Regions, "Id", "Name", groupProfile.RegionId);
            return View(groupProfile);
        }

        // GET: Admin/GroupProfiles/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupProfile groupProfile = await db.GroupProfiles.FindAsync(id);
            if (groupProfile == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", groupProfile.CityId);
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name", groupProfile.CountryId);
            ViewBag.Id = new SelectList(db.Groups, "Id", "Name", groupProfile.Id);
            ViewBag.RegionId = new SelectList(db.Regions, "Id", "Name", groupProfile.RegionId);
            return View(groupProfile);
        }

        // POST: Admin/GroupProfiles/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,GroupId,Name,Description,CountryId,RegionId,CityId")] GroupProfile groupProfile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(groupProfile).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", groupProfile.CityId);
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name", groupProfile.CountryId);
            ViewBag.Id = new SelectList(db.Groups, "Id", "Name", groupProfile.Id);
            ViewBag.RegionId = new SelectList(db.Regions, "Id", "Name", groupProfile.RegionId);
            return View(groupProfile);
        }

        // GET: Admin/GroupProfiles/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupProfile groupProfile = await db.GroupProfiles.FindAsync(id);
            if (groupProfile == null)
            {
                return HttpNotFound();
            }
            return View(groupProfile);
        }

        // POST: Admin/GroupProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            GroupProfile groupProfile = await db.GroupProfiles.FindAsync(id);
            db.GroupProfiles.Remove(groupProfile);
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
