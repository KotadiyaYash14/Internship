USE [YK327YashKotadiya];

Create Table YKCustomer(
C_ID Int primary key identity(1,1) not null,
C_Name Varchar(255),
C_Address varchar(255)
)

Create Table YKProduct(
P_ID int primary key identity(1,1) not null,
P_Name varchar(255),
P_Price decimal(6,2),
);

Create Table YKOrder(
O_ID int primary key identity(1,1) not null,
O_Date Date,
O_Amount decimal(6,2),
C_ID int foreign key references YKCustomer(C_ID),
P_ID int foreign key references YKProduct(P_ID),
P_Quantity int,
PaymentStatus char(10) check (PaymentStatus = 'Paid' or PaymentStatus='Unpaid')
);

--- exec Sp_rename 'YKOrder.Cust_ID' , 'C_ID', 'Column';

select * from YKCustomer;
select * from YKProduct;
select * from YKOrder;

insert into YKCustomer (C_Name,C_Address) 
values ('Yash','Junagadh'),
('Vasu','Rajkot'),
('Prince','Baroda'),
('Virag','Jamnagar'),
('Bhavya','Palanpur'),
('Chirag','Siddhpur'),
('Hemang','Bhuj'),
('Vivek','Dessa'),
('Sahil','Surat'),
('Darshan','Bhavanagar'),
('Arpit','Anand'),
('Mayank','Rajkot'),	
('Pratik','Keshod'),
('Kavan','Junagadh'),
('Bhautik','Vidhyanagar'),
('Nikunj','Amreli'),
('Smit','Baroda'),
('Om','Ahmedabad'),
('Dhruval','Surat'),
('Ravi','Morbi');

insert into YKProduct (P_Name,P_Price)
values ('Car',3000),
('Bike',2500),
('Mobile',1500),
('Laptop',2000),
('Computer',2200),
('AC',2300),
('Refrigerator',2800),
('Washing Machine',1000),
('TV',2000),
('Shoose',1000),
('Watch',1200),
('Key Board',800),
('Mouse',500),
('Fan',1300),
('Cemera',1700),
('HeadPhones',1100),
('Goggles',900),
('CPU',2300),
('Bag',500),
('Lamp',400);

insert into YKOrder (O_Date,O_Amount,C_ID,P_ID,P_Quantity,PaymentStatus)
values ('2019-12-11',1000,1,1,1,'Paid'),
('2019-11-23',1200,2,2,2,'Paid'),
('2019-03-21',2000,3,3,3,'Unpaid'),
('2019-01-01',1500,4,4,2,'Unpaid'),
('2019-11-25',1600,5,5,1,'Paid'),
('2020-07-17',2000,6,6,4,'Paid'),
('2020-12-05',2100,7,7,5,'Unpaid'),
('2020-05-01',2000,8,8,3,'Paid'),
('2020-02-25',1900,9,9,1,'Unpaid'),
('2020-09-20',1300,10,10,7,'Paid'),
('2021-11-05',2300,11,11,6,'Paid'),
('2021-10-07',900,12,12,3,'Unpaid'),
('2021-07-20',1600,13,13,2,'Unpaid'),
('2021-06-08',500,14,14,9,'Unpaid'),
('2021-05-30',1300,15,15,4,'Paid'),
('2022-06-28',2600,1,1,3,'Paid'),
('2022-05-03',1000,2,5,6,'Unpaid'),
('2022-01-03',1400,4,3,7,'Paid'),
('2023-08-20',2300,5,8,4,'Paid'),
('2023-09-12',1100,3,2,10,'Unpaid');

--- 1.Create a stored procedure called "get_customers" that returns all customers from the "customers" table.
Create Procedure Sp_get_customers 
AS
Begin
select * from YKCustomer;
End

exec Sp_get_customers;

--- 2.Create a stored procedure called "get_orders" that returns all orders from the "orders" table.
Create procedure Sp_get_orders
AS
Begin
select * from YKOrder;
End

exec Sp_get_orders;

--- 3.Create a stored procedure called "get_order_details" that accepts an order ID as a parameter and returns the details of that order (i.e., the products and quantities).
Create Procedure Sp_get_order_details @order_Id int 
AS
Begin
select O.*,P.P_Name,P.P_Price from [YKOrder] O inner join [YKProduct] P on O.O_Id = P.P_ID where O.O_Id = @order_Id; 
End

exec Sp_get_order_details @order_Id = 1;

--- 4.Create a stored procedure called "get_customer_orders" that accepts a customer ID as a parameter and returns all orders for that customer.
create Procedure Sp_get_customer_orders @customer_Id int
AS
Begin
select * from [YKOrder] where C_ID = @customer_Id;
End

exec Sp_get_customer_orders @customer_Id = 2;

--- 5.Create a stored procedure called "get_order_total" that accepts an order ID as a parameter and returns the total amount of the order.
create Procedure sp_get_order_total @order_Id int
AS
Begin
select sum(O.O_Amount) as TotalAmount,O.O_Id from [YKOrder] O group by O.O_Id having O.O_Id = @order_Id;
End

exec sp_get_order_total @order_Id = 1;

--- 6.Create a stored procedure called "get_product_list" that returns a list of all products from the "products" table.
create procedure Sp_get_product_list
AS
begin
select * from [YKProduct]
end

exec Sp_get_product_list;

--- 7.Create a stored procedure called "get_product_info" that accepts a product ID as a parameter and returns the details of that product.
Create procedure Sp_get_product_info @product_Id int
AS
begin
select * from [YKProduct] where P_ID = @product_Id;
end

exec Sp_get_product_info @product_Id = 3;

--- 8.Create a stored procedure called "get_customer_info" that accepts a customer ID as a parameter and returns the details of that customer.
create procedure Sp_get_customer_info @customer_id int 
As
begin
select * from [YKCustomer] where C_ID = @customer_id ;
end

exec Sp_get_customer_info @customer_id = 4;

--- 9.Create a stored procedure called "update_customer_info" that accepts a customer ID and new information as parameters and updates the customer's information in the "customers" table.
create procedure Sp_update_customer_info @customer_Id int, @customer_name varchar(255), @customer_address varchar(255)
As
begin
begin tran
update [YKCustomer] set C_Name = @customer_name, C_Address = @customer_address where C_ID = @customer_Id;
commit tran
select * from [YKCustomer] where C_Id = @customer_Id;
end

exec Sp_update_customer_info @customer_Id = 1, @customer_name = 'John', @customer_address = 'Mumbai';

--- 10.Create a stored procedure called "delete_customer" that accepts a customer ID as a parameter and deletes that customer from the "customers" table.
create procedure Sp_delete_customer @customer_Id int
As
begin
delete from [YKCustomer] where C_ID = @customer_Id;
end

exec Sp_delete_customer @customer_Id = 20;

--- 11.Create a stored procedure called "get_order_count" that accepts a customer ID as a parameter and returns the number of orders for that customer.
Create procedure Sp_get_order_count @customer_Id int
As
begin
select C_ID,count(*) as TotalOrders from [YKOrder] where C_ID = @customer_Id group by C_ID;
end

exec Sp_get_order_count @customer_Id = 15;

--- 12.Create a stored procedure called "get_customer_balance" that accepts a customer ID as a parameter and returns the customer's balance (i.e., the total amount of all orders minus the total amount of all payments).
create procedure Sp_get_customer_balance @customer_Id int
as
begin
declare @Total decimal(6,2) = (select sum(O_Amount) from YKOrder where C_ID = @customer_Id);
declare @TotalPayments decimal(6,2) = (select sum(O_Amount) from YKOrder where C_ID = @customer_Id and PaymentStatus = 'Paid')
print @Total - @TotalPayments;
end

exec Sp_get_customer_balance @customer_Id = 2

--- 13.Create a stored procedure called "get_customer_payments" that accepts a customer ID as a parameter and returns all payments made by that customer.
create procedure Sp_get_customer_payments @customer_Id int
As
begin
select * from YKOrder where C_Id = @customer_Id and PaymentStatus = 'Paid';
end

exec Sp_get_customer_payments @customer_Id = 2;

--- 14.Create a stored procedure called "add_customer" that accepts a name and address as parameters and adds a new customer to the "customers" table.
create procedure Sp_add_customer @customer_name varchar(255), @customer_address varchar(255)
As
begin
insert into YKCustomer values (@customer_name,@customer_address)
end

exec Sp_add_customer @customer_name = 'Virat', @customer_address = 'Delhi';

--- 15.Create a stored procedure called "get_top_products" that returns the top 10 products based on sales volume.
create procedure Sp_get_top_products
As
begin
select P.P_Name,O.P_ID,sum(O.P_Quantity) as TotalSalesVolume from YKOrder O inner join YKProduct P on O.P_ID = P.P_ID group by O.P_ID,P.P_Name;
end 

exec Sp_get_top_products;

--- 16.Create a stored procedure called "get_product_sales" that accepts a product ID as a parameter and returns the total sales volume for that product.
create procedure Sp_get_product_sales @product_Id int
as
begin
select P.P_Name,O.P_ID,sum(P_Quantity) as TotalSalesVolume from YKOrder O inner join YKProduct P on O.P_ID = P.P_ID where O.P_ID = @product_Id group by O.P_ID,P.P_Name;
end

exec Sp_get_product_sales @product_Id = 8;

--- 17.Create a stored procedure called "get_customer_orders_by_date" that accepts a customer ID and date range as parameters and returns all orders for that customer within the specified date range.
create procedure Sp_get_customer_orders_by_date @customer_Id int, @Startdate date, @EndDate date
As
begin
select * from YKOrder where C_ID = @customer_Id and O_Date between @Startdate and @EndDate
end

exec Sp_get_customer_orders_by_date @customer_Id = 5, @Startdate = '2019-11-25', @EndDate= '2022-01-03';

--- 18.Create a stored procedure called "get_order_details_by_date" that accepts an order ID and date range as parameters and returns the details of that order within the specified date range.
CREATE procedure Sp_get_order_details_by_date @order_Id int ,@Startdate date, @EndDate date
as
begin
select * from YKOrder where O_Id = @order_Id  and O_Date between @Startdate and @EndDate;
end

exec Sp_get_order_details_by_date @order_Id = 1, @Startdate = '2019-12-11', @EndDate = '2023-11-25';

--- 19.Create a stored procedure called "get_product_sales_by_date" that accepts a product ID and date range as parameters and returns the total sales volume for that product within the specified date range.
create procedure Sp_get_product_sales_by_date @product_Id int,@Startdate date, @EndDate date
as
begin
select P.P_Name,O.P_ID,sum(P_Quantity) as TotalSalesVolume from YKOrder O inner join YKProduct P on O.P_ID = P.P_ID
where O.P_ID = @product_Id and O_Date between @Startdate and @EndDate group by P.P_Name,O.P_ID;
end

exec Sp_get_product_sales_by_date @product_Id = 5, @Startdate = '2019-11-25', @EndDate = '2023-09-12';

--- 20.Create a stored procedure called "get_customer_balance_by_date" that accepts a customer ID and date range as parameters and returns the customer's balance within the specified date range.
create procedure get_customer_balance_by_date @customer_Id int, @Startdate date, @EndDate date
as
begin
select C_ID,sum(O_Amount) as TotalAmount from YKOrder where C_ID = @customer_Id and O_Date between @Startdate and @EndDate group by C_ID;
end

exec get_customer_balance_by_date @customer_Id = 1, @Startdate = '2019-12-11', @EndDate = '2023-05-03';

--- 21.Create a stored procedure called "add_order" that accepts a customer ID, order date, and total amount as parameters and adds a new order to the "orders" table.
create procedure add_order @customer_Id int, @order_date date, @newTotalAmount decimal(6,2)
as
begin
insert into YKOrder (C_ID,O_Date,O_Amount)values (@customer_Id,@order_date,@newTotalAmount);
end

exec add_order @customer_Id= 19, @order_date = '2023-03-01', @newTotalAmount = 1000;

--- 22.Create a stored procedure called "update_order_total" that accepts an order ID and a new total amount as parameters and updates the total amount of the order in the "orders" table.
create procedure Sp_update_order_total @order_Id int, @newTotalAmount decimal(6,2)
AS
begin
begin tran
update YKOrder set O_Amount = @newTotalAmount where O_Id = @order_Id;
commit tran
end

exec Sp_update_order_total @order_Id = 1, @newTotalAmount = 200;

--- 23.Create a stored procedure called "delete_order" that accepts an order ID as a parameter and deletes that order from the "orders" table.
create procedure Sp_delete_order @order_Id int
as
begin
delete from YKOrder where O_ID = @order_Id;
end

exec Sp_delete_order @order_Id = 20;