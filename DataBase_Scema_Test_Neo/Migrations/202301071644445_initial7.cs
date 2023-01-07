namespace DataBase_Scema_Test_Neo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial7 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Examinations", "MaxScore");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Examinations", "MaxScore", c => c.Int(nullable: false));
        }
    }
}
