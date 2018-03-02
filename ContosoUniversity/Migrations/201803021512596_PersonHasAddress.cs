namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonHasAddress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Person", "Address_Email", c => c.String(maxLength: 128));
            CreateIndex("dbo.Person", "Address_Email");
            AddForeignKey("dbo.Person", "Address_Email", "dbo.Address", "Email");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Person", "Address_Email", "dbo.Address");
            DropIndex("dbo.Person", new[] { "Address_Email" });
            DropColumn("dbo.Person", "Address_Email");
        }
    }
}
