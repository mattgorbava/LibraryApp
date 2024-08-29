﻿// <auto-generated />
using System;
using LibraryApp.Model.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibraryApp.Migrations
{
    [DbContext(typeof(LibraryDBContext))]
    [Migration("20240829143844_AuthorRefactoring2")]
    partial class AuthorRefactoring2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LibraryApp.Model.Entities.Author", b =>
                {
                    b.Property<string>("AuthorName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("AuthorName");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("LibraryApp.Model.Entities.Book", b =>
                {
                    b.Property<string>("BookId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FieldOfInterest")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsLendable")
                        .HasColumnType("bit");

                    b.Property<bool>("IsLent")
                        .HasColumnType("bit");

                    b.Property<bool>("IsLost")
                        .HasColumnType("bit");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookId");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("LibraryApp.Model.Entities.BookAuthor", b =>
                {
                    b.Property<string>("BookId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AuthorName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("BorrowDate")
                        .HasColumnType("datetime2");

                    b.HasKey("BookId", "AuthorName");

                    b.HasIndex("AuthorName");

                    b.ToTable("BookAuthor");
                });

            modelBuilder.Entity("LibraryApp.Model.Entities.Personnel", b =>
                {
                    b.Property<int>("PersonnelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonnelId"));

                    b.Property<DateTime>("EmploymentDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeregistered")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonnelId");

                    b.ToTable("Personnel");
                });

            modelBuilder.Entity("LibraryApp.Model.Entities.Subscriber", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CNP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsRegistered")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonId");

                    b.ToTable("Subscriber");
                });

            modelBuilder.Entity("LibraryApp.Model.Entities.BookAuthor", b =>
                {
                    b.HasOne("LibraryApp.Model.Entities.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryApp.Model.Entities.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });
#pragma warning restore 612, 618
        }
    }
}
