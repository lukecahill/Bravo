using System.Collections.Generic;
using System.Linq;

namespace Bravo.ViewModels {
	public class ArtistViewModel {
		public int ArtistId { get; set; }
		public string ArtistName { get; set; }

		public IEnumerable<AlbumViewModel> AlbumsList { get; set; }

		public ArtistViewModel(Models.Artist artist) {
			this.ArtistId = artist.ArtistId;
			this.ArtistName = artist.ArtistName;
			this.AlbumsList = artist.Albums.Select(e => new AlbumViewModel(e)).ToList();
		}

		public ArtistViewModel() { }
	}

	public class ArtistViewModelSummary {
		public int ArtistId { get; set; }
		public string ArtistName { get; set; }

		public ArtistViewModelSummary(Models.Artist artist) {
			this.ArtistId = artist.ArtistId;
			this.ArtistName = artist.ArtistName;
		}

		public ArtistViewModelSummary() { }

	}
}