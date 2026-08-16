using Common.Clases.InsurancesModel;
using Common.Clases.UserRolesModel;
using Dr.Application.Interfaces.DbContext;
using Dr.Domain.Entities.Category;
using Dr.Domain.Entities.Reserves;
using Dr.Domain.Entities.User;
using Dr.Domain.Entities.Users;
//using Dr.Persistence.Migrations;
using Microsoft.EntityFrameworkCore;
using System;


namespace Dr.Persistence.Context
{
    public class DataBaseContext : DbContext, IDataBaseContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserInRole> UserInRoles { get; set; }
        public DbSet<Service> Services { get; set; }

        public DbSet<Category> Category { get; set; }
        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<Appointments> Appointments { get; set; }
        public DbSet<CalenderD> Calenders { get; set; }
        public DbSet<Times> Times { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //SetRelations(modelBuilder); //برای روابط
            ApplyQueryFilter(modelBuilder); //برای فیلد های حذف شده
            SeedData(modelBuilder); //وارد کردن بیمه ها
            modelBuilder.Entity<User>().HasIndex(x => x.Phone).IsUnique(); //یکتا بودن شماره تلفن
            modelBuilder.Entity<Appointments>().HasIndex(x => x.AppoinmentCode).IsUnique(); //یکتا بودن نوبت
            modelBuilder.Entity<Appointments>().HasIndex(p => p.TrackingCode).IsUnique(); //یکتا بودن ترکینگ کد



            base.OnModelCreating(modelBuilder);
        }



        private void ApplyQueryFilter(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Role>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<UserInRole>().HasQueryFilter(p => !p.IsRemoved);


            modelBuilder.Entity<Insurance>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Service>().HasQueryFilter(p => !p.IsRemoved);

            modelBuilder.Entity<Category>().HasQueryFilter(p => !p.IsRemoved);

            modelBuilder.Entity<Appointments>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<CalenderD>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Times>().HasQueryFilter(p => !p.IsRemoved);

        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Insurance>().HasData(new Insurance { ID = 2, Name = InsurancesModel.TaminEjtemaee, InsertTime = new DateTime(2026, 4, 5) });
            modelBuilder.Entity<Insurance>().HasData(new Insurance { ID = 3, Name = InsurancesModel.KhadamatDarmani, InsertTime = new DateTime(2026, 4, 5) });
            modelBuilder.Entity<Insurance>().HasData(new Insurance { ID = 4, Name = InsurancesModel.ArteshJA, InsertTime = new DateTime(2026, 4, 5) });
            modelBuilder.Entity<Insurance>().HasData(new Insurance { ID = 5, Name = InsurancesModel.Azad, InsertTime = new DateTime(2026, 4, 5) });
            modelBuilder.Entity<Insurance>().HasData(new Insurance { ID = 6, Name = InsurancesModel.Banks, InsertTime = new DateTime(2026, 4, 5) });
            modelBuilder.Entity<Insurance>().HasData(new Insurance { ID = 7, Name = InsurancesModel.Atbaee, InsertTime = new DateTime(2026, 4, 5) });
            modelBuilder.Entity<Insurance>().HasData(new Insurance { ID = 8, Name = InsurancesModel.Sayer, InsertTime = new DateTime(2026, 4, 5) });


            modelBuilder.Entity<Role>().HasData(new Role { RoleID = 1, RoleName = nameof(UserRoles.Admin), InsertTime = new DateTime(2026, 4, 5) });
            modelBuilder.Entity<Role>().HasData(new Role { RoleID = 2, RoleName = nameof(UserRoles.Operator), InsertTime = new DateTime(2026, 4, 5) });
            modelBuilder.Entity<Role>().HasData(new Role { RoleID = 3, RoleName = nameof(UserRoles.Customer), InsertTime = new DateTime(2026, 4, 5) });

            modelBuilder.Entity<Times>().HasData(new Times { ID = 1, Hour = "16", Minute = "00", InsertTime = new DateTime(2026, 4, 5) });
            modelBuilder.Entity<Times>().HasData(new Times { ID = 2, Hour = "16", Minute = "30", InsertTime = new DateTime(2026, 4, 5) });
            modelBuilder.Entity<Times>().HasData(new Times { ID = 3, Hour = "17", Minute = "00", InsertTime = new DateTime(2026, 4, 5) });
            modelBuilder.Entity<Times>().HasData(new Times { ID = 4, Hour = "17", Minute = "30", InsertTime = new DateTime(2026, 4, 5) });
            modelBuilder.Entity<Times>().HasData(new Times { ID = 5, Hour = "18", Minute = "00", InsertTime = new DateTime(2026, 4, 5) });
            modelBuilder.Entity<Times>().HasData(new Times { ID = 6, Hour = "18", Minute = "30", InsertTime = new DateTime(2026, 4, 5) });


            var calendars = new List<CalenderD>();

            var startDate = new DateOnly(1405, 3, 31);

            for (int i = 0; i < 120; i++)
            {
                var date = startDate.AddDays(i);

                calendars.Add(new CalenderD
                {
                    ID = i + 1,
                    Date = date,
                    IsHoliday = date.DayOfWeek == DayOfWeek.Thursday ||
                                date.DayOfWeek == DayOfWeek.Friday ? true : false,
                    InsertTime = new DateTime(2026,6,21)
                });
            }



            modelBuilder.Entity<Service>().HasData(new Service { ID = 1, Name = "ایمپلنت", Price = 17800000, InsertTime = new DateTime(2026, 4, 5) });
            modelBuilder.Entity<Service>().HasData(new Service { ID = 2, Name = "لمینیت", Price = 17000000, InsertTime = new DateTime(2026, 4, 5) });
            modelBuilder.Entity<Service>().HasData(new Service { ID = 3, Name = "ارتودنسی ثابت 2 فک", Price = 95000000, InsertTime = new DateTime(2026, 4, 5) });
            modelBuilder.Entity<Service>().HasData(new Service { ID = 4, Name = "کامپوزیت", Price = 7000000, InsertTime = new DateTime(2026, 4, 5) });
            modelBuilder.Entity<Service>().HasData(new Service { ID = 5, Name = "عصب کشی یک کانال", Price = 4500000, InsertTime = new DateTime(2026, 4, 5) });
            modelBuilder.Entity<Service>().HasData(new Service { ID = 6, Name = "ترمیم دندان", Price = 1500000, InsertTime = new DateTime(2026, 4, 5) });
            modelBuilder.Entity<Service>().HasData(new Service { ID = 7, Name = "روکش دندان", Price = 2500000, InsertTime = new DateTime(2026, 4, 5) });


        }

    }
}
