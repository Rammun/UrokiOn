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
    public class GroupTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/GroupTypes
        public async Task<ActionResult> Index()
        {
            return View(await db.GroupTypes.ToListAsync());
        }

        // GET: Admin/GroupTypes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupType groupType = await db.GroupTypes.FindAsync(id);
            if (groupType == null)
            {
                return HttpNotFound();
            }
            return View(groupType);
        }

        // GET: Admin/GroupTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/GroupTypes/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Description")] GroupType groupType)
        {
            if (ModelState.IsValid)
            {
                db.GroupTypes.Add(groupType);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(groupType);
        }

        // GET: Admin/GroupTypes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupType groupType = await db.GroupTypes.FindAsync(id);
            if (groupType == null)
            {
                return HttpNotFound();
            }
            return View(groupType);
        }

        // POST: Admin/GroupTypes/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Description")] GroupType groupType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(groupType).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(groupType);
        }

        // GET: Admin/GroupTypes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupType groupType = await db.GroupTypes.FindAsync(id);
            if (groupType == null)
            {
                return HttpNotFound();
            }
            return View(groupType);
        }

        // POST: Admin/GroupTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            GroupType groupType = await db.GroupTypes.FindAsync(id);
            db.GroupTypes.Remove(groupType);
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
