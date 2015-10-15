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
    public class RequestGGsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        UserManager<ApplicationUser> userManager;

        public RequestGGsController()
        {
            userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
        }

        // GET: Admin/RequestGGs
        public async Task<ActionResult> Index()
        {
            var requestGGs = db.RequestGGs.Include(r => r.GroupFrom).Include(r => r.GroupIn).Include(r => r.User);
            return View(await requestGGs.ToListAsync());
        }

        // GET: Admin/RequestGGs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestGG requestGG = await db.RequestGGs.FindAsync(id);
            if (requestGG == null)
            {
                return HttpNotFound();
            }
            return View(requestGG);
        }

        // GET: Admin/RequestGGs/Create
        public ActionResult Create()
        {
            ViewBag.GroupFromId = new SelectList(db.Groups, "Id", "Name");
            ViewBag.GroupInId = new SelectList(db.Groups, "Id", "Name");
            ViewBag.UserId = new SelectList(userManager.Users, "Id", "Email");
            return View();
        }

        // POST: Admin/RequestGGs/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,UserId,GroupFromId,GroupInId,Text,CreateDate,InOut,Status")] RequestGG requestGG)
        {
            if (ModelState.IsValid)
            {
                db.RequestGGs.Add(requestGG);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.GroupFromId = new SelectList(db.Groups, "Id", "Name", requestGG.GroupFromId);
            ViewBag.GroupInId = new SelectList(db.Groups, "Id", "Name", requestGG.GroupInId);
            ViewBag.UserId = new SelectList(userManager.Users, "Id", "Email", requestGG.UserId);
            return View(requestGG);
        }

        // GET: Admin/RequestGGs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestGG requestGG = await db.RequestGGs.FindAsync(id);
            if (requestGG == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupFromId = new SelectList(db.Groups, "Id", "Name", requestGG.GroupFromId);
            ViewBag.GroupInId = new SelectList(db.Groups, "Id", "Name", requestGG.GroupInId);
            ViewBag.UserId = new SelectList(userManager.Users, "Id", "Email", requestGG.UserId);
            return View(requestGG);
        }

        // POST: Admin/RequestGGs/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,UserId,GroupFromId,GroupInId,Text,CreateDate,InOut,Status")] RequestGG requestGG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(requestGG).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.GroupFromId = new SelectList(db.Groups, "Id", "Name", requestGG.GroupFromId);
            ViewBag.GroupInId = new SelectList(db.Groups, "Id", "Name", requestGG.GroupInId);
            ViewBag.UserId = new SelectList(userManager.Users, "Id", "Email", requestGG.UserId);
            return View(requestGG);
        }

        // GET: Admin/RequestGGs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestGG requestGG = await db.RequestGGs.FindAsync(id);
            if (requestGG == null)
            {
                return HttpNotFound();
            }
            return View(requestGG);
        }

        // POST: Admin/RequestGGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            RequestGG requestGG = await db.RequestGGs.FindAsync(id);
            db.RequestGGs.Remove(requestGG);
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
