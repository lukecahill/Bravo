﻿using Bravo.DAL;
using Bravo.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

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

		public void Dispose() {
			db.Dispose();
		}
	}
}