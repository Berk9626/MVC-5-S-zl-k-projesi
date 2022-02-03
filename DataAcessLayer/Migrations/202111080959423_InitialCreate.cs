namespace DataAcessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "WriterPassword", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Writers", "WriterPassword");
        }
    }
}
