﻿// <auto-generated />
using System;
using LawyerProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LawyerProject.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230515183021_DocumentKinds-create-Table")]
    partial class DocumentKindscreateTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LawyerProject.Models.DB.AdministrativeWork", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AdministrativeWorkKindID_FK")
                        .HasColumnType("int");

                    b.Property<int?>("CaseID_FK")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FinishBefor")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsFinished")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AdministrativeWorkKindID_FK");

                    b.HasIndex("CaseID_FK");

                    b.ToTable("AdministrativeWorks");
                });

            modelBuilder.Entity("LawyerProject.Models.DB.AdministrativeWorkKind", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("administrativeWorkKinds");
                });

            modelBuilder.Entity("LawyerProject.Models.DB.Case", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CaseSubKindId_FK")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreateOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DayraId_FK")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastUpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CaseSubKindId_FK");

                    b.HasIndex("DayraId_FK");

                    b.ToTable("Cases");
                });

            modelBuilder.Entity("LawyerProject.Models.DB.CaseClient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CaseId_FK")
                        .HasColumnType("int");

                    b.Property<int>("ClientId_FK")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CaseId_FK");

                    b.HasIndex("ClientId_FK");

                    b.ToTable("CaseClients");
                });

            modelBuilder.Entity("LawyerProject.Models.DB.CaseEnemy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CaseId_FK")
                        .HasColumnType("int");

                    b.Property<int>("EnemyId_FK")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CaseId_FK");

                    b.HasIndex("EnemyId_FK");

                    b.ToTable("CaseEnemies");
                });

            modelBuilder.Entity("LawyerProject.Models.DB.CaseKind", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CaseKinds");
                });

            modelBuilder.Entity("LawyerProject.Models.DB.CaseSubKind", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CaseKindId_FK")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CaseKindId_FK");

                    b.ToTable("CaseSubKinds");
                });

            modelBuilder.Entity("LawyerProject.Models.DB.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("LawyerProject.Models.DB.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NationalNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("LawyerProject.Models.DB.Court", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CityID_FK")
                        .HasColumnType("int");

                    b.Property<int>("CourtKindID_FK")
                        .HasColumnType("int");

                    b.Property<string>("Discription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CityID_FK");

                    b.HasIndex("CourtKindID_FK");

                    b.ToTable("Courts");
                });

            modelBuilder.Entity("LawyerProject.Models.DB.CourtKind", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CourtKinds");
                });

            modelBuilder.Entity("LawyerProject.Models.DB.Dayra", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("AddressOfGadwal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressOfJudgment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressOfSecertary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameOfSecertary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NyabaId_FK")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("NyabaId_FK");

                    b.ToTable("Dayras");
                });

            modelBuilder.Entity("LawyerProject.Models.DB.DocumentKind", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DocumentKinds");
                });

            modelBuilder.Entity("LawyerProject.Models.DB.Enemy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnemyLawyer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("National")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Enemies");
                });

            modelBuilder.Entity("LawyerProject.Models.DB.MaktabTawseek", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MaktabTawseeks");
                });

            modelBuilder.Entity("LawyerProject.Models.DB.Nyaba", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CourtId_FK")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NyabaKindId_FK")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourtId_FK");

                    b.HasIndex("NyabaKindId_FK");

                    b.ToTable("Nyabas");
                });

            modelBuilder.Entity("LawyerProject.Models.DB.NyabaKind", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("NyabaKinds");
                });

            modelBuilder.Entity("LawyerProject.Models.DB.Tawkeel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("MaktabTawseekId_FK")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TawkeelPath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MaktabTawseekId_FK");

                    b.ToTable("Tawkeels");
                });

            modelBuilder.Entity("LawyerProject.Models.DB.TawkeelClients", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClientId_FK")
                        .HasColumnType("int");

                    b.Property<int>("TawkeelId_FK")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId_FK");

                    b.HasIndex("TawkeelId_FK");

                    b.ToTable("TawkeelClients");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("LawyerProject.Models.DB.AdministrativeWork", b =>
                {
                    b.HasOne("LawyerProject.Models.DB.AdministrativeWorkKind", "AdministrativeWorkKind")
                        .WithMany("AdministrativeWorks")
                        .HasForeignKey("AdministrativeWorkKindID_FK");

                    b.HasOne("LawyerProject.Models.DB.Case", "Case")
                        .WithMany("AdministrativeWorks")
                        .HasForeignKey("CaseID_FK");

                    b.Navigation("AdministrativeWorkKind");

                    b.Navigation("Case");
                });

            modelBuilder.Entity("LawyerProject.Models.DB.Case", b =>
                {
                    b.HasOne("LawyerProject.Models.DB.CaseSubKind", "CaseSubKind")
                        .WithMany("Cases")
                        .HasForeignKey("CaseSubKindId_FK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LawyerProject.Models.DB.Dayra", "Dayra")
                        .WithMany()
                        .HasForeignKey("DayraId_FK");

                    b.Navigation("CaseSubKind");

                    b.Navigation("Dayra");
                });

            modelBuilder.Entity("LawyerProject.Models.DB.CaseClient", b =>
                {
                    b.HasOne("LawyerProject.Models.DB.Case", "Case")
                        .WithMany("CaseClients")
                        .HasForeignKey("CaseId_FK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LawyerProject.Models.DB.Client", "Client")
                        .WithMany("CaseClients")
                        .HasForeignKey("ClientId_FK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Case");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("LawyerProject.Models.DB.CaseEnemy", b =>
                {
                    b.HasOne("LawyerProject.Models.DB.Case", "Case")
                        .WithMany("CaseEnemies")
                        .HasForeignKey("CaseId_FK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LawyerProject.Models.DB.Enemy", "Enemy")
                        .WithMany("CaseEnemye")
                        .HasForeignKey("EnemyId_FK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Case");

                    b.Navigation("Enemy");
                });

            modelBuilder.Entity("LawyerProject.Models.DB.CaseSubKind", b =>
                {
                    b.HasOne("LawyerProject.Models.DB.CaseKind", "CaseKind")
                        .WithMany("CaseSubKinds")
                        .HasForeignKey("CaseKindId_FK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CaseKind");
                });

            modelBuilder.Entity("LawyerProject.Models.DB.Court", b =>
                {
                    b.HasOne("LawyerProject.Models.DB.City", "City")
                        .WithMany("Courts")
                        .HasForeignKey("CityID_FK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LawyerProject.Models.DB.CourtKind", "CourtKind")
                        .WithMany("Courts")
                        .HasForeignKey("CourtKindID_FK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("CourtKind");
                });

            modelBuilder.Entity("LawyerProject.Models.DB.Dayra", b =>
                {
                    b.HasOne("LawyerProject.Models.DB.Nyaba", "Nyaba")
                        .WithMany("Dayras")
                        .HasForeignKey("NyabaId_FK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Nyaba");
                });

            modelBuilder.Entity("LawyerProject.Models.DB.Nyaba", b =>
                {
                    b.HasOne("LawyerProject.Models.DB.Court", "Court")
                        .WithMany("Nyabas")
                        .HasForeignKey("CourtId_FK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LawyerProject.Models.DB.NyabaKind", "NyabaKind")
                        .WithMany("Nyabas")
                        .HasForeignKey("NyabaKindId_FK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Court");

                    b.Navigation("NyabaKind");
                });

            modelBuilder.Entity("LawyerProject.Models.DB.Tawkeel", b =>
                {
                    b.HasOne("LawyerProject.Models.DB.MaktabTawseek", "MaktabTawseek")
                        .WithMany("Tawkeels")
                        .HasForeignKey("MaktabTawseekId_FK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MaktabTawseek");
                });

            modelBuilder.Entity("LawyerProject.Models.DB.TawkeelClients", b =>
                {
                    b.HasOne("LawyerProject.Models.DB.Client", "Client")
                        .WithMany("TawkeelClients")
                        .HasForeignKey("ClientId_FK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LawyerProject.Models.DB.Tawkeel", "Tawkeel")
                        .WithMany("TawkeelClients")
                        .HasForeignKey("TawkeelId_FK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Tawkeel");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LawyerProject.Models.DB.AdministrativeWorkKind", b =>
                {
                    b.Navigation("AdministrativeWorks");
                });

            modelBuilder.Entity("LawyerProject.Models.DB.Case", b =>
                {
                    b.Navigation("AdministrativeWorks");

                    b.Navigation("CaseClients");

                    b.Navigation("CaseEnemies");
                });

            modelBuilder.Entity("LawyerProject.Models.DB.CaseKind", b =>
                {
                    b.Navigation("CaseSubKinds");
                });

            modelBuilder.Entity("LawyerProject.Models.DB.CaseSubKind", b =>
                {
                    b.Navigation("Cases");
                });

            modelBuilder.Entity("LawyerProject.Models.DB.City", b =>
                {
                    b.Navigation("Courts");
                });

            modelBuilder.Entity("LawyerProject.Models.DB.Client", b =>
                {
                    b.Navigation("CaseClients");

                    b.Navigation("TawkeelClients");
                });

            modelBuilder.Entity("LawyerProject.Models.DB.Court", b =>
                {
                    b.Navigation("Nyabas");
                });

            modelBuilder.Entity("LawyerProject.Models.DB.CourtKind", b =>
                {
                    b.Navigation("Courts");
                });

            modelBuilder.Entity("LawyerProject.Models.DB.Enemy", b =>
                {
                    b.Navigation("CaseEnemye");
                });

            modelBuilder.Entity("LawyerProject.Models.DB.MaktabTawseek", b =>
                {
                    b.Navigation("Tawkeels");
                });

            modelBuilder.Entity("LawyerProject.Models.DB.Nyaba", b =>
                {
                    b.Navigation("Dayras");
                });

            modelBuilder.Entity("LawyerProject.Models.DB.NyabaKind", b =>
                {
                    b.Navigation("Nyabas");
                });

            modelBuilder.Entity("LawyerProject.Models.DB.Tawkeel", b =>
                {
                    b.Navigation("TawkeelClients");
                });
#pragma warning restore 612, 618
        }
    }
}
