using System.Collections.Generic;

namespace Bravo.ViewModels {
	public class AlbumViewModel {
		public int AlbumId { get; set; }
		public string AlbumName { get; set; }
		public int GenreId { get; set; }
		public int SongCount { get; set; }

		public virtual ICollection<SongViewModel> Songs { get; set; }

		public AlbumViewModel(Models.Album album) {
			this.AlbumId = album.AlbumId;
			this.AlbumName = album.AlbumName;
			this.GenreId = album.GenreId;
			this.SongCount = album.Songs.Count;
		}

		public AlbumViewModel() { }
	}

	public class AlbumViewModelSummary {
		public int AlbumId { get; set; }
		public string AlbumName { get; set; }
		public int GenreId { get; set; }

		public AlbumViewModelSummary(Models.Album album) {
			this.AlbumId = album.AlbumId;
			this.AlbumName = album.AlbumName;
			this.GenreId = album.GenreId;
		}

		public AlbumViewModelSummary() { }
	}
}