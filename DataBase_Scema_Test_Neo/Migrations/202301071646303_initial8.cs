namespace DataBase_Scema_Test_Neo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial8 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SelectedAnswers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SelectedAnswer = c.String(),
                        Candidate_Id = c.Int(),
                        Examination_Id = c.Int(),
                        Question_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Candidates", t => t.Candidate_Id)
                .ForeignKey("dbo.Examinations", t => t.Examination_Id)
                .ForeignKey("dbo.Questions", t => t.Question_Id)
                .Index(t => t.Candidate_Id)
                .Index(t => t.Examination_Id)
                .Index(t => t.Question_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SelectedAnswers", "Question_Id", "dbo.Questions");
            DropForeignKey("dbo.SelectedAnswers", "Examination_Id", "dbo.Examinations");
            DropForeignKey("dbo.SelectedAnswers", "Candidate_Id", "dbo.Candidates");
            DropIndex("dbo.SelectedAnswers", new[] { "Question_Id" });
            DropIndex("dbo.SelectedAnswers", new[] { "Examination_Id" });
            DropIndex("dbo.SelectedAnswers", new[] { "Candidate_Id" });
            DropTable("dbo.SelectedAnswers");
        }
    }
}
