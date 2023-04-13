use YK327YashKotadiya;

Create Table myCustomer(
	Id int identity(1,1),
	[Name] varchar(255),
	UserName varchar(255), 
	[Password] varchar(50),
	Email varchar(255),
	DOB date,
	[Address] varchar(255),
	ContactNo varchar(30)
);

Create Table mySalesman(
	Id int identity(1,1),
	[Name] varchar(255),
	UserName varchar(255),
	[Password] varchar(50),
	Email varchar(255),
	DOB date,
	[Address] varchar(255),
	ContactNo varchar(30)
);

Create Table myCategory(
	Id int identity(1,1),
	[Name] varchar(255)
);

Create Table myItems(
	Id int identity(1,1),
	[Name] varchar(255),
	Category int,
	Rate decimal(10,2),
	DOM date,
	DOE date 
);

Create Table ModeOfPayment(
	Id int identity(1,1),
	[Name] varchar(255)
);

Create Table myOrders(
	Id int identity(1,1),
	OrderNo int,
	Customer int,
	OrderQty  int,
	BillAmount decimal(10,2),
	DOD date,
	Salesman int,
	DeliveryAddress varchar(255),
	City varchar(50),
	ContactNo varchar(30),
	MOP int,
	OrderStatus int
);

Create Table OrderDetails(
	Id int identity(1,1),
	OrderId int,
	ItemId int,
	OrderQty int,
	OrderAmount decimal(10,2)
);

alter table myCustomer add constraint pk_cust_id primary key(id);
alter table mySalesman add constraint pk_sals_id primary key(id);
alter table myCategory add constraint pk_cat_id primary key(id);
alter table myItems add constraint pk_item_id primary key(id);
alter table ModeOfPayment add constraint pk_mop_id primary key(id);
alter table myOrders add constraint pk_ord_id primary key(id);
alter table OrderDetails add constraint pk_od_id primary key(id);

alter table myItems add constraint fk_cat_id foreign key(Category) references myCategory(id);
alter table myOrders add constraint fk_cust_id foreign key(Customer) references myCustomer(id);
alter table myOrders add constraint fk_sals_id foreign key(Salesman) references mySalesman(id);
alter table myOrders add constraint fk_mop_id foreign key(MOP) references ModeOfPayment(id);
alter table OrderDetails add constraint fk_ord_id foreign key(OrderId) references myOrders(id);
alter table OrderDetails add constraint fk_item_id foreign key(ItemId) references myItems(id);

alter table myCustomer add constraint uk_uname unique(UserName);
alter table myCustomer add constraint uk_email unique(Email);
alter table myOrders add constraint uk_ordno unique(OrderNo);

create or alter procedure SP_AddEditCustomer 
(
	@Id int,
	@Name varchar(255),
	@UserName varchar(255), 
	@Password varchar(50),
	@Email varchar(255),
	@DOB date,
	@Address varchar(255),
	@ContactNo varchar(30)
)
as
begin
if(@id is null)
begin
insert into myCustomer ([name],UserName,[Password],Email,DOB,[Address],ContactNo) values (@Name,@UserName,@Password,@Email,@DOB,@Address,@ContactNo)
end
else
begin
begin tran
update myCustomer set [Name]=@Name,UserName=@UserName,[Password]=@Password,Email=@Email,DOB=@DOB,[Address]=@Address,ContactNo=@ContactNo where id=@Id
commit tran
end
end

exec SP_AddEditCustomer null,'chirag','chirag123','chiku123','chirag@gmail.com','2002-01-01','PARIS','9756721378'
exec SP_AddEditCustomer null,'yash','yash123','yash14','yash@gmail.com','2001-12-14','junagadh','9737012270'
exec SP_AddEditCustomer null,'hemang','hemang123','hemu123','hemang@gmail.com','2002-11-17','bhuj','12345678'
exec SP_AddEditCustomer null,'vivek','vivek123','viku123','vivek@gmail.com','2002-04-23','deesa','8765432156'
exec SP_AddEditCustomer null,'bhavya','bhavya123','bhavya111','bhavya@gmail.com','2002-04-02','palanpur','765432234'

select * FROM myCustomer

--drop table myCustomer
--drop table myOrders
--drop table mySalesman
--drop table ModeOfPayment
--drop table myItems
--drop table myCategory
--drop table OrderDetails

create or alter procedure SP_AddEditSalesman
(
    @Id int,
	@Name varchar(255),
	@UserName varchar(255),
	@Password varchar(50),
	@Email varchar(255),
	@DOB date,
	@Address varchar(255),
	@ContactNo varchar(30)
)
as
begin 
if(@id is null)
begin
insert into mySalesman ([Name],UserName,[Password],Email,DOB,[Address],ContactNo) values (@Name,@UserName,@Password,@Email,@DOB,@Address,@ContactNo)
end
else
begin
begin tran
update mySalesman set [Name]=@Name,UserName=@UserName,[Password]=@Password,Email=@Email,DOB=@DOB,[Address]=@Address,ContactNo=@ContactNo where id=@id
commit tran
end
end

exec SP_AddEditSalesman null,'vatsal','vatsal123','vatsu123','vatsal@gmail.com','2002-08-05','baroda','987654324'
exec SP_AddEditSalesman 2,'yasni','yansi123','utu123','yansi@gmail.com','2002-04-02','amreli','8732112456'
exec SP_AddEditSalesman null,'krishna','krishna123','krishu123','krishna@gmail.com','2002-12-08','rjkt','876543212'
exec SP_AddEditSalesman null,'vidhi','vidhi123','vidhu123','vidhi@gmail.com','2001-06-08','dahod','987654325'
exec SP_AddEditSalesman null,'dhruvi','dhruvi123','dhruvi1234','dhruvi@gmail.com','2001-07-16','amd','97543123'

create or alter procedure SP_AddEditCategory
(
    @Id int ,
	@Name varchar(255)
)
as
begin
if(@id is null)
begin
insert into myCategory ([name]) values (@Name);
end
else
begin
begin tran
update myCategory set [name]=@Name where id=@Id
commit tran
end
end

exec SP_AddEditCategory null,'clothes'
exec SP_AddEditCategory null,'watches'
exec SP_AddEditCategory null,'moblies'
exec SP_AddEditCategory null,'cars'
exec SP_AddEditCategory null,'laptops'

create or alter procedure SP_AddEditItems
(
	@Id int,
	@Name varchar(255),
	@Category int,
	@Rate decimal(10,2),
	@DOM date,
	@DOE date 
)
as
begin
if(@id is null)
begin
insert into myItems ([Name],Category,Rate,DOM,DOE) values (@Name,@Category,@Rate,@DOM,@DOE);
end
else
begin
begin tran
update myItems set [name]=@Name,Category=@Category,Rate=@Rate,DOM=@DOM,DOE=@DOE where id=@Id;
commit tran
end
end

exec SP_AddEditItems null,'shirt',1,500,'2021-09-04','2022-08-04'
exec SP_AddEditItems null,'tshirt',1,700,'2021-04-04','2022-06-04'
exec SP_AddEditItems null,'rado',2,2500,'2021-01-01','2022-03-09'
exec SP_AddEditItems null,'oppo',3,7000,'2021-10-21','2022-12-04'
exec SP_AddEditItems null,'verna',4,9000,'2021-11-27','2022-02-25'
exec SP_AddEditItems null,'dell',5,8000,'2021-12-15','2022-05-05'


create or alter procedure SP_AddEditModeOfPayment
(
	@Id int,
	@Name varchar(255)
)
as
begin
if(@id is null)
begin
insert into ModeOfPayment ([Name]) values (@Name);
end
else
begin
begin tran
update ModeOfPayment set [Name]=@Name where id=@Id;
commit tran
end
end

exec SP_AddEditModeOfPayment null,'upi'
exec SP_AddEditModeOfPayment null,'net banking'
exec SP_AddEditModeOfPayment null,'cash'
exec SP_AddEditModeOfPayment null,'emi'
exec SP_AddEditModeOfPayment null,'credit card'

create or alter procedure SP_AddEditOrders
(
    @Id int ,
	@OrderNo int,
	@Customer int,
	@OrderQty  int,
	@BillAmount decimal(10,2),
	@DOD date,
	@Salesman int,
	@DeliveryAddress varchar(255),
	@City varchar(50),
	@ContactNo varchar(30),
	@MOP int,
	@OrderStatus int
)
as
begin 
if(@id is null)
begin
insert into myOrders (OrderNo,Customer,OrderQty,BillAmount,DOD,Salesman,DeliveryAddress,City,ContactNo,MOP,OrderStatus) values (@OrderNo,@Customer,@OrderQty,@BillAmount,@DOD,@Salesman,@DeliveryAddress,@City,@ContactNo,@MOP,@OrderStatus)
end
else
begin
begin tran
update myOrders set OrderNo=@OrderNo,Customer=@Customer,OrderQty=@OrderQty,BillAmount=@BillAmount,DOD=@DOD,Salesman=@Salesman,DeliveryAddress=@DeliveryAddress,City=@City,ContactNo=@ContactNo,MOP=@MOP,OrderStatus=@OrderStatus where id=@Id
commit tran
end
end

exec SP_AddEditOrders null,1,1,2,2000,'2021-12-12',1,'ahmedabad','rjkt','0987654312',1,2
exec SP_AddEditOrders null,2,1,1,2000,'2021-04-15',2,'junagadh','amreli','87765654',1,1
exec SP_AddEditOrders null,3,2,3,2000,'2021-07-18',3,'baroda','deesa','132456789',2,2
exec SP_AddEditOrders null,4,3,2,2000,'2021-05-17',4,'surat','palanpur','9675434323',3,1
exec SP_AddEditOrders null,5,4,3,2000,'2021-01-11',5,'rajkot','dahod','78756432',4,2

create or alter procedure SP_AddEditOrderDetails
(
	@Id int,
	@OrderId int,
	@ItemId int,
	@OrderQty int,
	@OrderAmount decimal(10,2)
)
as
begin
if(@id is null)
begin
insert into OrderDetails (OrderId,ItemId,OrderQty,OrderAmount) values (@OrderId,@ItemId,@OrderQty,@OrderAmount);
end
else
begin
begin tran
update OrderDetails set OrderId=@OrderId,ItemId=@ItemId,@OrderQty=@OrderQty,OrderAmount=@OrderAmount where id=@id;
commit tran
end
end

exec SP_AddEditOrderDetails null,1,1,1,500
exec SP_AddEditOrderDetails null,2,2,2,1000
exec SP_AddEditOrderDetails null,3,3,1,2000
exec SP_AddEditOrderDetails null,4,4,3,3000
exec SP_AddEditOrderDetails null,5,5,2,1500

--5. Create a prameterized Store Procedure to retrive all the Order Information as per Customer. (If CustomerId not passed then retrive all the orders) [8]
--	Information I want : 
--		--CustomerName
--		--OrderNo
--		--OrderQty (Total Qty of all the Items) (Using Function)
--		--OrderAmount (Total Amount of Order) (Using Function)
--		--SalesmanName
--		--Address
--		--City
--		--ContactNo
--		--MOP Name
--		--DOD
		
		
	CREATE OR ALTER FUNCTION TOTALQTY(@customerid int)
	RETURNS INT
	AS
	BEGIN
	DECLARE @total int
	   set @total =  (select sum(OrderQty) from myOrders where Customer = @customerid)
	   return @total
	END
	select dbo.TOTALQTY(1) as TotalQty

	create or alter function totalamount(@customerid int)
     returns decimal (10,2)
	 as
	 begin 
	 DECLARE @total decimal (10,2)
	  set @total =  (select sum(OrderAmount) from OrderDetails od inner join myOrders mo on od.OrderId = mo.Id where Customer = @customerid)
	  return @total                                  
	 end
	select dbo.totalamount(1) as TotalOrderAmount

	create or alter procedure SP_retriveOrderInformation
	(
	@customer_id int
	)
	as
	begin
	if(@customer_id is null)
	begin
	   select mc.[Name],mo.OrderNo,dbo.TOTALQTY(@customer_id) as TotalQty, dbo.totalamount(@customer_id) as TotalOrderAmount,ms.[name],mc.[Address],mc.ContactNo,mo.City,mop.[Name],mo.DOD from myCustomer mc inner join  
	   myOrders mo on mc.Id = mo.Customer inner join mySalesman ms on ms.Id = mo.Salesman inner join ModeOfPayment mop on mop.Id =  mo.MOP
	end
	else
	begin
	   select mc.[Name],mo.OrderNo,dbo.TOTALQTY(@customer_id) as TotalQty, dbo.totalamount(@customer_id) as TotalOrderAmount,ms.[name],mc.[Address],mc.ContactNo,mo.City,mop.[Name],mo.DOD from myCustomer mc inner join  
	   myOrders mo on mc.Id = mo.Customer inner join mySalesman ms on ms.Id = mo.Salesman inner join ModeOfPayment mop on mop.Id =  mo.MOP
	   where mc.Id = @customer_id
	end
	end

	exec SP_retriveOrderInformation 2

--4. Create a User Defined Function that will retrive TotalOrderAmount from the OrderDetails Table as per Customer. [8]
--	I just want total amount as per customerid I Passed.

create or alter function TotalOrderAmount(@customer_id int)
returns decimal(10,2)
as
begin
	 DECLARE @total decimal (10,2)
    set @total = (select sum(OrderAmount) from OrderDetails od inner join myOrders mo on od.OrderId =mo.Id where customer =@customer_id)
	return @total
end
select dbo.totalamount(1) as TotalOrderAmount



--3. Create a Parmeterized Store Procedure to retrive all the OrderDetails as per Customer (If CustomerId not passed then retrive all the orders) ( Make sure to Add Everything in Single Procedure) [8]
--	Information I want : 
		--CustomerName
		--ItemName
		--Item Rate
		--Qty
		--OrderAmount (Qty * ItemRate)
	
	create or alter procedure SP_allOrderDetails
	(
	@customer_id int
	)
	 as
	 begin
	 if(@customer_id is null)
	 begin
	 select mc.[Name],mi.[Name],mi.Rate,od.OrderAmount,mo.OrderQty from myOrders mo inner join myCustomer mc on mo.Customer = mc.Id inner join OrderDetails od on od.OrderId = mo.Id inner join myItems mi on mi.Id = od.ItemId
	 end
	 else
	 begin
	  select mc.[Name],mi.[Name],mi.Rate,od.OrderAmount,mo.OrderQty from myOrders mo inner join myCustomer mc on mo.Customer = mc.Id inner join OrderDetails od on od.OrderId = mo.Id inner join myItems mi on mi.Id = od.ItemId where mc.Id = @customer_id;
	 end
	 end

 exec SP_allOrderDetails 2

 --6. Create a Parameterized Store Procedure to Cancel Order as per OrderNo (If I pass wrong orderno then message should be there)

 create or alter procedure CancelOrder
 (
 @orderno int
 )
 as
 begin
 if(@orderno in (select OrderNo from myOrders))
 begin
    begin tran
	     update myOrders set OrderStatus = 2 where OrderNo = @orderno
	commit tran
 end
 else
 begin
 print 'enter valid no.'
 end
 end

 exec CancelOrder 2