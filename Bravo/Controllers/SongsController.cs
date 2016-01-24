using Bravo.DAL;
using Bravo.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using Bravo.BusinessLogic.Repositories;
using System.Web.Mvc;

namespace Bravo.Controllers {
	public class SongsController : Controller {

		// TODO: Change this later
		private BravoContext db = new BravoContext();
		private SongRepository _rep = new SongRepository();

		// For non-DI
		public SongsController() { }

		// For DI
		public SongsController(SongRepository song) {
			_rep = song;
		}

		// GET: Songs
		public ActionResult Index() {
			var songs = _rep.GetAll();
			return View(songs.ToArray());
		}

		// GET: Songs/Details/5
		public ActionResult Details(int id) {
			//if (id == null) {
			//	return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			//}
			var song = _rep.GetById(id);
			if (song == null) {
				return HttpNotFound();
			}
			return View(song);
		}

		// GET: Songs/Create
		public ActionResult Create() {
			ViewBag.AlbumId = new SelectList(db.Albums, "AlbumId", "AlbumName");
			return View();
		}

		// POST: Songs/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "SongId,SongName,AlbumId")] Song song) {
			if (ModelState.IsValid) {
				_rep.Create(song);
				return RedirectToAction("Index");
			}

			ViewBag.AlbumId = new SelectList(db.Albums, "AlbumId", "AlbumName", song.AlbumId);
			return View(song);
		}

		// GET: Songs/Edit/5
		public ActionResult Edit(int? id) {
			if (id == null) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Song song = db.Songs.Find(id);
			if (song == null) {
				return HttpNotFound();
			}
			ViewBag.AlbumId = new SelectList(db.Albums, "AlbumId", "AlbumName", song.AlbumId);
			return View(song);
		}

		// POST: Songs/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "SongId,SongName,AlbumId")] Song song) {
			if (ModelState.IsValid) {
				db.Entry(song).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewBag.AlbumId = new SelectList(db.Albums, "AlbumId", "AlbumName", song.AlbumId);
			return View(song);
		}

		// GET: Songs/Delete/5
		public ActionResult Delete(int id) {
			//if (id == null) {
			//	return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			//}

			var song = _rep.CheckExists(id);
			if (!song) {
				return HttpNotFound();
			}
			return View(song);
		}

		// POST: Songs/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id) {
			_rep.Delete(id);
			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing) {
			if (disposing) {
				db.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
