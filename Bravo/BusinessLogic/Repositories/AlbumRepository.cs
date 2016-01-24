using Bravo.DAL;
using Bravo.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Bravo.BusinessLogic.Repositories {
	public class AlbumRepository : IDisposable {

		private readonly BravoContext db = new BravoContext();

		public IEnumerable<AlbumViewModel>GetAll() {
			var entity = db.Albums.ToList();

			return entity.Select(e => new AlbumViewModel(e)).ToList();
		}

		public AlbumViewModel GetById(int id) {
			var entity = db.Albums.FirstOrDefault(e => e.AlbumId == id);

			return new AlbumViewModel(entity);
		}

		public AlbumViewModel Create(Models.Album album) {
			db.Albums.Add(album);
			db.SaveChanges();

			return new AlbumViewModel(album);
		}

		public void Update(Models.Album album) {
			var entity = db.Albums.FirstOrDefault(e => e.AlbumId == album.AlbumId);

			entity.AlbumId = album.AlbumId;
			entity.AlbumName = album.AlbumName;
			entity.ArtistId = album.ArtistId;
			entity.GenreId = album.GenreId;

			db.Entry(entity).State = EntityState.Modified;
			db.SaveChanges();
		}

		public void Delete(int id) {
			var entity = db.Albums.FirstOrDefault(e => e.AlbumId == id);

			db.Albums.Remove(entity);
			db.SaveChanges();
		}

		public bool CheckExists(int id) {
			return db.Albums.Any(e => e.AlbumId == id);
		}

		public void Dispose() {
			db.Dispose();
		}
	}
}