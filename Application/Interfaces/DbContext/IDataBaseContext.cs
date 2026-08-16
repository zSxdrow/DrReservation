using Dr.Domain.Entities.Category;
using Dr.Domain.Entities.Reserves;
using Dr.Domain.Entities.User;
using Dr.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Dr.Application.Interfaces.DbContext
{
    public interface IDataBaseContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserInRole> UserInRoles { get; set; }

        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Appointments> Appointments { get; set; }
        public DbSet<CalenderD> Calenders { get; set; }
        public DbSet<Times> Times { get; set; }

        public DbSet<Category> Category { get; set; }



        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
