namespace Student.DAL.Migrations.ContextB
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Student : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Evaluations",
                c => new
                    {
                        EvaluationId = c.Int(nullable: false, identity: true),
                        ExamId = c.Int(nullable: false),
                        UserId = c.String(),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EvaluationId)
                .ForeignKey("dbo.Exams", t => t.ExamId, cascadeDelete: true)
                .Index(t => t.ExamId);
            
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        ExamId = c.Int(nullable: false, identity: true),
                        GroupId = c.Int(nullable: false),
                        LessonId = c.Int(nullable: false),
                        ExamDate = c.DateTime(nullable: false),
                        Duration = c.Int(nullable: false),
                        FullMark = c.Int(nullable: false),
                        Created = c.DateTime(),
                        Exam_ExamId = c.Int(),
                    })
                .PrimaryKey(t => t.ExamId)
                .ForeignKey("dbo.Exams", t => t.Exam_ExamId)
                .ForeignKey("dbo.Lessons", t => t.LessonId, cascadeDelete: true)
                .ForeignKey("dbo.StudentGroup", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.GroupId)
                .Index(t => t.LessonId)
                .Index(t => t.Exam_ExamId);
            
            CreateTable(
                "dbo.Lessons",
                c => new
                    {
                        LessonId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Lesson_LessonId = c.Int(),
                    })
                .PrimaryKey(t => t.LessonId)
                .ForeignKey("dbo.Lessons", t => t.Lesson_LessonId)
                .Index(t => t.Lesson_LessonId);
            
            CreateTable(
                "dbo.StudentGroup",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GroupLessons",
                c => new
                    {
                        GroupLessonId = c.Int(nullable: false, identity: true),
                        GroupId = c.Int(nullable: false),
                        LessonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GroupLessonId)
                .ForeignKey("dbo.Lessons", t => t.LessonId, cascadeDelete: true)
                .ForeignKey("dbo.StudentGroup", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.GroupId)
                .Index(t => t.LessonId);
            
            CreateTable(
                "dbo.ExamResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.String(maxLength: 128),
                        QuestionId = c.Int(nullable: false),
                        StudentAnswer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QuestionBanks", t => t.QuestionId, cascadeDelete: true)
                .ForeignKey("dbo.Student", t => t.StudentId)
                .Index(t => t.StudentId)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.QuestionBanks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExamId = c.Int(nullable: false),
                        Mark = c.Int(nullable: false),
                        Question = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exams", t => t.ExamId, cascadeDelete: true)
                .Index(t => t.ExamId);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Options",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuestionId = c.Int(nullable: false),
                        Answer = c.String(),
                        Correct_Answer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QuestionBanks", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Options", "QuestionId", "dbo.QuestionBanks");
            DropForeignKey("dbo.ExamResults", "StudentId", "dbo.Student");
            DropForeignKey("dbo.ExamResults", "QuestionId", "dbo.QuestionBanks");
            DropForeignKey("dbo.QuestionBanks", "ExamId", "dbo.Exams");
            DropForeignKey("dbo.Evaluations", "ExamId", "dbo.Exams");
            DropForeignKey("dbo.Exams", "GroupId", "dbo.StudentGroup");
            DropForeignKey("dbo.GroupLessons", "GroupId", "dbo.StudentGroup");
            DropForeignKey("dbo.GroupLessons", "LessonId", "dbo.Lessons");
            DropForeignKey("dbo.Exams", "LessonId", "dbo.Lessons");
            DropForeignKey("dbo.Lessons", "Lesson_LessonId", "dbo.Lessons");
            DropForeignKey("dbo.Exams", "Exam_ExamId", "dbo.Exams");
            DropIndex("dbo.Options", new[] { "QuestionId" });
            DropIndex("dbo.QuestionBanks", new[] { "ExamId" });
            DropIndex("dbo.ExamResults", new[] { "QuestionId" });
            DropIndex("dbo.ExamResults", new[] { "StudentId" });
            DropIndex("dbo.GroupLessons", new[] { "LessonId" });
            DropIndex("dbo.GroupLessons", new[] { "GroupId" });
            DropIndex("dbo.Lessons", new[] { "Lesson_LessonId" });
            DropIndex("dbo.Exams", new[] { "Exam_ExamId" });
            DropIndex("dbo.Exams", new[] { "LessonId" });
            DropIndex("dbo.Exams", new[] { "GroupId" });
            DropIndex("dbo.Evaluations", new[] { "ExamId" });
            DropTable("dbo.Options");
            DropTable("dbo.Student");
            DropTable("dbo.QuestionBanks");
            DropTable("dbo.ExamResults");
            DropTable("dbo.GroupLessons");
            DropTable("dbo.StudentGroup");
            DropTable("dbo.Lessons");
            DropTable("dbo.Exams");
            DropTable("dbo.Evaluations");
        }
    }
}
