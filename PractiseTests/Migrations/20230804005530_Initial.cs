using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PractiseTests.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Certifications",
                columns: table => new
                {
                    CertificationTestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CertificationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CertificationDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NoTestPapers = table.Column<int>(type: "int", nullable: false),
                    Questions = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certifications", x => x.CertificationTestId);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    ContactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.ContactId);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    OrderItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CategoryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.OrderItemId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    ProdCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.ProdCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "TestPaper",
                columns: table => new
                {
                    TestPaperId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestPaperName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CertificationTestId = table.Column<int>(type: "int", nullable: false),
                    QuestionNo = table.Column<int>(type: "int", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorrectAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestPaper", x => x.TestPaperId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RememberMe = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "Certifications",
                columns: new[] { "CertificationTestId", "Active", "CertificationDescription", "CertificationName", "FileName", "NoTestPapers", "Price", "Questions" },
                values: new object[,]
                {
                    { 2, true, "DevOps Foundation", "DevOps Foundation", "devopsfoundation.png", 6, 20m, 30 },
                    { 3, true, "DevOps Leader", "DevOps Leader", "DevOpsLeader.png", 6, 25m, 30 },
                    { 4, true, "DevSecOps Foundation", "DevSecOps Foundation", "DevSecOps.png", 6, 20m, 30 },
                    { 5, true, "DevSecOps Practioner", "DevSecOps Practioner", "devsecopspract.png", 6, 25m, 30 }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "OrderId", "Active", "OrderDate", "OrderNo" },
                values: new object[] { 1, "Y", new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "C001" });

            migrationBuilder.InsertData(
                table: "OrderItem",
                columns: new[] { "OrderItemId", "CategoryCode", "OrderId", "ProductId", "Quantity", "TotPrice" },
                values: new object[,]
                {
                    { 1, "C", 1, 1, 2, 0m },
                    { 2, "C", 1, 2, 2, 0m }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "CategoryCode", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "C", "DevOps Foundation", "DevOps Foundation", 20m },
                    { 2, "C", "DevOps Leader", "DevOps Leader", 25m },
                    { 3, "C", "DevOps Foundation", "DevSecOps Foundation", 20m },
                    { 4, "C", "DevOps Leader", "DevSecOps Practioner", 25m }
                });

            migrationBuilder.InsertData(
                table: "ProductCategory",
                columns: new[] { "ProdCategoryId", "CategoryCode", "CategoryName" },
                values: new object[] { 1, "C", "Certification" });

            migrationBuilder.InsertData(
                table: "TestPaper",
                columns: new[] { "TestPaperId", "Active", "Answer1", "Answer2", "Answer3", "Answer4", "CertificationTestId", "CorrectAnswer", "Question", "QuestionNo", "TestPaperName" },
                values: new object[,]
                {
                    { 2, false, "A. Methodology for identifying and removing constraints", "B. The key principles of DevOps", "C. Disciplined, data-driven approach for reducing waste ", "D. A methodology for performing continuous improvement ", 2, "B", "What is the Three Ways?", 1, "TestPaper-1" },
                    { 3, false, "A. Pushes work through a process ", "B. Requires a workflow management tool ", "C. Pulls work through a process ", "D. Enables more work in progress ", 2, "C", "Which statement about Kanban is CORRECT?", 2, "TestPaper-1" },
                    { 4, false, "A. Aggressive resistance", "B. Apathy ", "C. Finger pointing ", "D. Exhaustion ", 2, "B", "Which statement BEST describes change fatigue? ", 1, "TestPaper-2" },
                    { 5, true, "A. QA testers ", "B. Support professionals ", "C. Suppliers ", "D. All of the above ", 2, "D", "Which of the following roles are DevOps stakeholders? ", 1, "TestPaper-1" },
                    { 6, false, "A. QA testers ", "B. Support professionals ", "C. Suppliers ", "D. All of the above ", 3, "D", "Which of the following roles are DevOps stakeholders? ", 1, "TestPaper-1" },
                    { 7, true, "A. QA testers ", "B. Support professionals ", "C. Suppliers ", "D. All of the above ", 3, "D", "Which of the following roles are DevOps stakeholders? ", 1, "TestPaper-1" },
                    { 8, true, "A. QA testers ", "B. Support professionals ", "C. Suppliers ", "D. All of the above ", 3, "D", "Which of the following roles are DevOps stakeholders? ", 1, "TestPaper-2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Certifications");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.DropTable(
                name: "TestPaper");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
