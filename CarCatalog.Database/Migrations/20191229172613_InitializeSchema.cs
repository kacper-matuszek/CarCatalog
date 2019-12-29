using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarCatalog.Database.Migrations
{
    public partial class InitializeSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDateEntity = table.Column<DateTime>(nullable: false),
                    UpdateDateEntity = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
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
                    CreatedDateEntity = table.Column<DateTime>(nullable: false),
                    UpdateDateEntity = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Code = table.Column<string>(nullable: true),
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
                    CreatedDateEntity = table.Column<DateTime>(nullable: false),
                    UpdateDateEntity = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
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
                    CreatedDateEntity = table.Column<DateTime>(nullable: false),
                    UpdateDateEntity = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
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
                    CreatedDateEntity = table.Column<DateTime>(nullable: false),
                    UpdateDateEntity = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    EngineId = table.Column<Guid>(nullable: false),
                    CategoryId = table.Column<Guid>(nullable: false),
                    CatalogId = table.Column<Guid>(nullable: true),
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
                        onDelete: ReferentialAction.Restrict);
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
                columns: new[] { "Id", "CreatedDateEntity", "IsDeleted", "Name", "PictureName", "UpdateDateEntity" },
                values: new object[,]
                {
                    { new Guid("0c5f8f9e-a0e5-4698-87af-588da11adc6f"), new DateTime(2019, 12, 29, 18, 26, 12, 204, DateTimeKind.Local).AddTicks(9684), false, "Sport", "Sport.jpg", new DateTime(2019, 12, 29, 18, 26, 12, 204, DateTimeKind.Local).AddTicks(9717) },
                    { new Guid("055536e6-8d75-43ad-869f-5a77b6fa7ce7"), new DateTime(2019, 12, 29, 18, 26, 12, 205, DateTimeKind.Local).AddTicks(840), false, "Limousine", "Limousine.jpg", new DateTime(2019, 12, 29, 18, 26, 12, 205, DateTimeKind.Local).AddTicks(854) },
                    { new Guid("8411e08f-c1d9-4a7c-a3c8-5c7f956645f3"), new DateTime(2019, 12, 29, 18, 26, 12, 205, DateTimeKind.Local).AddTicks(877), false, "Passenger", "Passenger.jpg", new DateTime(2019, 12, 29, 18, 26, 12, 205, DateTimeKind.Local).AddTicks(880) }
                });

            migrationBuilder.InsertData(
                table: "Engine",
                columns: new[] { "Id", "AmountCylinders", "Capacity", "Code", "CreatedDateEntity", "Fuel", "HorsePower", "IsDeleted", "KiloWat", "Turbo", "UpdateDateEntity" },
                values: new object[,]
                {
                    { new Guid("1451ebb5-443d-4da3-91a6-c15052a64550"), 6, 3f, "45", new DateTime(2019, 12, 29, 18, 26, 12, 206, DateTimeKind.Local).AddTicks(8374), 1, 231, false, 170, true, new DateTime(2019, 12, 29, 18, 26, 12, 206, DateTimeKind.Local).AddTicks(8377) },
                    { new Guid("d20657e6-cd52-4282-9018-2bd17587119f"), 6, 3f, "50", new DateTime(2019, 12, 29, 18, 26, 12, 206, DateTimeKind.Local).AddTicks(8367), 1, 286, false, 210, true, new DateTime(2019, 12, 29, 18, 26, 12, 206, DateTimeKind.Local).AddTicks(8370) },
                    { new Guid("7176d110-4d14-4290-935c-3140156114e0"), 6, 3f, "50", new DateTime(2019, 12, 29, 18, 26, 12, 206, DateTimeKind.Local).AddTicks(8358), 1, 347, false, 255, true, new DateTime(2019, 12, 29, 18, 26, 12, 206, DateTimeKind.Local).AddTicks(8361) },
                    { new Guid("9e2e8a06-6932-4eaf-a502-d6dd8bbbf005"), 4, 2f, "40", new DateTime(2019, 12, 29, 18, 26, 12, 206, DateTimeKind.Local).AddTicks(8351), 1, 204, false, 150, true, new DateTime(2019, 12, 29, 18, 26, 12, 206, DateTimeKind.Local).AddTicks(8354) },
                    { new Guid("c0f13571-ef04-4bca-bc9a-c237b451e57b"), 4, 2f, "40", new DateTime(2019, 12, 29, 18, 26, 12, 206, DateTimeKind.Local).AddTicks(8343), 1, 190, false, 140, true, new DateTime(2019, 12, 29, 18, 26, 12, 206, DateTimeKind.Local).AddTicks(8346) },
                    { new Guid("4707a2db-5c6c-4689-8b13-7d1244e7b3a4"), 4, 2f, "35", new DateTime(2019, 12, 29, 18, 26, 12, 206, DateTimeKind.Local).AddTicks(8336), 1, 150, false, 110, true, new DateTime(2019, 12, 29, 18, 26, 12, 206, DateTimeKind.Local).AddTicks(8339) },
                    { new Guid("e238cfff-9c27-4a9a-ac24-31f153a0e2ea"), 6, 3f, "55", new DateTime(2019, 12, 29, 18, 26, 12, 206, DateTimeKind.Local).AddTicks(8326), 0, 340, false, 250, true, new DateTime(2019, 12, 29, 18, 26, 12, 206, DateTimeKind.Local).AddTicks(8329) },
                    { new Guid("e02e815d-c82d-45c2-848f-cd257334dc63"), 6, 2.9f, "F50", new DateTime(2019, 12, 29, 18, 26, 12, 206, DateTimeKind.Local).AddTicks(8319), 0, 450, false, 331, true, new DateTime(2019, 12, 29, 18, 26, 12, 206, DateTimeKind.Local).AddTicks(8322) },
                    { new Guid("67a68076-9eaf-40cc-bc13-b410a8943f5b"), 6, 3f, "50", new DateTime(2019, 12, 29, 18, 26, 12, 206, DateTimeKind.Local).AddTicks(8311), 0, 354, false, 260, true, new DateTime(2019, 12, 29, 18, 26, 12, 206, DateTimeKind.Local).AddTicks(8314) },
                    { new Guid("351047a6-b4a0-465c-9c91-ac7f355f5535"), 4, 2f, "45", new DateTime(2019, 12, 29, 18, 26, 12, 206, DateTimeKind.Local).AddTicks(8304), 0, 245, false, 180, true, new DateTime(2019, 12, 29, 18, 26, 12, 206, DateTimeKind.Local).AddTicks(8307) },
                    { new Guid("8b43a35b-d306-404c-8e8c-78bef3ceb895"), 4, 2f, "40", new DateTime(2019, 12, 29, 18, 26, 12, 206, DateTimeKind.Local).AddTicks(8295), 0, 190, false, 140, true, new DateTime(2019, 12, 29, 18, 26, 12, 206, DateTimeKind.Local).AddTicks(8298) },
                    { new Guid("c7d9f487-1848-421b-8ce6-2cfdd1036c56"), 4, 2f, "35", new DateTime(2019, 12, 29, 18, 26, 12, 206, DateTimeKind.Local).AddTicks(8287), 0, 150, false, 110, true, new DateTime(2019, 12, 29, 18, 26, 12, 206, DateTimeKind.Local).AddTicks(8291) },
                    { new Guid("68643845-0733-4bee-870b-1581b1db9470"), 5, 2.5f, "45", new DateTime(2019, 12, 29, 18, 26, 12, 206, DateTimeKind.Local).AddTicks(8146), 0, 400, false, 294, true, new DateTime(2019, 12, 29, 18, 26, 12, 206, DateTimeKind.Local).AddTicks(8149) },
                    { new Guid("4f5b62c0-5346-4745-990a-8dc0a6688d80"), 4, 2f, "40", new DateTime(2019, 12, 29, 18, 26, 12, 206, DateTimeKind.Local).AddTicks(8138), 0, 300, false, 221, true, new DateTime(2019, 12, 29, 18, 26, 12, 206, DateTimeKind.Local).AddTicks(8141) },
                    { new Guid("3d6a58b8-eb54-4a93-8b24-12777408ebe7"), 4, 1.4f, "A34", new DateTime(2019, 12, 29, 18, 26, 12, 206, DateTimeKind.Local).AddTicks(8117), 0, 204, false, 150, true, new DateTime(2019, 12, 29, 18, 26, 12, 206, DateTimeKind.Local).AddTicks(8120) },
                    { new Guid("527d76bd-0892-4041-8008-172319ea0f0c"), 4, 2f, "40", new DateTime(2019, 12, 29, 18, 26, 12, 206, DateTimeKind.Local).AddTicks(8109), 0, 200, false, 147, true, new DateTime(2019, 12, 29, 18, 26, 12, 206, DateTimeKind.Local).AddTicks(8112) },
                    { new Guid("da41b3e5-2727-41a9-8504-db2155424a26"), 4, 1.5f, "35", new DateTime(2019, 12, 29, 18, 26, 12, 206, DateTimeKind.Local).AddTicks(8099), 0, 150, false, 110, true, new DateTime(2019, 12, 29, 18, 26, 12, 206, DateTimeKind.Local).AddTicks(8103) },
                    { new Guid("b68f0932-74aa-4960-b84b-563c657132bd"), 3, 1f, "30", new DateTime(2019, 12, 29, 18, 26, 12, 206, DateTimeKind.Local).AddTicks(8002), 0, 116, false, 85, true, new DateTime(2019, 12, 29, 18, 26, 12, 206, DateTimeKind.Local).AddTicks(8018) },
                    { new Guid("3d4a562f-e3aa-4e57-be86-83460d977b60"), 3, 1f, "25", new DateTime(2019, 12, 29, 18, 26, 12, 206, DateTimeKind.Local).AddTicks(3751), 0, 95, false, 70, true, new DateTime(2019, 12, 29, 18, 26, 12, 206, DateTimeKind.Local).AddTicks(3776) }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Avatar", "CreatedDateEntity", "IsDeleted", "Name", "UpdateDateEntity" },
                values: new object[,]
                {
                    { new Guid("2fecd99a-e554-4b66-be26-026e12c3529e"), "https://s3.amazonaws.com/uifaces/faces/twitter/jarjan/128.jpg", new DateTime(2019, 12, 29, 18, 26, 12, 166, DateTimeKind.Local).AddTicks(8467), false, "Noah.Roberts56", new DateTime(2019, 12, 29, 18, 26, 12, 169, DateTimeKind.Local).AddTicks(3052) },
                    { new Guid("e213f3f3-72a9-4da0-9b94-a85651ee05af"), "https://s3.amazonaws.com/uifaces/faces/twitter/her_ruu/128.jpg", new DateTime(2019, 12, 29, 18, 26, 12, 188, DateTimeKind.Local).AddTicks(1703), false, "Luigi53", new DateTime(2019, 12, 29, 18, 26, 12, 188, DateTimeKind.Local).AddTicks(1758) },
                    { new Guid("17b29634-451f-4106-9c3f-3d959a29bc53"), "https://s3.amazonaws.com/uifaces/faces/twitter/pmeissner/128.jpg", new DateTime(2019, 12, 29, 18, 26, 12, 188, DateTimeKind.Local).AddTicks(2235), false, "Taya73", new DateTime(2019, 12, 29, 18, 26, 12, 188, DateTimeKind.Local).AddTicks(2243) },
                    { new Guid("9b1abdb4-8ef4-4544-bd06-9e0fe16c6bd8"), "https://s3.amazonaws.com/uifaces/faces/twitter/andytlaw/128.jpg", new DateTime(2019, 12, 29, 18, 26, 12, 188, DateTimeKind.Local).AddTicks(2402), false, "Emil14", new DateTime(2019, 12, 29, 18, 26, 12, 188, DateTimeKind.Local).AddTicks(2408) }
                });

            migrationBuilder.InsertData(
                table: "Catalog",
                columns: new[] { "Id", "CreatedDate", "CreatedDateEntity", "IsDeleted", "Name", "UpdateDateEntity", "UserId" },
                values: new object[] { new Guid("924cce38-da44-4b44-a9f5-430d3830debe"), new DateTime(2019, 12, 28, 20, 54, 31, 341, DateTimeKind.Local).AddTicks(7931), new DateTime(2019, 12, 29, 18, 26, 12, 201, DateTimeKind.Local).AddTicks(1935), false, "animi", new DateTime(2019, 12, 29, 18, 26, 12, 201, DateTimeKind.Local).AddTicks(1992), new Guid("2fecd99a-e554-4b66-be26-026e12c3529e") });

            migrationBuilder.InsertData(
                table: "Catalog",
                columns: new[] { "Id", "CreatedDate", "CreatedDateEntity", "IsDeleted", "Name", "UpdateDateEntity", "UserId" },
                values: new object[] { new Guid("26c28d0b-55b8-4f7a-92c3-a775565eb7e9"), new DateTime(2019, 12, 29, 10, 29, 34, 54, DateTimeKind.Local).AddTicks(3276), new DateTime(2019, 12, 29, 18, 26, 12, 203, DateTimeKind.Local).AddTicks(2207), false, "ut", new DateTime(2019, 12, 29, 18, 26, 12, 203, DateTimeKind.Local).AddTicks(2231), new Guid("9b1abdb4-8ef4-4544-bd06-9e0fe16c6bd8") });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "AmountDoors", "AmountSeats", "CatalogId", "CategoryId", "Color", "CreatedDateEntity", "DriveType", "EngineId", "GearBox", "IsDeleted", "Manufacturer", "Mileage", "Model", "OriginCountry", "PictureName", "Type", "UpdateDateEntity", "VIN" },
                values: new object[,]
                {
                    { new Guid("f7b5247b-da3e-4c1f-b031-4fdbfd523876"), 2, 2, new Guid("924cce38-da44-4b44-a9f5-430d3830debe"), new Guid("8411e08f-c1d9-4a7c-a3c8-5c7f956645f3"), "gold", new DateTime(2019, 12, 29, 18, 26, 12, 215, DateTimeKind.Local).AddTicks(2838), 3, new Guid("4f5b62c0-5346-4745-990a-8dc0a6688d80"), 2, false, "Porsche", 175678, "Wrangler", "Botswana", "Porsche.jpg", 3, new DateTime(2019, 12, 29, 18, 26, 12, 215, DateTimeKind.Local).AddTicks(2891), "F9A77Y7BQBPL98981" },
                    { new Guid("beee2a82-be1e-49dc-975b-187f79b1b032"), 2, 4, new Guid("26c28d0b-55b8-4f7a-92c3-a775565eb7e9"), new Guid("055536e6-8d75-43ad-869f-5a77b6fa7ce7"), "violet", new DateTime(2019, 12, 29, 18, 26, 12, 226, DateTimeKind.Local).AddTicks(2000), 0, new Guid("7176d110-4d14-4290-935c-3140156114e0"), 2, false, "Chevrolet", 33660, "Land Cruiser", "Romania", "Chevrolet.jpg", 0, new DateTime(2019, 12, 29, 18, 26, 12, 226, DateTimeKind.Local).AddTicks(2005), "FHX8TWRS33K139540" },
                    { new Guid("44d7e912-c5ef-4e99-b2c9-e4e3bf198115"), 4, 5, new Guid("26c28d0b-55b8-4f7a-92c3-a775565eb7e9"), new Guid("0c5f8f9e-a0e5-4698-87af-588da11adc6f"), "tan", new DateTime(2019, 12, 29, 18, 26, 12, 226, DateTimeKind.Local).AddTicks(1927), 3, new Guid("527d76bd-0892-4041-8008-172319ea0f0c"), 3, false, "Porsche", 110986, "Colorado", "Canada", "Porsche.jpg", 4, new DateTime(2019, 12, 29, 18, 26, 12, 226, DateTimeKind.Local).AddTicks(1932), "N55X038BI5NF94705" },
                    { new Guid("3ffa8abf-7821-4029-845d-f176363b3a21"), 5, 5, new Guid("26c28d0b-55b8-4f7a-92c3-a775565eb7e9"), new Guid("8411e08f-c1d9-4a7c-a3c8-5c7f956645f3"), "silver", new DateTime(2019, 12, 29, 18, 26, 12, 226, DateTimeKind.Local).AddTicks(1850), 2, new Guid("c0f13571-ef04-4bca-bc9a-c237b451e57b"), 1, false, "Rolls Royce", 1022, "Escalade", "Mozambique", "Rolls Royce.jpg", 1, new DateTime(2019, 12, 29, 18, 26, 12, 226, DateTimeKind.Local).AddTicks(1856), "XYPGA5EOHVZK97087" },
                    { new Guid("137929da-8c3e-497d-8368-21ac4a4d8ab6"), 5, 5, new Guid("26c28d0b-55b8-4f7a-92c3-a775565eb7e9"), new Guid("0c5f8f9e-a0e5-4698-87af-588da11adc6f"), "cyan", new DateTime(2019, 12, 29, 18, 26, 12, 226, DateTimeKind.Local).AddTicks(1773), 3, new Guid("3d4a562f-e3aa-4e57-be86-83460d977b60"), 0, false, "Hyandai", 85507, "Cruze", "Czech Republic", "Hyandai.jpg", 3, new DateTime(2019, 12, 29, 18, 26, 12, 226, DateTimeKind.Local).AddTicks(1778), "KIDWP5Q7GFNF58556" },
                    { new Guid("f90db5c9-dfe6-433d-8f46-4dac1a116320"), 2, 3, new Guid("26c28d0b-55b8-4f7a-92c3-a775565eb7e9"), new Guid("8411e08f-c1d9-4a7c-a3c8-5c7f956645f3"), "salmon", new DateTime(2019, 12, 29, 18, 26, 12, 226, DateTimeKind.Local).AddTicks(1394), 0, new Guid("c0f13571-ef04-4bca-bc9a-c237b451e57b"), 1, false, "Nissan", 159458, "Camaro", "Belarus", "Nissan.jpg", 4, new DateTime(2019, 12, 29, 18, 26, 12, 226, DateTimeKind.Local).AddTicks(1399), "0JXOMIA13AV938634" },
                    { new Guid("3dbd4535-6b39-426f-98ea-9184a5073389"), 5, 4, new Guid("26c28d0b-55b8-4f7a-92c3-a775565eb7e9"), new Guid("0c5f8f9e-a0e5-4698-87af-588da11adc6f"), "cyan", new DateTime(2019, 12, 29, 18, 26, 12, 226, DateTimeKind.Local).AddTicks(1113), 2, new Guid("3d4a562f-e3aa-4e57-be86-83460d977b60"), 1, false, "Mercedes Benz", 117456, "Grand Caravan", "Guatemala", "Mercedes Benz.jpg", 2, new DateTime(2019, 12, 29, 18, 26, 12, 226, DateTimeKind.Local).AddTicks(1118), "UJV5M6N8S0C756117" },
                    { new Guid("c2982a71-b9db-4a79-9fea-5b2b93bbc760"), 4, 4, new Guid("26c28d0b-55b8-4f7a-92c3-a775565eb7e9"), new Guid("0c5f8f9e-a0e5-4698-87af-588da11adc6f"), "mint green", new DateTime(2019, 12, 29, 18, 26, 12, 226, DateTimeKind.Local).AddTicks(866), 3, new Guid("351047a6-b4a0-465c-9c91-ac7f355f5535"), 2, false, "Cadillac", 122868, "Charger", "Mauritania", "Cadillac.jpg", 2, new DateTime(2019, 12, 29, 18, 26, 12, 226, DateTimeKind.Local).AddTicks(872), "NUPDWRJ43ZGK26675" },
                    { new Guid("f8a5c971-db8a-41b8-8f7c-c68f9be6c390"), 2, 4, new Guid("26c28d0b-55b8-4f7a-92c3-a775565eb7e9"), new Guid("0c5f8f9e-a0e5-4698-87af-588da11adc6f"), "gold", new DateTime(2019, 12, 29, 18, 26, 12, 225, DateTimeKind.Local).AddTicks(9468), 0, new Guid("b68f0932-74aa-4960-b84b-563c657132bd"), 2, false, "Porsche", 33305, "Mercielago", "Switzerland", "Porsche.jpg", 3, new DateTime(2019, 12, 29, 18, 26, 12, 225, DateTimeKind.Local).AddTicks(9524), "744H0ZSR00HV38749" },
                    { new Guid("ba0a232f-b684-4b9e-a0f2-7539537770e2"), 3, 5, new Guid("924cce38-da44-4b44-a9f5-430d3830debe"), new Guid("0c5f8f9e-a0e5-4698-87af-588da11adc6f"), "olive", new DateTime(2019, 12, 29, 18, 26, 12, 226, DateTimeKind.Local).AddTicks(2282), 3, new Guid("67a68076-9eaf-40cc-bc13-b410a8943f5b"), 1, false, "Rolls Royce", 84665, "PT Cruiser", "Dominican Republic", "Rolls Royce.jpg", 1, new DateTime(2019, 12, 29, 18, 26, 12, 226, DateTimeKind.Local).AddTicks(2287), "SAPU5P00PTNP20976" },
                    { new Guid("20dde053-ef4f-46ca-81ce-d7c83a6b8a35"), 2, 4, new Guid("924cce38-da44-4b44-a9f5-430d3830debe"), new Guid("0c5f8f9e-a0e5-4698-87af-588da11adc6f"), "azure", new DateTime(2019, 12, 29, 18, 26, 12, 226, DateTimeKind.Local).AddTicks(1650), 1, new Guid("7176d110-4d14-4290-935c-3140156114e0"), 2, false, "Nissan", 65897, "Silverado", "Svalbard & Jan Mayen Islands", "Nissan.jpg", 5, new DateTime(2019, 12, 29, 18, 26, 12, 226, DateTimeKind.Local).AddTicks(1655), "YE5HV67YLDCC43174" },
                    { new Guid("b69e8023-6e38-4a80-a2f0-9f989e27212a"), 4, 4, new Guid("924cce38-da44-4b44-a9f5-430d3830debe"), new Guid("055536e6-8d75-43ad-869f-5a77b6fa7ce7"), "fuchsia", new DateTime(2019, 12, 29, 18, 26, 12, 226, DateTimeKind.Local).AddTicks(1573), 3, new Guid("c7d9f487-1848-421b-8ce6-2cfdd1036c56"), 1, false, "Mini", 17324, "Mustang", "Nepal", "Mini.jpg", 4, new DateTime(2019, 12, 29, 18, 26, 12, 226, DateTimeKind.Local).AddTicks(1578), "YUEXVWVEYJJA54410" },
                    { new Guid("d6b00a88-04a0-4d0a-add7-67384725b297"), 2, 5, new Guid("924cce38-da44-4b44-a9f5-430d3830debe"), new Guid("0c5f8f9e-a0e5-4698-87af-588da11adc6f"), "yellow", new DateTime(2019, 12, 29, 18, 26, 12, 226, DateTimeKind.Local).AddTicks(1474), 1, new Guid("c0f13571-ef04-4bca-bc9a-c237b451e57b"), 1, false, "Mini", 34290, "Alpine", "Mexico", "Mini.jpg", 1, new DateTime(2019, 12, 29, 18, 26, 12, 226, DateTimeKind.Local).AddTicks(1479), "N6A7D4RGRMUD51042" },
                    { new Guid("f6198b7b-474d-4085-9720-d6ee45476a9d"), 2, 5, new Guid("924cce38-da44-4b44-a9f5-430d3830debe"), new Guid("8411e08f-c1d9-4a7c-a3c8-5c7f956645f3"), "tan", new DateTime(2019, 12, 29, 18, 26, 12, 226, DateTimeKind.Local).AddTicks(1318), 3, new Guid("7176d110-4d14-4290-935c-3140156114e0"), 2, false, "Cadillac", 41601, "Element", "Christmas Island", "Cadillac.jpg", 3, new DateTime(2019, 12, 29, 18, 26, 12, 226, DateTimeKind.Local).AddTicks(1323), "1LDZNQH73NPV20732" },
                    { new Guid("f74e2894-0c87-45b4-ace5-dd901b59b3b7"), 3, 3, new Guid("924cce38-da44-4b44-a9f5-430d3830debe"), new Guid("055536e6-8d75-43ad-869f-5a77b6fa7ce7"), "plum", new DateTime(2019, 12, 29, 18, 26, 12, 226, DateTimeKind.Local).AddTicks(1235), 0, new Guid("3d4a562f-e3aa-4e57-be86-83460d977b60"), 0, false, "Honda", 186932, "Mustang", "Chile", "Honda.jpg", 4, new DateTime(2019, 12, 29, 18, 26, 12, 226, DateTimeKind.Local).AddTicks(1241), "Z1AW3FRXUSCI15828" },
                    { new Guid("3726127e-1d00-4fd4-a26a-6cfdd0dfa583"), 5, 2, new Guid("924cce38-da44-4b44-a9f5-430d3830debe"), new Guid("0c5f8f9e-a0e5-4698-87af-588da11adc6f"), "turquoise", new DateTime(2019, 12, 29, 18, 26, 12, 226, DateTimeKind.Local).AddTicks(1035), 3, new Guid("67a68076-9eaf-40cc-bc13-b410a8943f5b"), 3, false, "Fiat", 101601, "Element", "Marshall Islands", "Fiat.jpg", 4, new DateTime(2019, 12, 29, 18, 26, 12, 226, DateTimeKind.Local).AddTicks(1039), "9PCLXX4PEFYU79572" },
                    { new Guid("bad00308-e501-4b57-9ade-fc32280fb760"), 5, 2, new Guid("924cce38-da44-4b44-a9f5-430d3830debe"), new Guid("0c5f8f9e-a0e5-4698-87af-588da11adc6f"), "pink", new DateTime(2019, 12, 29, 18, 26, 12, 226, DateTimeKind.Local).AddTicks(955), 2, new Guid("d20657e6-cd52-4282-9018-2bd17587119f"), 0, false, "Volkswagen", 178369, "Aventador", "Jersey", "Volkswagen.jpg", 3, new DateTime(2019, 12, 29, 18, 26, 12, 226, DateTimeKind.Local).AddTicks(960), "ULH7NOIMBWSW22924" },
                    { new Guid("f3811e85-5d92-4858-b7ea-7fc0cf56aa73"), 4, 2, new Guid("924cce38-da44-4b44-a9f5-430d3830debe"), new Guid("8411e08f-c1d9-4a7c-a3c8-5c7f956645f3"), "olive", new DateTime(2019, 12, 29, 18, 26, 12, 226, DateTimeKind.Local).AddTicks(743), 1, new Guid("527d76bd-0892-4041-8008-172319ea0f0c"), 0, false, "Hyandai", 180719, "Spyder", "Afghanistan", "Hyandai.jpg", 5, new DateTime(2019, 12, 29, 18, 26, 12, 226, DateTimeKind.Local).AddTicks(755), "KBJZH4DKCOC316914" },
                    { new Guid("51673933-e413-47e8-9daf-4adea58eb3eb"), 3, 3, new Guid("26c28d0b-55b8-4f7a-92c3-a775565eb7e9"), new Guid("055536e6-8d75-43ad-869f-5a77b6fa7ce7"), "maroon", new DateTime(2019, 12, 29, 18, 26, 12, 226, DateTimeKind.Local).AddTicks(2077), 1, new Guid("e238cfff-9c27-4a9a-ac24-31f153a0e2ea"), 1, false, "Chrysler", 14009, "Impala", "Mauritania", "Chrysler.jpg", 3, new DateTime(2019, 12, 29, 18, 26, 12, 226, DateTimeKind.Local).AddTicks(2082), "CH3F3K6U02ZP50425" },
                    { new Guid("a9d8bf87-5f71-4b3a-b76a-383694835550"), 3, 3, new Guid("26c28d0b-55b8-4f7a-92c3-a775565eb7e9"), new Guid("0c5f8f9e-a0e5-4698-87af-588da11adc6f"), "maroon", new DateTime(2019, 12, 29, 18, 26, 12, 226, DateTimeKind.Local).AddTicks(2198), 2, new Guid("3d6a58b8-eb54-4a93-8b24-12777408ebe7"), 2, false, "Ford", 193304, "Jetta", "Holy See (Vatican City State)", "Ford.jpg", 2, new DateTime(2019, 12, 29, 18, 26, 12, 226, DateTimeKind.Local).AddTicks(2204), "DATO5QZ4RZKK76293" }
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
