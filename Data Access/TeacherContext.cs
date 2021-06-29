using System;
using University_hierarchy.Entity;
using Microsoft.EntityFrameworkCore;

namespace University_hierarchy.DAL
{
    class TeacherContext : DbContext
    {
        public  TeacherContext(DbContextOptions options ) : base(options) {}

        public DbSet<Teacher> Students {get; set;}
        

        public DbSet<Teacher_subject> Teacher_subject {get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         =>optionsBuilder
              .UseMySql(@"Server=localhost;database=library;user=user;password= ", new MySqlServerVersion(new Version(8, 0, 11)));
    }
    }

