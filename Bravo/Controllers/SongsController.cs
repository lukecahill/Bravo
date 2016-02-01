using Bravo.Models;
using Bravo.BusinessLogic.Repositories;
using System.Web.Mvc;

namespace Bravo.Controllers {
	public class SongsController : Controller {

		private SongRepository _rep = null;

		public SongsController() {
			_rep = new SongRepository();
		}

		// GET: Songs
		public ActionResult Index() {
			return View(_rep.GetAll());
		}

		// GET: Songs/Details/5
		public ActionResult Details(int id) {
			var song = _rep.GetById(id);
			if (song == null) {
				return HttpNotFound();
			}
			return View(song);
		}

		// GET: Songs/Create
		public ActionResult Create() {
			ViewBag.AlbumId = _rep.AlbumsSelectList(null);
			return View();
		}

		// POST: Songs/Create
		[HttpPost, ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "SongId,SongName,AlbumId")] Song song) {
			if (ModelState.IsValid) {
				_rep.Create(song);
				return RedirectToAction("Index");
			}

			ViewBag.AlbumId = _rep.AlbumsSelectList(song.SongId);
			return View(song);
		}

		// GET: Songs/Edit/5
		public ActionResult Edit(int id) {
			var check = _rep.CheckExists(id);
			if (!check) {
				return HttpNotFound();
			}

			var song = _rep.GetById(id);

			ViewBag.AlbumId = _rep.AlbumsSelectList(song.AlbumId);
			return View(song);
		}

		// POST: Songs/Edit/5
		[HttpPost, ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "SongId,SongName,AlbumId")] Song song) {
			if (ModelState.IsValid) {
				_rep.Update(song);
				return RedirectToAction("Index");
			}
			ViewBag.AlbumId = _rep.AlbumsSelectList(song.AlbumId);
			return View(song);
		}

		// GET: Songs/Delete/5
		public ActionResult Delete(int id) {

			var check = _rep.CheckExists(id);
			if (!check) {
				return HttpNotFound();
			}

			var song = _rep.GetById(id);
			return View(song);
		}

		// POST: Songs/Delete/5
		[HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id) {
			_rep.Delete(id);
			return RedirectToAction("Index");
		}
	}
}
