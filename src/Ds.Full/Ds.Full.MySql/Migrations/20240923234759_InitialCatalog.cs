using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ds.Full.MySql.Migrations
{
    /// <inheritdoc />
    public partial class InitialCatalog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(256)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Rating = table.Column<sbyte>(type: "TINYINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PkCategoryId", x => x.Id);
                },
                comment: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    Code = table.Column<string>(type: "VARCHAR(64)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "VARCHAR(128)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PkProfileId", x => x.Id);
                },
                comment: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    ProfileId = table.Column<int>(type: "INT", nullable: false),
                    PersonId = table.Column<long>(type: "BIGINT", nullable: true),
                    UserName = table.Column<string>(type: "VARCHAR(64)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<ulong>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PkUserId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profile_TO_User_ON_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    UserId = table.Column<int>(type: "INT", nullable: true),
                    FullName = table.Column<string>(type: "VARCHAR(256)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BirthDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    PersonType = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PkPersonId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_TO_User_ON_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    RentalId = table.Column<long>(type: "BIGINT", nullable: false),
                    CustomerId = table.Column<long>(type: "BIGINT", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    RentalFee = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    OtherFee = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: true),
                    OverdueFee = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: true),
                    RewindFee = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PkPaymentId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_TO_Payment_ON_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PersonAddress",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PersonId = table.Column<long>(type: "BIGINT", nullable: false),
                    AddressType = table.Column<short>(type: "SMALLINT", nullable: false),
                    Address = table.Column<string>(type: "VARCHAR(128)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PkPersonAddressId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_TO_PersonAddress_ON_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PersonContact",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PersonId = table.Column<long>(type: "BIGINT", nullable: false),
                    ContactType = table.Column<short>(type: "SMALLINT", nullable: false),
                    Contact = table.Column<string>(type: "VARCHAR(128)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PkPersonContactId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_TO_PersonContact_ON_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Title",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    CategoryId = table.Column<int>(type: "INT", nullable: false),
                    AuthorId = table.Column<long>(type: "BIGINT", nullable: true),
                    ProducerId = table.Column<long>(type: "BIGINT", nullable: true),
                    FullName = table.Column<string>(type: "VARCHAR(256)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReleaseDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    MediaType = table.Column<sbyte>(type: "TINYINT", nullable: false),
                    ContentType = table.Column<sbyte>(type: "TINYINT", nullable: false),
                    Rating = table.Column<sbyte>(type: "TINYINT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PkTitleId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_TO_Title_ON_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Person_TO_Title_ON_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Person_TO_Title_ON_ProducerId",
                        column: x => x.ProducerId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Rental",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    UserId = table.Column<int>(type: "INT", nullable: false),
                    CustomerId = table.Column<long>(type: "BIGINT", nullable: false),
                    PaymentId = table.Column<long>(type: "BIGINT", nullable: true),
                    Status = table.Column<sbyte>(type: "TINYINT", nullable: false),
                    RentalDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DeadlineDate = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    ReturnDate = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PkRentalId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rental_Person_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rental_TO_Payment_ON_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_TO_Rental_ON_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    TitleId = table.Column<long>(type: "BIGINT", nullable: false),
                    SupplierId = table.Column<long>(type: "BIGINT", nullable: false),
                    AcquisitionDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    AcquisitionValue = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    Status = table.Column<sbyte>(type: "TINYINT", nullable: false),
                    SellingDate = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    SellingValue = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PkInventoryId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_TO_Inventory_ON_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Title_TO_Inventory_ON_TitleId",
                        column: x => x.TitleId,
                        principalTable: "Title",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RentalItem",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RentalId = table.Column<long>(type: "BIGINT", nullable: false),
                    InventoryId = table.Column<long>(type: "BIGINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PkRentalItemId", x => x.Id);
                    table.ForeignKey(
                        name: "DK_Inventory_TO_RentalItem_ON_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rental_TO_RentalItem_ON_RentalId",
                        column: x => x.RentalId,
                        principalTable: "Rental",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_SupplierId",
                table: "Inventory",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_TitleId",
                table: "Inventory",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_CustomerId",
                table: "Payment",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_UserId",
                table: "Person",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonAddress_PersonId",
                table: "PersonAddress",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonContact_PersonId",
                table: "PersonContact",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Rental_CustomerId",
                table: "Rental",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Rental_PaymentId",
                table: "Rental",
                column: "PaymentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rental_UserId",
                table: "Rental",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RentalItem_InventoryId",
                table: "RentalItem",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RentalItem_RentalId",
                table: "RentalItem",
                column: "RentalId");

            migrationBuilder.CreateIndex(
                name: "IX_Title_AuthorId",
                table: "Title",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Title_CategoryId",
                table: "Title",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Title_ProducerId",
                table: "Title",
                column: "ProducerId");

            migrationBuilder.CreateIndex(
                name: "IX_User_ProfileId",
                table: "User",
                column: "ProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonAddress");

            migrationBuilder.DropTable(
                name: "PersonContact");

            migrationBuilder.DropTable(
                name: "RentalItem");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "Rental");

            migrationBuilder.DropTable(
                name: "Title");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Profile");
        }
    }
}
