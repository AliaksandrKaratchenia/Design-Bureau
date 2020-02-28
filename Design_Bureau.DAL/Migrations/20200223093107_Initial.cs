using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Design_Bureau.DAL.Migrations
{
    public partial class Initial : Migration
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
                name: "PriceDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DesignCost = table.Column<double>(nullable: false),
                    ConstructionCost = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TermsOfReferences",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    IsRegistered = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TermsOfReferences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Role = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MultiStoreyHouseProjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    TermsOfReferenceId = table.Column<int>(nullable: false),
                    PriceDetailsId = table.Column<int>(nullable: false),
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
                    table.ForeignKey(
                        name: "FK_MultiStoreyHouseProjects_PriceDetails_PriceDetailsId",
                        column: x => x.PriceDetailsId,
                        principalTable: "PriceDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MultiStoreyHouseProjects_TermsOfReferences_TermsOfReferenceId",
                        column: x => x.TermsOfReferenceId,
                        principalTable: "TermsOfReferences",
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
                    MultiStoreyHouseProjectId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Designers_MultiStoreyHouseProjects_MultiStoreyHouseProjectId",
                        column: x => x.MultiStoreyHouseProjectId,
                        principalTable: "MultiStoreyHouseProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "IX_MultiStoreyHouseProjects_PriceDetailsId",
                table: "MultiStoreyHouseProjects",
                column: "PriceDetailsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MultiStoreyHouseProjects_TermsOfReferenceId",
                table: "MultiStoreyHouseProjects",
                column: "TermsOfReferenceId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Designers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "MultiStoreyHouseProjects");

            migrationBuilder.DropTable(
                name: "ChiefDesigners");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "PriceDetails");

            migrationBuilder.DropTable(
                name: "TermsOfReferences");
        }
    }
}
