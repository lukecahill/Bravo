using System.Data.Entity;
using System.Diagnostics;
using model = Bravo.Models;

namespace Bravo.DAL {
	public class BravoContext : DbContext {
		public BravoContext() : base("name=BravoContext") {
			Database.SetInitializer<BravoContext>(null);
			Configuration.LazyLoadingEnabled = false;

			this.Database.Log = s => Debug.WriteLine(s);
		}

		public DbSet<model.Album> Albums { get; set; }
		public DbSet<model.Artist> Artists { get; set; }
		public DbSet<model.Genre> Genres { get; set; }
		public DbSet<model.Song> Songs { get; set; }
	}
}