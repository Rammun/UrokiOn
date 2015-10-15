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
    public class GroupsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Groups
        public async Task<ActionResult> Index()
        {
            var groups = db.Groups.Include(g => g.GroupProfile).Include(g => g.GroupType).Include(g => g.ParentGroup);
            return View(await groups.ToListAsync());
        }

        // GET: Admin/Groups/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = await db.Groups.FindAsync(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // GET: Admin/Groups/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.GroupProfiles, "Id", "Name");
            ViewBag.GroupTypeId = new SelectList(db.GroupTypes, "Id", "Name");
            ViewBag.ParentGroupId = new SelectList(db.Groups, "Id", "Name");
            return View();
        }

        // POST: Admin/Groups/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,ParentGroupId,GroupProfileId,GroupTypeId,AdministratorId")] Group group)
        {
            if (ModelState.IsValid)
            {
                db.Groups.Add(group);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.GroupProfiles, "Id", "Name", group.Id);
            ViewBag.GroupTypeId = new SelectList(db.GroupTypes, "Id", "Name", group.GroupTypeId);
            ViewBag.ParentGroupId = new SelectList(db.Groups, "Id", "Name", group.ParentGroupId);
            return View(group);
        }

        // GET: Admin/Groups/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = await db.Groups.FindAsync(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.GroupProfiles, "Id", "Name", group.Id);
            ViewBag.GroupTypeId = new SelectList(db.GroupTypes, "Id", "Name", group.GroupTypeId);
            ViewBag.ParentGroupId = new SelectList(db.Groups, "Id", "Name", group.ParentGroupId);
            return View(group);
        }

        // POST: Admin/Groups/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,ParentGroupId,GroupProfileId,GroupTypeId,AdministratorId")] Group group)
        {
            if (ModelState.IsValid)
            {
                db.Entry(group).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.GroupProfiles, "Id", "Name", group.Id);
            ViewBag.GroupTypeId = new SelectList(db.GroupTypes, "Id", "Name", group.GroupTypeId);
            ViewBag.ParentGroupId = new SelectList(db.Groups, "Id", "Name", group.ParentGroupId);
            return View(group);
        }

        // GET: Admin/Groups/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = await db.Groups.FindAsync(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // POST: Admin/Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Group group = await db.Groups.FindAsync(id);
            db.Groups.Remove(group);
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
