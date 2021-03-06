﻿using Bravo.BindingModels;
using Bravo.DAL;
using Bravo.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Bravo.BusinessLogic.Repositories {
	public class ArtistRepository : IDisposable {

		private readonly BravoContext db = new BravoContext();

		public IEnumerable<ArtistViewModelSummary> GetAll() {
			var entities = db.Artists.ToList();
			return entities.Select(e => new ArtistViewModelSummary(e)).ToList();
		}

		public ArtistViewModel GetById(int id) {
			var entity = db.Artists
				.Include(a => a.Albums)
				.FirstOrDefault(e => e.ArtistId == id);

			return new ArtistViewModel(entity);
		}

		public ArtistViewModel Create(CreateArtistBindingModel artist) {
			var model = new Models.Artist {
				ArtistName = artist.ArtistName
			};
			
			db.Artists.Add(model);
			db.SaveChanges();

			return new ArtistViewModel(model);
		}

		public void Update(UpdateArtistBindingModel artist) {
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

		public SelectList AlbumSelectList(int? id) {
			return new SelectList(db.Albums, "AlbumId", "AlbumName", id);
		}

		public void Dispose() {
			db.Dispose();
		}
	}
}