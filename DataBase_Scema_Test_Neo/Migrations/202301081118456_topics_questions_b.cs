namespace DataBase_Scema_Test_Neo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class topics_questions_b : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Topics", "Question_Id", "dbo.Questions");
            DropIndex("dbo.Topics", new[] { "Question_Id" });
            CreateTable(
                "dbo.QuestionTopics",
                c => new
                    {
                        Question_Id = c.Int(nullable: false),
                        Topic_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Question_Id, t.Topic_Id })
                .ForeignKey("dbo.Questions", t => t.Question_Id, cascadeDelete: true)
                .ForeignKey("dbo.Topics", t => t.Topic_Id, cascadeDelete: true)
                .Index(t => t.Question_Id)
                .Index(t => t.Topic_Id);
            
            DropColumn("dbo.Topics", "Question_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Topics", "Question_Id", c => c.Int());
            DropForeignKey("dbo.QuestionTopics", "Topic_Id", "dbo.Topics");
            DropForeignKey("dbo.QuestionTopics", "Question_Id", "dbo.Questions");
            DropIndex("dbo.QuestionTopics", new[] { "Topic_Id" });
            DropIndex("dbo.QuestionTopics", new[] { "Question_Id" });
            DropTable("dbo.QuestionTopics");
            CreateIndex("dbo.Topics", "Question_Id");
            AddForeignKey("dbo.Topics", "Question_Id", "dbo.Questions", "Id");
        }
    }
}
