namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into Genres (Id, Name) Values(1, 'Drama')");
            Sql("Insert Into Genres (Id, Name) Values(2, 'Action')");
            Sql("Insert Into Genres (Id, Name) Values(3, 'Comedy')");
            Sql("Insert Into Genres (Id, Name) Values(4, 'Sifi')");
            Sql("Insert Into Genres (Id, Name) Values(5, 'Romance')");
            Sql("Insert Into Genres (Id, Name) Values(6, 'Family')");
        }
        
        public override void Down()
        {
        }
    }
}
