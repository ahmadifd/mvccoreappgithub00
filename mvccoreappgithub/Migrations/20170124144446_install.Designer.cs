using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using mvccoreappgithub.Data;

namespace mvccoreappgithub.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170124144446_install")]
    partial class install
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("mvccoreappgithub.Models.Person", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("PersonID");

                    b.Property<int>("JID")
                        .HasColumnName("JobID");

                    b.Property<int?>("Age");

                    b.Property<string>("Email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("FullName")
                        .HasColumnType("VarChar(16)")
                        .HasAnnotation("MaxLength", 5);

                    b.Property<string>("Password")
                        .HasAnnotation("MaxLength", 5);

                    b.Property<int?>("Phone");

                    b.Property<string>("RepeatEmail");

                    b.Property<int>("Salary");

                    b.Property<string>("UserName")
                        .IsRequired();

                    b.HasKey("ID", "JID");

                    b.ToTable("AllPeople");
                });
        }
    }
}
