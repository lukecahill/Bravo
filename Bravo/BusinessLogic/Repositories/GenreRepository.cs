using Bravo.DAL;
using Bravo.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Bravo.BusinessLogic.Repositories {
	public class GenreRepository : IDisposable {

		private readonly BravoContext db = new BravoContext();

		public IEnumerable<GenreViewModel> GetAll() {
			var entities = db.Genres.ToList();

			return entities.Select(e => new GenreViewModel(e)).ToList();
		}

		public GenreViewModel GetById(int id) {
			var entity = db.Genres.FirstOrDefault(e => e.GenreId == id);

			return new GenreViewModel(entity);
		}

		public GenreViewModel Create(Models.Genre genre) {
			db.Genres.Add(genre);
			db.SaveChanges();

			return new GenreViewModel(genre);
		}

		public void Update(Models.Genre genre) {
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

		public void Dispose() {
			db.Dispose();
		}
	}
}