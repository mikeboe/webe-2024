﻿// <auto-generated />
using System;
using BlazorAppCrud.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BlazorAppCrud.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-rc.2.24474.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BlazorAppCrud.Models.Entities.AnswersClass", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("answer");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("boolean")
                        .HasColumnName("is_correct")
                        .HasAnnotation("Relational:JsonPropertyName", "is_correct");

                    b.Property<string>("QuestionId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("question_id");

                    b.Property<string>("QuestionsClassId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("questions_class_id");

                    b.HasKey("Id");

                    b.HasIndex("QuestionsClassId");

                    b.ToTable("answers", "public");
                });

            modelBuilder.Entity("BlazorAppCrud.Models.Entities.QuestionsClass", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("question")
                        .HasAnnotation("Relational:JsonPropertyName", "question");

                    b.Property<string>("TopicId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("topic_id");

                    b.HasKey("Id");

                    b.ToTable("questions", "public");
                });

            modelBuilder.Entity("BlazorAppCrud.Models.Entities.TopicClass", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.ToTable("topics", "public");
                });

            modelBuilder.Entity("BlazorAppCrud.Models.Entities.UserClass", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("role");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("userName");

                    b.HasKey("Id");

                    b.ToTable("users", "public");
                });

            modelBuilder.Entity("BlazorAppCrud.Models.Entities.AnswersClass", b =>
                {
                    b.HasOne("BlazorAppCrud.Models.Entities.QuestionsClass", null)
                        .WithMany("Answers")
                        .HasForeignKey("QuestionsClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BlazorAppCrud.Models.Entities.QuestionsClass", b =>
                {
                    b.Navigation("Answers");
                });
#pragma warning restore 612, 618
        }
    }
}
