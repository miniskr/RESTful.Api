﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RESTful.API.Data;

namespace RESTful.API.Migrations
{
    [DbContext(typeof(RoutineDbContext))]
    partial class RoutineDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3");

            modelBuilder.Entity("RESTful.API.Entities.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Introduction")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d0587ebd-4267-42fd-8a80-da6d058d9c00"),
                            Introduction = "Great Company",
                            Name = "Microsoft"
                        },
                        new
                        {
                            Id = new Guid("a8dec6cd-a296-460d-a717-41364b282f4b"),
                            Introduction = "Dot't be evil",
                            Name = "Google"
                        },
                        new
                        {
                            Id = new Guid("9709146e-e83c-45ba-8267-f5c0ee65fbef"),
                            Introduction = "Fubao Company",
                            Name = "Alibaba"
                        });
                });

            modelBuilder.Entity("RESTful.API.Entities.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmployeeNo")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(10);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<int>("Gender")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8fd60c67-46cb-46cf-bd0f-864a6e93c847"),
                            CompanyId = new Guid("a8dec6cd-a296-460d-a717-41364b282f4b"),
                            DateOfBirth = new DateTime(1986, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeNo = "G003",
                            FirstName = "Mary",
                            Gender = 2,
                            LastName = "Kin"
                        },
                        new
                        {
                            Id = new Guid("39b8abd2-d49b-4b8d-8ca4-0bce642893a6"),
                            CompanyId = new Guid("a8dec6cd-a296-460d-a717-41364b282f4b"),
                            DateOfBirth = new DateTime(1977, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeNo = "G093",
                            FirstName = "Mary",
                            Gender = 1,
                            LastName = "Kin"
                        },
                        new
                        {
                            Id = new Guid("57695b2d-655e-4cef-9974-163c25721765"),
                            CompanyId = new Guid("d0587ebd-4267-42fd-8a80-da6d058d9c00"),
                            DateOfBirth = new DateTime(1973, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeNo = "MSFT231",
                            FirstName = "Nick",
                            Gender = 1,
                            LastName = "Carter"
                        },
                        new
                        {
                            Id = new Guid("2b540fa2-708a-4830-941c-b9ff20036946"),
                            CompanyId = new Guid("d0587ebd-4267-42fd-8a80-da6d058d9c00"),
                            DateOfBirth = new DateTime(1973, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeNo = "MSFT777",
                            FirstName = "Vince",
                            Gender = 1,
                            LastName = "Ted"
                        });
                });

            modelBuilder.Entity("RESTful.API.Entities.Employee", b =>
                {
                    b.HasOne("RESTful.API.Entities.Company", "Company")
                        .WithMany("Employees")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}