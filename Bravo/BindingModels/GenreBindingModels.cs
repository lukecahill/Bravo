using System.ComponentModel.DataAnnotations;

namespace Bravo.BindingModels {
	public class CreateGenreBindingModel {
		[Required]
		public string GenreName { get; set; }
	}

	public class DeleteGenreBindingModel {
		[Required]
		public int GenreId { get; set; }
	}

	public class UpdateGenreBindingModel {
		[Required]
		public int GenreId { get; set; }

		[Required]
		public string GenreName { get; set; }
	}
}