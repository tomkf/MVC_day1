﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Portfolio.Models;

namespace portfolio_mvc.Migrations
{
    [DbContext(typeof(PortfolioContext))]
    [Migration("20200509220904_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Portfolio.Models.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Title");

                    b.Property<string>("Url");

                    b.HasKey("ProjectId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Portfolio.Models.Technology", b =>
                {
                    b.Property<string>("Name");

                    b.HasKey("Name");

                    b.ToTable("Technologies");
                });

            modelBuilder.Entity("Portfolio.Models.TechnologyProject", b =>
                {
                    b.Property<string>("TechnologyName");

                    b.Property<int>("ProjectId");

                    b.HasKey("TechnologyName", "ProjectId");

                    b.HasAlternateKey("ProjectId", "TechnologyName");

                    b.ToTable("TechnologyProjects");
                });

            modelBuilder.Entity("Portfolio.Models.TechnologyProject", b =>
                {
                    b.HasOne("Portfolio.Models.Project", "Project")
                        .WithMany("TechnologyProjects")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Portfolio.Models.Technology", "Technology")
                        .WithMany("TechnologyProjects")
                        .HasForeignKey("TechnologyName")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
