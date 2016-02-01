using Bravo.DAL;
using Bravo.Models;
using Bravo.BusinessLogic.Repositories;
using System.Web.Mvc;

namespace Bravo.Controllers {
	public class AlbumsController : Controller {
		private BravoContext db = new BravoContext();
		private AlbumRepository _rep = new AlbumRepository();

		// GET: Albums
		public ActionResult Index() {
			return View(_rep.GetAll());
		}

		// GET: Albums/Details/5
		public ActionResult Details(int id) {
			var album = _rep.GetById(id);
			if (album == null) {
				return HttpNotFound();
			}
			return View(album);
		}

		// GET: Albums/Create
		public ActionResult Create() {
			ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "GenreName");
			return View();
		}

		// POST: Albums/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "AlbumId,AlbumName,GenreId")] Album album) {
			if (ModelState.IsValid) {
				_rep.Create(album);
				return RedirectToAction("Index");
			}

			ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "GenreName", album.GenreId);
			return View(album);
		}

		// GET: Albums/Edit/5
		public ActionResult Edit(int id) {
			var check = _rep.CheckExists(id);
			if (!check) {
				return HttpNotFound();
			}

			var album = _rep.GetById(id);
			ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "GenreName", album.AlbumId);
			return View(album);
		}

		// POST: Albums/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "AlbumId,AlbumName,GenreId")] Album album) {
			if (ModelState.IsValid) {
				_rep.Update(album);
				return RedirectToAction("Index");
			}
			ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "GenreName", album.GenreId);
			return View(album);
		}

		// GET: Albums/Delete/5
		public ActionResult Delete(int id) {
			var album = _rep.CheckExists(id);
			if (!album) {
				return HttpNotFound();
			}
			return View(album);
		}

		// POST: Albums/Delete/5
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
