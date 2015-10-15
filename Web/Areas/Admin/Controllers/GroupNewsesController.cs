using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domain;
using Domain.Entities;

namespace Web.Areas.Admin.Controllers
{
    public class GroupNewsesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/GroupNewses
        public async Task<ActionResult> Index()
        {
            var groupNewses = db.GroupNewses.Include(g => g.Group);
            return View(await groupNewses.ToListAsync());
        }

        // GET: Admin/GroupNewses/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupNewse groupNewse = await db.GroupNewses.FindAsync(id);
            if (groupNewse == null)
            {
                return HttpNotFound();
            }
            return View(groupNewse);
        }

        // GET: Admin/GroupNewses/Create
        public ActionResult Create()
        {
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name");
            return View();
        }

        // POST: Admin/GroupNewses/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,GroupId,Title,Text,CreateDate,Status")] GroupNewse groupNewse)
        {
            if (ModelState.IsValid)
            {
                db.GroupNewses.Add(groupNewse);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name", groupNewse.GroupId);
            return View(groupNewse);
        }

        // GET: Admin/GroupNewses/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupNewse groupNewse = await db.GroupNewses.FindAsync(id);
            if (groupNewse == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name", groupNewse.GroupId);
            return View(groupNewse);
        }

        // POST: Admin/GroupNewses/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,GroupId,Title,Text,CreateDate,Status")] GroupNewse groupNewse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(groupNewse).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name", groupNewse.GroupId);
            return View(groupNewse);
        }

        // GET: Admin/GroupNewses/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupNewse groupNewse = await db.GroupNewses.FindAsync(id);
            if (groupNewse == null)
            {
                return HttpNotFound();
            }
            return View(groupNewse);
        }

        // POST: Admin/GroupNewses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            GroupNewse groupNewse = await db.GroupNewses.FindAsync(id);
            db.GroupNewses.Remove(groupNewse);
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
