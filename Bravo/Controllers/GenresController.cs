using Bravo.BindingModels;
using Bravo.BusinessLogic.Repositories;
using System.Web.Mvc;

namespace Bravo.Controllers {
	public class GenresController : Controller {

		private GenreRepository _rep = new GenreRepository();

		// GET: Genres
		public ActionResult Index() {
			return View(_rep.GetAll());
		}

		// GET: Genres/Details/5
		public ActionResult Details(int id) {
			var genre = _rep.GetById(id);

			if (genre == null) {
				return HttpNotFound();
			}
			return View(genre);
		}

		// GET: Genres/Create
		public ActionResult Create() {
			return View();
		}

		// POST: Genres/Create
		[HttpPost, ValidateAntiForgeryToken, Authorize]
		public ActionResult Create([Bind(Include = "GenreId,GenreName")] CreateGenreBindingModel genre) {
			if (ModelState.IsValid) {
				_rep.Create(genre);
				return RedirectToAction("Index");
			}

			return View(genre);
		}

		// GET: Genres/Edit/5
		public ActionResult Edit(int id) {
			var genre = _rep.GetById(id);

			if (genre == null) {
				return HttpNotFound();
			}
			return View(genre);
		}

		// POST: Genres/Edit/5
		[HttpPost, ValidateAntiForgeryToken, Authorize]
		public ActionResult Edit([Bind(Include = "GenreId,GenreName")] UpdateGenreBindingModel genre) {
			if (ModelState.IsValid) {
				_rep.Update(genre);
				return RedirectToAction("Index");
			}
			return View(genre);
		}

		// GET: Genres/Delete/5
		public ActionResult Delete(int id) {
			var genre = _rep.GetById(id);
			if (genre == null) {
				return HttpNotFound();
			}
			return View(genre);
		}

		// POST: Genres/Delete/5
		[HttpPost, ActionName("Delete"), ValidateAntiForgeryToken, Authorize]
		public ActionResult DeleteConfirmed(int id) {
			var genre = _rep.GetById(id);
			return RedirectToAction("Index");
		}
	}
}
