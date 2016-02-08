using Bravo.BindingModels;
using Bravo.BusinessLogic.Repositories;
using System.Web.Mvc;

namespace Bravo.Controllers {
	public class ArtistsController : Controller {
		
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
		[HttpPost, ValidateAntiForgeryToken, Authorize]
		public ActionResult Create([Bind(Include = "ArtistId,ArtistName")] CreateArtistBindingModel artist) {
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
		[HttpPost, ValidateAntiForgeryToken, Authorize]
		public ActionResult Edit([Bind(Include = "ArtistId,ArtistName")] UpdateArtistBindingModel artist) {
			if (ModelState.IsValid) {
				_rep.Update(artist);
				return RedirectToAction("Index");
			}
			return View(artist);
		}

		// GET: Artists/Delete/5
		public ActionResult Delete(int id) {
			var check = _rep.CheckExists(id);

			if (!check) {
				return HttpNotFound();
			}

			var artist = _rep.GetById(id);
			return View(artist);
		}

		// POST: Artists/Delete/5
		[HttpPost, ActionName("Delete"), ValidateAntiForgeryToken, Authorize]
		public ActionResult DeleteConfirmed(int id) {
			_rep.Delete(id);
			return RedirectToAction("Index");
		}
	}
}
