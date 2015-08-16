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
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Web.Areas.Admin.Controllers
{
    public class RequestGUsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        UserManager<ApplicationUser> userManager;

        public RequestGUsController()
        {
            userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
        }

        // GET: Admin/RequestGUs
        public async Task<ActionResult> Index()
        {
            var requestGUs = db.RequestGUs.Include(r => r.Group).Include(r => r.User).Include(r => r.UserRequest);
            return View(await requestGUs.ToListAsync());
        }

        // GET: Admin/RequestGUs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestGU requestGU = await db.RequestGUs.FindAsync(id);
            if (requestGU == null)
            {
                return HttpNotFound();
            }
            return View(requestGU);
        }

        // GET: Admin/RequestGUs/Create
        public ActionResult Create()
        {
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name");
            ViewBag.UserId = new SelectList(userManager.Users, "Id", "Email");
            ViewBag.UserRequestId = new SelectList(userManager.Users, "Id", "Email");
            return View();
        }

        // POST: Admin/RequestGUs/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,UserId,GroupId,UserRequestId,Text,CreatDate,InOut,Status")] RequestGU requestGU)
        {
            if (ModelState.IsValid)
            {
                db.RequestGUs.Add(requestGU);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name", requestGU.GroupId);
            ViewBag.UserId = new SelectList(userManager.Users, "Id", "Email", requestGU.UserId);
            ViewBag.UserRequestId = new SelectList(userManager.Users, "Id", "Email", requestGU.UserRequestId);
            return View(requestGU);
        }

        // GET: Admin/RequestGUs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestGU requestGU = await db.RequestGUs.FindAsync(id);
            if (requestGU == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name", requestGU.GroupId);
            ViewBag.UserId = new SelectList(userManager.Users, "Id", "Email", requestGU.UserId);
            ViewBag.UserRequestId = new SelectList(userManager.Users, "Id", "Email", requestGU.UserRequestId);
            return View(requestGU);
        }

        // POST: Admin/RequestGUs/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,UserId,GroupId,UserRequestId,Text,CreatDate,InOut,Status")] RequestGU requestGU)
        {
            if (ModelState.IsValid)
            {
                db.Entry(requestGU).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name", requestGU.GroupId);
            ViewBag.UserId = new SelectList(userManager.Users, "Id", "Email", requestGU.UserId);
            ViewBag.UserRequestId = new SelectList(userManager.Users, "Id", "Email", requestGU.UserRequestId);
            return View(requestGU);
        }

        // GET: Admin/RequestGUs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestGU requestGU = await db.RequestGUs.FindAsync(id);
            if (requestGU == null)
            {
                return HttpNotFound();
            }
            return View(requestGU);
        }

        // POST: Admin/RequestGUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            RequestGU requestGU = await db.RequestGUs.FindAsync(id);
            db.RequestGUs.Remove(requestGU);
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
