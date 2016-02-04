using System.ComponentModel.DataAnnotations;

namespace Bravo.BindingModels {
	public class CreateSongBindingModel {
		[Required]
		public string SongName { get; set; }

		[Required]
		public int AlbumnId { get; set; }
	}

	public class DeleteSongBindingModel {
		[Required]
		public int SongId { get; set; }
	}

	public class UpdateSongBindingModel {
		[Required]
		public string SongName { get; set; }

		[Required]
		public int AlbumId { get; set; }
	}
}