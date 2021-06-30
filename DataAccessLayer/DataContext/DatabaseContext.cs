using System;
using DataAccessLayer.Entity;
using Microsoft.EntityFrameworkCore;


namespace DataAccessLayer.DataContext
{
    public class DatabaseContext : DbContext
    {
        public class OptionsBuild
    {
      
            public OptionsBuild()
            {

                Settings = new AppConfiguration();

                OptionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();

                OptionsBuilder.UseSqlServer(Settings.SqlConnectionString);
                DatabaseOptions = OptionsBuilder.Options;
            }
            public DbContextOptionsBuilder<DatabaseContext> OptionsBuilder { get; set; }
            public DbContextOptions<DatabaseContext> DatabaseOptions { get; set; }
            private AppConfiguration Settings { get; set; }
        }

        public static OptionsBuild Options = new OptionsBuild();


        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DbSet<Student> Students { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student_subject> Student_Subjects { get; set; }
        public DbSet<Teacher_subject> Teacher_Subjects { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Assessment> Assessments{ get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Speciality> Specialities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //SET CUSTOM DEFAULT VALUE ON CREATION
            //MODIFIED DATE: 
            DateTime modifiedDate = new DateTime(1900, 1, 1);

            #region University
            modelBuilder.Entity<University>().ToTable("university");
            //Primary Key & Identity Column
            modelBuilder.Entity<University>().HasKey(un => un.University_Id);
            modelBuilder.Entity<University>().Property(un => un.University_Id).UseIdentityColumn(1, 1).IsRequired().HasColumnName("university_id");
            //COLUMN SETTINGS
            modelBuilder.Entity<University>().Property(un => un.University_Name).IsRequired(true).HasMaxLength(100).HasColumnName("university_name");
            /*//RelationShips
            modelBuilder.Entity<University>()
                   .HasMany<Student>(un => un.Students)
                   .WithOne(st => st.University)
                   .HasForeignKey(uni => uni.University_Id)
                   .OnDelete(DeleteBehavior.Restrict);//Can't delete an applicants info Ever, We can update it though.
            modelBuilder.Entity<University>()
                   .HasMany<Teacher>(un => un.Teachers)
                   .WithOne(t => t.University)
                   .HasForeignKey(uni => uni.University_Id)
                   .OnDelete(DeleteBehavior.Restrict);//Can't delete an applicants info Ever, We can update it though.
            */
            #endregion

            #region Student
            modelBuilder.Entity<Student>().ToTable("Student");

            modelBuilder.Entity<Student>().HasKey(st => st.Student_Id);
            modelBuilder.Entity<Student>().Property(st => st.Student_Id).UseIdentityColumn(1, 1).IsRequired().HasColumnName("student_id");

            modelBuilder.Entity<Student>().Property(st => st.University_Id).IsRequired(true).HasColumnName("university_id");
            modelBuilder.Entity<Student>().Property(st => st.FirstName).IsRequired(true).HasMaxLength(20).HasColumnName("student_name");
            modelBuilder.Entity<Student>().Property(st => st.LastName).IsRequired(true).HasMaxLength(20).HasColumnName("student_surname");
            modelBuilder.Entity<Student>().Property(st => st.Faculty_Id).IsRequired(true).HasColumnName("faculty_id");
            modelBuilder.Entity<Student>().Property(st => st.Speciality_Id).IsRequired(true).HasColumnName("speciality_id");
            modelBuilder.Entity<Student>().Property(st => st.Group_Id).IsRequired(true).HasColumnName("group_id");


            modelBuilder.Entity<Student>()
                   .HasOne<University>(st => st.University)
                   .WithMany(yn => yn.Students)
                   .HasForeignKey(uni => uni.University_Id)
                   .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Student>()
                   .HasOne<Group>(st => st.Group)
                   .WithOne(gr => gr.Student)
                   .HasForeignKey<Student>(stu => stu.Group_Id)
                   .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Student>()
                               .HasOne<Faculty>(st => st.Faculty)
                               .WithOne(f => f.Student)
                               .HasForeignKey<Student>(uni => uni.Faculty_Id)
                               .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Student>()
                               .HasOne<Speciality>(st => st.Speciality)
                               .WithOne(s => s.Student)
                               .HasForeignKey<Student>(uni => uni.Speciality_Id)
                               .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Student>()
                               .HasOne<Faculty>(st => st.Faculty)
                               .WithOne(f => f.Student)
                               .HasForeignKey<Student>(uni => uni.Faculty_Id)
                               .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region Teacher

            modelBuilder.Entity<Teacher>().ToTable("Teacher");

            modelBuilder.Entity<Teacher>().HasKey(t => t.Teacher_Id);
            modelBuilder.Entity<Teacher>().Property(t => t.Teacher_Id).UseIdentityColumn(1, 1).IsRequired().HasColumnName("teacher_id");

            modelBuilder.Entity<Teacher>().Property(t => t.University_Id).IsRequired(true).HasColumnName("university_id");
            modelBuilder.Entity<Teacher>().Property(t => t.FirstName).IsRequired(true).HasColumnName("teacher_name");
            modelBuilder.Entity<Teacher>().Property(t => t.LastName).IsRequired(true).HasColumnName("teacher_surname");

            modelBuilder.Entity<Teacher>()
                               .HasOne<University>(t => t.University)
                               .WithMany(un => un.Teachers)
                               .HasForeignKey(uni => uni.University_Id)
                               .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region Teacher_subject
            modelBuilder.Entity<Teacher_subject>().ToTable("Teacher_subject");


            modelBuilder.Entity<Teacher_subject>().Property(ts => ts.Teacher_Id).IsRequired(true).HasColumnName("teacher_id");
            modelBuilder.Entity<Teacher_subject>().Property(ts => ts.Subject_Id).IsRequired(true).HasColumnName("subject_id");

            modelBuilder.Entity<Teacher_subject>()
                                           .HasOne<Teacher>(t => t.Teacher)
                                           .WithMany(ts => ts.Teacher_Subject)
                                           .HasForeignKey(uni => uni.Teacher_Id)
                                           .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Teacher_subject>()
                                           .HasOne<Subject>(t => t.Subject)
                                           .WithMany(ts => ts.Teacher_Subject)
                                           .HasForeignKey(uni => uni.Subject_Id)
                                           .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region Subject

            modelBuilder.Entity<Subject>().ToTable("Subject");

            modelBuilder.Entity<Subject>().HasKey(s => s.Subject_Id);
            modelBuilder.Entity<Subject>().Property(s => s.Subject_Id).UseIdentityColumn(1, 1).IsRequired().HasColumnName("subject_id");

            modelBuilder.Entity<Subject>().Property(s => s.Subject_name).IsRequired(true).HasColumnName("subject_name");





            #endregion

            #region Student_Subject
            modelBuilder.Entity<Student_subject>().ToTable("Student_subject");


            modelBuilder.Entity<Student_subject>().Property(ss => ss.Student_Id).IsRequired(true).HasColumnName("student_id");
            modelBuilder.Entity<Student_subject>().Property(ss => ss.Subject_Id).IsRequired(true).HasColumnName("subject_id");

            modelBuilder.Entity<Student_subject>()
                                           .HasOne<Student>(ss => ss.Student)
                                           .WithMany(s => s.Student_Subject)
                                           .HasForeignKey(uni => uni.Student_Id)
                                           .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Student_subject>()
                                           .HasOne<Subject>(ss => ss.Subject)
                                           .WithMany(s => s.Student_Subject)
                                           .HasForeignKey(uni => uni.Subject_Id)
                                           .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region Assessment
            modelBuilder.Entity<Assessment>().ToTable("Assessment");

            modelBuilder.Entity<Assessment>().HasKey(a => a.Assessment_Id);
            modelBuilder.Entity<Assessment>().Property(a => a.Assessment_Id).UseIdentityColumn(1, 1).IsRequired().HasColumnName("subject_id");

            modelBuilder.Entity<Assessment>().Property(a => a.Student_Id).IsRequired(true).HasColumnName("student_id");
            modelBuilder.Entity<Assessment>().Property(a => a.Subject_Id).IsRequired(true).HasColumnName("subject_id");
            modelBuilder.Entity<Assessment>().Property(a => a.Grade).IsRequired(false).HasColumnName("grade");

            modelBuilder.Entity<Assessment>()
                                           .HasOne<Subject>(a => a.Subject)
                                           .WithOne(s => s.Assessment)
                                           .HasForeignKey<Assessment>(uni => uni.Subject_Id)
                                           .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Assessment>()
                                           .HasOne<Student>(a => a.Student)
                                           .WithMany(st => st.Assessment)
                                           .HasForeignKey(uni => uni.Student_Id)
                                           .OnDelete(DeleteBehavior.Restrict);

            #endregion
        }


    }
}

