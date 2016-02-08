using Bravo.BindingModels;
using Bravo.BusinessLogic.Repositories;
using System.Web.Mvc;

namespace Bravo.Controllers {
	public class AlbumsController : Controller {
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
			ViewBag.GenreId = _rep.GenreSelectList(null);
			ViewBag.ArtistId = _rep.ArtistSelectList(null);
			return View();
		}

		// POST: Albums/Create
		[HttpPost, ValidateAntiForgeryToken, Authorize]
		public ActionResult Create([Bind(Include = "AlbumId,AlbumName,GenreId,ArtistId")] CreateAlbumBindingModel album) {
			if (ModelState.IsValid) {

				_rep.Create(album);
				return RedirectToAction("Index");
			}

			ViewBag.GenreId = _rep.GenreSelectList(album.GenreId);
			ViewBag.ArtistId = _rep.ArtistSelectList(album.ArtistId);
			return View(album);
		}

		// GET: Albums/Edit/5
		public ActionResult Edit(int id) {
			var check = _rep.CheckExists(id);
			if (!check) {
				return HttpNotFound();
			}

			var album = _rep.GetById(id);
			ViewBag.GenreId = _rep.GenreSelectList(album.GenreId);
			ViewBag.ArtistId = _rep.ArtistSelectList(album.ArtistId);
			return View(album);
		}

		// POST: Albums/Edit/5
		[HttpPost, ValidateAntiForgeryToken, Authorize]
		public ActionResult Edit([Bind(Include = "AlbumId,AlbumName,GenreId,ArtistId")] UpdateAlbumBindingModel album) {
			if (ModelState.IsValid) {
				_rep.Update(album);
				return RedirectToAction("Index");
			}

			ViewBag.GenreId = _rep.GenreSelectList(album.GenreId);
			ViewBag.ArtistId = _rep.ArtistSelectList(album.ArtistId);
			return View(album);
		}

		// GET: Albums/Delete/5
		public ActionResult Delete(int id) {
			var check = _rep.CheckExists(id);
			if (!check) {
				return HttpNotFound();
			}

			var album = _rep.GetById(id);
			return View(album);
		}

		// POST: Albums/Delete/5
		[HttpPost, ActionName("Delete"), ValidateAntiForgeryToken, Authorize]
		public ActionResult DeleteConfirmed(int id) {
			_rep.Delete(id);
			return RedirectToAction("Index");
		}
	}
}
