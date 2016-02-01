using System.Collections.Generic;
using System.Linq;

namespace Bravo.ViewModels {
	public class GenreViewModel {
		public int GenreId { get; set; }
		public string GenreName { get; set; }

		public virtual ICollection<AlbumViewModel> AlbumList { get; set; }

		public GenreViewModel(Models.Genre genre) {
			this.GenreId = genre.GenreId;
			this.GenreName = genre.GenreName;
			this.AlbumList = genre.Albums.Select(e => new AlbumViewModel(e)).ToList();
		}

		public GenreViewModel() { }
	}

	public class GenreViewModelSummary {
		public int GenreId { get; set; }
		public string GenreName { get; set; }

		public GenreViewModelSummary(Models.Genre genre) {
			this.GenreId = genre.GenreId;
			this.GenreName = genre.GenreName;
		}

		public GenreViewModelSummary() { }
	}
}