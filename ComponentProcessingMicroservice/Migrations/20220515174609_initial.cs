using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComponentProcessingMicroservice.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MasterTable",
                columns: table => new
                {
                    RequestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<string>(nullable: true),
                    ComponentType = table.Column<string>(nullable: true),
                    ComponentName = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    ProcessingCharge = table.Column<float>(nullable: false),
                    PackagingAndDeliveryCharge = table.Column<float>(nullable: false),
                    DateOfDelivery = table.Column<DateTime>(nullable: false),
                    CreditCardNumber = table.Column<string>(nullable: true),
                    CreditLimit = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterTable", x => x.RequestId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MasterTable");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
