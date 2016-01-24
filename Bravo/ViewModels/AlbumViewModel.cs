namespace Bravo.ViewModels {
	public class AlbumViewModel {
		public int AlbumId { get; set; }
		public string AlbumName { get; set; }
		public int GenreId { get; set; }

		public AlbumViewModel(Models.Album album) {
			this.AlbumId = album.AlbumId;
			this.AlbumName = album.AlbumName;
			this.GenreId = album.GenreId;
		}

		public AlbumViewModel() { }
	}
}