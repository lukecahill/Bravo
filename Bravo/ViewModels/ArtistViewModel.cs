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

			if(artist.Albums.Any(e => e.ArtistId == this.ArtistId)) {

				var list = new List<AlbumViewModel>();
				var listOfAlbums = artist.Albums.ToList().Where(e => e.ArtistId == this.ArtistId);
				
				foreach (var item in listOfAlbums) {
					var entity = new AlbumViewModel {
						AlbumName = item.AlbumName,
						AlbumId = item.AlbumId,
						GenreId = item.GenreId
					};
					list.Add(entity);
				}
				this.AlbumsList = list;
			}
		}
	}
}