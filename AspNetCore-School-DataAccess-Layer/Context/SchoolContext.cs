using AspNetCore_School_DataAccess_Layer.Identity;
using AspNetCore_School_Entity_Layer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AspNetCore_School_DataAccess_Layer.Context.SchoolContext;

namespace AspNetCore_School_DataAccess_Layer.Context
{
    public class SchoolContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public SchoolContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<School> Schools { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<School>().HasData(
                new School() { Id = 1, Name = "Bayrak Lisesi", District = "Yeşilköy Mahallesi" },
                new School() { Id = 2, Name = "Güneş Lisesi", District = "Merkez Mahallesi" },
                new School() { Id = 3, Name = "Deniz Lisesi", District = "Sahil Mahallesi" }
                );

            builder.Entity<Class>().HasData(
                new Class() { Id = 1, Name = "Sınıf 1", SchoolId = 1 },
                new Class() { Id = 2, Name = "Sınıf 2", SchoolId = 1 },
                new Class() { Id = 3, Name = "Sınıf 3", SchoolId = 1 },

                new Class() { Id = 4, Name = "Sınıf 1", SchoolId = 2 },
                new Class() { Id = 5, Name = "Sınıf 2", SchoolId = 2 },
                new Class() { Id = 6, Name = "Sınıf 3", SchoolId = 2 },

                new Class() { Id = 7, Name = "Sınıf 1", SchoolId = 3 },
                new Class() { Id = 8, Name = "Sınıf 2", SchoolId = 3 },
                new Class() { Id = 9, Name = "Sınıf 3", SchoolId = 3 }



                );

            
            builder.Entity<Student>().HasData(
                new Student { Id = 1, Name = "Ahmet", SurName = "Yılmaz", SchoolNo = "1001", ClassId = 1 },
                new Student { Id = 2, Name = "Mehmet", SurName = "Demir", SchoolNo = "1002", ClassId = 1 },
                new Student { Id = 3, Name = "Ayşe", SurName = "Kara", SchoolNo = "1003", ClassId = 1 },
                new Student { Id = 4, Name = "Fatma", SurName = "Kurt", SchoolNo = "1004", ClassId = 1 },
                new Student { Id = 5, Name = "Mustafa", SurName = "Taş", SchoolNo = "1005", ClassId = 1 },
                new Student { Id = 6, Name = "Hatice", SurName = "Aydın", SchoolNo = "1006", ClassId = 1 },
                new Student { Id = 7, Name = "Ali", SurName = "Yıldırım", SchoolNo = "1007", ClassId = 1 },
                new Student { Id = 8, Name = "Nur", SurName = "Sarı", SchoolNo = "1008", ClassId = 1 },
                new Student { Id = 9, Name = "Emir", SurName = "Kara", SchoolNo = "1009", ClassId = 1 },
                new Student { Id = 10, Name = "Ebru", SurName = "Yılmaz", SchoolNo = "1010", ClassId = 1 },
          
                new Student { Id = 11, Name = "Selin", SurName = "Ateş", SchoolNo = "1011", ClassId = 2 },
                new Student { Id = 12, Name = "Burak", SurName = "Demir", SchoolNo = "1012", ClassId = 2 },
                new Student { Id = 13, Name = "Zeynep", SurName = "Kurt", SchoolNo = "1013", ClassId = 2 },
                new Student { Id = 14, Name = "Kerem", SurName = "Yılmaz", SchoolNo = "1014", ClassId = 2 },
                new Student { Id = 15, Name = "Aslı", SurName = "Taş", SchoolNo = "1015", ClassId = 2 },
                new Student { Id = 16, Name = "Deniz", SurName = "Sarı", SchoolNo = "1016", ClassId = 2 },
                new Student { Id = 17, Name = "Cem", SurName = "Aydın", SchoolNo = "1017", ClassId = 2 },
                new Student { Id = 18, Name = "Elif", SurName = "Kara", SchoolNo = "1018", ClassId = 2 },
                new Student { Id = 19, Name = "Merve", SurName = "Yıldırım", SchoolNo = "1019", ClassId = 2 },
                new Student { Id = 20, Name = "Can", SurName = "Ateş", SchoolNo = "1020", ClassId = 2 },

                new Student { Id = 21, Name = "Ege", SurName = "Kara", SchoolNo = "1021", ClassId = 3 },
                new Student { Id = 22, Name = "Elif", SurName = "Yılmaz", SchoolNo = "1022", ClassId = 3 },
                new Student { Id = 23, Name = "Onur", SurName = "Taş", SchoolNo = "1023", ClassId = 3 },
                new Student { Id = 24, Name = "Yaren", SurName = "Sarı", SchoolNo = "1024", ClassId = 3 },
                new Student { Id = 25, Name = "Cemal", SurName = "Demir", SchoolNo = "1025", ClassId = 3 },
                new Student { Id = 26, Name = "Seda", SurName = "Aydın", SchoolNo = "1026", ClassId = 3 },
                new Student { Id = 27, Name = "Kaan", SurName = "Kurt", SchoolNo = "1027", ClassId = 3 },
                new Student { Id = 28, Name = "Rabia", SurName = "Yıldırım", SchoolNo = "1028", ClassId = 3 },
                new Student { Id = 29, Name = "Tolga", SurName = "Sarı", SchoolNo = "1029", ClassId = 3 },
                new Student { Id = 30, Name = "Aylin", SurName = "Ateş", SchoolNo = "1030", ClassId = 3 },

                new Student { Id = 31, Name = "Defne", SurName = "Kara", SchoolNo = "1031", ClassId = 4 },
                new Student { Id = 32, Name = "Arda", SurName = "Yılmaz", SchoolNo = "1032", ClassId = 4 },
                new Student { Id = 33, Name = "Selin", SurName = "Demir", SchoolNo = "1033", ClassId = 4 },
                new Student { Id = 34, Name = "Kerem", SurName = "Taş", SchoolNo = "1034", ClassId = 4 },
                new Student { Id = 35, Name = "Zeynep", SurName = "Kurt", SchoolNo = "1035", ClassId = 4 },
                new Student { Id = 36, Name = "Ali", SurName = "Aydın", SchoolNo = "1036", ClassId = 4 },
                new Student { Id = 37, Name = "Ela", SurName = "Sarı", SchoolNo = "1037", ClassId = 4 },
                new Student { Id = 38, Name = "Emir", SurName = "Yıldırım", SchoolNo = "1038", ClassId = 4 },
                new Student { Id = 39, Name = "Lina", SurName = "Taş", SchoolNo = "1039", ClassId = 4 },
                new Student { Id = 40, Name = "Aycan", SurName = "Ateş", SchoolNo = "1040", ClassId = 4 },

                new Student { Id = 41, Name = "Eren", SurName = "Kara", SchoolNo = "1041", ClassId = 5 },
                new Student { Id = 42, Name = "Ezgi", SurName = "Yılmaz", SchoolNo = "1042", ClassId = 5 },
                new Student { Id = 43, Name = "Alihan", SurName = "Demir", SchoolNo = "1043", ClassId = 5 },
                new Student { Id = 44, Name = "Sude", SurName = "Taş", SchoolNo = "1044", ClassId = 5 },
                new Student { Id = 45, Name = "Cemre", SurName = "Kurt", SchoolNo = "1045", ClassId = 5 },
                new Student { Id = 46, Name = "Kaan", SurName = "Aydın", SchoolNo = "1046", ClassId = 5 },
                new Student { Id = 47, Name = "Mina", SurName = "Sarı", SchoolNo = "1047", ClassId = 5 },
                new Student { Id = 48, Name = "Ayşenur", SurName = "Yıldırım", SchoolNo = "1048", ClassId = 5 },
                new Student { Id = 49, Name = "Kerim", SurName = "Taş", SchoolNo = "1049", ClassId = 5 },
                new Student { Id = 50, Name = "Lara", SurName = "Ateş", SchoolNo = "1050", ClassId = 5 },

                new Student { Id = 51, Name = "Selin", SurName = "Kara", SchoolNo = "2001", ClassId = 6 },
                new Student { Id = 52, Name = "Arda", SurName = "Yılmaz", SchoolNo = "2002", ClassId = 6 },
                new Student { Id = 53, Name = "Elif", SurName = "Demir", SchoolNo = "2003", ClassId = 6 },
                new Student { Id = 54, Name = "Kerem", SurName = "Taş", SchoolNo = "2004", ClassId = 6 },
                new Student { Id = 55, Name = "Zeynep", SurName = "Kurt", SchoolNo = "2005", ClassId =6 },
                new Student { Id = 56, Name = "Ali", SurName = "Aydın", SchoolNo = "2006", ClassId = 6 },
                new Student { Id = 57, Name = "Ela", SurName = "Sarı", SchoolNo = "2007", ClassId = 6 },
                new Student { Id = 58, Name = "Emir", SurName = "Yıldırım", SchoolNo = "2008", ClassId = 6 },
                new Student { Id = 59, Name = "Lina", SurName = "Taş", SchoolNo = "2009", ClassId = 6 },
                new Student { Id = 60, Name = "Aycan", SurName = "Ateş", SchoolNo = "2010", ClassId = 6 },

                new Student { Id = 61, Name = "Mehmet", SurName = "Kara", SchoolNo = "2011", ClassId = 7 },
                new Student { Id = 62, Name = "Ceren", SurName = "Yılmaz", SchoolNo = "2012", ClassId = 7 },
                new Student { Id = 63, Name = "Oğuz", SurName = "Demir", SchoolNo = "2013", ClassId = 7 },
                new Student { Id = 64, Name = "Sude", SurName = "Taş", SchoolNo = "2014", ClassId = 7 },
                new Student { Id = 65, Name = "Cemre", SurName = "Kurt", SchoolNo = "2015", ClassId = 7 },
                new Student { Id = 66, Name = "Kaan", SurName = "Aydın", SchoolNo = "2016", ClassId = 7 },
                new Student { Id = 67, Name = "Ela", SurName = "Sarı", SchoolNo = "2017", ClassId = 7 },
                new Student { Id = 68, Name = "Emir", SurName = "Yıldırım", SchoolNo = "2018", ClassId = 7 },
                new Student { Id = 69, Name = "Lina", SurName = "Taş", SchoolNo = "2019", ClassId = 7 },
                new Student { Id = 70, Name = "Aycan", SurName = "Ateş", SchoolNo = "2020", ClassId = 7 },

                new Student { Id = 71, Name = "Selin", SurName = "Kara", SchoolNo = "2401", ClassId = 8 },
                new Student { Id = 72, Name = "Arda", SurName = "Yılmaz", SchoolNo = "2402", ClassId = 8 },
                new Student { Id = 73, Name = "Elif", SurName = "Demir", SchoolNo = "2403", ClassId = 8 },
                new Student { Id = 74, Name = "Kerem", SurName = "Taş", SchoolNo = "2404", ClassId = 8 },
                new Student { Id = 75, Name = "Zeynep", SurName = "Kurt", SchoolNo = "2405", ClassId = 8 },
                new Student { Id = 76, Name = "Ali", SurName = "Aydın", SchoolNo = "2406", ClassId = 8 },
                new Student { Id = 77, Name = "Ela", SurName = "Sarı", SchoolNo = "2407", ClassId = 8 },
                new Student { Id = 78, Name = "Emir", SurName = "Yıldırım", SchoolNo = "2408", ClassId = 8 },
                new Student { Id = 79, Name = "Lina", SurName = "Taş", SchoolNo = "2409", ClassId = 8 },
                new Student { Id = 80, Name = "Aycan", SurName = "Ateş", SchoolNo = "2410", ClassId = 8 },

                new Student { Id = 81, Name = "Eren", SurName = "Kara", SchoolNo = "2501", ClassId = 9 },
                new Student { Id = 82, Name = "Ezgi", SurName = "Yılmaz", SchoolNo = "2502", ClassId = 9 },
                new Student { Id = 83, Name = "Alihan", SurName = "Demir", SchoolNo = "2503", ClassId = 9 },
                new Student { Id = 84, Name = "Sude", SurName = "Taş", SchoolNo = "2504", ClassId = 9 },
                new Student { Id = 85, Name = "Cemre", SurName = "Kurt", SchoolNo = "2505", ClassId = 9 },
                new Student { Id = 86, Name = "Kaan", SurName = "Aydın", SchoolNo = "2506", ClassId = 9 },
                new Student { Id = 87, Name = "Mina", SurName = "Sarı", SchoolNo = "2507", ClassId = 9 },
                new Student { Id = 88, Name = "Ayşenur", SurName = "Yıldırım", SchoolNo = "2508", ClassId = 9 },
                new Student { Id = 89, Name = "Kerim", SurName = "Taş", SchoolNo = "2509", ClassId = 9 },
                new Student { Id = 90, Name = "Lara", SurName = "Ateş", SchoolNo = "2510", ClassId = 9 }


                    );

            





            base.OnModelCreating(builder);
        }

    }
}

