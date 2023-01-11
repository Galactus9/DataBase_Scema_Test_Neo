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
                        ExamQuestions_Id = c.Int(),
                        Candidate_Id = c.Int(),
                        Certificate_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExamQuestions", t => t.ExamQuestions_Id)
                .ForeignKey("dbo.Candidates", t => t.Candidate_Id)
                .ForeignKey("dbo.Certificates", t => t.Certificate_Id)
                .Index(t => t.ExamQuestions_Id)
                .Index(t => t.Candidate_Id)
                .Index(t => t.Certificate_Id);
            
            CreateTable(
                "dbo.ExamQuestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PullOfQuestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TextOfQuestion = c.String(),
                        possibleAnswers_Id = c.Int(),
                        ExamQuestions_Id = c.Int(),
                        Topic_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PossibleAnswers", t => t.possibleAnswers_Id)
                .ForeignKey("dbo.ExamQuestions", t => t.ExamQuestions_Id)
                .ForeignKey("dbo.Topics", t => t.Topic_Id)
                .Index(t => t.possibleAnswers_Id)
                .Index(t => t.ExamQuestions_Id)
                .Index(t => t.Topic_Id);
            
            CreateTable(
                "dbo.PossibleAnswers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Answer1 = c.String(),
                        Answer2 = c.String(),
                        Answer3 = c.String(),
                        Answer4 = c.String(),
                        Index = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Topics", "Certificate_Id", "dbo.Certificates");
            DropForeignKey("dbo.PullOfQuestions", "Topic_Id", "dbo.Topics");
            DropForeignKey("dbo.Examinations", "Certificate_Id", "dbo.Certificates");
            DropForeignKey("dbo.Examinations", "Candidate_Id", "dbo.Candidates");
            DropForeignKey("dbo.Examinations", "ExamQuestions_Id", "dbo.ExamQuestions");
            DropForeignKey("dbo.PullOfQuestions", "ExamQuestions_Id", "dbo.ExamQuestions");
            DropForeignKey("dbo.PullOfQuestions", "possibleAnswers_Id", "dbo.PossibleAnswers");
            DropIndex("dbo.Topics", new[] { "Certificate_Id" });
            DropIndex("dbo.PullOfQuestions", new[] { "Topic_Id" });
            DropIndex("dbo.PullOfQuestions", new[] { "ExamQuestions_Id" });
            DropIndex("dbo.PullOfQuestions", new[] { "possibleAnswers_Id" });
            DropIndex("dbo.Examinations", new[] { "Certificate_Id" });
            DropIndex("dbo.Examinations", new[] { "Candidate_Id" });
            DropIndex("dbo.Examinations", new[] { "ExamQuestions_Id" });
            DropTable("dbo.Topics");
            DropTable("dbo.Certificates");
            DropTable("dbo.PossibleAnswers");
            DropTable("dbo.PullOfQuestions");
            DropTable("dbo.ExamQuestions");
            DropTable("dbo.Examinations");
            DropTable("dbo.Candidates");
        }
    }
}
