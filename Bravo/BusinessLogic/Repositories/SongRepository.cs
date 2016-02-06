using Bravo.BindingModels;
using Bravo.DAL;
using Bravo.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Bravo.BusinessLogic.Repositories {
	public class SongRepository : IDisposable {

		private BravoContext db = new BravoContext();

		public IEnumerable<SongViewModelSummary> GetAll() {
			var entities = db.Songs
				.Include(a => a.Album)
				.ToList();

			return entities.Select(e => new SongViewModelSummary(e)).ToList();
		}

		public SongViewModel GetById(int id) {
			var entity = db.Songs
				.Include(a => a.Album)
				.Include(a => a.Album.Songs)
				.FirstOrDefault(a => a.SongId == id);

			return new SongViewModel(entity);
		}

		public SongViewModel Create(CreateSongBindingModel song) {
			var model = new Models.Song {
				SongName = song.SongName,
				AlbumId = song.AlbumId
			};

			db.Songs.Add(model);
			db.SaveChanges();

			return new SongViewModel(model);
		}

		public void Update(UpdateSongBindingModel song) {
			var entity = db.Songs.FirstOrDefault(a => a.SongId == song.SongId);

			entity.SongName = song.SongName;
			entity.AlbumId = song.AlbumId;

			db.Entry(entity).State = EntityState.Modified;
			db.SaveChanges();
		}

		public void Delete(int id) {
			var entity = db.Songs.FirstOrDefault(a => a.SongId == id);

			db.Songs.Remove(entity);
			db.SaveChanges();
		}

		public bool CheckExists(int id) {
			return db.Songs.Any(e => e.SongId == id);
		}

		public SelectList AlbumsSelectList(int? id) {
			return new SelectList(db.Albums, "AlbumId", "AlbumName", id);
		}

		public void Dispose() {
			db.Dispose();
		}
	}
}