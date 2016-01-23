using System.ComponentModel.DataAnnotations;

namespace Bravo.Models {
	public class Song {
		[Required]
		public int SongId { get; set; }

		[Required, MaxLength(255)]
		public string SongName { get; set; }

		[Required]
		public int AlbumId { get; set; }

		public virtual Album Album { get; set; }
	}
}