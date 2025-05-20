using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Investors.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssetClass",
                columns: table => new
                {
                    AssetClassID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetClass", x => x.AssetClassID);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryID);
                });

            migrationBuilder.CreateTable(
                name: "InvestorType",
                columns: table => new
                {
                    InvestorTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeOfInvestor = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestorType", x => x.InvestorTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Investor",
                columns: table => new
                {
                    InvestorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InvestorTypeID = table.Column<int>(type: "int", nullable: true),
                    CountryID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investor", x => x.InvestorID);
                    table.ForeignKey(
                        name: "FK_Investor_Country_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Country",
                        principalColumn: "CountryID");
                    table.ForeignKey(
                        name: "FK_Investor_InvestorType_InvestorTypeID",
                        column: x => x.InvestorTypeID,
                        principalTable: "InvestorType",
                        principalColumn: "InvestorTypeID");
                });

            migrationBuilder.CreateTable(
                name: "Commitment",
                columns: table => new
                {
                    CommitmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssetClassID = table.Column<int>(type: "int", nullable: true),
                    InvestorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commitment", x => x.CommitmentID);
                    table.ForeignKey(
                        name: "FK_Commitment_AssetClass_AssetClassID",
                        column: x => x.AssetClassID,
                        principalTable: "AssetClass",
                        principalColumn: "AssetClassID");
                    table.ForeignKey(
                        name: "FK_Commitment_Investor_InvestorID",
                        column: x => x.InvestorID,
                        principalTable: "Investor",
                        principalColumn: "InvestorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssetClass_Name",
                table: "AssetClass",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Commitment_AssetClassID",
                table: "Commitment",
                column: "AssetClassID");

            migrationBuilder.CreateIndex(
                name: "IX_Commitment_InvestorID",
                table: "Commitment",
                column: "InvestorID");

            migrationBuilder.CreateIndex(
                name: "IX_Country_Name",
                table: "Country",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Investor_CountryID",
                table: "Investor",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Investor_InvestorTypeID",
                table: "Investor",
                column: "InvestorTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_InvestorType_TypeOfInvestor",
                table: "InvestorType",
                column: "TypeOfInvestor",
                unique: true,
                filter: "[TypeOfInvestor] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commitment");

            migrationBuilder.DropTable(
                name: "AssetClass");

            migrationBuilder.DropTable(
                name: "Investor");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "InvestorType");
        }
    }
}
