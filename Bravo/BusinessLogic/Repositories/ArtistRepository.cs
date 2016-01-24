using Bravo.DAL;
using Bravo.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Bravo.BusinessLogic.Repositories {
	public class ArtistRepository : IDisposable {

		private readonly BravoContext db = new BravoContext();

		public IEnumerable<ArtistViewModel> GetAll() {
			var entities = db.Artists.ToList();

			return entities.Select( e => new ArtistViewModel(e)).ToList();
		}

		public ArtistViewModel GetById(int id) {
			var entity = db.Artists.FirstOrDefault(e => e.ArtistId == id);

			return new ArtistViewModel(entity);
		}

		public ArtistViewModel Create(Models.Artist artist) {
			db.Artists.Add(artist);
			db.SaveChanges();

			return new ArtistViewModel(artist);
		}

		public void Update(Models.Artist artist) {
			var entity = db.Artists.FirstOrDefault(e => e.ArtistId == artist.ArtistId);

			entity.ArtistId = artist.ArtistId;
			entity.ArtistName = artist.ArtistName;

			db.Entry(entity).State = EntityState.Modified;
			db.SaveChanges();
		}

		public void Delete(int id) {
			var entity = db.Artists.FirstOrDefault(e => e.ArtistId == id);

			db.Artists.Remove(entity);
			db.SaveChanges();
		}

		public bool CheckExists(int id) {
			return db.Artists.Any(e => e.ArtistId == id);
		}

		public void Dispose() {
			db.Dispose();
		}
	}
}