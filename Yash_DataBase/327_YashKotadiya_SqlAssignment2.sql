USE [YK327YashKotadiya]

----- Create Employee Department Table -----
Create table [emp_department](
[DPT_CODE] int primary key not null,
[DPT_NAME] varchar(250) not null,
[DPT_ALLOTMENT] bigint
);

----- Insert Record into Employee Department Deatils Table-----
insert into [emp_department]([DPT_CODE],[DPT_NAME],[DPT_ALLOTMENT])values(57,'IT',65000);
insert into [emp_department]([DPT_CODE],[DPT_NAME],[DPT_ALLOTMENT])values(63,'Finance',15000);
insert into [emp_department]([DPT_CODE],[DPT_NAME],[DPT_ALLOTMENT])values(47,'HR',240000);
insert into [emp_department]([DPT_CODE],[DPT_NAME],[DPT_ALLOTMENT])values(27,'RD',55000);
insert into [emp_department]([DPT_CODE],[DPT_NAME],[DPT_ALLOTMENT])values(89,'QC',75000);

select * from [emp_department]

----- Create Employee Deatils Table -----
Create Table [emp_details](
[EMP_IDNO] int primary key,
[EMP_FNAME] varchar(250) not null,
[EMP_LNAME] varchar(250) not null,
[EMP_DEPT] int foreign key references [emp_department](DPT_CODE) not null
);

----- Insert Record into Employee Deatils Table -----
insert into [emp_details]([EMP_IDNO],[EMP_FNAME],[EMP_LNAME],[EMP_DEPT])values(127323,'Michale','Robbin',57);
insert into [emp_details]([EMP_IDNO],[EMP_FNAME],[EMP_LNAME],[EMP_DEPT])values(526689,'Carlos','Snares',63);
insert into [emp_details]([EMP_IDNO],[EMP_FNAME],[EMP_LNAME],[EMP_DEPT])values(843795,'Enric','Dosio',57);
insert into [emp_details]([EMP_IDNO],[EMP_FNAME],[EMP_LNAME],[EMP_DEPT])values(328717,'Jhon','Snares',63);
insert into [emp_details]([EMP_IDNO],[EMP_FNAME],[EMP_LNAME],[EMP_DEPT])values(444527,'Joseph','Dosni',47);
insert into [emp_details]([EMP_IDNO],[EMP_FNAME],[EMP_LNAME],[EMP_DEPT])values(659831,'Zanifer','Emily',47);
insert into [emp_details]([EMP_IDNO],[EMP_FNAME],[EMP_LNAME],[EMP_DEPT])values(847674,'Kuleswar','Sitaraman',57);
insert into [emp_details]([EMP_IDNO],[EMP_FNAME],[EMP_LNAME],[EMP_DEPT])values(748681,'Henrey','Gabriel',47);
insert into [emp_details]([EMP_IDNO],[EMP_FNAME],[EMP_LNAME],[EMP_DEPT])values(555935,'Alex','Manuel',57);
insert into [emp_details]([EMP_IDNO],[EMP_FNAME],[EMP_LNAME],[EMP_DEPT])values(539569,'George','Mardy',27);
insert into [emp_details]([EMP_IDNO],[EMP_FNAME],[EMP_LNAME],[EMP_DEPT])values(733843,'Mario','Saule',63);
insert into [emp_details]([EMP_IDNO],[EMP_FNAME],[EMP_LNAME],[EMP_DEPT])values(631548,'Alan','Snappy',27);
insert into [emp_details]([EMP_IDNO],[EMP_FNAME],[EMP_LNAME],[EMP_DEPT])values(839139,'Maria','Foster',57);

select * from [emp_details]

----- Create Company Table -----
Create table [company_mast](
[COM_ID] int primary key,
[COM_NAME] varchar(250)
);

----- Insert Record into Company Table -----
insert into[company_mast]([COM_ID],[COM_NAME])values(11,'Samsung');
insert into[company_mast]([COM_ID],[COM_NAME])values(12,'iBall');
insert into[company_mast]([COM_ID],[COM_NAME])values(13,'Epsion');
insert into[company_mast]([COM_ID],[COM_NAME])values(14,'Zebronics');
insert into[company_mast]([COM_ID],[COM_NAME])values(15,'Asus');
insert into[company_mast]([COM_ID],[COM_NAME])values(16,'Frontech');

select * from [company_mast]

----- Create Item Table -----
Create table [item_mast](
[PRO_ID] int primary key,
[PRO_NAME] varchar(250),
[PRO_PRICE] decimal,
[PRO_COM] int foreign key references [company_mast](COM_ID)
);

----- Insert Record into Item Table -----
insert into[item_mast]([PRO_ID],[PRO_NAME],[PRO_PRICE],[PRO_COM])values(101,'Mother Board',3200,15);
insert into[item_mast]([PRO_ID],[PRO_NAME],[PRO_PRICE],[PRO_COM])values(102,'Key Board',450,16);
insert into[item_mast]([PRO_ID],[PRO_NAME],[PRO_PRICE],[PRO_COM])values(103,'ZIP drive',250,14);
insert into[item_mast]([PRO_ID],[PRO_NAME],[PRO_PRICE],[PRO_COM])values(104,'Speaker',550,16);
insert into[item_mast]([PRO_ID],[PRO_NAME],[PRO_PRICE],[PRO_COM])values(105,'Monitor',5000,11);
insert into[item_mast]([PRO_ID],[PRO_NAME],[PRO_PRICE],[PRO_COM])values(106,'DVD drive',900,12);
insert into[item_mast]([PRO_ID],[PRO_NAME],[PRO_PRICE],[PRO_COM])values(107,'CD drive',800,12);
insert into[item_mast]([PRO_ID],[PRO_NAME],[PRO_PRICE],[PRO_COM])values(108,'Printer',2600,13);
insert into[item_mast]([PRO_ID],[PRO_NAME],[PRO_PRICE],[PRO_COM])values(109,'Refill cartridge ',350,13);
insert into[item_mast]([PRO_ID],[PRO_NAME],[PRO_PRICE],[PRO_COM])values(110,'Mouse ',250,12);

select * from [item_mast]

----- Create Salesman Table -----
Create Table [salesman1](
[salesman_id] int primary key,
[name] varchar(250),
[city] varchar(250),
[commission] decimal
);

----- Insert Record into Salesman Table -----
insert into [salesman1]([salesman_id],[name],[city],[commission])values(5001,'James Hoog','New York',0.15);
insert into [salesman1]([salesman_id],[name],[city],[commission])values(5002,'Nail Knite','Paris',0.13);
insert into [salesman1]([salesman_id],[name],[city],[commission])values(5005,'Pit Alex','London',0.11);
insert into [salesman1]([salesman_id],[name],[city],[commission])values(5006,'Mc Lyon','Paris',0.14);
insert into [salesman1]([salesman_id],[name],[city],[commission])values(5007,'Paul Adam ','Rome',0.13);
insert into [salesman1]([salesman_id],[name],[city],[commission])values(5003,'Lauson Hen','San Jose',0.12);

select * from [salesman1]

----- Create Customer Table -----
Create Table [customer](
[customer_id] int primary key,
[cust_name] varchar(250),
[city] varchar(250),
[grade] int,
[salesman_id] int foreign key references [salesman1](salesman_id)
);

----- Insert Record into Customer Table -----
insert into [customer]([customer_id],[cust_name],[city],[grade],[salesman_id])values(3002,'Nick Rimando','New York',100,5001);
insert into [customer]([customer_id],[cust_name],[city],[grade],[salesman_id])values(3007,'Brad Davis','New York',200,5001);
insert into [customer]([customer_id],[cust_name],[city],[grade],[salesman_id])values(3005,'Graham Zusi','California',200,5002);
insert into [customer]([customer_id],[cust_name],[city],[grade],[salesman_id])values(3008,'Julian Green','London',300,5002);
insert into [customer]([customer_id],[cust_name],[city],[grade],[salesman_id])values(3004,'Fabian Johnson','Peris',300,5006);
insert into [customer]([customer_id],[cust_name],[city],[grade],[salesman_id])values(3009,'Geoff Cameron','Berlin',100,5003);
insert into [customer]([customer_id],[cust_name],[city],[grade],[salesman_id])values(3003,'Jozy Altidor ','Moscow',200,5007);
insert into [customer]([customer_id],[cust_name],[city],[grade],[salesman_id])values(3001,'Brad Guzan','London',null,5005);

select * from [customer]

----- Create Orders Table -----
Create table [Orders](
[ord_no] int primary key,
[purch_amt] decimal,
[ord_date] date,
[customer_id] int foreign key references [customer](customer_id),
[salesman_id] int foreign key references [salesman1](salesman_id)
);

----- Insert Record into Orders Table -----
insert into[Orders]([ord_no],[purch_amt],[ord_date],[customer_id],[salesman_id])values(70001,150.5,'2012-10-05',3005,5002);
insert into[Orders]([ord_no],[purch_amt],[ord_date],[customer_id],[salesman_id])values(70009,270.65,'2012-09-10',3001,5005);
insert into[Orders]([ord_no],[purch_amt],[ord_date],[customer_id],[salesman_id])values(70002,65.26,'2012-10-05',3002,5001);
insert into[Orders]([ord_no],[purch_amt],[ord_date],[customer_id],[salesman_id])values(70004,110.5,'2012-08-17',3009,5003);
insert into[Orders]([ord_no],[purch_amt],[ord_date],[customer_id],[salesman_id])values(70007,948.5,'2012-09-10',3005,5002);
insert into[Orders]([ord_no],[purch_amt],[ord_date],[customer_id],[salesman_id])values(70005,2400.6,'2012-07-27',3007,5001);
insert into[Orders]([ord_no],[purch_amt],[ord_date],[customer_id],[salesman_id])values(70008,5760,'2012-09-10',3002,5001);
insert into[Orders]([ord_no],[purch_amt],[ord_date],[customer_id],[salesman_id])values(70010,1983.43,'2012-10-10',3004,5006);
insert into[Orders]([ord_no],[purch_amt],[ord_date],[customer_id],[salesman_id])values(70003,2480.4,'2012-10-10',3009,5003);
insert into[Orders]([ord_no],[purch_amt],[ord_date],[customer_id],[salesman_id])values(70012,250.45,'2012-06-27',3008,5002);
insert into[Orders]([ord_no],[purch_amt],[ord_date],[customer_id],[salesman_id])values(70011,75.29 ,'2012-08-17',3003,5007);
insert into[Orders]([ord_no],[purch_amt],[ord_date],[customer_id],[salesman_id])values(70013,3045.6,'2012-04-25',3002,5001);

select * from [Orders]

----- (1) Write a SQL statement to find the total purchase amount of all orders. -----
SELECT SUM(O.purch_amt) AS totalPurchaseAmount FROM [orders] O;

----- (2) Write a SQL statement to find the average purchase amount of all orders. -----
SELECT AVG(O.purch_amt) AS averagePurchaseAmount FROM [orders] O;

----- (3) Write a SQL statement to find the number of salesmen currently listing for all of their customers -----
SELECT COUNT(C.salesman_id) FROM [customer] C;

----- (4) Write a SQL statement to know how many customer have listed their names. -----
SELECT COUNT(C.customer_id) FROM [customer] C;

----- (5) Write a SQL statement find the number of customers who gets at least a gradation for his/her performance -----
SELECT COUNT(C.customer_id) FROM [customer] C WHERE C.grade IS NOT NULL;

----- (6) Write a SQL statement to get the maximum purchase amount of all the orders -----
SELECT MAX(O.purch_amt) AS maximumPurchaseAmount FROM [orders] O;

----- (7) Write a SQL statement to get the minimum purchase amount of all the orders -----
SELECT MIN(O.purch_amt) AS minimumPurchaseAmount FROM [orders] O;

----- (8) Write a SQL statement which selects the highest grade for each of the cities of the customers. -----
SELECT C.city, MAX(C.grade) FROM [customer] C GROUP BY C.city ;

----- (9) Write a SQL statement to find the highest purchase amount ordered by the each customer with their ID and highest purchase amount. -----
SELECT O.customer_id, MAX(O.purch_amt) AS maximumPurchaseAmount FROM [orders] O GROUP BY O.customer_id;

----- (10) Write a SQL statement to find the highest purchase amount ordered by the each customer on a particular date with their ID, order date and highest purchase amount. -----
SELECT O.customer_id,O.ord_date, MAX(O.purch_amt) AS maximumPurchaseAmount FROM [orders] O GROUP BY O.customer_id,O.ord_date;

----- (11) Write a SQL statement to find the highest purchase amount on a date '2012-08-17' for each salesman with their ID. -----
SELECT O.salesman_id,MAX(O.purch_amt) AS maximumPurchaseAmount FROM [orders] O  WHERE O.ord_date='2012-08-17' GROUP BY O.salesman_id;

----- (12) Write a SQL statement to find the highest purchase amount with their ID and order date, for only those customers who have highest purchase amount in a day is more than 2000. -----
SELECT O.customer_id,O.ord_date,MAX(O.purch_amt) AS maximumPurchaseAmount FROM [orders] O GROUP BY O.customer_id,O.ord_date HAVING MAX(O.purch_amt)>2000;

----- (13) Write a SQL statement to find the highest purchase amount with their ID and order date, for those customers who have a higher purchase amount in a day is within the range 2000 and 6000 -----
SELECT O.customer_id,O.ord_date,MAX(O.purch_amt) AS maximumPurchaseAmount FROM [orders] O  GROUP BY O.customer_id,O.ord_date HAVING MAX(O.purch_amt) BETWEEN 2000 AND 6000; 

----- (14) Write a SQL statement to find the highest purchase amount with their ID and order date, for only those customers who have a higher purchase amount in a day is within the list 2000, 3000, 5760 and 6000. -----
SELECT O.customer_id,O.ord_date,MAX(O.purch_amt) AS maximumPurchaseAmount FROM [orders] O GROUP BY O.customer_id,O.ord_date HAVING MAX(O.purch_amt) IN (2000,3000,5760,6000); 

----- (15) Write a SQL statement to find the highest purchase amount with their ID, for only those customers whose ID is within the range 3002 and 3007. -----
SELECT O.customer_id,MAX(O.purch_amt) AS maximumPurchaseAmount FROM [orders] O GROUP BY O.customer_id HAVING(O.customer_id) BETWEEN 3002 AND 3007;

----- (16) Write a SQL statement to display customer details (ID and purchase amount) whose IDs are within the range 3002 and 3007 and highest purchase amount is more than 1000.  -----
SELECT O.customer_id,MAX(O.purch_amt) AS maximumPurchaseAmount FROM [orders] O GROUP BY O.customer_id HAVING(O.customer_id) BETWEEN 3002 AND 3007 AND MAX(O.purch_amt)>1000;

----- (17) Write a SQL statement to find the highest purchase amount with their ID, for only those salesmen whose ID is within the range 5003 and 5008. -----
SELECT O.customer_id,O.salesman_id,MAX(O.purch_amt) AS maximumPurchaseAmount FROM [orders] O GROUP BY O.customer_id,O.salesman_id HAVING (O.salesman_id) BETWEEN 5005 AND 5008; 

----- (18) Write a SQL statement that counts all orders for a date August 17th, 2012. -----
SELECT COUNT(O.customer_id) FROM [orders] O WHERE O.ord_date = '2012-08-17';

-----  (19) Write a SQL statement that count the number of salesmen for whom a city is specified. Note that there may be spaces or no spaces in the city column if no city is specified. -----
SELECT COUNT(S.salesman_id) FROM[salesman] S WHERE S.city is not null;

----- (20) Write a query that counts the number of salesmen with their order date and ID registering orders for each day. -----
SELECT COUNT(O.salesman_id),O.ord_date,O.salesman_id  FROM[orders] O GROUP BY O.ord_date,O.salesman_id;

----- (21) Write a SQL query to calculate the average price of all the products. -----
SELECT AVG(I.PRO_PRICE) AS averageProductPrice from [item_mast] I;

----- (22) Write a SQL query to find the number of products with a price more than or equal to Rs.350. -----
SELECT COUNT(*) FROM [item_mast] I  WHERE I.PRO_PRICE >= 350; 

----- (23) Write a SQL query to display the average price of each company's products, along with their code. -----
SELECT I.PRO_COM,AVG(I.PRO_PRICE) AS averageProductPrice FROM [item_mast] I GROUP BY I.PRO_COM;

----- (24) Write a query in SQL to find the sum of the allotment amount of all departments. -----
SELECT SUM(D.DPT_ALLOTMENT) AS totalAllotmentAmount FROM [emp_department] D;

----- (25) Write a query in SQL to find the number of employees in each department along with the department code. -----
SELECT E.EMP_DEPT,COUNT(E.EMP_IDNO) FROM [emp_details] E GROUP BY E.EMP_DEPT;