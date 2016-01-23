using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bravo.Models {
	public class Genre {
		[Required]
		public int GenreId { get; set; }

		[Required, MaxLength(255)]
		public string GenreName { get; set; }

		public virtual ICollection<Album> Album { get; set; }
	}
}