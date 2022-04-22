using Student.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DAL.EF
{
    //public class StoreDBInitializer : DropCreateDatabaseAlways<EFDbContext>
    //{
    //    protected override void Seed(EFDbContext context)
    //    {
    //        IList<StudentGroup> defaultCategory = new List<StudentGroup>();
    //        defaultCategory.Add(new StudentGroup() { Id = 1, Name = "MT440" });

    //        foreach (var category in defaultCategory)
    //            context.StudentGroups.Add(category);



    //        base.Seed(context);
    //    }
    //}
    public class EFDbContext : DbContext
    {
        public EFDbContext() :
            base("DefaultConnection1")
        { }
        public EFDbContext(string conectionString) : base(conectionString)
        {
            //Database.SetInitializer(new StoreDBInitializer());
        }

        public DbSet<StudentGroup> StudentGroups { get; set; }

        public DbSet<Lesson> Lessons { get; set; }

        public DbSet<GroupLesson> GroupLessons { get; set; }

        public DbSet<Exam> Exams { get; set; }

       // public DbSet<Exams> Exam { get; set; }

        public DbSet<Evaluation> Evaluations { get; set; }




    }
}
