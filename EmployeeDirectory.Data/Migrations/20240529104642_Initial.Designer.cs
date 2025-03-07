﻿// <auto-generated />
using EmployeeDirectory.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmployeeDirectory.Data.Migrations
{
    [DbContext(typeof(EmployeeDbContext))]
    [Migration("20240529104642_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EmployeeDirectory.Data.DBModels.Department", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "PE"
                        },
                        new
                        {
                            Id = 2,
                            Name = "IT"
                        },
                        new
                        {
                            Id = 3,
                            Name = "HR"
                        },
                        new
                        {
                            Id = 4,
                            Name = "QA"
                        });
                });

            modelBuilder.Entity("EmployeeDirectory.Data.DBModels.Employee", b =>
                {
                    b.Property<string>("EmpNo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DateOfBirth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("EmailId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JoinDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Manager")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("EmpNo");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("RoleId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("EmployeeDirectory.Data.DBModels.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "WebApp"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Website"
                        },
                        new
                        {
                            Id = 3,
                            Name = "iOS App"
                        });
                });

            modelBuilder.Entity("EmployeeDirectory.Data.DBModels.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("EmployeeDirectory.Data.DBModels.Employee", b =>
                {
                    b.HasOne("EmployeeDirectory.Data.DBModels.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EmployeeDirectory.Data.DBModels.Project", "Project")
                        .WithMany("Employees")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EmployeeDirectory.Data.DBModels.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Project");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("EmployeeDirectory.Data.DBModels.Role", b =>
                {
                    b.HasOne("EmployeeDirectory.Data.DBModels.Department", "Department")
                        .WithMany("Roles")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("EmployeeDirectory.Data.DBModels.Department", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("EmployeeDirectory.Data.DBModels.Project", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
