namespace LoveExam.Model.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using LoveExam.Model.Entity;
public partial class ExamContext : DbContext
    {
        public ExamContext()
            : base("name=ExamContext")
        {
        }

        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<User> T_User { get; set; }
        public virtual DbSet<Attachment> Attachment { get; set; }
        public virtual DbSet<Choice> Choice { get; set; }
        public virtual DbSet<QueAnswer> QueAnswer{ get; set; }
        public virtual DbSet<Judge> Judge { get; set; }
        public virtual DbSet<MoreChoice> MoreChoice { get; set; }
        public virtual DbSet<Topic> Topic { get; set; }
        public virtual DbSet<Exam> Exam { get; set; }
        public virtual DbSet<Test> Test { get; set; }
        public virtual DbSet<StuTest> StuTest { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Class>()
                .Property(e => e.SchName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Gender)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.SchName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.EMail)
                .IsUnicode(false);
        }
    }
}
