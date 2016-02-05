using System.ComponentModel.DataAnnotations;

namespace Bravo.BindingModels {
	public class CreateAlbumBindingModel {
		[Required]
		public string AlbumName { get; set; }

		[Required]
		public int GenreId { get; set; }

		[Required]
		public int ArtistId { get; set; }
	}

	public class DeleteAlbumBindingModel {
		[Required]
		public int AlbumId { get; set; }
	}

	public class UpdateAlbumBindingModel {
		[Required]
		public int AlbumId { get; set; }

		[Required]
		public string AlbumName { get; set; }

		[Required]
		public int GenreId { get; set; }

		[Required]
		public int ArtistId { get; set; }
	}
}