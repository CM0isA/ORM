using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ORM2.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    customerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    zipcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    state = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    county = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.customerID);
                });

            migrationBuilder.CreateTable(
                name: "freelancers",
                columns: table => new
                {
                    freelancerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    freelancer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    zipcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    state = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    county = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_freelancers", x => x.freelancerID);
                });

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    priceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.priceID);
                });

            migrationBuilder.CreateTable(
                name: "projects",
                columns: table => new
                {
                    projectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estimation = table.Column<int>(type: "int", nullable: false),
                    customerID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projects", x => x.projectID);
                    table.ForeignKey(
                        name: "FK_projects_Customers_customerID",
                        column: x => x.customerID,
                        principalTable: "Customers",
                        principalColumn: "customerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "times",
                columns: table => new
                {
                    LogID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    freelancerID = table.Column<int>(type: "int", nullable: true),
                    workday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    hours = table.Column<int>(type: "int", nullable: false),
                    projectID = table.Column<int>(type: "int", nullable: true),
                    priceID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_times", x => x.LogID);
                    table.ForeignKey(
                        name: "FK_times_freelancers_freelancerID",
                        column: x => x.freelancerID,
                        principalTable: "freelancers",
                        principalColumn: "freelancerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_times_Prices_priceID",
                        column: x => x.priceID,
                        principalTable: "Prices",
                        principalColumn: "priceID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_times_projects_projectID",
                        column: x => x.projectID,
                        principalTable: "projects",
                        principalColumn: "projectID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_projects_customerID",
                table: "projects",
                column: "customerID");

            migrationBuilder.CreateIndex(
                name: "IX_times_freelancerID",
                table: "times",
                column: "freelancerID");

            migrationBuilder.CreateIndex(
                name: "IX_times_priceID",
                table: "times",
                column: "priceID");

            migrationBuilder.CreateIndex(
                name: "IX_times_projectID",
                table: "times",
                column: "projectID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "times");

            migrationBuilder.DropTable(
                name: "freelancers");

            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "projects");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
