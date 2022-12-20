﻿// <auto-generated />
using CoreCodeBased.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoreCodeBased.Migrations
{
    [DbContext(typeof(EFDataContext))]
    partial class EFDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoreCodeBased.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DepartmentCode")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(20)");

                    b.HasKey("DepartmentId");

                    b.ToTable("Department","dbo");
                });

            modelBuilder.Entity("CoreCodeBased.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DepartmentId");

                    b.Property<string>("EmployeeCode")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.HasKey("EmployeeId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employee","dbo");
                });

            modelBuilder.Entity("CoreCodeBased.Models.Employee", b =>
                {
                    b.HasOne("CoreCodeBased.Models.Department", "DepartmentInfo")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
