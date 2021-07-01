﻿// <auto-generated />
using DataAccessLayer.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataAccessLayer.Entity.Assessment", b =>
                {
                    b.Property<int>("Assessment_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("assessment_id")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Grade")
                        .HasColumnType("int")
                        .HasColumnName("grade");

                    b.Property<int>("Student_Id")
                        .HasColumnType("int")
                        .HasColumnName("student_id");

                    b.Property<int>("Subject_Id")
                        .HasColumnType("int")
                        .HasColumnName("subject_id");

                    b.HasKey("Assessment_Id");

                    b.HasIndex("Student_Id");

                    b.HasIndex("Subject_Id")
                        .IsUnique();

                    b.ToTable("Assessment");
                });

            modelBuilder.Entity("DataAccessLayer.Entity.Faculty", b =>
                {
                    b.Property<int>("Faculty_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("faculty_id")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Faculty_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("faculty_name");

                    b.HasKey("Faculty_Id");

                    b.ToTable("faculty");
                });

            modelBuilder.Entity("DataAccessLayer.Entity.Group", b =>
                {
                    b.Property<int>("Group_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("group_id")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Group_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("group_name");

                    b.HasKey("Group_Id");

                    b.ToTable("group");
                });

            modelBuilder.Entity("DataAccessLayer.Entity.Speciality", b =>
                {
                    b.Property<int>("Speciality_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("speciality_id")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Faculty_Id")
                        .HasColumnType("int")
                        .HasColumnName("faculty_id");

                    b.Property<string>("Speciality_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("speciality_name");

                    b.HasKey("Speciality_Id");

                    b.HasIndex("Faculty_Id");

                    b.ToTable("Specilaity");
                });

            modelBuilder.Entity("DataAccessLayer.Entity.Student", b =>
                {
                    b.Property<int>("Student_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("student_id")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Faculty_Id")
                        .HasColumnType("int")
                        .HasColumnName("faculty_id");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("student_name");

                    b.Property<int>("Group_Id")
                        .HasColumnType("int")
                        .HasColumnName("group_id");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("student_surname");

                    b.Property<int>("Speciality_Id")
                        .HasColumnType("int")
                        .HasColumnName("speciality_id");

                    b.Property<int>("University_Id")
                        .HasColumnType("int")
                        .HasColumnName("university_id");

                    b.HasKey("Student_Id");

                    b.HasIndex("Faculty_Id")
                        .IsUnique();

                    b.HasIndex("Group_Id")
                        .IsUnique();

                    b.HasIndex("Speciality_Id")
                        .IsUnique();

                    b.HasIndex("University_Id");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("DataAccessLayer.Entity.Student_subject", b =>
                {
                    b.Property<int>("Student_Id")
                        .HasColumnType("int");

                    b.Property<int>("Subject_Id")
                        .HasColumnType("int");

                    b.HasKey("Student_Id", "Subject_Id");

                    b.HasIndex("Subject_Id");

                    b.ToTable("Student_subject");
                });

            modelBuilder.Entity("DataAccessLayer.Entity.Subject", b =>
                {
                    b.Property<int>("Subject_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("subject_id")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Subject_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("subject_name");

                    b.HasKey("Subject_Id");

                    b.ToTable("Subject");
                });

            modelBuilder.Entity("DataAccessLayer.Entity.Teacher", b =>
                {
                    b.Property<int>("Teacher_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("teacher_id")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("teacher_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("teacher_surname");

                    b.Property<int>("University_Id")
                        .HasColumnType("int")
                        .HasColumnName("university_id");

                    b.HasKey("Teacher_Id");

                    b.HasIndex("University_Id");

                    b.ToTable("Teacher");
                });

            modelBuilder.Entity("DataAccessLayer.Entity.Teacher_subject", b =>
                {
                    b.Property<int>("Teacher_Id")
                        .HasColumnType("int");

                    b.Property<int>("Subject_Id")
                        .HasColumnType("int");

                    b.HasKey("Teacher_Id", "Subject_Id");

                    b.HasIndex("Subject_Id");

                    b.ToTable("Teacher_subject");
                });

            modelBuilder.Entity("DataAccessLayer.Entity.University", b =>
                {
                    b.Property<int>("University_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("university_id")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("University_Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("university_name");

                    b.HasKey("University_Id");

                    b.ToTable("university");
                });

            modelBuilder.Entity("DataAccessLayer.Entity.Assessment", b =>
                {
                    b.HasOne("DataAccessLayer.Entity.Student", "Student")
                        .WithMany("Assessment")
                        .HasForeignKey("Student_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DataAccessLayer.Entity.Subject", "Subject")
                        .WithOne("Assessment")
                        .HasForeignKey("DataAccessLayer.Entity.Assessment", "Subject_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("DataAccessLayer.Entity.Speciality", b =>
                {
                    b.HasOne("DataAccessLayer.Entity.Faculty", "Faculty")
                        .WithMany("Speicality")
                        .HasForeignKey("Faculty_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("DataAccessLayer.Entity.Student", b =>
                {
                    b.HasOne("DataAccessLayer.Entity.Faculty", "Faculty")
                        .WithOne("Student")
                        .HasForeignKey("DataAccessLayer.Entity.Student", "Faculty_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DataAccessLayer.Entity.Group", "Group")
                        .WithOne("Student")
                        .HasForeignKey("DataAccessLayer.Entity.Student", "Group_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DataAccessLayer.Entity.Speciality", "Speciality")
                        .WithOne("Student")
                        .HasForeignKey("DataAccessLayer.Entity.Student", "Speciality_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DataAccessLayer.Entity.University", "University")
                        .WithMany("Students")
                        .HasForeignKey("University_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Faculty");

                    b.Navigation("Group");

                    b.Navigation("Speciality");

                    b.Navigation("University");
                });

            modelBuilder.Entity("DataAccessLayer.Entity.Student_subject", b =>
                {
                    b.HasOne("DataAccessLayer.Entity.Student", "Student")
                        .WithMany("Student_Subject")
                        .HasForeignKey("Student_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DataAccessLayer.Entity.Subject", "Subject")
                        .WithMany("Student_Subject")
                        .HasForeignKey("Subject_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("DataAccessLayer.Entity.Teacher", b =>
                {
                    b.HasOne("DataAccessLayer.Entity.University", "University")
                        .WithMany("Teachers")
                        .HasForeignKey("University_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("University");
                });

            modelBuilder.Entity("DataAccessLayer.Entity.Teacher_subject", b =>
                {
                    b.HasOne("DataAccessLayer.Entity.Subject", "Subject")
                        .WithMany("Teacher_Subject")
                        .HasForeignKey("Subject_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DataAccessLayer.Entity.Teacher", "Teacher")
                        .WithMany("Teacher_Subject")
                        .HasForeignKey("Teacher_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Subject");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("DataAccessLayer.Entity.Faculty", b =>
                {
                    b.Navigation("Speicality");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("DataAccessLayer.Entity.Group", b =>
                {
                    b.Navigation("Student");
                });

            modelBuilder.Entity("DataAccessLayer.Entity.Speciality", b =>
                {
                    b.Navigation("Student");
                });

            modelBuilder.Entity("DataAccessLayer.Entity.Student", b =>
                {
                    b.Navigation("Assessment");

                    b.Navigation("Student_Subject");
                });

            modelBuilder.Entity("DataAccessLayer.Entity.Subject", b =>
                {
                    b.Navigation("Assessment");

                    b.Navigation("Student_Subject");

                    b.Navigation("Teacher_Subject");
                });

            modelBuilder.Entity("DataAccessLayer.Entity.Teacher", b =>
                {
                    b.Navigation("Teacher_Subject");
                });

            modelBuilder.Entity("DataAccessLayer.Entity.University", b =>
                {
                    b.Navigation("Students");

                    b.Navigation("Teachers");
                });
#pragma warning restore 612, 618
        }
    }
}