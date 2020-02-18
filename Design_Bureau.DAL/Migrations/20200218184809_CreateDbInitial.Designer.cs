﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Design_Bureau.DAL.Migrations
{
    [DbContext(typeof(DesignBureauDbContext))]
    [Migration("20200218184809_CreateDbInitial")]
    partial class CreateDbInitial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Design_Bureau.Entities.ChiefDesigner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("ChiefDesigners");
                });

            modelBuilder.Entity("Design_Bureau.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Design_Bureau.Entities.Designer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MultiStoreyHouseProjectId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("MultiStoreyHouseProjectId");

                    b.ToTable("Designers");
                });

            modelBuilder.Entity("Design_Bureau.Entities.MultiStoreyHouseProject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ChiefDesignerId");

                    b.Property<int>("CustomerId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ChiefDesignerId");

                    b.HasIndex("CustomerId");

                    b.ToTable("MultiStoreyHouseProjects");
                });

            modelBuilder.Entity("Design_Bureau.Entities.PriceDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("ConstructionCost");

                    b.Property<double>("DesignCost");

                    b.Property<int>("MultiStoreyHouseProjectId");

                    b.HasKey("Id");

                    b.HasIndex("MultiStoreyHouseProjectId")
                        .IsUnique();

                    b.ToTable("PriceDetails");
                });

            modelBuilder.Entity("Design_Bureau.Entities.TermsOfReference", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<bool>("IsRegistered");

                    b.Property<int>("MultiStoreyHouseProjectId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("MultiStoreyHouseProjectId")
                        .IsUnique();

                    b.ToTable("TermsOfReferences");
                });

            modelBuilder.Entity("Design_Bureau.Entities.Designer", b =>
                {
                    b.HasOne("Design_Bureau.Entities.MultiStoreyHouseProject", "MultiStoreyHouseProject")
                        .WithMany("Designers")
                        .HasForeignKey("MultiStoreyHouseProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Design_Bureau.Entities.MultiStoreyHouseProject", b =>
                {
                    b.HasOne("Design_Bureau.Entities.ChiefDesigner", "ChiefDesigner")
                        .WithMany("MultiStoreyHouseProjects")
                        .HasForeignKey("ChiefDesignerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Design_Bureau.Entities.Customer", "Customer")
                        .WithMany("MultiStoreyHouseProjects")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Design_Bureau.Entities.PriceDetails", b =>
                {
                    b.HasOne("Design_Bureau.Entities.MultiStoreyHouseProject", "MultiStoreyHouseProject")
                        .WithOne("PriceDetails")
                        .HasForeignKey("Design_Bureau.Entities.PriceDetails", "MultiStoreyHouseProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Design_Bureau.Entities.TermsOfReference", b =>
                {
                    b.HasOne("Design_Bureau.Entities.MultiStoreyHouseProject", "MultiStoreyHouseProject")
                        .WithOne("TermsOfReference")
                        .HasForeignKey("Design_Bureau.Entities.TermsOfReference", "MultiStoreyHouseProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
