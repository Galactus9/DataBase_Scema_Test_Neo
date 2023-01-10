namespace DataBase_Scema_Test_Neo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fddgd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.QuestionTopics", "Question_Id", "dbo.Questions");
            DropForeignKey("dbo.QuestionTopics", "Topic_Id", "dbo.Topics");
            DropIndex("dbo.QuestionTopics", new[] { "Question_Id" });
            DropIndex("dbo.QuestionTopics", new[] { "Topic_Id" });
            AddColumn("dbo.Questions", "Topic_Id", c => c.Int());
            CreateIndex("dbo.Questions", "Topic_Id");
            AddForeignKey("dbo.Questions", "Topic_Id", "dbo.Topics", "Id");
            DropTable("dbo.QuestionTopics");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.QuestionTopics",
                c => new
                    {
                        Question_Id = c.Int(nullable: false),
                        Topic_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Question_Id, t.Topic_Id });
            
            DropForeignKey("dbo.Questions", "Topic_Id", "dbo.Topics");
            DropIndex("dbo.Questions", new[] { "Topic_Id" });
            DropColumn("dbo.Questions", "Topic_Id");
            CreateIndex("dbo.QuestionTopics", "Topic_Id");
            CreateIndex("dbo.QuestionTopics", "Question_Id");
            AddForeignKey("dbo.QuestionTopics", "Topic_Id", "dbo.Topics", "Id", cascadeDelete: true);
            AddForeignKey("dbo.QuestionTopics", "Question_Id", "dbo.Questions", "Id", cascadeDelete: true);
        }
    }
}
