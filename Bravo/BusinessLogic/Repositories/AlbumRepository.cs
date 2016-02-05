using Bravo.BindingModels;
using Bravo.DAL;
using Bravo.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Bravo.BusinessLogic.Repositories {
	public class AlbumRepository : IDisposable {

		private readonly BravoContext db = new BravoContext();

		public IEnumerable<AlbumViewModelSummary>GetAll() {
			var entity = db.Albums.ToList();

			return entity.Select(e => new AlbumViewModelSummary(e)).ToList();
		}

		public AlbumViewModel GetById(int id) {
			var entity = db.Albums
				.Include(a => a.Songs)
				.FirstOrDefault(e => e.AlbumId == id);

			return new AlbumViewModel(entity);
		}

		public AlbumViewModel Create(CreateAlbumBindingModel album) {
			var model = new Models.Album {
				AlbumName = album.AlbumName,
				GenreId = album.GenreId,
				ArtistId = album.ArtistId
			};

			db.Albums.Add(model);
			db.SaveChanges();

			return new AlbumViewModel(model);
		}

		public void Update(UpdateAlbumBindingModel album) {
			var entity = db.Albums.FirstOrDefault(e => e.AlbumId == album.AlbumId);
			
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

		public SelectList ArtistSelectList(int? id) {
			return new SelectList(db.Artists, "ArtistId", "ArtistName", id);
		}

		public SelectList GenreSelectList(int? id) {
			return new SelectList(db.Genres, "GenreId", "ArtistId", id);
		}

		public void Dispose() {
			db.Dispose();
		}
	}
}