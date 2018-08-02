using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Roomy.Data;
using Roomy.Models;
using Roomy.Areas.Backoffice.Models;
using System.IO;
using Roomy.Filters;

namespace Roomy.Areas.Backoffice.Controllers
{
    [AuthenticationFilter]
    public class RoomsController : Controller
    {
        private RoomyDbContext db = new RoomyDbContext();

        // GET: Backoffice/Rooms
        public async Task<ActionResult> Index()
        {
            var rooms = db.Rooms.Include(r => r.Category).Where(x => ! x.Deleted);
            return View(await rooms.ToListAsync());
        }

        // GET: Backoffice/Rooms/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = await db.Rooms.FindAsync(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // GET: Backoffice/Rooms/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name");
            return View();
        }

        // POST: Backoffice/Rooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Name,Capacity,Price,Description,CategoryID")] Room room)
        {
            if (ModelState.IsValid)
            {
                db.Rooms.Add(room);
                await db.SaveChangesAsync();
                return RedirectToAction("Edit", new { id = room.ID });
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", room.CategoryID);
            return View(room);
        }

        // GET: Backoffice/Rooms/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = await db.Rooms.Include(x => x.RoomFiles).SingleOrDefaultAsync(x => x.ID == id);
                //.FindAsync(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", room.CategoryID);
            return View(room);
        }

        // POST: Backoffice/Rooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name,Capacity,Price,Description,CategoryID")] Room room)
        {
            if (ModelState.IsValid)
            {
                db.Entry(room).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", room.CategoryID);
            return View(room);
        }

        // GET: Backoffice/Rooms/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = await db.Rooms.FindAsync(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // POST: Backoffice/Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Room room = await db.Rooms.FindAsync(id);
            //db.Rooms.Remove(room);
            room.Deleted = true;
            db.Entry(room).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddFile(AddFileViewModel model)
        {
            var roomFile = new RoomFile();
            roomFile.Name = model.FileUpload.FileName;
            roomFile.ContentType = model.FileUpload.ContentType;
            roomFile.RoomID = model.RoomID;

            using (var reader = new BinaryReader(model.FileUpload.InputStream))
            {
                roomFile.Content = reader.ReadBytes(model.FileUpload.ContentLength);
            }

            db.RoomFiles.Add(roomFile);
            await db.SaveChangesAsync();

            return RedirectToAction("Edit", new { id = model.RoomID });
        }

        public async Task<ActionResult> Download(int id)
        {
            var file = await db.RoomFiles.FindAsync(id);

            return File(file.Content, file.ContentType, file.Name);
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
