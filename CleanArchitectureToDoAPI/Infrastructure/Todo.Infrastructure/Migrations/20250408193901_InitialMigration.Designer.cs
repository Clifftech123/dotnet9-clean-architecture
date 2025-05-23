﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Todo.Infrastructure.Context;

#nullable disable

namespace Todo.Infrastructure.Migrations
{
    [DbContext(typeof(TodoDbContext))]
    [Migration("20250408193901_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Todo.Domain.Entities.TodoCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("TodoCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Work related tasks",
                            Title = "Work"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Personal tasks",
                            Title = "Personal"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Shopping tasks",
                            Title = "Shopping"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Health related tasks",
                            Title = "Health"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Fitness related tasks",
                            Title = "Fitness"
                        });
                });

            modelBuilder.Entity("Todo.Domain.Entities.TodoItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDone")
                        .HasColumnType("bit");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("TodoCategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("TodoCategoryId");

                    b.ToTable("TodoItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateDate = new DateTime(2025, 4, 8, 19, 39, 1, 189, DateTimeKind.Local).AddTicks(3179),
                            DueDate = new DateTime(2025, 4, 9, 19, 39, 1, 188, DateTimeKind.Local).AddTicks(3041),
                            IsDone = false,
                            Note = "This is the first todo",
                            Title = "First Todo",
                            TodoCategoryId = 1,
                            UpdateDate = new DateTime(2025, 4, 8, 19, 39, 1, 189, DateTimeKind.Local).AddTicks(3365)
                        },
                        new
                        {
                            Id = 2,
                            CreateDate = new DateTime(2025, 4, 8, 19, 39, 1, 189, DateTimeKind.Local).AddTicks(3513),
                            DueDate = new DateTime(2025, 4, 10, 19, 39, 1, 189, DateTimeKind.Local).AddTicks(3509),
                            IsDone = false,
                            Note = "This is the second todo",
                            Title = "Second Todo",
                            TodoCategoryId = 2,
                            UpdateDate = new DateTime(2025, 4, 8, 19, 39, 1, 189, DateTimeKind.Local).AddTicks(3514)
                        },
                        new
                        {
                            Id = 3,
                            CreateDate = new DateTime(2025, 4, 8, 19, 39, 1, 189, DateTimeKind.Local).AddTicks(3516),
                            DueDate = new DateTime(2025, 4, 11, 19, 39, 1, 189, DateTimeKind.Local).AddTicks(3515),
                            IsDone = false,
                            Note = "This is the third todo",
                            Title = "Third Todo",
                            TodoCategoryId = 3,
                            UpdateDate = new DateTime(2025, 4, 8, 19, 39, 1, 189, DateTimeKind.Local).AddTicks(3516)
                        },
                        new
                        {
                            Id = 4,
                            CreateDate = new DateTime(2025, 4, 8, 19, 39, 1, 189, DateTimeKind.Local).AddTicks(3518),
                            DueDate = new DateTime(2025, 4, 12, 19, 39, 1, 189, DateTimeKind.Local).AddTicks(3517),
                            IsDone = false,
                            Note = "This is the fourth todo",
                            Title = "Fourth Todo",
                            TodoCategoryId = 4,
                            UpdateDate = new DateTime(2025, 4, 8, 19, 39, 1, 189, DateTimeKind.Local).AddTicks(3519)
                        });
                });

            modelBuilder.Entity("Todo.Domain.Entities.TodoItem", b =>
                {
                    b.HasOne("Todo.Domain.Entities.TodoCategory", "Category")
                        .WithMany("TodoItems")
                        .HasForeignKey("TodoCategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Todo.Domain.Entities.TodoCategory", b =>
                {
                    b.Navigation("TodoItems");
                });
#pragma warning restore 612, 618
        }
    }
}
