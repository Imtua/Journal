﻿// <auto-generated />
using System;
using Journal.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Journal.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240412115221_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ArticleTag", b =>
                {
                    b.Property<Guid>("ArticlesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TagsId")
                        .HasColumnType("uuid");

                    b.HasKey("ArticlesId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("ArticleTag");
                });

            modelBuilder.Entity("Journal.Domain.Entities.Article", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Article", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("382b5a7b-d39a-4a76-b848-33cd03210187"),
                            Content = "Test Content1",
                            CreatedAt = new DateTime(2024, 4, 12, 11, 52, 19, 790, DateTimeKind.Utc).AddTicks(4975),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            Description = "Test Description1",
                            Title = "Test Article1",
                            UserId = new Guid("cff09933-e686-4448-98ad-7e438f8aa077")
                        },
                        new
                        {
                            Id = new Guid("c920547f-7075-4bff-8182-7960f63521bf"),
                            Content = "Test Content2",
                            CreatedAt = new DateTime(2024, 4, 12, 11, 52, 19, 790, DateTimeKind.Utc).AddTicks(4980),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            Description = "Test Description2",
                            Title = "Test Article2",
                            UserId = new Guid("cff09933-e686-4448-98ad-7e438f8aa077")
                        });
                });

            modelBuilder.Entity("Journal.Domain.Entities.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ArticleId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.HasIndex("UserId");

                    b.ToTable("Comment", (string)null);
                });

            modelBuilder.Entity("Journal.Domain.Entities.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Tag", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("ae4f8d18-2f24-4497-bf0d-08f428c8cab0"),
                            CreatedAt = new DateTime(2024, 4, 12, 11, 52, 19, 791, DateTimeKind.Utc).AddTicks(1336),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            Title = "Спорт"
                        },
                        new
                        {
                            Id = new Guid("ae38013a-a9ca-4029-96cf-3d91fe30fc8f"),
                            CreatedAt = new DateTime(2024, 4, 12, 11, 52, 19, 791, DateTimeKind.Utc).AddTicks(1338),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            Title = "Музыка"
                        },
                        new
                        {
                            Id = new Guid("3ef9b2a3-3759-492c-bb8a-8710a3553081"),
                            CreatedAt = new DateTime(2024, 4, 12, 11, 52, 19, 791, DateTimeKind.Utc).AddTicks(1340),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            Title = "Кино"
                        },
                        new
                        {
                            Id = new Guid("0d52f8ef-1ce1-49d1-b126-26989af3250d"),
                            CreatedAt = new DateTime(2024, 4, 12, 11, 52, 19, 791, DateTimeKind.Utc).AddTicks(1341),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            Title = "IT"
                        });
                });

            modelBuilder.Entity("Journal.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("cff09933-e686-4448-98ad-7e438f8aa077"),
                            CreatedAt = new DateTime(2024, 4, 12, 11, 52, 19, 791, DateTimeKind.Utc).AddTicks(4394),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            Login = "Test User",
                            Password = "querty"
                        });
                });

            modelBuilder.Entity("Journal.Domain.Entities.UserToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("RefreshTokenExpiryTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserToken");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f259eb19-bc6d-47a7-aa8e-98b314cc9d6f"),
                            RefreshToken = "QQQQQQ",
                            RefreshTokenExpiryTime = new DateTime(2024, 4, 19, 11, 52, 19, 791, DateTimeKind.Utc).AddTicks(6086),
                            UserId = new Guid("cff09933-e686-4448-98ad-7e438f8aa077")
                        });
                });

            modelBuilder.Entity("ArticleTag", b =>
                {
                    b.HasOne("Journal.Domain.Entities.Article", null)
                        .WithMany()
                        .HasForeignKey("ArticlesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Journal.Domain.Entities.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Journal.Domain.Entities.Article", b =>
                {
                    b.HasOne("Journal.Domain.Entities.User", "User")
                        .WithMany("Articles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Journal.Domain.Entities.Comment", b =>
                {
                    b.HasOne("Journal.Domain.Entities.Article", "Article")
                        .WithMany("Comments")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Journal.Domain.Entities.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Journal.Domain.Entities.UserToken", b =>
                {
                    b.HasOne("Journal.Domain.Entities.User", "User")
                        .WithOne("UserToken")
                        .HasForeignKey("Journal.Domain.Entities.UserToken", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Journal.Domain.Entities.Article", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Journal.Domain.Entities.User", b =>
                {
                    b.Navigation("Articles");

                    b.Navigation("Comments");

                    b.Navigation("UserToken");
                });
#pragma warning restore 612, 618
        }
    }
}
