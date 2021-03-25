using Microsoft.EntityFrameworkCore.Migrations;

namespace ORM2.Migrations
{
    public partial class CreateAddressTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "address",
                table: "freelancers");

            migrationBuilder.DropColumn(
                name: "city",
                table: "freelancers");

            migrationBuilder.DropColumn(
                name: "county",
                table: "freelancers");

            migrationBuilder.DropColumn(
                name: "state",
                table: "freelancers");

            migrationBuilder.DropColumn(
                name: "zipcode",
                table: "freelancers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "address",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "county",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "state",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "zipcode",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "addressID",
                table: "freelancers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "addressID",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    addressID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    zipcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    state = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    county = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.addressID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_freelancers_addressID",
                table: "freelancers",
                column: "addressID");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_addressID",
                table: "Customers",
                column: "addressID");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Address_addressID",
                table: "Customers",
                column: "addressID",
                principalTable: "Address",
                principalColumn: "addressID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_freelancers_Address_addressID",
                table: "freelancers",
                column: "addressID",
                principalTable: "Address",
                principalColumn: "addressID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Address_addressID",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_freelancers_Address_addressID",
                table: "freelancers");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropIndex(
                name: "IX_freelancers_addressID",
                table: "freelancers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_addressID",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "addressID",
                table: "freelancers");

            migrationBuilder.DropColumn(
                name: "addressID",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "freelancers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "city",
                table: "freelancers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "county",
                table: "freelancers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "state",
                table: "freelancers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "zipcode",
                table: "freelancers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "county",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "state",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "zipcode",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
