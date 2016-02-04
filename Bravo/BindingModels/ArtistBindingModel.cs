using System.ComponentModel.DataAnnotations;

namespace Bravo.BindingModels {
	public class CreateArtistBindingModel {
		[Required]
		public string ArtistName { get; set; }
	}

	public class DeleteArtistBindingModel {
		[Required]
		public int ArtistId { get; set; }
	}

	public class UpdateArtistBindingModel {
		[Required]
		public int ArtistId { get; set; }

		[Required]
		public string ArtistName { get; set; }
	}
}