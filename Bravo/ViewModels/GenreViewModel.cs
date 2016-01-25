namespace Bravo.ViewModels {
	public class GenreViewModel {
		public int LabelId { get; set; }
		public string LabelName { get; set; }

		public GenreViewModel(Models.Genre genre) {
			this.LabelId = genre.GenreId;
			this.LabelName = genre.GenreName;
		}

		public GenreViewModel() { }
	}

	public class GenreViewModelSummary {
		public int LabelId { get; set; }
		public string LabelName { get; set; }

		public GenreViewModelSummary(Models.Genre genre) {
			this.LabelId = genre.GenreId;
			this.LabelName = genre.GenreName;
		}

		public GenreViewModelSummary() { }
	}
}