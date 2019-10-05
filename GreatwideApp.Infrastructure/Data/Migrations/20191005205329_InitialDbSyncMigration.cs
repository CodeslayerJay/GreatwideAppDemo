using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GreatwideApp.Infrastructure.Data.Migrations
{
    public partial class InitialDbSyncMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Commented out so initial changes to the entities doesn't
            // override or update database constructs
            //migrationBuilder.EnsureSchema(
            //    name: "Production");

            //migrationBuilder.CreateTable(
            //    name: "ProductModel",
            //    schema: "Production",
            //    columns: table => new
            //    {
            //        ProductModelID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Name = table.Column<string>(maxLength: 50, nullable: false),
            //        CatalogDescription = table.Column<string>(type: "xml", nullable: true),
            //        Instructions = table.Column<string>(type: "xml", nullable: true),
            //        rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ProductModel", x => x.ProductModelID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Product",
            //    schema: "Production",
            //    columns: table => new
            //    {
            //        ProductID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Name = table.Column<string>(maxLength: 50, nullable: false),
            //        ProductNumber = table.Column<string>(maxLength: 25, nullable: false),
            //        MakeFlag = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
            //        FinishedGoodsFlag = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
            //        Color = table.Column<string>(maxLength: 15, nullable: true),
            //        SafetyStockLevel = table.Column<short>(nullable: false),
            //        ReorderPoint = table.Column<short>(nullable: false),
            //        StandardCost = table.Column<decimal>(type: "money", nullable: false),
            //        ListPrice = table.Column<decimal>(type: "money", nullable: false),
            //        Size = table.Column<string>(maxLength: 5, nullable: true),
            //        SizeUnitMeasureCode = table.Column<string>(maxLength: 3, nullable: true),
            //        WeightUnitMeasureCode = table.Column<string>(maxLength: 3, nullable: true),
            //        Weight = table.Column<decimal>(type: "decimal(8, 2)", nullable: true),
            //        DaysToManufacture = table.Column<int>(nullable: false),
            //        ProductLine = table.Column<string>(maxLength: 2, nullable: true),
            //        Class = table.Column<string>(maxLength: 2, nullable: true),
            //        Style = table.Column<string>(maxLength: 2, nullable: true),
            //        ProductModelID = table.Column<int>(nullable: true),
            //        SellStartDate = table.Column<DateTime>(type: "datetime", nullable: false),
            //        SellEndDate = table.Column<DateTime>(type: "datetime", nullable: true),
            //        DiscontinuedDate = table.Column<DateTime>(type: "datetime", nullable: true),
            //        rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
            //        ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Product", x => x.ProductID);
            //        table.ForeignKey(
            //            name: "FK_Product_ProductModel_ProductModelID",
            //            column: x => x.ProductModelID,
            //            principalSchema: "Production",
            //            principalTable: "ProductModel",
            //            principalColumn: "ProductModelID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ProductReview",
            //    schema: "Production",
            //    columns: table => new
            //    {
            //        ProductReviewID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        ProductID = table.Column<int>(nullable: false),
            //        ReviewerName = table.Column<string>(maxLength: 50, nullable: false),
            //        ReviewDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        EmailAddress = table.Column<string>(maxLength: 50, nullable: false),
            //        Rating = table.Column<int>(nullable: false),
            //        Comments = table.Column<string>(maxLength: 3850, nullable: true),
            //        ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ProductReview", x => x.ProductReviewID);
            //        table.ForeignKey(
            //            name: "FK_ProductReview_Product_ProductID",
            //            column: x => x.ProductID,
            //            principalSchema: "Production",
            //            principalTable: "Product",
            //            principalColumn: "ProductID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "AK_Product_Name",
            //    schema: "Production",
            //    table: "Product",
            //    column: "Name",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Product_ProductModelID",
            //    schema: "Production",
            //    table: "Product",
            //    column: "ProductModelID");

            //migrationBuilder.CreateIndex(
            //    name: "AK_Product_ProductNumber",
            //    schema: "Production",
            //    table: "Product",
            //    column: "ProductNumber",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "AK_Product_rowguid",
            //    schema: "Production",
            //    table: "Product",
            //    column: "rowguid",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "PXML_ProductModel_CatalogDescription",
            //    schema: "Production",
            //    table: "ProductModel",
            //    column: "CatalogDescription");

            //migrationBuilder.CreateIndex(
            //    name: "PXML_ProductModel_Instructions",
            //    schema: "Production",
            //    table: "ProductModel",
            //    column: "Instructions");

            //migrationBuilder.CreateIndex(
            //    name: "AK_ProductModel_Name",
            //    schema: "Production",
            //    table: "ProductModel",
            //    column: "Name",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "AK_ProductModel_rowguid",
            //    schema: "Production",
            //    table: "ProductModel",
            //    column: "rowguid",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_ProductReview_ProductID",
            //    schema: "Production",
            //    table: "ProductReview",
            //    column: "ProductID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ProductReview_ProductID_Name",
            //    schema: "Production",
            //    table: "ProductReview",
            //    columns: new[] { "Comments", "ProductID", "ReviewerName" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductReview",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "ProductModel",
                schema: "Production");
        }
    }
}
