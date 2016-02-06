using System.Collections.Generic;

namespace Bravo.ViewModels {
	public class AlbumViewModel {
		public int AlbumId { get; set; }
		public string AlbumName { get; set; }
		public int GenreId { get; set; }
		public int ArtistId { get; set; }
		public string ArtistName { get; set; }

		public virtual ICollection<SongViewModel> SongList { get; set; }

		public AlbumViewModel(Models.Album album) {
			this.AlbumId = album.AlbumId;
			this.AlbumName = album.AlbumName;
			this.GenreId = album.GenreId;
			this.ArtistId = album.ArtistId;
			this.ArtistName = album.Artist.ArtistName;
		}

		public AlbumViewModel() { }
	}

	public class AlbumViewModelSummary {
		public int AlbumId { get; set; }
		public string AlbumName { get; set; }
		public int GenreId { get; set; }
		public string ArtistName { get; set; }

		public AlbumViewModelSummary(Models.Album album) {
			this.AlbumId = album.AlbumId;
			this.AlbumName = album.AlbumName;
			this.GenreId = album.GenreId;
			this.ArtistName = album.Artist.ArtistName;
		}

		public AlbumViewModelSummary() { }
	}
}