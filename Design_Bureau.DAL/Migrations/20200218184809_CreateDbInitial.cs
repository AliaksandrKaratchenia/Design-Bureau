using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Design_Bureau.DAL.Migrations
{
    public partial class CreateDbInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChiefDesigners",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiefDesigners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MultiStoreyHouseProjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    ChiefDesignerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultiStoreyHouseProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MultiStoreyHouseProjects_ChiefDesigners_ChiefDesignerId",
                        column: x => x.ChiefDesignerId,
                        principalTable: "ChiefDesigners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MultiStoreyHouseProjects_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Designers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    MultiStoreyHouseProjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Designers_MultiStoreyHouseProjects_MultiStoreyHouseProjectId",
                        column: x => x.MultiStoreyHouseProjectId,
                        principalTable: "MultiStoreyHouseProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PriceDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DesignCost = table.Column<double>(nullable: false),
                    ConstructionCost = table.Column<double>(nullable: false),
                    MultiStoreyHouseProjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceDetails_MultiStoreyHouseProjects_MultiStoreyHouseProjectId",
                        column: x => x.MultiStoreyHouseProjectId,
                        principalTable: "MultiStoreyHouseProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TermsOfReferences",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsRegistered = table.Column<bool>(nullable: false),
                    MultiStoreyHouseProjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TermsOfReferences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TermsOfReferences_MultiStoreyHouseProjects_MultiStoreyHouseProjectId",
                        column: x => x.MultiStoreyHouseProjectId,
                        principalTable: "MultiStoreyHouseProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Designers_MultiStoreyHouseProjectId",
                table: "Designers",
                column: "MultiStoreyHouseProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_MultiStoreyHouseProjects_ChiefDesignerId",
                table: "MultiStoreyHouseProjects",
                column: "ChiefDesignerId");

            migrationBuilder.CreateIndex(
                name: "IX_MultiStoreyHouseProjects_CustomerId",
                table: "MultiStoreyHouseProjects",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceDetails_MultiStoreyHouseProjectId",
                table: "PriceDetails",
                column: "MultiStoreyHouseProjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TermsOfReferences_MultiStoreyHouseProjectId",
                table: "TermsOfReferences",
                column: "MultiStoreyHouseProjectId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Designers");

            migrationBuilder.DropTable(
                name: "PriceDetails");

            migrationBuilder.DropTable(
                name: "TermsOfReferences");

            migrationBuilder.DropTable(
                name: "MultiStoreyHouseProjects");

            migrationBuilder.DropTable(
                name: "ChiefDesigners");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
