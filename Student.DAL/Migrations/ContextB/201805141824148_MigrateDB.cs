namespace Student.DAL.Migrations.ContextB
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB : DbMigration
    {
        public override void Up()
        {
           // Down();
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
                })
                .PrimaryKey(t => t.ExamId)
                .ForeignKey("dbo.Lessons", t => t.LessonId, cascadeDelete: true)
                .ForeignKey("dbo.StudentGroup", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.GroupId)
                .Index(t => t.LessonId);

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

        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.Evaluations", "ExamId", "dbo.Exams");
            //DropForeignKey("dbo.Exams", "GroupId", "dbo.StudentGroup");
            //DropForeignKey("dbo.GroupLessons", "GroupId", "dbo.StudentGroup");
            //DropForeignKey("dbo.GroupLessons", "LessonId", "dbo.Lessons");
            //DropForeignKey("dbo.Exams", "LessonId", "dbo.Lessons");
            //DropForeignKey("dbo.Lessons", "Lesson_LessonId", "dbo.Lessons");
            //DropIndex("dbo.GroupLessons", new[] { "LessonId" });
            //DropIndex("dbo.GroupLessons", new[] { "GroupId" });
            //DropIndex("dbo.Lessons", new[] { "Lesson_LessonId" });
            //DropIndex("dbo.Exams", new[] { "LessonId" });
            //DropIndex("dbo.Exams", new[] { "GroupId" });
            //DropIndex("dbo.Evaluations", new[] { "ExamId" });
            //DropTable("dbo.GroupLessons");
            //DropTable("dbo.StudentGroup");
            //DropTable("dbo.Lessons");
            //DropTable("dbo.Exams");
            DropTable("dbo.Evaluations");
        }
    }
}
