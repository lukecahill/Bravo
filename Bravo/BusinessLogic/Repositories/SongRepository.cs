using Bravo.DAL;
using Bravo.ViewModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System;

namespace Bravo.BusinessLogic.Repositories {
	public class SongRepository : IDisposable {

		private BravoContext db = new BravoContext();

		public IEnumerable<SongViewModel> GetAll() {
			var entities = db.Songs
				.Include(a => a.Album)
				.ToList();

			return entities.Select(e => new SongViewModel(e)).ToList();
		}

		public SongViewModel GetById(int id) {
			var entity = db.Songs
				.Include(a => a.Album)
				.Where(a => a.SongId == id)
				.FirstOrDefault();

			return new SongViewModel(entity);
		}

		public SongViewModel Create(Models.Song song) {
			db.Songs.Add(song);
			db.SaveChanges();

			return new SongViewModel(song);
		}

		public void Update(Models.Song song) {
			var entity = db.Songs.FirstOrDefault(a => a.SongId == song.SongId);

			entity.SongName = song.SongName;
			entity.SongId = song.SongId;

			db.Entry(entity).State = EntityState.Modified;
			db.SaveChanges();
		}

		public void Delete(int id) {
			var entity = db.Songs.FirstOrDefault(a => a.SongId == id);

			db.Songs.Remove(entity);
			db.SaveChanges();
		}

		public void Dispose() {
			db.Dispose();
		}
	}
}