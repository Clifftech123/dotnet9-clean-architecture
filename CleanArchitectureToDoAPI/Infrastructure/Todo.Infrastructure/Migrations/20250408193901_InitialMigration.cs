using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Todo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TodoCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TodoItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDone = table.Column<bool>(type: "bit", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    TodoCategoryId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TodoItems_TodoCategories_TodoCategoryId",
                        column: x => x.TodoCategoryId,
                        principalTable: "TodoCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "TodoCategories",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "Work related tasks", "Work" },
                    { 2, "Personal tasks", "Personal" },
                    { 3, "Shopping tasks", "Shopping" },
                    { 4, "Health related tasks", "Health" },
                    { 5, "Fitness related tasks", "Fitness" }
                });

            migrationBuilder.InsertData(
                table: "TodoItems",
                columns: new[] { "Id", "CreateDate", "DueDate", "IsDone", "Note", "Title", "TodoCategoryId", "UpdateDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 4, 8, 19, 39, 1, 189, DateTimeKind.Local).AddTicks(3179), new DateTime(2025, 4, 9, 19, 39, 1, 188, DateTimeKind.Local).AddTicks(3041), false, "This is the first todo", "First Todo", 1, new DateTime(2025, 4, 8, 19, 39, 1, 189, DateTimeKind.Local).AddTicks(3365) },
                    { 2, new DateTime(2025, 4, 8, 19, 39, 1, 189, DateTimeKind.Local).AddTicks(3513), new DateTime(2025, 4, 10, 19, 39, 1, 189, DateTimeKind.Local).AddTicks(3509), false, "This is the second todo", "Second Todo", 2, new DateTime(2025, 4, 8, 19, 39, 1, 189, DateTimeKind.Local).AddTicks(3514) },
                    { 3, new DateTime(2025, 4, 8, 19, 39, 1, 189, DateTimeKind.Local).AddTicks(3516), new DateTime(2025, 4, 11, 19, 39, 1, 189, DateTimeKind.Local).AddTicks(3515), false, "This is the third todo", "Third Todo", 3, new DateTime(2025, 4, 8, 19, 39, 1, 189, DateTimeKind.Local).AddTicks(3516) },
                    { 4, new DateTime(2025, 4, 8, 19, 39, 1, 189, DateTimeKind.Local).AddTicks(3518), new DateTime(2025, 4, 12, 19, 39, 1, 189, DateTimeKind.Local).AddTicks(3517), false, "This is the fourth todo", "Fourth Todo", 4, new DateTime(2025, 4, 8, 19, 39, 1, 189, DateTimeKind.Local).AddTicks(3519) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TodoItems_TodoCategoryId",
                table: "TodoItems",
                column: "TodoCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TodoItems");

            migrationBuilder.DropTable(
                name: "TodoCategories");
        }
    }
}
