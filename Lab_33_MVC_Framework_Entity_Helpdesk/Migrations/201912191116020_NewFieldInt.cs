namespace Lab_33_MVC_Framework_Entity_Helpdesk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewFieldInt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "NewFieldInt", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "NewFieldInt");
        }
    }
}
