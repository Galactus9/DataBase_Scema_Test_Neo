namespace DataBase_Scema_Test_Neo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial6 : DbMigration
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
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TextOfQuestion = c.String(),
                        possibleAnswers_Id = c.Int(),
                        Topic_Id = c.Int(),
                        Examination_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PossibleAnswers", t => t.possibleAnswers_Id)
                .ForeignKey("dbo.Topics", t => t.Topic_Id)
                .ForeignKey("dbo.Examinations", t => t.Examination_Id)
                .Index(t => t.possibleAnswers_Id)
                .Index(t => t.Topic_Id)
                .Index(t => t.Examination_Id);
            
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
            
            CreateTable(
                "dbo.Examinations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MaxScore = c.Int(nullable: false),
                        Candidate_Id = c.Int(),
                        Certificate_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Candidates", t => t.Candidate_Id)
                .ForeignKey("dbo.Certificates", t => t.Certificate_Id)
                .Index(t => t.Candidate_Id)
                .Index(t => t.Certificate_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "Examination_Id", "dbo.Examinations");
            DropForeignKey("dbo.Examinations", "Certificate_Id", "dbo.Certificates");
            DropForeignKey("dbo.Examinations", "Candidate_Id", "dbo.Candidates");
            DropForeignKey("dbo.Topics", "Certificate_Id", "dbo.Certificates");
            DropForeignKey("dbo.Questions", "Topic_Id", "dbo.Topics");
            DropForeignKey("dbo.Questions", "possibleAnswers_Id", "dbo.PossibleAnswers");
            DropIndex("dbo.Examinations", new[] { "Certificate_Id" });
            DropIndex("dbo.Examinations", new[] { "Candidate_Id" });
            DropIndex("dbo.Questions", new[] { "Examination_Id" });
            DropIndex("dbo.Questions", new[] { "Topic_Id" });
            DropIndex("dbo.Questions", new[] { "possibleAnswers_Id" });
            DropIndex("dbo.Topics", new[] { "Certificate_Id" });
            DropTable("dbo.Examinations");
            DropTable("dbo.PossibleAnswers");
            DropTable("dbo.Questions");
            DropTable("dbo.Topics");
            DropTable("dbo.Certificates");
            DropTable("dbo.Candidates");
        }
    }
}
