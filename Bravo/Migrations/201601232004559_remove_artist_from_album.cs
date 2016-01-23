namespace Bravo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remove_artist_from_album : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Albums", "ArtistId", "dbo.Artists");
            DropIndex("dbo.Albums", new[] { "ArtistId" });
            RenameColumn(table: "dbo.Albums", name: "ArtistId", newName: "Artist_ArtistId");
            AlterColumn("dbo.Albums", "Artist_ArtistId", c => c.Int());
            CreateIndex("dbo.Albums", "Artist_ArtistId");
            AddForeignKey("dbo.Albums", "Artist_ArtistId", "dbo.Artists", "ArtistId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Albums", "Artist_ArtistId", "dbo.Artists");
            DropIndex("dbo.Albums", new[] { "Artist_ArtistId" });
            AlterColumn("dbo.Albums", "Artist_ArtistId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Albums", name: "Artist_ArtistId", newName: "ArtistId");
            CreateIndex("dbo.Albums", "ArtistId");
            AddForeignKey("dbo.Albums", "ArtistId", "dbo.Artists", "ArtistId", cascadeDelete: true);
        }
    }
}
