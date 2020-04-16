using Microsoft.EntityFrameworkCore;
using RESTful.API.Entities;
using System;
using System.Collections.Generic;

namespace RESTful.API.Data
{
    public class RoutineDbContext : DbContext
    {
        public RoutineDbContext(DbContextOptions<RoutineDbContext> options)
            : base(options)
        {

        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .Property(x => x.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Company>()
                .Property(x => x.Introduction).HasMaxLength(100);

            modelBuilder.Entity<Employee>()
                .Property(x => x.EmployeeNo).IsRequired().HasMaxLength(10);
            modelBuilder.Entity<Employee>()
                .Property(x => x.FirstName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Employee>()
                .Property(x => x.LastName).IsRequired().HasMaxLength(50);

            modelBuilder.Entity<Employee>()
                .HasOne(x => x.Company)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.CompanyId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Company>().HasData(
                new Company
                {
                    Id = Guid.Parse("d0587ebd-4267-42fd-8a80-da6d058d9c00"),
                    Name = "Microsoft",
                    Introduction = "Great Company"
                },
                new Company
                {
                    Id = Guid.Parse("a8dec6cd-a296-460d-a717-41364b282f4b"),
                    Name = "Google",
                    Introduction = "Dot't be evil"
                },
                new Company
                {
                    Id = Guid.Parse("9709146e-e83c-45ba-8267-f5c0ee65fbef"),
                    Name = "Alibaba",
                    Introduction = "Fubao Company"
                });

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id= Guid.Parse("8fd60c67-46cb-46cf-bd0f-864a6e93c847"),
                    CompanyId = Guid.Parse("a8dec6cd-a296-460d-a717-41364b282f4b"),
                    DateOfBirth = new DateTime(1986, 11, 4),
                    EmployeeNo = "G003",
                    FirstName = "Mary",
                    LastName = "Kin",
                    Gender = Gender.女
                },
                new Employee
                {
                    Id = Guid.Parse("39b8abd2-d49b-4b8d-8ca4-0bce642893a6"),
                    CompanyId = Guid.Parse("a8dec6cd-a296-460d-a717-41364b282f4b"),
                    DateOfBirth = new DateTime(1977, 3, 8),
                    EmployeeNo = "G093",
                    FirstName = "Mary",
                    LastName = "Kin",
                    Gender = Gender.男
                },
                new Employee
                {
                    Id = Guid.Parse("57695b2d-655e-4cef-9974-163c25721765"),
                    CompanyId = Guid.Parse("d0587ebd-4267-42fd-8a80-da6d058d9c00"),
                    DateOfBirth = new DateTime(1973, 2, 1),
                    EmployeeNo = "MSFT231",
                    FirstName = "Nick",
                    LastName = "Carter",
                    Gender = Gender.男
                },
                new Employee
                {
                    Id = Guid.Parse("2b540fa2-708a-4830-941c-b9ff20036946"),
                    CompanyId = Guid.Parse("d0587ebd-4267-42fd-8a80-da6d058d9c00"),
                    DateOfBirth = new DateTime(1973, 2, 1),
                    EmployeeNo = "MSFT777",
                    FirstName = "Vince",
                    LastName = "Ted",
                    Gender = Gender.男
                });
        }
    }
}
