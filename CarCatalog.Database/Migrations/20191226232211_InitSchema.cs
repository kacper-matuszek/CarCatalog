using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarCatalog.Database.Migrations
{
    public partial class InitSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PictureName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Engine",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Code = table.Column<int>(nullable: false),
                    Capacity = table.Column<float>(nullable: false),
                    HorsePower = table.Column<int>(nullable: false),
                    KiloWat = table.Column<int>(nullable: false),
                    Fuel = table.Column<int>(nullable: false),
                    AmountCylinders = table.Column<int>(nullable: false),
                    Turbo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engine", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    Avatar = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Catalog_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EngineId = table.Column<Guid>(nullable: false),
                    CategoryId = table.Column<Guid>(nullable: false),
                    CatalogId = table.Column<Guid>(nullable: false),
                    VIN = table.Column<string>(nullable: true),
                    Manufacturer = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Mileage = table.Column<int>(nullable: false),
                    Color = table.Column<string>(nullable: true),
                    DriveType = table.Column<int>(nullable: false),
                    GearBox = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    AmountDoors = table.Column<int>(nullable: false),
                    AmountSeats = table.Column<int>(nullable: false),
                    OriginCountry = table.Column<string>(nullable: true),
                    PictureName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Car_Catalog_CatalogId",
                        column: x => x.CatalogId,
                        principalTable: "Catalog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Car_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Car_Engine_EngineId",
                        column: x => x.EngineId,
                        principalTable: "Engine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name", "PictureName" },
                values: new object[,]
                {
                    { new Guid("66d4775d-f4d3-4664-a69c-456cefeaefe8"), "Sport", "Sport.jpg" },
                    { new Guid("df26f0ba-854c-4f43-90f6-1abeab3ff092"), "Limousine", "Limousine.jpg" },
                    { new Guid("c8786545-d6bd-4d84-9790-9cd67701db74"), "Passenger", "Passenger.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Engine",
                columns: new[] { "Id", "AmountCylinders", "Capacity", "Code", "Fuel", "HorsePower", "KiloWat", "Turbo" },
                values: new object[,]
                {
                    { new Guid("cee7f524-d325-48ac-9720-3ad28098b435"), 6, 3f, 45, 1, 231, 170, true },
                    { new Guid("5614a251-c9cc-4286-a808-cd0847ef2856"), 6, 3f, 50, 1, 286, 210, true },
                    { new Guid("fbfdc6f2-4a0c-4215-aa7a-5b14d0c0d5a4"), 6, 3f, 0, 1, 347, 255, true },
                    { new Guid("5215243f-c85a-420b-8283-b504cbb0fe8f"), 4, 2f, 40, 1, 204, 150, true },
                    { new Guid("5f6746d3-1a9c-4fc5-869a-6a5c8560fd6b"), 4, 2f, 40, 1, 190, 140, true },
                    { new Guid("7413db33-f1f1-45c8-98a4-c116c1e57a4c"), 4, 2f, 35, 1, 150, 110, true },
                    { new Guid("1f955975-5e38-42b6-bbef-8556941863b0"), 6, 3f, 55, 0, 340, 250, true },
                    { new Guid("afe256ad-8bc7-41fd-b163-bca69c94de2f"), 6, 2.9f, 0, 0, 450, 331, true },
                    { new Guid("25ccffa1-b364-4726-98e9-1afd4e963e1d"), 6, 3f, 0, 0, 354, 260, true },
                    { new Guid("2eed9dc3-45c9-44ea-91f7-74c74f639fc1"), 4, 2f, 45, 0, 245, 180, true },
                    { new Guid("2e793b29-ff25-4a23-b6fd-c04dd1cd5ad0"), 4, 2f, 40, 0, 190, 140, true },
                    { new Guid("f28e550b-6e49-4c4c-aafe-7cf2d1b66c77"), 4, 2f, 35, 0, 150, 110, true },
                    { new Guid("447d8039-02a0-47a7-bab9-57d4e0cbfe11"), 5, 2.5f, 0, 0, 400, 294, true },
                    { new Guid("053acf54-e485-4c69-b521-9a3e050c1e48"), 4, 2f, 0, 0, 300, 221, true },
                    { new Guid("909be4e1-5bfe-463a-adce-f2462c48d8bc"), 4, 1.4f, 0, 0, 204, 150, true },
                    { new Guid("23b87e53-36ee-4bf7-814b-834b5f209037"), 4, 2f, 40, 0, 200, 147, true },
                    { new Guid("87c9ee10-2f12-43f2-8042-def639afa3ee"), 4, 1.5f, 35, 0, 150, 110, true },
                    { new Guid("91627a36-4129-4286-9de1-8cac97073478"), 3, 1f, 30, 0, 116, 85, true },
                    { new Guid("bd26fb0f-015d-4625-9009-7af1797fc111"), 3, 1f, 25, 0, 95, 70, true }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Avatar", "UserName" },
                values: new object[,]
                {
                    { new Guid("e8657ca1-623b-445d-9ae1-42ae3b2bdce4"), "https://s3.amazonaws.com/uifaces/faces/twitter/dhrubo/128.jpg", "Marie.Gutkowski" },
                    { new Guid("3ab6fb24-46ea-40c8-be19-acd34b7d92cc"), "https://s3.amazonaws.com/uifaces/faces/twitter/Karimmove/128.jpg", "Jayda88" },
                    { new Guid("b66cb147-ab10-4f6a-ac42-f2f4374ff80d"), "https://s3.amazonaws.com/uifaces/faces/twitter/adhamdannaway/128.jpg", "Amalia.Wunsch" },
                    { new Guid("9cdf2f2e-e5e9-41a9-981c-7821519c63f6"), "https://s3.amazonaws.com/uifaces/faces/twitter/agustincruiz/128.jpg", "Billy.Durgan48" }
                });

            migrationBuilder.InsertData(
                table: "Catalog",
                columns: new[] { "Id", "CreatedDate", "Name", "UserId" },
                values: new object[] { new Guid("139d3f48-e507-447a-8ba5-27e03db09624"), new DateTime(2019, 12, 26, 22, 44, 17, 829, DateTimeKind.Local).AddTicks(8390), "eos", new Guid("e8657ca1-623b-445d-9ae1-42ae3b2bdce4") });

            migrationBuilder.InsertData(
                table: "Catalog",
                columns: new[] { "Id", "CreatedDate", "Name", "UserId" },
                values: new object[] { new Guid("6f86c1b9-1174-46d2-a369-9cbe1c0a116b"), new DateTime(2019, 12, 26, 15, 16, 18, 341, DateTimeKind.Local).AddTicks(414), "adipisci", new Guid("3ab6fb24-46ea-40c8-be19-acd34b7d92cc") });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "AmountDoors", "AmountSeats", "CatalogId", "CategoryId", "Color", "DriveType", "EngineId", "GearBox", "Manufacturer", "Mileage", "Model", "OriginCountry", "PictureName", "Type", "VIN" },
                values: new object[,]
                {
                    { new Guid("fa86e173-2a42-4a1d-86bb-a021a8c576c1"), 5, 3, new Guid("139d3f48-e507-447a-8ba5-27e03db09624"), new Guid("c8786545-d6bd-4d84-9790-9cd67701db74"), "gold", 2, new Guid("1f955975-5e38-42b6-bbef-8556941863b0"), 1, "Honda", 166847, "Element", "Ghana", "Honda.jpg", 3, "YK8D0EE05RJW12432" },
                    { new Guid("2cb9fc82-b79c-453c-a700-28cc10d97c12"), 2, 5, new Guid("6f86c1b9-1174-46d2-a369-9cbe1c0a116b"), new Guid("c8786545-d6bd-4d84-9790-9cd67701db74"), "ivory", 3, new Guid("053acf54-e485-4c69-b521-9a3e050c1e48"), 3, "Honda", 176509, "Expedition", "Congo", "Honda.jpg", 2, "KGRK9NU5XSVL37661" },
                    { new Guid("01fe8ead-e6b6-4821-862b-bbb47916e682"), 3, 5, new Guid("6f86c1b9-1174-46d2-a369-9cbe1c0a116b"), new Guid("66d4775d-f4d3-4664-a69c-456cefeaefe8"), "lime", 0, new Guid("7413db33-f1f1-45c8-98a4-c116c1e57a4c"), 2, "Audi", 46645, "Colorado", "Cook Islands", "Audi.jpg", 4, "LCXW1WJUXQJI74931" },
                    { new Guid("f3de44d4-6daf-4777-97c7-b8292d3ad4a1"), 5, 4, new Guid("6f86c1b9-1174-46d2-a369-9cbe1c0a116b"), new Guid("c8786545-d6bd-4d84-9790-9cd67701db74"), "green", 1, new Guid("23b87e53-36ee-4bf7-814b-834b5f209037"), 3, "Land Rover", 170765, "PT Cruiser", "Algeria", "Land Rover.jpg", 1, "0334BLXE7XZE94729" },
                    { new Guid("be009aca-498e-42ef-846d-8222c0b51334"), 4, 4, new Guid("6f86c1b9-1174-46d2-a369-9cbe1c0a116b"), new Guid("66d4775d-f4d3-4664-a69c-456cefeaefe8"), "cyan", 3, new Guid("2e793b29-ff25-4a23-b6fd-c04dd1cd5ad0"), 3, "Land Rover", 169618, "Charger", "El Salvador", "Land Rover.jpg", 4, "WZ9ROKT6SSRJ73285" },
                    { new Guid("dba4703d-61bb-4127-b8b7-797f9cd42ba3"), 2, 4, new Guid("6f86c1b9-1174-46d2-a369-9cbe1c0a116b"), new Guid("c8786545-d6bd-4d84-9790-9cd67701db74"), "maroon", 2, new Guid("1f955975-5e38-42b6-bbef-8556941863b0"), 0, "Jeep", 84206, "F-150", "Guinea", "Jeep.jpg", 4, "QMPXXZT3P3GC44044" },
                    { new Guid("e5a56b6e-f2de-4001-bc1b-d8ffd00db4fd"), 2, 2, new Guid("6f86c1b9-1174-46d2-a369-9cbe1c0a116b"), new Guid("c8786545-d6bd-4d84-9790-9cd67701db74"), "ivory", 3, new Guid("25ccffa1-b364-4726-98e9-1afd4e963e1d"), 3, "Tesla", 60134, "Golf", "Namibia", "Tesla.jpg", 2, "WZG1KCNJS2H926992" },
                    { new Guid("e7824811-48c9-4d8d-a208-d275b3d032ec"), 3, 5, new Guid("139d3f48-e507-447a-8ba5-27e03db09624"), new Guid("66d4775d-f4d3-4664-a69c-456cefeaefe8"), "grey", 3, new Guid("909be4e1-5bfe-463a-adce-f2462c48d8bc"), 2, "Kia", 111883, "ATS", "Maldives", "Kia.jpg", 4, "L7ZLSKUBK4Q646545" },
                    { new Guid("d08ce175-949c-46eb-ae98-597f90f5abcb"), 3, 5, new Guid("139d3f48-e507-447a-8ba5-27e03db09624"), new Guid("df26f0ba-854c-4f43-90f6-1abeab3ff092"), "indigo", 3, new Guid("f28e550b-6e49-4c4c-aafe-7cf2d1b66c77"), 2, "Maserati", 82063, "Camaro", "Peru", "Maserati.jpg", 1, "9MQPR2PNSOQ971072" },
                    { new Guid("0dec5f28-f4cd-4c15-b9e9-4cb526683bdd"), 5, 5, new Guid("139d3f48-e507-447a-8ba5-27e03db09624"), new Guid("c8786545-d6bd-4d84-9790-9cd67701db74"), "yellow", 0, new Guid("afe256ad-8bc7-41fd-b163-bca69c94de2f"), 0, "Volkswagen", 171127, "A8", "Lesotho", "Volkswagen.jpg", 2, "VC4BN35VH6EH34685" },
                    { new Guid("85a165d7-b868-47f9-9023-26dad5a1c821"), 2, 2, new Guid("139d3f48-e507-447a-8ba5-27e03db09624"), new Guid("66d4775d-f4d3-4664-a69c-456cefeaefe8"), "yellow", 3, new Guid("053acf54-e485-4c69-b521-9a3e050c1e48"), 2, "BMW", 112849, "Grand Cherokee", "British Indian Ocean Territory (Chagos Archipelago)", "BMW.jpg", 3, "QI51PMWZXWR138648" },
                    { new Guid("c59526eb-7eb5-4795-a5bc-b0edf165ac9f"), 5, 3, new Guid("139d3f48-e507-447a-8ba5-27e03db09624"), new Guid("df26f0ba-854c-4f43-90f6-1abeab3ff092"), "indigo", 1, new Guid("fbfdc6f2-4a0c-4215-aa7a-5b14d0c0d5a4"), 0, "Land Rover", 140379, "Mustang", "Croatia", "Land Rover.jpg", 4, "SQ8SZAHVROGS26496" },
                    { new Guid("b3f452dd-c4b2-44cb-b16c-d8c9cb445e54"), 4, 3, new Guid("139d3f48-e507-447a-8ba5-27e03db09624"), new Guid("c8786545-d6bd-4d84-9790-9cd67701db74"), "olive", 3, new Guid("cee7f524-d325-48ac-9720-3ad28098b435"), 3, "Toyota", 104244, "Golf", "Bahamas", "Toyota.jpg", 5, "CL1TEM2CADV292491" },
                    { new Guid("68b4dfb3-fd67-41b9-8bcf-88202dbf29b5"), 5, 3, new Guid("139d3f48-e507-447a-8ba5-27e03db09624"), new Guid("66d4775d-f4d3-4664-a69c-456cefeaefe8"), "silver", 2, new Guid("87c9ee10-2f12-43f2-8042-def639afa3ee"), 3, "Dodge", 44699, "Camry", "Barbados", "Dodge.jpg", 1, "22N98ZT8G1BM39572" },
                    { new Guid("e9435900-4c9b-45e4-bdc9-aed7d774f1a6"), 3, 4, new Guid("139d3f48-e507-447a-8ba5-27e03db09624"), new Guid("66d4775d-f4d3-4664-a69c-456cefeaefe8"), "tan", 3, new Guid("2eed9dc3-45c9-44ea-91f7-74c74f639fc1"), 2, "Aston Martin", 40374, "Charger", "Holy See (Vatican City State)", "Aston Martin.jpg", 3, "JLKSW6WXNBZC87345" },
                    { new Guid("d1e74571-4ca7-4848-a8c5-9c10ce038bdb"), 5, 2, new Guid("139d3f48-e507-447a-8ba5-27e03db09624"), new Guid("66d4775d-f4d3-4664-a69c-456cefeaefe8"), "olive", 3, new Guid("2eed9dc3-45c9-44ea-91f7-74c74f639fc1"), 2, "BMW", 18634, "Civic", "Slovenia", "BMW.jpg", 0, "Q96XY2NU44D871613" },
                    { new Guid("cb413d95-5a10-4931-8ff0-1cbe5c81f50b"), 4, 2, new Guid("139d3f48-e507-447a-8ba5-27e03db09624"), new Guid("df26f0ba-854c-4f43-90f6-1abeab3ff092"), "lime", 3, new Guid("2eed9dc3-45c9-44ea-91f7-74c74f639fc1"), 3, "Maserati", 174551, "Escalade", "Zambia", "Maserati.jpg", 3, "QUBXPIBNLZQZ45103" },
                    { new Guid("ae756af4-a6a2-4eeb-b16c-988e8e1cd4e3"), 4, 5, new Guid("139d3f48-e507-447a-8ba5-27e03db09624"), new Guid("df26f0ba-854c-4f43-90f6-1abeab3ff092"), "gold", 2, new Guid("5f6746d3-1a9c-4fc5-869a-6a5c8560fd6b"), 2, "Jaguar", 192680, "CTS", "Cyprus", "Jaguar.jpg", 3, "PJAJXEQTROOP49093" },
                    { new Guid("0576073d-3ca5-4cb7-a4b5-5debb0a8fa8f"), 2, 2, new Guid("6f86c1b9-1174-46d2-a369-9cbe1c0a116b"), new Guid("c8786545-d6bd-4d84-9790-9cd67701db74"), "purple", 3, new Guid("fbfdc6f2-4a0c-4215-aa7a-5b14d0c0d5a4"), 3, "Chevrolet", 40919, "Explorer", "Hungary", "Chevrolet.jpg", 1, "ZDT2QL3NMDSG41120" },
                    { new Guid("ff703e03-d38a-4b5d-8808-e06c673051f4"), 2, 5, new Guid("6f86c1b9-1174-46d2-a369-9cbe1c0a116b"), new Guid("66d4775d-f4d3-4664-a69c-456cefeaefe8"), "white", 3, new Guid("1f955975-5e38-42b6-bbef-8556941863b0"), 0, "Aston Martin", 199513, "Colorado", "Antigua and Barbuda", "Aston Martin.jpg", 5, "JA3C732QZDYU71904" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_CatalogId",
                table: "Car",
                column: "CatalogId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_CategoryId",
                table: "Car",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_EngineId",
                table: "Car",
                column: "EngineId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_UserId",
                table: "Catalog",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "Catalog");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Engine");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
