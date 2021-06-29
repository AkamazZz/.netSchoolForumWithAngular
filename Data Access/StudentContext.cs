using System;
using University_hierarchy.Entity;
using Microsoft.EntityFrameworkCore;

namespace University_hierarchy.DAL
{
    class StudentContext : DbContext
    {
        public  StudentContext(DbContextOptions options ) : base(options) {}

        public DbSet<Student> Students {get; set;}
        
        public DbSet<Speciality> Specialities {get; set;}

        public DbSet<Faculty> Faculties {get; set;}

        public DbSet<Student_subject> Students_subject {get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         =>optionsBuilder
              .UseMySql(@"Server=localhost;database=library;user=user;password= ", new MySqlServerVersion(new Version(8, 0, 11)));
    }
    }

