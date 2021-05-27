﻿// <auto-generated />
using System;
using LibraryManagement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LibraryManagement.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210525191757_Roles")]
    partial class Roles
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.Property<int>("AuthorsAuthorID")
                        .HasColumnType("int");

                    b.Property<int>("BooksBookID")
                        .HasColumnType("int");

                    b.HasKey("AuthorsAuthorID", "BooksBookID");

                    b.HasIndex("BooksBookID");

                    b.ToTable("AuthorBook");
                });

            modelBuilder.Entity("LibraryManagement.Models.Author", b =>
                {
                    b.Property<int>("AuthorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuthorID");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("LibraryManagement.Models.Book", b =>
                {
                    b.Property<int>("BookID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookID");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("LibraryManagement.Models.City", b =>
                {
                    b.Property<int>("CityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CityID");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            CityID = 1,
                            Name = "Adjud"
                        },
                        new
                        {
                            CityID = 2,
                            Name = "Aiud"
                        },
                        new
                        {
                            CityID = 3,
                            Name = "Alba Iulia"
                        },
                        new
                        {
                            CityID = 4,
                            Name = "Alexandria"
                        },
                        new
                        {
                            CityID = 5,
                            Name = "Arad"
                        },
                        new
                        {
                            CityID = 6,
                            Name = "Bacău"
                        },
                        new
                        {
                            CityID = 7,
                            Name = "Baia Mare"
                        },
                        new
                        {
                            CityID = 8,
                            Name = "Băilești"
                        },
                        new
                        {
                            CityID = 9,
                            Name = "Bârlad"
                        },
                        new
                        {
                            CityID = 10,
                            Name = "Beiuș"
                        },
                        new
                        {
                            CityID = 11,
                            Name = "Bistrița"
                        },
                        new
                        {
                            CityID = 12,
                            Name = "Blaj"
                        },
                        new
                        {
                            CityID = 13,
                            Name = "Botoșani"
                        },
                        new
                        {
                            CityID = 14,
                            Name = "Brad"
                        },
                        new
                        {
                            CityID = 15,
                            Name = "Brăila"
                        },
                        new
                        {
                            CityID = 16,
                            Name = "Brașov"
                        },
                        new
                        {
                            CityID = 17,
                            Name = "București"
                        },
                        new
                        {
                            CityID = 18,
                            Name = "Buzău"
                        },
                        new
                        {
                            CityID = 19,
                            Name = "Calafat"
                        },
                        new
                        {
                            CityID = 20,
                            Name = "Călărași"
                        },
                        new
                        {
                            CityID = 21,
                            Name = "Câmpia Turzii"
                        },
                        new
                        {
                            CityID = 22,
                            Name = "Câmpina"
                        },
                        new
                        {
                            CityID = 23,
                            Name = "Câmpulung"
                        },
                        new
                        {
                            CityID = 24,
                            Name = "Câmpulung Moldovenesc"
                        },
                        new
                        {
                            CityID = 25,
                            Name = "Caracal"
                        },
                        new
                        {
                            CityID = 26,
                            Name = "Caransebeș"
                        },
                        new
                        {
                            CityID = 27,
                            Name = "Carei"
                        },
                        new
                        {
                            CityID = 28,
                            Name = "Cluj Napoca"
                        },
                        new
                        {
                            CityID = 29,
                            Name = "Codlea"
                        },
                        new
                        {
                            CityID = 30,
                            Name = "Constanța"
                        },
                        new
                        {
                            CityID = 31,
                            Name = "Craiova"
                        },
                        new
                        {
                            CityID = 32,
                            Name = "Curtea de Argeș"
                        },
                        new
                        {
                            CityID = 33,
                            Name = "Dej"
                        },
                        new
                        {
                            CityID = 34,
                            Name = "Deva"
                        },
                        new
                        {
                            CityID = 35,
                            Name = "Dorohoi"
                        },
                        new
                        {
                            CityID = 36,
                            Name = "Drăgășani"
                        },
                        new
                        {
                            CityID = 37,
                            Name = "Drobeta-Turnu Severin"
                        },
                        new
                        {
                            CityID = 38,
                            Name = "Făgăraș"
                        },
                        new
                        {
                            CityID = 39,
                            Name = "Fălticeni"
                        },
                        new
                        {
                            CityID = 40,
                            Name = "Fetești"
                        },
                        new
                        {
                            CityID = 41,
                            Name = "Focșani"
                        },
                        new
                        {
                            CityID = 42,
                            Name = "Galați"
                        },
                        new
                        {
                            CityID = 43,
                            Name = "Gheorgheni"
                        },
                        new
                        {
                            CityID = 44,
                            Name = "Gherla"
                        },
                        new
                        {
                            CityID = 45,
                            Name = "Giurgiu"
                        },
                        new
                        {
                            CityID = 46,
                            Name = "Hunedoara"
                        },
                        new
                        {
                            CityID = 47,
                            Name = "Huși"
                        },
                        new
                        {
                            CityID = 48,
                            Name = "Iași"
                        },
                        new
                        {
                            CityID = 49,
                            Name = "Lugoj"
                        },
                        new
                        {
                            CityID = 50,
                            Name = "Lupeni"
                        },
                        new
                        {
                            CityID = 51,
                            Name = "Mangalia"
                        },
                        new
                        {
                            CityID = 52,
                            Name = "Marghita"
                        },
                        new
                        {
                            CityID = 53,
                            Name = "Medgidia"
                        },
                        new
                        {
                            CityID = 54,
                            Name = "Mediaș"
                        },
                        new
                        {
                            CityID = 55,
                            Name = "Miercurea Ciuc"
                        },
                        new
                        {
                            CityID = 56,
                            Name = "Moinești"
                        },
                        new
                        {
                            CityID = 57,
                            Name = "Moreni"
                        },
                        new
                        {
                            CityID = 58,
                            Name = "Motru"
                        },
                        new
                        {
                            CityID = 59,
                            Name = "Odorheiu Secuiesc"
                        },
                        new
                        {
                            CityID = 60,
                            Name = "Oltenița"
                        },
                        new
                        {
                            CityID = 61,
                            Name = "Onești"
                        },
                        new
                        {
                            CityID = 62,
                            Name = "Oradea"
                        },
                        new
                        {
                            CityID = 63,
                            Name = "Orăștie"
                        },
                        new
                        {
                            CityID = 64,
                            Name = "Orșova"
                        },
                        new
                        {
                            CityID = 65,
                            Name = "Pașcani"
                        },
                        new
                        {
                            CityID = 66,
                            Name = "Petroșani"
                        },
                        new
                        {
                            CityID = 67,
                            Name = "Piatra Neamț"
                        },
                        new
                        {
                            CityID = 68,
                            Name = "Pitești"
                        },
                        new
                        {
                            CityID = 69,
                            Name = "Ploiești"
                        },
                        new
                        {
                            CityID = 70,
                            Name = "Rădăuți"
                        },
                        new
                        {
                            CityID = 71,
                            Name = "Râmnicu Sărat"
                        },
                        new
                        {
                            CityID = 72,
                            Name = "Râmnicu Vâlcea"
                        },
                        new
                        {
                            CityID = 73,
                            Name = "Reghin"
                        },
                        new
                        {
                            CityID = 74,
                            Name = "Reșița"
                        },
                        new
                        {
                            CityID = 75,
                            Name = "Roman"
                        },
                        new
                        {
                            CityID = 76,
                            Name = "Roșiorii de Vede"
                        },
                        new
                        {
                            CityID = 77,
                            Name = "Săcele"
                        },
                        new
                        {
                            CityID = 78,
                            Name = "Salonta"
                        },
                        new
                        {
                            CityID = 79,
                            Name = "Satu Mare"
                        },
                        new
                        {
                            CityID = 80,
                            Name = "Sebeș"
                        },
                        new
                        {
                            CityID = 81,
                            Name = "Sfântu Gheorghe"
                        },
                        new
                        {
                            CityID = 82,
                            Name = "Sibiu"
                        },
                        new
                        {
                            CityID = 83,
                            Name = "Sighetu Marmației"
                        },
                        new
                        {
                            CityID = 84,
                            Name = "Sighișoara"
                        },
                        new
                        {
                            CityID = 85,
                            Name = "Slatina"
                        },
                        new
                        {
                            CityID = 86,
                            Name = "Slobozia"
                        },
                        new
                        {
                            CityID = 87,
                            Name = "Suceava"
                        },
                        new
                        {
                            CityID = 88,
                            Name = "Târgoviște"
                        },
                        new
                        {
                            CityID = 89,
                            Name = "Târgu Jiu"
                        },
                        new
                        {
                            CityID = 90,
                            Name = "Târgu Mureș"
                        },
                        new
                        {
                            CityID = 91,
                            Name = "Târgu Secuiesc"
                        },
                        new
                        {
                            CityID = 92,
                            Name = "Târnăveni"
                        },
                        new
                        {
                            CityID = 93,
                            Name = "Tecuci"
                        },
                        new
                        {
                            CityID = 94,
                            Name = "Timișoara"
                        },
                        new
                        {
                            CityID = 95,
                            Name = "Toplița"
                        },
                        new
                        {
                            CityID = 96,
                            Name = "Tulcea"
                        },
                        new
                        {
                            CityID = 97,
                            Name = "Turda"
                        },
                        new
                        {
                            CityID = 98,
                            Name = "Turnu Măgurele"
                        },
                        new
                        {
                            CityID = 99,
                            Name = "Urziceni"
                        },
                        new
                        {
                            CityID = 100,
                            Name = "Vaslui"
                        },
                        new
                        {
                            CityID = 101,
                            Name = "Vatra Dornei"
                        },
                        new
                        {
                            CityID = 102,
                            Name = "Vulcan"
                        },
                        new
                        {
                            CityID = 103,
                            Name = "Zalău"
                        });
                });

            modelBuilder.Entity("LibraryManagement.Models.Message", b =>
                {
                    b.Property<int>("MessageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("RequestID")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("MessageID");

                    b.HasIndex("RequestID");

                    b.HasIndex("UserID");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("LibraryManagement.Models.Request", b =>
                {
                    b.Property<int>("RequestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("BorrowDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ReturnDeadline")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("SubsidiaryID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("RequestID");

                    b.HasIndex("BookID");

                    b.HasIndex("SubsidiaryID");

                    b.HasIndex("UserID");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("LibraryManagement.Models.Stock", b =>
                {
                    b.Property<int>("StockID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookID")
                        .HasColumnType("int");

                    b.Property<int>("Borrowed")
                        .HasColumnType("int");

                    b.Property<int>("SubsidiaryID")
                        .HasColumnType("int");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.HasKey("StockID");

                    b.HasIndex("BookID");

                    b.HasIndex("SubsidiaryID");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("LibraryManagement.Models.Subsidiary", b =>
                {
                    b.Property<int>("SubsidiaryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CityID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubsidiaryID");

                    b.HasIndex("CityID");

                    b.ToTable("Subsidiaries");
                });

            modelBuilder.Entity("LibraryManagement.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Blacklisted")
                        .HasColumnType("bit");

                    b.Property<int>("CityID")
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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.HasIndex("CityID");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConcurrencyStamp = "fcdf80b3-9078-4225-a0ed-24685976ea0c",
                            Name = "User",
                            NormalizedName = "USER"
                        },
                        new
                        {
                            Id = 2,
                            ConcurrencyStamp = "4330b7a8-097e-49f1-ad00-ec8553d3a413",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.HasOne("LibraryManagement.Models.Author", null)
                        .WithMany()
                        .HasForeignKey("AuthorsAuthorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryManagement.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksBookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LibraryManagement.Models.Message", b =>
                {
                    b.HasOne("LibraryManagement.Models.Request", null)
                        .WithMany("Messages")
                        .HasForeignKey("RequestID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryManagement.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LibraryManagement.Models.Request", b =>
                {
                    b.HasOne("LibraryManagement.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryManagement.Models.Subsidiary", "Subsidiary")
                        .WithMany()
                        .HasForeignKey("SubsidiaryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryManagement.Models.User", "User")
                        .WithMany("Requests")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Subsidiary");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LibraryManagement.Models.Stock", b =>
                {
                    b.HasOne("LibraryManagement.Models.Book", "Book")
                        .WithMany("Stocks")
                        .HasForeignKey("BookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryManagement.Models.Subsidiary", "Subsidiary")
                        .WithMany()
                        .HasForeignKey("SubsidiaryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Subsidiary");
                });

            modelBuilder.Entity("LibraryManagement.Models.Subsidiary", b =>
                {
                    b.HasOne("LibraryManagement.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("LibraryManagement.Models.User", b =>
                {
                    b.HasOne("LibraryManagement.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("LibraryManagement.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("LibraryManagement.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryManagement.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("LibraryManagement.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LibraryManagement.Models.Book", b =>
                {
                    b.Navigation("Stocks");
                });

            modelBuilder.Entity("LibraryManagement.Models.Request", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("LibraryManagement.Models.User", b =>
                {
                    b.Navigation("Requests");
                });
#pragma warning restore 612, 618
        }
    }
}
