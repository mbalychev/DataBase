﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PcRepaire.Data;

namespace PcRepaire.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("PcRepaire.Models.Employee", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Employee");
                });

            modelBuilder.Entity("PcRepaire.Models.Equipment", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int>("EquipUserId");

                    b.Property<int>("Manufacture");

                    b.Property<string>("Model");

                    b.Property<string>("SerialNumber");

                    b.Property<int>("SoftWareId");

                    b.HasKey("Id");

                    b.HasIndex("EquipUserId");

                    b.HasIndex("SoftWareId");

                    b.ToTable("Equipments");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Equipment");
                });

            modelBuilder.Entity("PcRepaire.Models.HardWare", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("HardType");

                    b.HasKey("Id");

                    b.ToTable("HardWares");
                });

            modelBuilder.Entity("PcRepaire.Models.RepairList", b =>
                {
                    b.Property<int>("Id");

                    b.Property<DateTime>("Date");

                    b.Property<int?>("HardWareId");

                    b.Property<bool>("HardWareRapaired");

                    b.Property<int>("PcId");

                    b.Property<int?>("RepaireManId");

                    b.Property<int?>("SoftWareId");

                    b.Property<bool>("SoftWareRapaired");

                    b.Property<int>("WorkerId");

                    b.HasKey("Id");

                    b.HasIndex("HardWareId");

                    b.HasIndex("PcId");

                    b.HasIndex("RepaireManId");

                    b.HasIndex("SoftWareId");

                    b.ToTable("RepairLists");
                });

            modelBuilder.Entity("PcRepaire.Models.SoftWare", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("SoftWares");
                });

            modelBuilder.Entity("PcRepaire.Models.ViewModels.StatRepaires", b =>
                {
                    b.Property<DateTime>("Date");

                    b.Property<int>("Count");

                    b.Property<int?>("StatisticId");

                    b.HasKey("Date");

                    b.HasIndex("StatisticId");

                    b.ToTable("StatRepaires");
                });

            modelBuilder.Entity("PcRepaire.Models.ViewModels.Statistic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Statistic");
                });

            modelBuilder.Entity("PcRepaire.Models.EquipUser", b =>
                {
                    b.HasBaseType("PcRepaire.Models.Employee");

                    b.HasDiscriminator().HasValue("EquipUser");
                });

            modelBuilder.Entity("PcRepaire.Models.RepaireMan", b =>
                {
                    b.HasBaseType("PcRepaire.Models.Employee");

                    b.HasDiscriminator().HasValue("RepaireMan");
                });

            modelBuilder.Entity("PcRepaire.Models.Pc", b =>
                {
                    b.HasBaseType("PcRepaire.Models.Equipment");

                    b.Property<int>("HardWareId");

                    b.HasIndex("HardWareId");

                    b.HasDiscriminator().HasValue("Pc");
                });

            modelBuilder.Entity("PcRepaire.Models.Tablet", b =>
                {
                    b.HasBaseType("PcRepaire.Models.Equipment");

                    b.HasDiscriminator().HasValue("Tablet");
                });

            modelBuilder.Entity("PcRepaire.Models.ViewModels.StatWorkers", b =>
                {
                    b.HasBaseType("PcRepaire.Models.RepaireMan");

                    b.Property<int>("CountHard");

                    b.Property<int>("CountRepaires");

                    b.Property<int>("CountSoft");

                    b.Property<int?>("StatisticId");

                    b.HasIndex("StatisticId");

                    b.HasDiscriminator().HasValue("StatWorkers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PcRepaire.Models.Equipment", b =>
                {
                    b.HasOne("PcRepaire.Models.EquipUser", "EquipUser")
                        .WithMany()
                        .HasForeignKey("EquipUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PcRepaire.Models.SoftWare", "SoftWare")
                        .WithMany()
                        .HasForeignKey("SoftWareId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PcRepaire.Models.RepairList", b =>
                {
                    b.HasOne("PcRepaire.Models.HardWare", "HardWare")
                        .WithMany()
                        .HasForeignKey("HardWareId");

                    b.HasOne("PcRepaire.Models.Pc", "Pc")
                        .WithMany()
                        .HasForeignKey("PcId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PcRepaire.Models.RepaireMan", "RepaireMan")
                        .WithMany("RepairList")
                        .HasForeignKey("RepaireManId");

                    b.HasOne("PcRepaire.Models.SoftWare", "SoftWare")
                        .WithMany()
                        .HasForeignKey("SoftWareId");
                });

            modelBuilder.Entity("PcRepaire.Models.ViewModels.StatRepaires", b =>
                {
                    b.HasOne("PcRepaire.Models.ViewModels.Statistic")
                        .WithMany("StatRepaires")
                        .HasForeignKey("StatisticId");
                });

            modelBuilder.Entity("PcRepaire.Models.Pc", b =>
                {
                    b.HasOne("PcRepaire.Models.HardWare", "HardWare")
                        .WithMany()
                        .HasForeignKey("HardWareId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PcRepaire.Models.ViewModels.StatWorkers", b =>
                {
                    b.HasOne("PcRepaire.Models.ViewModels.Statistic")
                        .WithMany("StatWorkers")
                        .HasForeignKey("StatisticId");
                });
#pragma warning restore 612, 618
        }
    }
}
