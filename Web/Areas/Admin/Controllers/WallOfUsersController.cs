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
    public class WallOfUsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/WallOfUsers
        public async Task<ActionResult> Index()
        {
            return View(await db.WallOfUsers.ToListAsync());
        }

        // GET: Admin/WallOfUsers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WallOfUser wallOfUser = await db.WallOfUsers.FindAsync(id);
            if (wallOfUser == null)
            {
                return HttpNotFound();
            }
            return View(wallOfUser);
        }

        // GET: Admin/WallOfUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/WallOfUsers/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,UserId,Text,CreateDate,Status")] WallOfUser wallOfUser)
        {
            if (ModelState.IsValid)
            {
                db.WallOfUsers.Add(wallOfUser);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(wallOfUser);
        }

        // GET: Admin/WallOfUsers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WallOfUser wallOfUser = await db.WallOfUsers.FindAsync(id);
            if (wallOfUser == null)
            {
                return HttpNotFound();
            }
            return View(wallOfUser);
        }

        // POST: Admin/WallOfUsers/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,UserId,Text,CreateDate,Status")] WallOfUser wallOfUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wallOfUser).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(wallOfUser);
        }

        // GET: Admin/WallOfUsers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WallOfUser wallOfUser = await db.WallOfUsers.FindAsync(id);
            if (wallOfUser == null)
            {
                return HttpNotFound();
            }
            return View(wallOfUser);
        }

        // POST: Admin/WallOfUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            WallOfUser wallOfUser = await db.WallOfUsers.FindAsync(id);
            db.WallOfUsers.Remove(wallOfUser);
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
