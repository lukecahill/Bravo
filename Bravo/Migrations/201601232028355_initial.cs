namespace Bravo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        AlbumId = c.Int(nullable: false, identity: true),
                        AlbumName = c.String(nullable: false, maxLength: 255),
                        GenreId = c.Int(nullable: false),
                        ArtistId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AlbumId)
                .ForeignKey("dbo.Artists", t => t.ArtistId, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.GenreId)
                .Index(t => t.ArtistId);
            
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        SongId = c.Int(nullable: false, identity: true),
                        SongName = c.String(nullable: false, maxLength: 255),
                        AlbumId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SongId)
                .ForeignKey("dbo.Albums", t => t.AlbumId, cascadeDelete: true)
                .Index(t => t.AlbumId);
            
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        ArtistId = c.Int(nullable: false, identity: true),
                        ArtistName = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.ArtistId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreId = c.Int(nullable: false, identity: true),
                        GenreName = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.GenreId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Albums", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Albums", "ArtistId", "dbo.Artists");
            DropForeignKey("dbo.Songs", "AlbumId", "dbo.Albums");
            DropIndex("dbo.Songs", new[] { "AlbumId" });
            DropIndex("dbo.Albums", new[] { "ArtistId" });
            DropIndex("dbo.Albums", new[] { "GenreId" });
            DropTable("dbo.Genres");
            DropTable("dbo.Artists");
            DropTable("dbo.Songs");
            DropTable("dbo.Albums");
        }
    }
}
