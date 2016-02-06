using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bravo.Models {
	public class Album {
		[Required]
		public int AlbumId { get; set; }

		[Required, MaxLength(255), Display(Name = "Title")]
		public string AlbumName { get; set; }

		[Required]
		public int GenreId { get; set; }

		[Required]
		public int ArtistId { get; set; }

		public virtual Genre Genre { get; set; }
		public virtual Artist Artist { get; set; }
		public ICollection<Song> Songs { get; set; }
	}
}