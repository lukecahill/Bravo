using Bravo.DAL;
using Bravo.Models;
using Bravo.BusinessLogic.Repositories;
using System.Web.Mvc;

namespace Bravo.Controllers {
	public class ArtistsController : Controller {

		private BravoContext _db = new BravoContext();
		private ArtistRepository _rep = new ArtistRepository();

		// GET: Artists
		public ActionResult Index() {
			return View(_rep.GetAll());
		}

		// GET: Artists/Details/5
		public ActionResult Details(int id) {
			var artist = _rep.GetById(id);

			if (artist == null) {
				return HttpNotFound();
			}
			return View(artist);
		}

		// GET: Artists/Create
		public ActionResult Create() {
			return View();
		}

		// POST: Artists/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "ArtistId,ArtistName,AlbumId")] Artist artist) {
			if (ModelState.IsValid) {
				_rep.Create(artist);
				return RedirectToAction("Index");
			}

			return View(artist);
		}

		// GET: Artists/Edit/5
		public ActionResult Edit(int id) {

			var artist = _rep.GetById(id);
			if (artist == null) {
				return HttpNotFound();
			}
			return View(artist);
		}

		// POST: Artists/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "ArtistId,ArtistName,AlbumId")] Artist artist) {
			if (ModelState.IsValid) {
				_rep.Update(artist);
				return RedirectToAction("Index");
			}
			return View(artist);
		}

		// GET: Artists/Delete/5
		public ActionResult Delete(int id) {
			var artist = _rep.CheckExists(id);

			if (!artist) {
				return HttpNotFound();
			}
			return View(artist);
		}

		// POST: Artists/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id) {
			_rep.Delete(id);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing) {
			if (disposing) {
				_db.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
