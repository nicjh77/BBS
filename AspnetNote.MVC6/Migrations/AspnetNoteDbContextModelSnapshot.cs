﻿// <auto-generated />
using AspnetNote.MVC6.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace AspnetNote.MVC6.Migrations
{
    [DbContext(typeof(AspnetNoteDbContext))]
    partial class AspnetNoteDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AspnetNote.MVC6.Models.Note", b =>
                {
                    b.Property<int>("NoteNo")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("NoteContents")
                        .IsRequired();

                    b.Property<string>("NoteTitle")
                        .IsRequired();

                    b.Property<int>("UserNo");

                    b.HasKey("NoteNo");

                    b.HasIndex("UserNo");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("AspnetNote.MVC6.Models.User", b =>
                {
                    b.Property<int>("UserNo")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.Property<string>("UserName")
                        .IsRequired();

                    b.Property<string>("UserPassword")
                        .IsRequired();

                    b.HasKey("UserNo");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AspnetNote.MVC6.Models.Note", b =>
                {
                    b.HasOne("AspnetNote.MVC6.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserNo")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}