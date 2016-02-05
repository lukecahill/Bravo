using Bravo.BindingModels;
using Bravo.DAL;
using Bravo.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Bravo.BusinessLogic.Repositories {
	public class GenreRepository : IDisposable {

		private readonly BravoContext db = new BravoContext();

		public IEnumerable<GenreViewModelSummary> GetAll() {
			var entities = db.Genres.ToList();

			return entities.Select(e => new GenreViewModelSummary(e)).ToList();
		}

		public GenreViewModel GetById(int id) {
			var entity = db.Genres
				.Include(e => e.Albums)
				.FirstOrDefault(e => e.GenreId == id);

			return new GenreViewModel(entity);
		}

		public GenreViewModel Create(CreateGenreBindingModel genre) {
			var model = new Models.Genre {
				GenreName = genre.GenreName
			};

			db.Genres.Add(model);
			db.SaveChanges();

			return new GenreViewModel(model);
		}

		public void Update(UpdateGenreBindingModel genre) {
			var entity = db.Genres.FirstOrDefault(e => e.GenreId == genre.GenreId);

			entity.GenreId = genre.GenreId;
			genre.GenreName = genre.GenreName;

			db.Entry(entity).State = EntityState.Modified;
			db.SaveChanges();
		}

		public void Delete(int id) {
			var entity = db.Genres.FirstOrDefault(e => e.GenreId == id);

			db.Genres.Remove(entity);
			db.SaveChanges();
		}

		public bool CheckExists(int id) {
			return db.Genres.Any(e => e.GenreId == id);
		}

		public void Dispose() {
			db.Dispose();
		}
	}
}