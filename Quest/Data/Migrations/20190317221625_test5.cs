using Microsoft.EntityFrameworkCore.Migrations;

namespace Quest.Data.Migrations
{
    public partial class test5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Item_ItemSlot1ID",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Item_ItemSlot2ID",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Item_ItemSlot3ID",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Item_ItemSlot4ID",
                table: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_ItemSlot1ID",
                table: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_ItemSlot2ID",
                table: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_ItemSlot3ID",
                table: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_ItemSlot4ID",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "Owner",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "ItemSlot1ID",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "ItemSlot2ID",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "ItemSlot3ID",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "ItemSlot4ID",
                table: "Inventory");

            migrationBuilder.RenameColumn(
                name: "Owner",
                table: "Inventory",
                newName: "PlayerId");

            migrationBuilder.AddColumn<int>(
                name: "InventoryIDID",
                table: "Item",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PlayerId",
                table: "Inventory",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Item_InventoryIDID",
                table: "Item",
                column: "InventoryIDID");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_PlayerId",
                table: "Inventory",
                column: "PlayerId",
                unique: true,
                filter: "[PlayerId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Player_PlayerId",
                table: "Inventory",
                column: "PlayerId",
                principalTable: "Player",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Inventory_InventoryIDID",
                table: "Item",
                column: "InventoryIDID",
                principalTable: "Inventory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Player_PlayerId",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_Inventory_InventoryIDID",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_InventoryIDID",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_PlayerId",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "InventoryIDID",
                table: "Item");

            migrationBuilder.RenameColumn(
                name: "PlayerId",
                table: "Inventory",
                newName: "Owner");

            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "Item",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Owner",
                table: "Inventory",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemSlot1ID",
                table: "Inventory",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemSlot2ID",
                table: "Inventory",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemSlot3ID",
                table: "Inventory",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemSlot4ID",
                table: "Inventory",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Item_ItemSlot1ID",
                table: "Inventory",
                column: "ItemSlot1ID",
                principalTable: "Item",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Item_ItemSlot2ID",
                table: "Inventory",
                column: "ItemSlot2ID",
                principalTable: "Item",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Item_ItemSlot3ID",
                table: "Inventory",
                column: "ItemSlot3ID",
                principalTable: "Item",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Item_ItemSlot4ID",
                table: "Inventory",
                column: "ItemSlot4ID",
                principalTable: "Item",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
