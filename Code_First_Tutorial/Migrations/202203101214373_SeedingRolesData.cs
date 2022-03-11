namespace Code_First_Tutorial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedingRolesData : DbMigration
    {
        public override void Up()
        {
            //Cannot insert explicit value for Id
            Sql("INSERT INTO Roles(Title) VALUES('Administrator')");
            Sql("INSERT INTO Roles(Title) VALUES('Power User')");
            Sql("INSERT INTO Roles(Title) VALUES('User')");
            Sql("INSERT INTO Roles(Title) VALUES('Client')");
        }
        
        public override void Down()
        {
        }
    }
}
