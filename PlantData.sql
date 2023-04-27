DROP DATABASE IF EXISTS PlantData;
CREATE DATABASE IF NOT EXISTS PlantData;
USE PlantData;

CREATE TABLE Orders (
  OrderId INT NOT NULL auto_increment,
  CustomerName VARCHAR(255) NOT NULL,
  CustomerEmail VARCHAR(255) NOT NULL,
  CustomerAddress VARCHAR(255) NOT NULL,
  OrderDate DATE NOT NULL,
  TotalPrice DECIMAL(10,2) NOT NULL,
  FulfillmentStatus VARCHAR(255) NOT NULL DEFAULT 'Pending',
  PRIMARY KEY (OrderId)
);

CREATE TABLE OrderItems (
  ItemId INT NOT NULL AUTO_INCREMENT,
  PlantName VARCHAR(255) NOT NULL,
  Quantity INT NOT NULL,
  UnitPrice DECIMAL(10,2) NOT NULL,
  OrderId INT NOT NULL,
  PRIMARY KEY (ItemId),
  FOREIGN KEY (OrderId) REFERENCES Orders(OrderId) ON DELETE CASCADE
);

INSERT INTO Orders (CustomerName, CustomerEmail, CustomerAddress, OrderDate, TotalPrice, FulfillmentStatus)
VALUES
  ('Annie Apple', 'annie@apple.com', '123 Orchard St, Randomcity USA', '2023-01-01', 50.50, 'Pending'),
  ('Billy Banana', 'billy@banana.com', '456 Monkey Ave, Randomcity USA', '2023-02-02', 75.21, 'Shipped'),
  ('Carl Celery', 'carl@celery.com', '789 Vegetable Rd, Randomcity USA', '2023-03-03', 100.32, 'Delivered');

INSERT INTO OrderItems (PlantName, Quantity, UnitPrice, OrderId)
VALUES
  ('Rose', 2, 10.00, 1),
  ('Tulip', 5, 5.00, 1),
  ('Lavender', 3, 8.00, 2),
  ('Daisy', 10, 2.50, 2),
  ('Orchid', 1, 50.00, 3),
  ('Sunflower', 5, 4.00, 3);