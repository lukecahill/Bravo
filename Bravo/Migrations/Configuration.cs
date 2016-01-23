namespace Bravo.Migrations {
	using System.Collections.Generic;
	using System.Data.Entity.Migrations;
	using System.Linq;
	using model = Bravo.Models;

	internal sealed class Configuration : DbMigrationsConfiguration<Bravo.DAL.BravoContext> {
		public Configuration() {
			AutomaticMigrationsEnabled = false;
		}

		protected override void Seed(Bravo.DAL.BravoContext context) {
			context.Albums.AddOrUpdate(GetAlbums.ToArray());
			context.Artists.AddOrUpdate(GetArtists.ToArray());
			context.Genres.AddOrUpdate(GetGenres.ToArray());
			context.Songs.AddOrUpdate(GetSongs.ToArray());
		}

		private IList<model.Album> GetAlbums {
			get {
				return new List<model.Album> {
					new model.Album { AlbumId = 1, AlbumName = "Indestructible", GenreId = 1, ArtistId = 1 },
					new model.Album { AlbumId = 2, AlbumName = "My Beautifiul Dark Twisted Fantasy", GenreId = 2, ArtistId = 2 },
					new model.Album { AlbumId = 3, AlbumName = "Stadium Arcadium", GenreId = 1, ArtistId = 3 }
				};
			}
		}

		private IList<model.Artist> GetArtists {
			get {
				return new List<model.Artist> {
					new model.Artist { ArtistId = 1, ArtistName = "Disturbed" },
					new model.Artist { ArtistId = 2, ArtistName = "Kanye West" },
					new model.Artist { ArtistId = 3, ArtistName = "Red Hot Chili Peppers" }
				};
			}
		}

		private IList<model.Genre> GetGenres {
			get {
				return new List<model.Genre> {
					new model.Genre { GenreId = 1, GenreName = "Rock" },
					new model.Genre { GenreId = 2, GenreName = "Rap" }
				};
			}
		}

		private IList<model.Song> GetSongs {
			get {
				return new List<model.Song> {
					new model.Song { SongId = 1, SongName = "Indestructible", AlbumId = 1 },
					new model.Song { SongId = 2, SongName = "Deveil in a New Dress", AlbumId = 2 },
					new model.Song { SongId = 3, SongName = "Otherside", AlbumId = 3 }
			};
			}
		}
	}
}
