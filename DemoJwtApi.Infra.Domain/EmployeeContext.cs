using DemoJwtApi.Infra.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoJwtApi.Infra.Domain
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {
        }
        public DbSet<Employee>? Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public virtual DbSet<UserInfo>? UserInfos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(new List<Department> {
                new Department(1, ".NET Developer"),
                new Department(2, "python"),
                new Department(3, "React")
                });
            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("UserInfo");
                entity.Property(e => e.Id).HasColumnName("UserId");
                entity.Property(e => e.Name).HasMaxLength(30).IsUnicode(false);
                entity.Property(e => e.Email).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.Password).HasMaxLength(20).IsUnicode(false);
            });
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");
                entity.Property(e => e.Id).HasColumnName("EmployeeID");
                entity.Property(e => e.Name).HasMaxLength(100).IsUnicode(false);
                entity.Property(e => e.JobTitle).HasMaxLength(50).IsUnicode(false);
            });
        }
    }
    }
