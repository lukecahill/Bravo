namespace Bravo.ViewModels {
	public class ArtistViewModel {
		public int ArtistId { get; set; }
		public string ArtistName { get; set; }

		public ArtistViewModel(Models.Artist artist) {
			this.ArtistId = artist.ArtistId;
			this.ArtistName = artist.ArtistName;
		}
	}
}