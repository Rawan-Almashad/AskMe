﻿// <auto-generated />
using AskMeProgram.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AskMeProgram.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241221143337_CreateProgram")]
    partial class CreateProgram
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AskMeProgram.Data.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Anonumous")
                        .HasColumnType("bit");

                    b.Property<string>("QuestionAnswer")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("QuestionBody")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("ToId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("AskMeProgram.Data.Models.Threadd", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Anonumous")
                        .HasColumnType("bit");

                    b.Property<int>("QuistionId")
                        .HasColumnType("int");

                    b.Property<string>("ThreadAnswer")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ThreadBody")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("ToId")
                        .HasColumnType("int");

                    b.Property<int>("fromId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuistionId");

                    b.ToTable("Threadds");
                });

            modelBuilder.Entity("AskMeProgram.Data.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AskMeProgram.Data.Models.Question", b =>
                {
                    b.HasOne("AskMeProgram.Data.Models.User", "User")
                        .WithMany("questions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("AskMeProgram.Data.Models.Threadd", b =>
                {
                    b.HasOne("AskMeProgram.Data.Models.Question", "Question")
                        .WithMany("threads")
                        .HasForeignKey("QuistionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("AskMeProgram.Data.Models.Question", b =>
                {
                    b.Navigation("threads");
                });

            modelBuilder.Entity("AskMeProgram.Data.Models.User", b =>
                {
                    b.Navigation("questions");
                });
#pragma warning restore 612, 618
        }
    }
}
