-----CREATE DATABASE-----
CREATE DATABASE YK327YashKotadiya

USE [YK327YashKotadiya]

-----CREATE USER TABLE-----
CREATE TABLE [User](
UserId INT PRIMARY KEY IDENTITY(1,1),
UserFirstName VARCHAR(200) NOT NULL,
UserLastName VARCHAR(200) NOT NULL,
UaerEmailId VARCHAR(100),
UserPassword VARCHAR(100),
UserCountryCode VARCHAR(5),
UserFirstMobileNumber VARCHAR(20) UNIQUE NOT NULL,
UserSecondMobileNumber VARCHAR(20),
UserCurrentAddress TEXT,
UserPermamentAddress TEXT,
UserPinCode VARCHAR(6),
CreatedOn DATETIME DEFAULT GETDATE(),
UpdatedOn DATETIME DEFAULT GETDATE()
);
select * from [User]

-----ALTER USER TABLE-----
ALTER TABLE [User]
ADD UserDOB DATETIME,
UserAge INT CHECK (UserAge > 0),
UserGender VARCHAR(10);

-----INSERT DATA INTO USER TABLE-----
INSERT INTO [User](UserFirstName,UserLastName,UaerEmailId,UserPassword,UserCountryCode,UserFirstMobileNumber,UserSecondMobileNumber,UserCurrentAddress,UserPermamentAddress,UserPinCode,UserDOB,UserAge,UserGender)
VALUES('Yash','Kotadiya','yashkotadiya222@gmail.com','123456','91','9737012270','9723594308','Ahmedabad','Junagadh','362215','2001-12-14',21,'Male');
INSERT INTO [User](UserFirstName,UserLastName,UaerEmailId,UserPassword,UserCountryCode,UserFirstMobileNumber,UserSecondMobileNumber,UserCurrentAddress,UserPermamentAddress,UserPinCode,UserDOB,UserAge,UserGender)
VALUES('Sahil','Borad','sahilbord111@gmail.com','12345678','91','9546788943','9874567852','Rajkot','Junagadh','362260','1999-04-04',23,'Male');
INSERT INTO [User](UserFirstName,UserLastName,UaerEmailId,UserPassword,UserCountryCode,UserFirstMobileNumber,UserSecondMobileNumber,UserCurrentAddress,UserPermamentAddress,UserPinCode,UserDOB,UserAge,UserGender)
VALUES('Chirag','Patel','chiragpatel333@gmail.com','123456789','91','9546754393','9899567852','Sidhpur','Ahmedanad','557825','2002-06-04',21,'Male');
INSERT INTO [User](UserFirstName,UserLastName,UaerEmailId,UserPassword,UserCountryCode,UserFirstMobileNumber,UserSecondMobileNumber,UserCurrentAddress,UserPermamentAddress,UserPinCode,UserDOB,UserAge,UserGender)
VALUES('Bhavya','Joshi','bhavyajoshi444@gmail.com','1234567890','91','9546754883','9659567852','Palanpur','Vadodara','784521','2002-04-03',21,'Male');
INSERT INTO [User](UserFirstName,UserLastName,UaerEmailId,UserPassword,UserCountryCode,UserFirstMobileNumber,UserSecondMobileNumber,UserCurrentAddress,UserPermamentAddress,UserPinCode,UserDOB,UserAge,UserGender)
VALUES('Hemang','Dholu','hemangdholu555@gmail.com','1234567890','91','9546754773','9657867852','Bhuj','Surat','668954','2002-08-08',21,'Male');

-----UPDATE USER TABLE-----
BEGIN TRANSACTION
UPDATE [User]
SET  UserCurrentAddress= 'USA' WHERE UserFirstName = 'Chirag'
UPDATE [User]
SET  UserPermamentAddress= 'Kutch' WHERE UserLastName = 'Dholu'
COMMIT TRANSACTION
ROLLBACK TRANSACTION

-----SHOW USER TABLE-----
SELECT * FROM [User]

-----RETRIVE RECORD FROM THE USER TABLE-----
SELECT * FROM [User] WHERE UserFirstName='Yash'

-----USEGE OF AGGREGATE FUNCTION-----
SELECT COUNT(*) FROM [User];

-----CREATE PRODUCT TABLE-----
CREATE TABLE [Product](
ProductId INT PRIMARY KEY IDENTITY(1,1),
ProductName VARCHAR(250),
ProductPrice DECIMAL
); 

-----ALTER PRODUCT TABLE-----
ALTER TABLE [Product]
ADD ProductQuantity VARCHAR(250);

-----INSERT DATA INTO PRODUCT TABLE-----
INSERT INTO [Product](ProductName,ProductPrice,ProductQuantity)
VALUES('Mobile','30000','1');
INSERT INTO [Product](ProductName,ProductPrice,ProductQuantity)
VALUES('TV','40000','1');
INSERT INTO [Product](ProductName,ProductPrice,ProductQuantity)
VALUES('Bike','80000','1');
INSERT INTO [Product](ProductName,ProductPrice,ProductQuantity)
VALUES('Car','500000','2');
INSERT INTO [Product](ProductName,ProductPrice,ProductQuantity)
VALUES('Laptop','60000','3');

BEGIN TRANSACTION
UPDATE [Product]
SET ProductQuantity= '4' WHERE  ProductName='Mobile'
UPDATE [Product]
SET ProductPrice= '90000' WHERE  ProductName='Bike'
COMMIT TRANSACTION
ROLLBACK TRANSACTION

-----SHOW PRODUCT TABLE-----
SELECT * FROM [Product]

-----RETRIVE RECORD FROM THE PRODUCT TABLE-----
SELECT * FROM [Product] WHERE ProductName='TV'

-----DELETE DATA FROM THE PRODUCT TABLE-----
DELETE FROM [Product] WHERE ProductName='Bike'

-----USEGE OF AGGREGATE FUNCTION-----
SELECT MIN(ProductPrice) AS SmallestPrice FROM Product;
SELECT MAX(ProductPrice) AS LargestPrice FROM Product;
SELECT AVG(ProductPrice) AS AvaragePrice FROM Product;
SELECT SUM(ProductPrice) FROM Product;

-----CREATE ORDER TABLE-----
CREATE TABLE [Order](
OrderId INT PRIMARY KEY IDENTITY(1,1),
ProductId INT FOREIGN KEY REFERENCES [Product](ProductId),
UserId INT FOREIGN KEY REFERENCES [User](UserId),
OrderDeliveryAddress TEXT,
OrderPlacedDate DATETIME DEFAULT GETDATE(),
OrderDeliveredDate DATETIME DEFAULT GETDATE()
);

-----INSERT DATA INTO ORDER TABLE-----
INSERT INTO [Order](ProductId,UserId,OrderDeliveryAddress)
VALUES(1,1,'Ahmedabad');
INSERT INTO [Order](ProductId,UserId,OrderDeliveryAddress)
VALUES(2,2,'Junagadh');
INSERT INTO [Order](ProductId,UserId,OrderDeliveryAddress)
VALUES(3,1,'Rajkot');
INSERT INTO [Order](ProductId,UserId,OrderDeliveryAddress)
VALUES(4,4,'Surat');
INSERT INTO [Order](ProductId,UserId,OrderDeliveryAddress)
VALUES(5,3,'Vadodara');

-----SHOW ORDER TABLE-----
SELECT * FROM [Order]

SELECT [Order].OrderId, [User].UserFirstName,[Product].ProductName FROM  [Order],[User],[Product]
where [Order].UserID = [User].UserID AND [Product].ProductId = [User].UserID

-----CREATE COUNTRY TABLE-----
CREATE TABLE [Country](
CountryId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
CountryName VARCHAR(250)
);

-----INSERT DATA INTO COUNTRY TABLE-----
INSERT INTO[Country](CountryName)VALUES('India'),('UK'),('USA'),('Austrila'),('UAE');

-----SHOW COUNTRY TABLE-----
SELECT * FROM [Country]

-----CREATE STATE TABLE-----
CREATE TABLE [State](
StateId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
StateName VARCHAR(250),
CountryId INT FOREIGN KEY REFERENCES [Country](CountryId)
);

-----INSERT DATA INTO STATE TABLE-----
INSERT INTO [State](StateName,CountryId)VALUES('Gujarat',1),('England',2),('Texas',3),('Western Australia',4),('Abu Dhabi',5);

-----SHOW STATE TABLE-----
SELECT * FROM [State]

-----CREATE CITY TABLE-----
CREATE TABLE [City](
CityId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
CityName VARCHAR(250),
CountryId INT FOREIGN KEY REFERENCES [Country](CountryId),
StateId INT FOREIGN KEY REFERENCES [State](StateId),
);

-----INSERT DATA INTO CITY TABLE-----
INSERT INTO [City](CityName,CountryId,StateId)VALUES('Junagadh',1,1),('Liverpool',2,2),('Houston',3,3),('Perth',4,4),('Al Zeina',5,5);

-----SHOW CITY TABLE-----
SELECT * FROM [City]
