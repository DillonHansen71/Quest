using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Quest.Data.Migrations
{
    public partial class test4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Owner = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ItemImage = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Damage = table.Column<long>(nullable: false),
                    Value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Owner = table.Column<string>(nullable: true),
                    Gold = table.Column<long>(nullable: false),
                    ItemSlot1ID = table.Column<int>(nullable: true),
                    ItemSlot2ID = table.Column<int>(nullable: true),
                    ItemSlot3ID = table.Column<int>(nullable: true),
                    ItemSlot4ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Inventory_Item_ItemSlot1ID",
                        column: x => x.ItemSlot1ID,
                        principalTable: "Item",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inventory_Item_ItemSlot2ID",
                        column: x => x.ItemSlot2ID,
                        principalTable: "Item",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inventory_Item_ItemSlot3ID",
                        column: x => x.ItemSlot3ID,
                        principalTable: "Item",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inventory_Item_ItemSlot4ID",
                        column: x => x.ItemSlot4ID,
                        principalTable: "Item",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_ItemSlot1ID",
                table: "Inventory",
                column: "ItemSlot1ID");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_ItemSlot2ID",
                table: "Inventory",
                column: "ItemSlot2ID");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_ItemSlot3ID",
                table: "Inventory",
                column: "ItemSlot3ID");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_ItemSlot4ID",
                table: "Inventory",
                column: "ItemSlot4ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "Item");
        }
    }
}
