namespace DataBase_Scema_Test_Neo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class topics_questions : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Questions", "Topic_Id", "dbo.Topics");
            DropForeignKey("dbo.SelectedAnswers", "Examination_Id", "dbo.Examinations");
            DropIndex("dbo.Questions", new[] { "Topic_Id" });
            DropIndex("dbo.SelectedAnswers", new[] { "Examination_Id" });
            RenameColumn(table: "dbo.SelectedAnswers", name: "Question_Id", newName: "ExamQuestion_Id");
            RenameIndex(table: "dbo.SelectedAnswers", name: "IX_Question_Id", newName: "IX_ExamQuestion_Id");
            AddColumn("dbo.Topics", "Question_Id", c => c.Int());
            AddColumn("dbo.SelectedAnswers", "Certificate_Id", c => c.Int());
            CreateIndex("dbo.Topics", "Question_Id");
            CreateIndex("dbo.SelectedAnswers", "Certificate_Id");
            AddForeignKey("dbo.Topics", "Question_Id", "dbo.Questions", "Id");
            AddForeignKey("dbo.SelectedAnswers", "Certificate_Id", "dbo.Certificates", "Id");
            DropColumn("dbo.Questions", "Topic_Id");
            DropColumn("dbo.SelectedAnswers", "Examination_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SelectedAnswers", "Examination_Id", c => c.Int());
            AddColumn("dbo.Questions", "Topic_Id", c => c.Int());
            DropForeignKey("dbo.SelectedAnswers", "Certificate_Id", "dbo.Certificates");
            DropForeignKey("dbo.Topics", "Question_Id", "dbo.Questions");
            DropIndex("dbo.SelectedAnswers", new[] { "Certificate_Id" });
            DropIndex("dbo.Topics", new[] { "Question_Id" });
            DropColumn("dbo.SelectedAnswers", "Certificate_Id");
            DropColumn("dbo.Topics", "Question_Id");
            RenameIndex(table: "dbo.SelectedAnswers", name: "IX_ExamQuestion_Id", newName: "IX_Question_Id");
            RenameColumn(table: "dbo.SelectedAnswers", name: "ExamQuestion_Id", newName: "Question_Id");
            CreateIndex("dbo.SelectedAnswers", "Examination_Id");
            CreateIndex("dbo.Questions", "Topic_Id");
            AddForeignKey("dbo.SelectedAnswers", "Examination_Id", "dbo.Examinations", "Id");
            AddForeignKey("dbo.Questions", "Topic_Id", "dbo.Topics", "Id");
        }
    }
}
