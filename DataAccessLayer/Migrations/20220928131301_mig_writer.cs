using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig_writer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blog_Writers_WriterId",
                table: "Blog");

            migrationBuilder.AlterColumn<int>(
                name: "WriterId",
                table: "Blog",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "NewsLetter",
                columns: table => new
                {
                    MailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MailStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsLetter", x => x.MailID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_Writers_WriterId",
                table: "Blog",
                column: "WriterId",
                principalTable: "Writers",
                principalColumn: "WriterId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blog_Writers_WriterId",
                table: "Blog");

            migrationBuilder.DropTable(
                name: "NewsLetter");

            migrationBuilder.AlterColumn<int>(
                name: "WriterId",
                table: "Blog",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_Writers_WriterId",
                table: "Blog",
                column: "WriterId",
                principalTable: "Writers",
                principalColumn: "WriterId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
