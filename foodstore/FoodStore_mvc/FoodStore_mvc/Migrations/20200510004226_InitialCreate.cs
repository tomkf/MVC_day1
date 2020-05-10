using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodStore_mvc.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Building",
                columns: table => new
                {
                    building_name = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    unit_num = table.Column<int>(nullable: false),
                    capacity = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Building__14E071A0CB93A857", x => new { x.building_name, x.unit_num });
                });

            migrationBuilder.CreateTable(
                name: "Manufacturer",
                columns: table => new
                {
                    mfg = table.Column<string>(unicode: false, maxLength: 25, nullable: false),
                    mfgDiscount = table.Column<decimal>(type: "decimal(18, 0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Manufact__DF50190DF6A5C524", x => x.mfg);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    vendor = table.Column<string>(unicode: false, maxLength: 25, nullable: false),
                    supplier_email = table.Column<string>(unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Supplier__42A1EB1C928D5FA1", x => x.vendor);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    branch = table.Column<string>(unicode: false, maxLength: 25, nullable: false),
                    region = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    building_name = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    unit_num = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Store__1F8431240463D376", x => x.branch);
                    table.ForeignKey(
                        name: "FK__Store__2F10007B",
                        columns: x => new { x.building_name, x.unit_num },
                        principalTable: "Building",
                        principalColumns: new[] { "building_name", "unit_num" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    productID = table.Column<int>(nullable: false),
                    name = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    mfg = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    vendor = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    price = table.Column<decimal>(type: "money", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.productID);
                    table.ForeignKey(
                        name: "FK__Product__mfg__286302EC",
                        column: x => x.mfg,
                        principalTable: "Manufacturer",
                        principalColumn: "mfg",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Product__vendor__29572725",
                        column: x => x.vendor,
                        principalTable: "Supplier",
                        principalColumn: "vendor",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    employee_id = table.Column<int>(nullable: false),
                    last_name = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    first_name = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    branch = table.Column<string>(unicode: false, maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.employee_id);
                    table.ForeignKey(
                        name: "FK__Employee__branch__4316F928",
                        column: x => x.branch,
                        principalTable: "Store",
                        principalColumn: "branch",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    invoiceNum = table.Column<int>(nullable: false),
                    branch = table.Column<string>(unicode: false, maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Invoice__F9EE1383938C89D4", x => x.invoiceNum);
                    table.ForeignKey(
                        name: "FK__Invoice__branch__31EC6D26",
                        column: x => x.branch,
                        principalTable: "Store",
                        principalColumn: "branch",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrder",
                columns: table => new
                {
                    po_num = table.Column<int>(nullable: false),
                    branch = table.Column<string>(unicode: false, maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Purchase__0FCD54D5F13621BE", x => x.po_num);
                    table.ForeignKey(
                        name: "FK__PurchaseO__branc__3C69FB99",
                        column: x => x.branch,
                        principalTable: "Store",
                        principalColumn: "branch",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductInvoice",
                columns: table => new
                {
                    productID = table.Column<int>(nullable: false),
                    invoiceNum = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ProductI__028E3072E4210938", x => new { x.productID, x.invoiceNum });
                    table.ForeignKey(
                        name: "FK__ProductIn__invoi__35BCFE0A",
                        column: x => x.invoiceNum,
                        principalTable: "Invoice",
                        principalColumn: "invoiceNum",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__ProductIn__produ__34C8D9D1",
                        column: x => x.productID,
                        principalTable: "Product",
                        principalColumn: "productID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductInvoiceWithQuantity",
                columns: table => new
                {
                    productID = table.Column<int>(nullable: false),
                    invoiceNum = table.Column<int>(nullable: false),
                    quantity = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ProductI__028E3072658FC761", x => new { x.productID, x.invoiceNum });
                    table.ForeignKey(
                        name: "FK__ProductIn__invoi__398D8EEE",
                        column: x => x.invoiceNum,
                        principalTable: "Invoice",
                        principalColumn: "invoiceNum",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__ProductIn__produ__38996AB5",
                        column: x => x.productID,
                        principalTable: "Product",
                        principalColumn: "productID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductPurchaseOrder",
                columns: table => new
                {
                    productID = table.Column<int>(nullable: false),
                    po_num = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ProductP__6DEC0407F891FA0E", x => new { x.productID, x.po_num });
                    table.ForeignKey(
                        name: "FK__ProductPu__po_nu__403A8C7D",
                        column: x => x.po_num,
                        principalTable: "PurchaseOrder",
                        principalColumn: "po_num",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__ProductPu__produ__3F466844",
                        column: x => x.productID,
                        principalTable: "Product",
                        principalColumn: "productID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_branch",
                table: "Employee",
                column: "branch");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_branch",
                table: "Invoice",
                column: "branch");

            migrationBuilder.CreateIndex(
                name: "IX_Product_mfg",
                table: "Product",
                column: "mfg");

            migrationBuilder.CreateIndex(
                name: "IX_Product_vendor",
                table: "Product",
                column: "vendor");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInvoice_invoiceNum",
                table: "ProductInvoice",
                column: "invoiceNum");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInvoiceWithQuantity_invoiceNum",
                table: "ProductInvoiceWithQuantity",
                column: "invoiceNum");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPurchaseOrder_po_num",
                table: "ProductPurchaseOrder",
                column: "po_num");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrder_branch",
                table: "PurchaseOrder",
                column: "branch");

            migrationBuilder.CreateIndex(
                name: "IX_Store_building_name_unit_num",
                table: "Store",
                columns: new[] { "building_name", "unit_num" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "ProductInvoice");

            migrationBuilder.DropTable(
                name: "ProductInvoiceWithQuantity");

            migrationBuilder.DropTable(
                name: "ProductPurchaseOrder");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "PurchaseOrder");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropTable(
                name: "Manufacturer");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "Building");
        }
    }
}
