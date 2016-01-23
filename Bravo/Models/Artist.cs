using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bravo.Models {
	public class Artist {
		[Required]
		public int ArtistId { get; set; }

		[Required, MaxLength(255)]
		public string ArtistName { get; set; }

		public virtual ICollection<Album> Albums { get; set; }
	}
}