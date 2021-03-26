using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddForeignKeyFreelancers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FreelancersFreelancerID",
                table: "Times",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Freelancers",
                columns: table => new
                {
                    FreelancerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FreelancerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Freelancers", x => x.FreelancerID);
                    table.ForeignKey(
                        name: "FK_Freelancers_Addresses_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Addresses",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Times_FreelancersFreelancerID",
                table: "Times",
                column: "FreelancersFreelancerID");

            migrationBuilder.CreateIndex(
                name: "IX_Freelancers_AddressID",
                table: "Freelancers",
                column: "AddressID");

            migrationBuilder.AddForeignKey(
                name: "FK_Times_Freelancers_FreelancersFreelancerID",
                table: "Times",
                column: "FreelancersFreelancerID",
                principalTable: "Freelancers",
                principalColumn: "FreelancerID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Times_Freelancers_FreelancersFreelancerID",
                table: "Times");

            migrationBuilder.DropTable(
                name: "Freelancers");

            migrationBuilder.DropIndex(
                name: "IX_Times_FreelancersFreelancerID",
                table: "Times");

            migrationBuilder.DropColumn(
                name: "FreelancersFreelancerID",
                table: "Times");
        }
    }
}
