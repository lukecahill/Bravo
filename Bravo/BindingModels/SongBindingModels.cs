using System.ComponentModel.DataAnnotations;

namespace Bravo.BindingModels {
	public class CreateSongBindingModel {
		[Required]
		public string SongName { get; set; }

		[Required]
		public int AlbumId { get; set; }
	}

	public class DeleteSongBindingModel {
		[Required]
		public int SongId { get; set; }
	}

	public class UpdateSongBindingModel {
		[Required]
		public int SongId { get; set; }

		[Required]
		public string SongName { get; set; }

		[Required]
		public int AlbumId { get; set; }
	}
}