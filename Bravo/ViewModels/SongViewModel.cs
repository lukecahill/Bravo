namespace Bravo.ViewModels {
	public class SongViewModel {
		public int SongId { get; set; }
		public string SongName { get; set; }
		public string AlbumName { get; set; }
		public int AlbumId { get; set; }

		public SongViewModel(Models.Song song) {
			this.SongId = song.SongId;
			this.AlbumName = song.Album.AlbumName;
			this.SongName = song.SongName;
			this.AlbumId = song.AlbumId;
		}

		public SongViewModel() { }
	}

	public class SongViewModelSummary {
		public int SongId { get; set; }
		public string SongName { get; set; }
		public string AlbumName { get; set; }
		public int AlbumId { get; set; }

		public SongViewModelSummary(Models.Song song) {
			this.SongId = song.SongId;
			this.AlbumName = song.Album.AlbumName;
			this.SongName = song.SongName;
			this.AlbumId = song.AlbumId;
		}

		public SongViewModelSummary() { }
	}
}