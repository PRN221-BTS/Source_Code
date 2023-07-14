using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObjects.Migrations
{
    /// <inheritdoc />
    public partial class ducanhnt22migrationupdatedb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Customer__A4AE64B8D3841F7E", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PaymentID = table.Column<int>(type: "int", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "date", nullable: true),
                    PaymentType = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Payment__9B556A58C1394462", x => x.PaymentID);
                });

            migrationBuilder.CreateTable(
                name: "WarehouseManager",
                columns: table => new
                {
                    WarehouseManagerID = table.Column<int>(type: "int", nullable: false),
                    WarehouseManagerName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Warehous__678D8266D49A4657", x => x.WarehouseManagerID);
                });

            migrationBuilder.CreateTable(
                name: "Bird",
                columns: table => new
                {
                    BirdID = table.Column<int>(type: "int", nullable: false),
                    BirdName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    BirdType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BirdQuantity = table.Column<int>(type: "int", nullable: true),
                    CustomerID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Bird__7694332EBEE1F1E1", x => x.BirdID);
                    table.ForeignKey(
                        name: "FK__Bird__CustomerID__4D94879B",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "CustomerID");
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: true),
                    ReceivingAddress = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    SendingAddress = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Note = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OrderType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Properties = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    PaymentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Order__C3905BAF77E35A4E", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK__Order__CustomerI__45F365D3",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "CustomerID");
                    table.ForeignKey(
                        name: "FK__Order__PaymentID__46E78A0C",
                        column: x => x.PaymentID,
                        principalTable: "Payment",
                        principalColumn: "PaymentID");
                });

            migrationBuilder.CreateTable(
                name: "Warehouse",
                columns: table => new
                {
                    WarehouseID = table.Column<int>(type: "int", nullable: false),
                    WarehouseManagerID = table.Column<int>(type: "int", nullable: true),
                    WarehouseName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Location = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Warehous__2608AFD9C650A74A", x => x.WarehouseID);
                    table.ForeignKey(
                        name: "FK__Warehouse__Wareh__3D5E1FD2",
                        column: x => x.WarehouseManagerID,
                        principalTable: "WarehouseManager",
                        principalColumn: "WarehouseManagerID");
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    OrderDetailID = table.Column<int>(type: "int", nullable: false),
                    OrderID = table.Column<int>(type: "int", nullable: true),
                    BirdID = table.Column<int>(type: "int", nullable: true),
                    Certificate = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    BirdCage = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    OtherItems = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    DeliveryStatus = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__OrderDet__D3B9D30C4E517E00", x => x.OrderDetailID);
                    table.ForeignKey(
                        name: "FK__OrderDeta__BirdI__5165187F",
                        column: x => x.BirdID,
                        principalTable: "Bird",
                        principalColumn: "BirdID");
                    table.ForeignKey(
                        name: "FK__OrderDeta__Order__5070F446",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "OrderID");
                });

            migrationBuilder.CreateTable(
                name: "Shipper",
                columns: table => new
                {
                    ShipperID = table.Column<int>(type: "int", nullable: false),
                    ShipperName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    IncomeWallet = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CodWallet = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    VehicleType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    WarehouseID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Shipper__1F8AFFB9BBE4A453", x => x.ShipperID);
                    table.ForeignKey(
                        name: "FK__Shipper__Warehou__403A8C7D",
                        column: x => x.WarehouseID,
                        principalTable: "Warehouse",
                        principalColumn: "WarehouseID");
                });

            migrationBuilder.CreateTable(
                name: "TrackingOrder",
                columns: table => new
                {
                    TrackingOrderID = table.Column<int>(type: "int", nullable: false),
                    TrackingStatus = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    SequenceNumber = table.Column<int>(type: "int", nullable: true),
                    EstimateDeliveryDate = table.Column<DateTime>(type: "date", nullable: true),
                    ActualDeliveryDate = table.Column<DateTime>(type: "date", nullable: true),
                    WarehouseID = table.Column<int>(type: "int", nullable: true),
                    OrderID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tracking__24D0CD62496122C9", x => x.TrackingOrderID);
                    table.ForeignKey(
                        name: "FK__TrackingO__Order__4AB81AF0",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "OrderID");
                    table.ForeignKey(
                        name: "FK__TrackingO__Wareh__49C3F6B7",
                        column: x => x.WarehouseID,
                        principalTable: "Warehouse",
                        principalColumn: "WarehouseID");
                });

            migrationBuilder.CreateTable(
                name: "Route",
                columns: table => new
                {
                    RouteID = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Distance = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ShipperID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Route__80979AAD6DA8365E", x => x.RouteID);
                    table.ForeignKey(
                        name: "FK__Route__ShipperID__4316F928",
                        column: x => x.ShipperID,
                        principalTable: "Shipper",
                        principalColumn: "ShipperID");
                });

            migrationBuilder.CreateTable(
                name: "OrderInRoute",
                columns: table => new
                {
                    OrderInRouteID = table.Column<int>(type: "int", nullable: false),
                    OrderID = table.Column<int>(type: "int", nullable: true),
                    RouteID = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__OrderInR__BC07D0C59485F650", x => x.OrderInRouteID);
                    table.ForeignKey(
                        name: "FK__OrderInRo__Order__5441852A",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "OrderID");
                    table.ForeignKey(
                        name: "FK__OrderInRo__Route__5535A963",
                        column: x => x.RouteID,
                        principalTable: "Route",
                        principalColumn: "RouteID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bird_CustomerID",
                table: "Bird",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerID",
                table: "Order",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_PaymentID",
                table: "Order",
                column: "PaymentID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_BirdID",
                table: "OrderDetail",
                column: "BirdID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderID",
                table: "OrderDetail",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderInRoute_OrderID",
                table: "OrderInRoute",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderInRoute_RouteID",
                table: "OrderInRoute",
                column: "RouteID");

            migrationBuilder.CreateIndex(
                name: "IX_Route_ShipperID",
                table: "Route",
                column: "ShipperID");

            migrationBuilder.CreateIndex(
                name: "IX_Shipper_WarehouseID",
                table: "Shipper",
                column: "WarehouseID");

            migrationBuilder.CreateIndex(
                name: "IX_TrackingOrder_OrderID",
                table: "TrackingOrder",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_TrackingOrder_WarehouseID",
                table: "TrackingOrder",
                column: "WarehouseID");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouse_WarehouseManagerID",
                table: "Warehouse",
                column: "WarehouseManagerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "OrderInRoute");

            migrationBuilder.DropTable(
                name: "TrackingOrder");

            migrationBuilder.DropTable(
                name: "Bird");

            migrationBuilder.DropTable(
                name: "Route");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Shipper");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Warehouse");

            migrationBuilder.DropTable(
                name: "WarehouseManager");
        }
    }
}
