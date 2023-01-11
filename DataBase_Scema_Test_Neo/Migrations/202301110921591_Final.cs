namespace DataBase_Scema_Test_Neo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Final : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Candidates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        MidleName = c.String(),
                        Gender = c.String(),
                        NativeLanguage = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        PhotoIdType = c.String(),
                        PhotoIdNumber = c.String(),
                        PhotoIdIssueDate = c.DateTime(nullable: false),
                        Email = c.String(),
                        Address = c.String(),
                        AddressLine2 = c.String(),
                        City = c.String(),
                        Region = c.String(),
                        PostalCode = c.Int(),
                        Country = c.String(),
                        LandlineNumber = c.String(),
                        MobileNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Examinations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SelectedAnswer = c.Int(nullable: false),
                        Candidate_Id = c.Int(),
                        Certificate_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Candidates", t => t.Candidate_Id)
                .ForeignKey("dbo.Certificates", t => t.Certificate_Id)
                .Index(t => t.Candidate_Id)
                .Index(t => t.Certificate_Id);
            
            CreateTable(
                "dbo.Certificates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        SubjectWeight = c.Int(nullable: false),
                        Certificate_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Certificates", t => t.Certificate_Id)
                .Index(t => t.Certificate_Id);
            
            CreateTable(
                "dbo.PullOfQuestionPerTopics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TextOfQuestion = c.String(),
                        possibleAnswers_Id = c.Int(),
                        Topic_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PossibleAnswers", t => t.possibleAnswers_Id)
                .ForeignKey("dbo.Topics", t => t.Topic_Id)
                .Index(t => t.possibleAnswers_Id)
                .Index(t => t.Topic_Id);
            
            CreateTable(
                "dbo.ExamQuestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        examination_Id = c.Int(),
                        PullOfQuestionPerTopic_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Examinations", t => t.examination_Id)
                .ForeignKey("dbo.PullOfQuestionPerTopics", t => t.PullOfQuestionPerTopic_Id)
                .Index(t => t.examination_Id)
                .Index(t => t.PullOfQuestionPerTopic_Id);
            
            CreateTable(
                "dbo.PossibleAnswers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CorectAnswer = c.String(),
                        OtherAnswer1 = c.String(),
                        OtherAnswer2 = c.String(),
                        OtherAnswer3 = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Topics", "Certificate_Id", "dbo.Certificates");
            DropForeignKey("dbo.PullOfQuestionPerTopics", "Topic_Id", "dbo.Topics");
            DropForeignKey("dbo.PullOfQuestionPerTopics", "possibleAnswers_Id", "dbo.PossibleAnswers");
            DropForeignKey("dbo.ExamQuestions", "PullOfQuestionPerTopic_Id", "dbo.PullOfQuestionPerTopics");
            DropForeignKey("dbo.ExamQuestions", "examination_Id", "dbo.Examinations");
            DropForeignKey("dbo.Examinations", "Certificate_Id", "dbo.Certificates");
            DropForeignKey("dbo.Examinations", "Candidate_Id", "dbo.Candidates");
            DropIndex("dbo.ExamQuestions", new[] { "PullOfQuestionPerTopic_Id" });
            DropIndex("dbo.ExamQuestions", new[] { "examination_Id" });
            DropIndex("dbo.PullOfQuestionPerTopics", new[] { "Topic_Id" });
            DropIndex("dbo.PullOfQuestionPerTopics", new[] { "possibleAnswers_Id" });
            DropIndex("dbo.Topics", new[] { "Certificate_Id" });
            DropIndex("dbo.Examinations", new[] { "Certificate_Id" });
            DropIndex("dbo.Examinations", new[] { "Candidate_Id" });
            DropTable("dbo.PossibleAnswers");
            DropTable("dbo.ExamQuestions");
            DropTable("dbo.PullOfQuestionPerTopics");
            DropTable("dbo.Topics");
            DropTable("dbo.Certificates");
            DropTable("dbo.Examinations");
            DropTable("dbo.Candidates");
        }
    }
}
