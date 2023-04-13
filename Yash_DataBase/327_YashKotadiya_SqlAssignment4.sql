USE [YK327YashKotadiya]

----- Create Employees Table -----
Create Table [Employees327](
[EmployeeID] int primary key,
[LastName] varchar(250),
[FirstName] varchar(250),
[Title] varchar(250),
[BirthDate] date,
[HireDate] date,
[ReportsTo] int,
[Address] nvarchar(max)
);

INSERT INTO [Employees327] ([EmployeeID], [LastName], [FirstName], [Title], [BirthDate], [HireDate], [ReportsTo], [Address])VALUES
(1, 'Bhavya', 'Joshi', 'Manager', '2002-04-02', '2021-01-01', 1, 'Palanpur'),
(2, 'Yash', 'Kotadiya', 'Assistant Manager', '2001-12-14', '2019-05-01', 2, 'Junagadh'),
(3, 'Chirag', 'Patel', 'Sales Representative', '2002-06-04', '2020-03-15', 3, 'Sidhpur'),
(4, 'Hemang', 'Dholu', 'Sales Representative', '2002-08-08', '2022-01-01', 3, 'Bhuj'),
(5, 'Vivek', 'Khatri', 'Customer Service', '2002-01-24', '2018-02-01', 5, 'Deesa'),
(6, 'Vatsal', 'Prajapati', 'Customer Service', '2002-05-17', '2017-02-01', 2, 'Deesa');

update Employees327 set  ReportsTo = null where EmployeeID =1
update Employees327 set  ReportsTo = 1 where EmployeeID =2
update Employees327 set  ReportsTo = 2 where EmployeeID =3
update Employees327 set  ReportsTo = 2 where EmployeeID =4
update Employees327 set  ReportsTo = 3 where EmployeeID =5
update Employees327 set  ReportsTo = 3 where EmployeeID =6

select * from [Employees327]

----- Create Customers Table -----
Create Table [Customers327](
[CustomerID] int primary key,
[CompanyName] varchar(250),
[ContactName] varchar(250),
[ContactTitle] varchar(250),
[Address] nvarchar(max),
[City] varchar(250),
[Country] varchar(250)
);

INSERT INTO [Customers327] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Country]) VALUES
(1, 'Google', 'Sundar Pichai', 'CEO', '123 Main St', 'Mumbai', 'India'),
(2, 'Amazon', 'Jeff Bezos', 'CEO', '456 Broadway', 'Los Angeles', 'USA'),
(3, 'Microsoft', 'Mark Johnson', 'Sales Manager', '789 Elm St', 'Perth', 'Australia'),
(4, 'Facebook', 'Emily Williams', 'Marketing Manager', '1010 Park Ave', 'Colombo', 'Sri Lanka'),
(5, 'Tesla', 'James Brown', 'Customer Service Manager', '1111 Oak St', 'Miami', 'USA'),
(6, 'Apple', 'Tim Cook', 'CEO', '1111 Oak St', 'Florida', 'USA');
Insert Into [Customers327] Values(7,'Flipkart','John Doe','Sales Manager','456 Alt Dc','Durban','Africa');

select * from [Customers327]

----- Create orders Table -----
Create Table [orders327](
[OrderID] int primary key,
[CustomerID] int foreign key (CustomerID) references [Customers327](CustomerID),
[EmployeeID] int foreign key (EmployeeID) references [Employees327](EmployeeID),
[OrderDate] date
);

INSERT INTO [orders327] ([OrderID], [CustomerID], [EmployeeID], [OrderDate]) VALUES
(1, 1, 1, '2022-01-01'),
(2, 2, 2, '2022-02-01'),
(3, 3, 3, '2022-03-01'),
(4, 4, 4, '2022-04-01'),
(5, 5, 5, '2022-05-01');
Insert Into [orders327] Values(6,1,1,'2022-06-01');

select * from [orders327]

----- 1)Write a SQL query to retrieve the list of all orders made by customers in the "USA"
select C.*,O.OrderID,O.OrderDate from [orders327] O inner join [Customers327] C on O.CustomerID = C.CustomerID where C.Country = 'USA';

----- 2)Write a SQL query to retrieve the list of all customers who have placed an order.
select C.*,O.OrderID,O.OrderDate from [Customers327] C  inner join [orders327] O on O.CustomerID = C.CustomerID;

----- 3)Write a SQL query to retrieve the list of all employees who have not yet placed an order.
select E.* from [Employees327] E left join [orders327] O on O.EmployeeID = E.EmployeeID where O.EmployeeID is null;

----- 4)Write a SQL query to retrieve the list of all employees who have placed an order.
select E.*,O.OrderID,O.OrderDate from [Employees327] E inner join [orders327] O on O.EmployeeID = E.EmployeeID;

----- 5)Write a SQL query to retrieve the list of all customers who have not yet placed an order.
select C.* from [Customers327] C left join [orders327] O on O.CustomerID = C.CustomerID where O.CustomerID is null;

----- 6)Write a SQL query to retrieve the list of all customers who have placed an order, along with the order date.
select C.*,O.OrderID,O.OrderDate from [Customers327] C inner join [orders327] O on O.CustomerID = C.CustomerID;

----- 7)Write a SQL query to retrieve the list of all orders placed by a particular customer.
select C.*,O.OrderID,O.OrderDate from [orders327] O inner join [Customers327] C on O.CustomerID = C.CustomerID where O.CustomerID = 1;

----- 8)Write a SQL query to retrieve the list of all orders placed by a particular employee.
select E.*,O.OrderID,O.OrderDate from [orders327] O inner join [Employees327] E on O.EmployeeID = E.EmployeeID where O.EmployeeID = 1;

----- 9)Write a SQL query to retrieve the list of all orders placed by a particular customer on a particular date.
select C.*,O.OrderID,O.OrderDate from [orders327] O inner join [Customers327] c on O.CustomerID = C.CustomerID where O.CustomerID = 1 and O.OrderDate = '2022-01-01';

----- 10)Write a SQL query to retrieve the list of all customers who have not yet placed an order, sorted by their country.
select C.* from [Customers327] C left join [orders327] O on O.CustomerID = C.CustomerID where O.CustomerID is null order by country asc;

----- 11)Write a SQL query to retrieve the list of all orders placed by customers in the "USA", sorted by order date.
select C.*,O.OrderID,O.OrderDate from [orders327] O inner join [Customers327] C on O.CustomerID = C.CustomerID where C.Country = 'USA' order by O.OrderDate asc;

----- 12)Write a SQL query to retrieve the list of all employees who have not yet placed an order, sorted by last name.
select E.* from [Employees327] E left join [orders327] O on O.EmployeeID = E.EmployeeID where O.EmployeeID is null order by E.LastName;

----- 13)Write a SQL query to retrieve the list of all customers who have placed an order, sorted by their company name.
select C.*,O.OrderID,O.OrderDate from [Customers327] C inner join [orders327] O on O.CustomerID = C.CustomerID order by C.CompanyName;

----- 14)Write a SQL query to retrieve the list of all employees who have placed an order, sorted by their hire date.
select E.*,O.OrderID,O.OrderDate from [Employees327] E inner join [orders327] O on O.EmployeeID = E.EmployeeID order by E.HireDate;

----- 15)Write a SQL query to retrieve the list of all customers who have placed an order on a particular date, sorted by their company name.
select C.*,O.OrderID,O.OrderDate from [Customers327] C inner join [orders327] O on O.CustomerID = C.CustomerID where O.OrderDate = '2022-05-01'order by C.CompanyName;

----- 16)Write a SQL query to retrieve the list of all customers who have placed an order, along with the employee who handled the order.
select * from (select C.*,O.OrderID,O.OrderDate,O.EmployeeID from [Customers327] C inner join [orders327] O on O.CustomerID = C.CustomerID) T inner join [Employees327] E on E.EmployeeID = T.EmployeeID;

----- 17)Write a SQL query to retrieve the list of all employees who have placed an order, along with the customer who placed the order.
select * from (select E.*,O.OrderID,O.OrderDate,O.CustomerID from [Employees327] E inner join [orders327] O  on O.EmployeeID = E.EmployeeID) T inner join [Customers327] C on C.CustomerID = T.CustomerID

----- 18)Write a SQL query to retrieve the list of all orders placed by customers in a particular country, along with the customer name and order date.
select C.*,O.OrderID,O.OrderDate from [orders327] O inner join [Customers327] C on  O.CustomerID = C.CustomerID where C.Country ='Sri Lanka'

----- 19)Write a SQL query to retrieve the list of all orders placed by employees who were born in a particular year, along with the employee name and order date.
select E.*,O.OrderID,O.OrderDate from [orders327] O inner join [Employees327] E on O.EmployeeID = E.EmployeeID where year(E.BirthDate)='2001';

----- 20)Write a SQL query to retrieve the list of all customers who have placed an order, along with the customer name, order date, and employee who handled the order.
select * from (select C.*,O.OrderDate,O.EmployeeID from [Customers327] C inner join [orders327] O on O.CustomerID = C.CustomerID) T inner join [Employees327] E on E.EmployeeID = T.EmployeeID;

----- 21)Write a SQL query to retrieve the list of all orders placed by customers who have a particular contact title, along with the customer name and order date.
select C.*,O.OrderID,O.OrderDate from [orders327] O inner join [Customers327] C on O.CustomerID = C.CustomerID where C.ContactTitle ='Sales Manager';

----- 22)Write a SQL query to retrieve the list of all orders placed by employees who have a particular job title, along with the employee name and order date.
select E.*,O.OrderID,O.OrderDate from [orders327] O inner join [Employees327] E on O.EmployeeID = E.EmployeeID where E.Title = 'Sales Representative';

----- 23)Write a SQL query to retrieve the list of all customers who have placed an order on a particular date, along with the customer name, order date, and employee who handled the order.
select * from (select C.*,O.OrderDate,O.EmployeeID from [Customers327] C inner join [orders327] O on O.CustomerID = c.CustomerID where O.OrderDate ='2022-04-01') T inner join [Employees327] E on E.EmployeeID =T.EmployeeID;

----- 24)Write a SQL query to retrieve the list of all orders placed by customers in a particular city, along with the customer name and order date.
select C.*,O.OrderID,O.OrderDate from [orders327] O inner join [Customers327] C on O.CustomerID = C.CustomerID where C.City = 'Perth';

----- 25)Write a SQL query to retrieve the list of all orders placed by employees who were born in a particular city, along with the employee name and order date.
select E.*,O.OrderID,O.OrderDate from [orders327] O inner join [Employees327] E on O.EmployeeID = E.EmployeeID where E.[Address] ='Junagadh'; 

----- 26)Write a SQL query to retrieve the list of all customers who have placed an order, along with the customer name, order date, and employee who handled the order, sorted by order date.
select * from(select C.*,O.OrderDate,EmployeeID from [Customers327] C inner join [orders327] O on O.CustomerID = C.CustomerID) T inner join [Employees327] E on E.EmployeeID = T.EmployeeID order by T.OrderDate;

----- 27)Write a SQL query to retrieve the list of all orders placed by customers in a particular country, along with the customer name and order date, sorted by order date.
select C.*,O.OrderID,O.OrderDate from [orders327] O inner join  [Customers327] C on O.CustomerID = C.CustomerID where C.Country ='USA' order by O.OrderDate;
