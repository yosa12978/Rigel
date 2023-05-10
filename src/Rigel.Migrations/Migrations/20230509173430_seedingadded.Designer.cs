﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Rigel.EFCore.Data;

#nullable disable

namespace Rigel.Migrations.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230509173430_seedingadded")]
    partial class seedingadded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("Rigel.Core.Models.Category", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("categories");

                    b.HasData(
                        new
                        {
                            id = "aS2Fg5J77o",
                            name = "test1"
                        },
                        new
                        {
                            id = "aS2Fg5J77g",
                            name = "test2"
                        },
                        new
                        {
                            id = "aS2Fg5J77h",
                            name = "test3"
                        });
                });

            modelBuilder.Entity("Rigel.Core.Models.Message", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("TEXT");

                    b.Property<string>("authorId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("deleted")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("edited")
                        .HasColumnType("INTEGER");

                    b.Property<string>("parentId")
                        .HasColumnType("TEXT");

                    b.Property<string>("postId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("pubDate")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.HasIndex("authorId");

                    b.HasIndex("parentId");

                    b.HasIndex("postId");

                    b.ToTable("messages");

                    b.HasData(
                        new
                        {
                            id = "1234567890",
                            authorId = "Ul524hmF82",
                            content = "test content 123",
                            deleted = false,
                            edited = false,
                            postId = "sdgweruhiq",
                            pubDate = new DateTime(2023, 5, 9, 20, 34, 30, 495, DateTimeKind.Local).AddTicks(8678)
                        },
                        new
                        {
                            id = "0987654321",
                            authorId = "h80G46mN5p",
                            content = "test reply 1",
                            deleted = false,
                            edited = false,
                            parentId = "1234567890",
                            postId = "sdgweruhiq",
                            pubDate = new DateTime(2023, 5, 9, 20, 34, 30, 495, DateTimeKind.Local).AddTicks(8687)
                        });
                });

            modelBuilder.Entity("Rigel.Core.Models.Post", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("TEXT");

                    b.Property<string>("authorId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("categoryId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("changeDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("deleted")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("edited")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("pubDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("subject")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.HasIndex("authorId");

                    b.HasIndex("categoryId");

                    b.ToTable("posts");

                    b.HasData(
                        new
                        {
                            id = "sdgweruhiq",
                            authorId = "h80G46mN5p",
                            categoryId = "aS2Fg5J77o",
                            changeDate = new DateTime(2023, 5, 9, 17, 34, 30, 495, DateTimeKind.Utc).AddTicks(8668),
                            deleted = false,
                            edited = false,
                            pubDate = new DateTime(2023, 5, 9, 17, 34, 30, 495, DateTimeKind.Utc).AddTicks(8668),
                            subject = "test subject 1"
                        },
                        new
                        {
                            id = "sdgwe3uhi1",
                            authorId = "h80G46mN5p",
                            categoryId = "aS2Fg5J77o",
                            changeDate = new DateTime(2023, 5, 9, 17, 34, 30, 495, DateTimeKind.Utc).AddTicks(8668),
                            deleted = false,
                            edited = false,
                            pubDate = new DateTime(2023, 5, 9, 17, 34, 30, 495, DateTimeKind.Utc).AddTicks(8668),
                            subject = "test subject 1"
                        });
                });

            modelBuilder.Entity("Rigel.Core.Models.User", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("TEXT");

                    b.Property<string>("avatar")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("isActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("nickname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("regDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("salt")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("users");

                    b.HasData(
                        new
                        {
                            id = "Ul524hmF82",
                            avatar = "https://cdn-6.motorsport.com/images/mgl/Y99JQRbY/s8/red-bull-racing-logo-1.jpg",
                            isActive = true,
                            nickname = "master",
                            password = "c73d82322484717cb277b3146a968928",
                            regDate = new DateTime(2023, 5, 9, 17, 34, 30, 495, DateTimeKind.Utc).AddTicks(8565),
                            role = "USER",
                            salt = "adminsalt",
                            username = "admin"
                        },
                        new
                        {
                            id = "h80G46mN5p",
                            avatar = "https://cdn.gpblog.com/news/2023/05/07/v2_large_7daff622d2093db14e6e82ff5810c16d444b8a8a.jpeg",
                            isActive = true,
                            nickname = "slave",
                            password = "22b1f2494b8b75f069b5b00cc29e07ef",
                            regDate = new DateTime(2023, 5, 9, 17, 34, 30, 495, DateTimeKind.Utc).AddTicks(8569),
                            role = "USER",
                            salt = "usersalt",
                            username = "user"
                        });
                });

            modelBuilder.Entity("Rigel.Core.Models.Message", b =>
                {
                    b.HasOne("Rigel.Core.Models.User", "author")
                        .WithMany("messages")
                        .HasForeignKey("authorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Rigel.Core.Models.Message", "parent")
                        .WithMany("replies")
                        .HasForeignKey("parentId");

                    b.HasOne("Rigel.Core.Models.Post", "post")
                        .WithMany("messages")
                        .HasForeignKey("postId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("author");

                    b.Navigation("parent");

                    b.Navigation("post");
                });

            modelBuilder.Entity("Rigel.Core.Models.Post", b =>
                {
                    b.HasOne("Rigel.Core.Models.User", "author")
                        .WithMany("posts")
                        .HasForeignKey("authorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Rigel.Core.Models.Category", "category")
                        .WithMany("posts")
                        .HasForeignKey("categoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("author");

                    b.Navigation("category");
                });

            modelBuilder.Entity("Rigel.Core.Models.Category", b =>
                {
                    b.Navigation("posts");
                });

            modelBuilder.Entity("Rigel.Core.Models.Message", b =>
                {
                    b.Navigation("replies");
                });

            modelBuilder.Entity("Rigel.Core.Models.Post", b =>
                {
                    b.Navigation("messages");
                });

            modelBuilder.Entity("Rigel.Core.Models.User", b =>
                {
                    b.Navigation("messages");

                    b.Navigation("posts");
                });
#pragma warning restore 612, 618
        }
    }
}