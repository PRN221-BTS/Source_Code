USE master;
GO

DROP DATABASE IF EXISTS BirdTransportationSystem;

CREATE DATABASE BirdTransportationSystem;

USE BirdTransportationSystem;

CREATE TABLE WarehouseManager (
    WarehouseManagerID INT PRIMARY KEY,
    WarehouseManagerName VARCHAR(50),
    Email VARCHAR(50),
    [Password] VARCHAR(50),
    PhoneNumber VARCHAR(20)
);

CREATE TABLE Customer (
    CustomerID INT PRIMARY KEY,
    CustomerName VARCHAR(50),
    Phone VARCHAR(20),
    Email VARCHAR(50),
    [Password] VARCHAR(50)
);

CREATE TABLE Payment (
    PaymentID INT PRIMARY KEY,
    PaymentDate DATE,
    [Status] VARCHAR(50)
);

CREATE TABLE Warehouse (
    WarehouseID INT PRIMARY KEY,
    WarehouseManagerID INT,
    WarehouseName VARCHAR(50),
    Location VARCHAR(100),
    FOREIGN KEY (WarehouseManagerID) REFERENCES WarehouseManager(WarehouseManagerID)
);

CREATE TABLE Shipper (
    ShipperID INT PRIMARY KEY,
    ShipperName VARCHAR(50),
    Income DECIMAL(18, 2),
    [Password] VARCHAR(50),
    VehicleType VARCHAR(50),
    Email VARCHAR(50),
    PhoneNumber VARCHAR(20),
    WarehouseID INT,
    FOREIGN KEY (WarehouseID) REFERENCES Warehouse(WarehouseID)
);

CREATE TABLE Route (
    RouteID INT PRIMARY KEY,
    Type VARCHAR(50),
    Distance DECIMAL(18, 2),
    Price DECIMAL(18, 2),
    ShipperID INT,
    FOREIGN KEY (ShipperID) REFERENCES Shipper(ShipperID)
);

CREATE TABLE [Order] (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    ReceivingAddress VARCHAR(100),
    SendingAddress VARCHAR(100),
    Note VARCHAR(200),
    [Status] VARCHAR(50),
    PaymentID INT,
    FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID),
    FOREIGN KEY (PaymentID) REFERENCES Payment(PaymentID)
);

CREATE TABLE TrackingOrder (
    TrackingOrderID INT PRIMARY KEY,
    TrackingStatus VARCHAR(50),
    SequenceNumber INT,
    EstimateDeliveryDate DATE,
    ActualDeliveryDate DATE,
    WarehouseID INT,
    OrderID INT,
    FOREIGN KEY (WarehouseID) REFERENCES Warehouse(WarehouseID),
    FOREIGN KEY (OrderID) REFERENCES [Order](OrderID)
);

CREATE TABLE Bird (
    BirdID INT PRIMARY KEY,
    BirdName VARCHAR(50),
    BirdType VARCHAR(50),
    Weight DECIMAL(18, 2),
    BirdQuantity INT,
    CustomerID INT, -- Foreign key to Customer table
    FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID)
);

CREATE TABLE OrderDetail (
    OrderDetailID INT PRIMARY KEY,
    OrderID INT,
    BirdID INT,
    Certificate VARCHAR(50),
    BirdCage VARCHAR(50),
    OtherItems VARCHAR(200),
    DeliveryStatus VARCHAR(50),
    Price DECIMAL(18, 2),
    FOREIGN KEY (OrderID) REFERENCES [Order](OrderID),
    FOREIGN KEY (BirdID) REFERENCES Bird(BirdID)
);

CREATE TABLE OrderInRoute (
    OrderInRouteID INT PRIMARY KEY,
    OrderID INT,
    RouteID INT,
	Status VARCHAR(200),
    FOREIGN KEY (OrderID) REFERENCES [Order](OrderID),
    FOREIGN KEY (RouteID) REFERENCES Route(RouteID)
);
USE BirdTransportationSystem;

INSERT INTO WarehouseManager (WarehouseManagerID, WarehouseManagerName, Email, [Password], PhoneNumber)
VALUES 
(1, 'John Doe', 'john@example.com', 'password123', '1234567890'),
(2, 'Sarah Johnson', 'sarah@example.com', 'password456', '9876543210'),
(3, 'Michael Smith', 'michael@example.com', 'password789', '1234567890');

INSERT INTO Customer (CustomerID, CustomerName, Phone, Email, [Password])
VALUES 
(1, 'Jane Smith', '9876543210', 'jane@example.com', 'password456'),
(2, 'Robert Davis', '7894561230', 'robert@example.com', 'password123'),
(3, 'Emily Wilson', '4567891230', 'emily@example.com', 'password234');

INSERT INTO Payment (PaymentID, PaymentDate, [Status])
VALUES 
(1, '2023-07-01', 'Completed'),
(2, '2023-07-02', 'Completed'),
(3, '2023-07-03', 'Pending');

INSERT INTO Warehouse (WarehouseID, WarehouseManagerID, WarehouseName, Location)
VALUES 
(1, 1, 'Central Warehouse', '123 Main Street'),
(2, 2, 'North Warehouse', '456 Elm Street'),
(3, 3, 'South Warehouse', '789 Oak Avenue');

INSERT INTO Shipper (ShipperID, ShipperName, Income, [Password], VehicleType, Email, PhoneNumber, WarehouseID)
VALUES 
(1, 'James Brown', 1000.00, 'password789', 'Truck', 'james@example.com', '9876543210', 1),
(2, 'Jessica Anderson', 1500.00, 'password345', 'Truck', 'jessica@example.com', '7894561230', 2),
(3, 'Duc Anh Dep Trai', 1200.00, 'password567', 'Van', 'ducanh@example.com', '4567891230', 3);

INSERT INTO Route (RouteID, Type, Distance, Price, ShipperID)
VALUES 
(1, 'Local Delivery', 10.5, 50.00, 1),
(2, 'Long-haul Delivery', 100.25, 200.00, 2),
(3, 'Local Delivery', 15.75, 75.00, 3);

INSERT INTO [Order] (OrderID, CustomerID, ReceivingAddress, SendingAddress, Note, [Status], PaymentID)
VALUES 
(1, 1, '456 Elm Street', '789 Oak Avenue', 'Fragile items', 'Pending', 1),
(2, 2, '123 Pine Street', '456 Maple Avenue', 'Fragile items', 'Pending', 2),
(3, 3, '789 Oak Avenue', '123 Elm Street', 'Handle with care', 'Completed', 3);

INSERT INTO TrackingOrder (TrackingOrderID, TrackingStatus, SequenceNumber, EstimateDeliveryDate, ActualDeliveryDate, WarehouseID, OrderID)
VALUES 
(1, 'In Transit', 1, '2023-07-02', NULL, 1, 1),
(2, 'In Transit', 1, '2023-07-03', NULL, 2, 2),
(3, 'Delivered', 1, '2023-07-02', '2023-07-02', 3, 3);

INSERT INTO Bird (BirdID, BirdName, BirdType, Weight, BirdQuantity, CustomerID)
VALUES 
(1, 'Parrot', 'Pet Bird', 1.5, 2, 1),
(2, 'Canary', 'Pet Bird', 0.2, 3, 2),
(3, 'Eagle', 'Bird of Prey', 5.7, 1, 3);

INSERT INTO OrderDetail (OrderDetailID, OrderID, BirdID, Certificate, BirdCage, OtherItems, DeliveryStatus, Price)
VALUES 
(1, 1, 1, 'ABC123', 'Small Cage', 'Bird Food', 'Delivered', 25.00),
(2, 2, 2, 'DEF456', 'Medium Cage', 'Bird Toys', 'In Progress', 30.00),
(3, 3, 3, 'GHI789', 'Large Cage', 'None', 'Delivered', 100.00);

INSERT INTO OrderInRoute (OrderInRouteID, OrderID, RouteID, Status)
VALUES 
(1, 1, 1, 'Waiting'),
(2, 2, 2, 'Done'),
(3, 3, 3, 'Pending');