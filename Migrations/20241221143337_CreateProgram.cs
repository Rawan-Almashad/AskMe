using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AskMeProgram.Migrations
{
    /// <inheritdoc />
    public partial class CreateProgram : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionBody = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    QuestionAnswer = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Anonumous = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ToId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Threadds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThreadBody = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ThreadAnswer = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Anonumous = table.Column<bool>(type: "bit", nullable: false),
                    ToId = table.Column<int>(type: "int", nullable: false),
                    fromId = table.Column<int>(type: "int", nullable: false),
                    QuistionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Threadds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Threadds_Questions_QuistionId",
                        column: x => x.QuistionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_UserId",
                table: "Questions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Threadds_QuistionId",
                table: "Threadds",
                column: "QuistionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Threadds");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
