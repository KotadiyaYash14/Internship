USE [YK327YashKotadiya]

select * from [emp_details]
select * from [emp_department]
select * from [company_mast]
select * from [item_mast]
select * from [Orders]
select * from [salesman1]
select * from [customer]
 
 alter table [salesman1] 
 alter column commission decimal(10,2);

update customer set city = 'Paris' where city = 'Peris';

begin tran
update salesman1 set commission = 0.15 where salesman_id = 5001;
update salesman1 set commission = 0.13 where salesman_id = 5002;
update salesman1 set commission = 0.11 where salesman_id = 5005;
update salesman1 set commission = 0.14 where salesman_id = 5006;
update salesman1 set commission = 0.13 where salesman_id = 5007;
update salesman1 set commission = 0.12 where salesman_id = 5003;
commit tran
rollback tran

--- 1) Write a SQL statement to prepare a list with salesman name, customer name and their cities for the salesmen and customer who belongs to the same city
select S.[name],C.cust_name,S.city from [salesman1] S inner join [customer] C on S.city = C.city;

--- 2) Write a SQL statement to make a list with order no, purchase amount, customer name and their cities for those orders which order amount between 500 and 2000
select O.ord_no,O.purch_amt,C.cust_name,C.city from [Orders] O inner join [customer] C on O.customer_id = C.customer_id where O.purch_amt between 500 and 2000;

--- 3) Write a SQL statement to know which salesman are working for which customer.
select * from [customer] C inner join [salesman1] S on C.salesman_id = S.salesman_id;

--- 4) Write a SQL statement to find the list of customers who appointed a salesman for their jobs who gets a commission from the company is more than 12%
select * from [salesman1] S inner join [customer] C on S.salesman_id = C.salesman_id where S.commission > 0.12;

--- 5) Write a SQL statement to find the list of customers who appointed a salesman for their jobs who does not live in the same city where their customer lives, and gets a commission is above 12%
select * from [customer] C inner join [salesman1] S on C.salesman_id = S.salesman_id and C.city != S.city where S.commission > 0.12;

--- 6) Write a SQL statement to find the details of a order i.e. order number, order date, amount of order, which customer gives the order and which salesman works for that customer and how much commission he gets for an order.
select O.ord_no,O.ord_date,O.purch_amt,S.[name],S.commission,C.cust_name from [Orders] O inner join [customer] C on
O.customer_id = C.customer_id  inner join [salesman1] S on S.salesman_id = C.salesman_id;

--- 7) Write a SQL statement to make a join on the tables salesman, customer and orders in such a form that the same column of each table will appear once and only the relational rows will come.
select O.*,S.[name],S.city,S.commission,C.cust_name,C.city,C.grade from [customer] C inner join [salesman1] S on
C.salesman_id = S.salesman_id inner join [Orders] O on C.customer_id = O.customer_id;

--- 8) Write a SQL statement to make a list in ascending order for the customer who works either through a salesman or by own. 
select * from [customer] C left join [salesman1] S on C.salesman_id = S.salesman_id order by C.customer_id asc;

--- 9) Write a SQL statement to make a list in ascending order for the customer who holds a grade less than 300 and works either through a salesman or by own.
select * from [customer] C left join [salesman1] S on C.salesman_id = S.salesman_id where C.grade < 300 order by C.customer_id asc;

--- 10) Write a SQL statement to make a report with customer name, city, order number, order date, and order amount in ascending order according to the order date to find that either any of the existing customers have placed no order or placed one or more orders.
select C.cust_name,C.city,O.ord_no,O.ord_date,O.purch_amt from [customer] C left join [Orders] O on C.customer_id = O.customer_id order by O.ord_date asc;

--- 11) Write a SQL statement to make a report with customer name, city, order number, order date, order amount salesman name and commission to find that either any of the existing customers have placed no order or placed one or more orders by their salesman or by own. 
select C.cust_name,C.city,O.ord_no,O.ord_date,O.purch_amt,S.[name],S.commission from [customer] C left join [Orders] O on C.customer_id = O.customer_id left join [salesman1] S on C.salesman_id = S.salesman_id;

--- 12) Write a SQL statement to make a list in ascending order for the salesmen who works either for one or more customer or not yet join under any of the customers. 
select distinct S.* from [customer] C left join [salesman1] S on C.salesman_id = S.salesman_id order by S.[name];

--- 13) Write a SQL statement to make a list for the salesmen who works either for one or more customer or not yet join under any of the customers who placed either one or more orders or no order to their supplier.
select distinct S.* from [customer] C left join [salesman1] S on C.salesman_id = S.salesman_id left join [Orders] O on C.customer_id = O.customer_id;

--- 14) Write a SQL statement to make a list for the salesmen who either work for one or more customers or yet to join any of the customer. The customer may have placed, either one or more orders on or above order amount 2000 and must have a grade, or he may not have placed any order to the associated supplier.
select S.*,C.cust_name,C.grade,O.ord_no,O.purch_amt from [salesman1] S left join [customer] C on C.salesman_id = S.salesman_id left join [Orders] O on C.customer_id = O.customer_id where O.purch_amt > 2000 or O.ord_no is null and C.grade is not null;

--- 15) Write a SQL statement to make a report with customer name, city, order no. order date, purchase amount for those customers from the existing list who placed one or more orders or which order(s) have been placed by the customer who is not on the list.
select C.cust_name,C.city,O.ord_no,O.ord_date,O.purch_amt from [customer] C left join [Orders] O on O.customer_id = C.customer_id where C.customer_id is not null;

--- 16) Write a SQL statement to make a report with customer name, city, order no. order date, purchase amount for only those customers on the list who must have a grade and placed one or more orders or which order(s) have been placed by the customer who is neither in the list not have a grade. 
select C.cust_name,C.city,O.ord_no,O.ord_date,O.purch_amt from [customer] C left join [Orders] O on O.customer_id = C.customer_id where C.grade is not null or C.customer_id is null;

--- 17) Write a SQL statement to make a cartesian product between salesman and customer i.e. each salesman will appear for all customer and vice versa.
select * from [customer] C cross join [salesman1] S;

--- 18) Write a SQL statement to make a cartesian product between salesman and customer i.e. each salesman will appear for all customer and vice versa for that customer who belongs to a city.
select * from [customer] C cross join [salesman1] S where  C.city is not null;

--- 19) Write a SQL statement to make a cartesian product between salesman and customer i.e. each salesman will appear for all customer and vice versa for those salesmen who belongs to a city and the customers who must have a grade. 
select * from [customer] C cross join [salesman1] S where S.city is not null and C.grade is not null;

--- 20) Write a SQL statement to make a cartesian product between salesman and customer i.e. each salesman will appear for all customer and vice versa for those salesmen who must belong a city which is not the same as his customer and the customers should have an own grade.
select * from [customer] C cross join [salesman1] S where S.city != C.city and C.grade is not null;

--- 21)  Write a SQL query to display all the data from the item_mast, including all the data for each item's producer company.
select * from [item_mast] I inner join [company_mast] CM on I.PRO_COM = CM.COM_ID;

--- 22) Write a SQL query to display the item name, price, and company name of all the product
select I.PRO_NAME,I.PRO_PRICE,CM.COM_NAME from [item_mast] I inner join [company_mast] CM on I.PRO_COM = CM.COM_ID;

--- 23) Write a SQL query to display the average price of items of each company, showing the name of the company. 
select avg(I.PRO_PRICE) as averagePrice,CM.COM_NAME from [item_mast] I inner join [company_mast] CM on I.PRO_COM = CM.COM_ID group by CM.COM_NAME; 

--- 24) Write a SQL query to display the names of the company whose products have an average price larger than or equal to Rs. 350.
select avg(I.PRO_PRICE) as averagePrice,CM.COM_NAME from [item_mast] I inner join [company_mast] CM on I.PRO_COM = CM.COM_ID group by CM.COM_NAME having avg(I.PRO_PRICE) >= 350;

--- 25) Write a SQL query to display the name of each company along with the ID and price for their most expensive product.
select max(I.PRO_PRICE) as maximumPrice,CM.COM_NAME,CM.COM_ID from [item_mast] I inner join [company_mast] CM on I.PRO_COM = CM.COM_ID group by CM.COM_NAME,CM.COM_ID;

--- 26) Write a query in SQL to display all the data of employees including their department
select * from [emp_details] EMP inner join [emp_department] ED on EMP.EMP_DEPT = ED.DPT_CODE;

--- 27) Write a query in SQL to display the first name and last name of each employee, along with the name and sanction amount for their department.
select EMP.EMP_FNAME,EMP.EMP_LNAME,ED.DPT_NAME,ED.DPT_ALLOTMENT from [emp_details] EMP inner join [emp_department] ED on EMP.EMP_DEPT = ED.DPT_CODE;

--- 28) Write a query in SQL to find the first name and last name of employees working for departments with a budget more than Rs. 50000.
select EMP.EMP_FNAME,EMP.EMP_LNAME,ED.DPT_NAME,ED.DPT_ALLOTMENT from [emp_details] EMP inner join [emp_department] ED on EMP.EMP_DEPT = ED.DPT_CODE where ED.DPT_ALLOTMENT > 50000;

--- 29) Write a query in SQL to find the names of departments where more than two employees are working.
select ED.DPT_NAME,count(EMP.EMP_IDNO) from [emp_details] EMP inner join [emp_department] ED on EMP.EMP_DEPT = ED.DPT_CODE group by ED.DPT_NAME having count(EMP.EMP_IDNO) > 2;

--- 30) Write a query to display all the orders from the orders table issued by the salesman 'Paul Adam'
select O.*,S.[name] from [Orders] O inner join [salesman1] S on O.salesman_id = S.salesman_id where S.[name] = 'Paul Adam';

--- 31) Write a query to display all the orders for the salesman who belongs to the city London.
select O.*,S.[name],S.city from [Orders] O inner join [salesman1] S on O.salesman_id = S.salesman_id where S.city = 'London';

--- 32) Write a query to find all the orders issued against the salesman who may works for customer whose id is 3007.
select O.*,S.[name],S.city from [Orders] O inner join [salesman1] S on O.salesman_id = S.salesman_id inner join [customer] C on O.customer_id = C.customer_id where C.customer_id = 3007;

--- 33) Write a query to display all the orders which values are greater than the average order value for 10th October 2012.
select * from [Orders] O where O.purch_amt > (select avg(O.purch_amt) from [Orders] O where O.ord_date = '2012-10-10');

--- 34) Write a query to find all orders attributed to a salesman in New york.
select O.*,S.city,S.[name],S.commission from [Orders] O inner join [salesman1] S on O.salesman_id = S.salesman_id where S.city = 'New york';

---35) Write a query to count the customers with grades above New York's average
select count(*) from [customer] C where C.grade > (select avg(C.grade) from [customer] C where C.city = 'New York');

--- 36) Write a query to display all the customers with orders issued on date 17th August, 2012
select * from [customer] C inner join [Orders] O on C.customer_id = O.customer_id where O.ord_date = '2012-08-17';

--- 37) Write a query to find the name and numbers of all salesmen who had more than one customer. 
select S.[name],count(C.customer_id) from [customer] C inner join [salesman1] S on C.salesman_id = S.salesman_id group by S.[name] having count(C.customer_id) > 1;

--- 38) Write a query to find all orders with order amounts which are above-average amounts for their customers.
SELECT * FROM [Orders] O WHERE O.purch_amt > (SELECT AVG(O1.purch_amt) FROM [Orders] O1 group by O1.customer_id having O.customer_id = o1.customer_id );

--- 39)  Write a queries to find all orders with order amounts which are on or above-average amounts for their customers. 
SELECT * FROM [Orders] O WHERE O.purch_amt >= (SELECT AVG(O1.purch_amt) FROM [Orders] O1 group by O1.customer_id having O.customer_id = o1.customer_id );

--- 40) Write a query to find the sums of the amounts from the orders table, grouped by date, eliminating all those dates where the sum was not at least 1000.00 above the maximum order amount for that date
select sum(O.purch_amt),O.ord_date from [Orders] O group by O.ord_date having sum(O.purch_amt) > (select (1000 + max(O1.purch_amt)) from [Orders] O1 where O.ord_date = O1.ord_date);
 
--- 41) Write a query to extract the data from the customer table if and only if one or more of the customers in the customer table are located in London.
select * from [customer] C where exists (select C.city from [customer] C where C.city = 'London');

--- 42) Write a query to find the salesmen who have multiple customers. 
select S.salesman_id, s.[name],count(c.customer_id) from [customer] C inner join [salesman1] S on C.salesman_id = S.salesman_id GROUP BY S.salesman_id,s.[name] HAVING count(c.customer_id) > 1;

--- 43) Write a query to find all the salesmen who worked for only one customer
select S.salesman_id, s.[name],count(c.customer_id) from [customer] C inner join [salesman1] S on C.salesman_id = S.salesman_id GROUP BY S.salesman_id,s.[name] HAVING count(c.customer_id) = 1;

--- 44) Write a query that extract the rows of all salesmen who have customers with more than one orders.
select S.* from [salesman1] S inner join [customer] C on S.salesman_id = C.salesman_id where (SELECT count(o.customer_id) FROM [Orders] O WHERE O.customer_id = C.customer_id) > 1;

--- 45) Write a query to find salesmen with all information who lives in the city where any of the customers lives. 
select * from [salesman1] S where exists (select * from [customer] C where C.city = S.city);
--- select * from [salesman1] s inner join [customer] c on c.salesman_id = s.salesman_id where s.city= c.city;

--- 46) Write a query to find all the salesmen for whom there are customers that follow them.
select * from [salesman1] S where city in (select c.city from [customer] C);

--- 47) Write a query to display the salesmen which name are alphabetically lower than the name of the customers.
select * from [salesman1] S where exists (select * from [customer] C where S.[name] < C.cust_name);

--- 48) Write a query to display the customers who have a greater gradation than any customer who belongs to the alphabetically lower than the city New York.
select * from [customer] C where C.grade > any (select C.grade from [customer] C where C.city < 'New York');

--- 49) Write a query to display all the orders that had amounts that were greater than at least one of the orders on September 10th 2012. 
select * from [Orders] O where O.purch_amt > any (select O.purch_amt from [Orders] O where O.ord_date= '2012-09-10');

--- 50) Write a query to find all orders with an amount smaller than any amount for a customer in London.
select * from [Orders] O where O.purch_amt < any (select O.purch_amt from [Orders] O inner join [customer] C on C.customer_id = O.customer_id where C.city = 'London');

---51) Write a query to display all orders with an amount smaller than any amount for a customer in London.
select * from [Orders] O where O.purch_amt < any (select O.purch_amt from [Orders] O inner join [customer] C on C.customer_id = O.customer_id where C.city = 'London');

--- 52) Write a query to display only those customers whose grade are, in fact, higher than every customer in New York. 
select * from [customer] C where C.grade > all(select C.grade from [customer] C where C.city = 'New York');

--- 53) Write a query to find only those customers whose grade are, higher than every customer to the city New York. 
select * from [customer] C where C.grade > all(select C.grade from [customer] C where C.city = 'New York');

--- 54) Write a query to get all the information for those customers whose grade is not as the grade of customer who belongs to the city London
select * from [customer] C where C.grade != any(select C.grade from [customer] C where C.city = 'London');

--- 55) Write a query to find all those customers whose grade are not as the grade, belongs to the city Paris.
select * from [customer] C where C.grade != any(select C.grade from [customer] C where C.city = 'Paris');

--- 56) Write a query to find all those customers who hold a different grade than any customer of the city Dallas.
select * from [customer] C where C.grade != all(select C.grade from [customer] C where C.city = 'Dallas');

--- 57) Write a SQL query to find the average price of each manufacturer's products along with their name.
select I.PRO_NAME,I.PRO_PRICE,CM.COM_NAME from [item_mast] I inner join [company_mast] CM on I.PRO_COM = CM.COM_ID where I.PRO_PRICE = (select avg(I.PRO_PRICE) from [item_mast] I where I.PRO_COM = CM.COM_ID); 

--- 58) Write a SQL query to display the average price of the products which is more than or equal to 350 along with their names.
select avg(I.PRO_PRICE),I.PRO_NAME from [item_mast] I where I.PRO_PRICE >= 350 group by I.PRO_NAME;

---59) Write a SQL query to display the name of each company, price for their most expensive product along with their Name.
select I.PRO_NAME,I.PRO_PRICE,CM.COM_NAME from [item_mast] I inner join [company_mast] CM on I.PRO_COM = CM.COM_ID where I.PRO_PRICE = (select max(I.PRO_PRICE) from [item_mast] I where I.PRO_COM = CM.COM_ID); 