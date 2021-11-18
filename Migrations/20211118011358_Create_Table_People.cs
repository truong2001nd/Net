using Microsoft.EntityFrameworkCore.Migrations;

namespace NetMVC.Migrations
{
    public partial class Create_Table_People : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nguoi");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Person",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Person",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PeopleID",
                table: "Person",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PeopleName",
                table: "Person",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "PeopleID",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "PeopleName",
                table: "Person");

            migrationBuilder.CreateTable(
                name: "Nguoi",
                columns: table => new
                {
                    PersonID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    FullName = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    StudentCdoe = table.Column<int>(type: "INTEGER", nullable: true),
                    University = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nguoi", x => x.PersonID);
                });
        }
    }
}
