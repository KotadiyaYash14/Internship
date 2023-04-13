USE [YK327YashKotadiya]

----- Create Employees Table-----
Create Table [Employees](
[employee_id] int primary key,
[employee_name] text,
[department] text,
[salary] numeric,
[hire_date] date
);

alter table [Employees]
alter column [department] varchar(250);

----- Isert record into employees Table -----
insert into [Employees]([employee_id],[employee_name],[department],[salary],[hire_date])values(1,'Yash','Frontend',35000,'2022-10-08');
insert into [Employees]([employee_id],[employee_name],[department],[salary],[hire_date])values(2,'Bhavya','DevOps',50000,'2022-08-23');
insert into [Employees]([employee_id],[employee_name],[department],[salary],[hire_date])values(3,'Chirag','Backend',40000,'2022-08-05');
insert into [Employees]([employee_id],[employee_name],[department],[salary],[hire_date])values(4,'Hemang','Fullstack',45000,'2022-07-25');
insert into [Employees]([employee_id],[employee_name],[department],[salary],[hire_date])values(5,'Yansi','Designing',30000,'2022-08-10');
insert into [Employees]([employee_id],[employee_name],[department],[salary],[hire_date])values(6,'Vivek','QA',30000,'2022-11-15');
insert into [Employees]([employee_id],[employee_name],[department],[salary],[hire_date])values(7,'Vatsal','Backend',40000,'2022-06-20');
insert into [Employees]([employee_id],[employee_name],[department],[salary],[hire_date])values(8,'Krishana','Fullstack',45000,'2022-09-27');
insert into [Employees]([employee_id],[employee_name],[department],[salary],[hire_date])values(9,'Vidhi','Designing',30000,'2022-09-11');
insert into [Employees]([employee_id],[employee_name],[department],[salary],[hire_date])values(10,'Arpit','Finance',32000,'2022-11-05');
insert into [Employees]([employee_id],[employee_name],[department],[salary],[hire_date])values(11,'Shreyas','Sales',28000,'2022-11-29');
insert into [Employees]([employee_id],[employee_name],[department],[salary],[hire_date])values(12,'Dhruvi','IT',35000,'2022-10-24');
insert into [Employees]([employee_id],[employee_name],[department],[salary],[hire_date])values(13,'Sahil','IT',35000,'2022-01-18');
insert into [Employees]([employee_id],[employee_name],[department],[salary],[hire_date])values(14,'Kavan','Sales',28000,'2023-01-18');
insert into [Employees]([employee_id],[employee_name],[department],[salary],[hire_date])values(15,'Darshan','Finance',32000,'2023-03-10');
  
select * from [Employees];

-----How many employees are in the table? -----
select count(*) from [Employees] E;

----- What is the highest salary in the table? -----
select max(E.salary) as HighsetSalary from [Employees] E;

----- What is the average salary by department? -----
select avg(E.salary) as AverageSalary,E.department from [Employees] E group by E.department;

----- Who are the top 5 highest paid employees? -----
select top 5 * from [Employees] E order by E.salary desc;

----- How many employees were hired in the last year? -----
select count(*) from [Employees] E where E.hire_date >= DATEADD(year,-1,getdate());

----- How do you select all columns from a table named "employees"? -----
select * from [Employees] E;

----- How do you select only the "employee_id" and "employee_name" columns from a table named "employees"? -----
select employee_id,employee_name from [Employees] E;

----- How do you filter records in a table named "employees" to only include those where the "salary" column is greater than or equal to 50000? -----
select * from [Employees] E where E.salary >= 50000;

----- How do you filter records in a table named "employees" to only include those where the "department" column is "Sales"? -----
select * from [Employees] E where E.department = 'sales';

----- How do you filter records in a table named "employees" to only include those where the "hire_date" column is between January 1, 2022 and December 31, 2022? -----
select * from [Employees] E where E.hire_date between '2002-01-01' and '2022-12-31';

----- How do you calculate the average salary of all employees in a table named "employees"? -----
select avg(E.salary) as averageSalary from [Employees] E;

----- How do you calculate the total salary of all employees in a table named "employees"? -----
select sum(E.salary) as totalSalary from [Employees] E;

----- How do you calculate the highest salary in a table named "employees"? -----
select max(E.salary) as highestSalary from [Employees] E;

----- How do you calculate the lowest salary in a table named "employees"? -----
select min(E.salary) as lowetSalary from [Employees] E;

----- How do you calculate the number of employees in a table named "employees"? -----
select count(*) from [Employees] E;

----- How do you sort the records in a table named "employees" by the "salary" column in ascending order? -----
select * from [Employees] E order by salary asc;

----- How do you sort the records in a table named "employees" by the "salary" column in descending order? -----
select * from [Employees] E order by salary desc;

----- How do you count the number of employees in each department in a table named "employees"? -----
select  E.department, count(*) from [employees] E group by E.department;

----- How do you select the first 10 records in a table named "employees"? -----
select top 10 * from [Employees] E;

----- How do you select the last 10 records in a table named "employees"? -----
select top 10 * from [Employees] E order by E.employee_id desc;

----- How do you select the top 5 highest paid employees from a table named "employees"? -----
select top 5 * from [Employees] E order by E.salary desc;

----- How do you select the top 10 highest paid employees from a table named "employees"? -----
select top 10 * from [Employees] E order by E.salary desc;

----- How do you select the bottom 5 lowest paid employees from a table named "employees"? -----
select top 5 * from [Employees] E order by E.salary asc;

----- How do you select the employees who have a salary that is above the average salary in a table named "employees"? -----
select * from [Employees] E where E.salary > (select avg(E.salary) from [Employees] E);

----- How do you select the employees who have a salary that is below the average salary in a table named "employees"? -----
select * from [Employees] E where E.salary < (select avg(E.salary) from [employees] E);

----- How do you select the employees who have a salary that is between 40000 and 60000 in a table named "employees"? -----
select * from [Employees] E where E.salary between 40000 and 60000;

----- How do you calculate the total salary of all employees in each department in a table named "employees"? -----
select E.department,sum(E.salary) as totalSalary from [Employees] E group by E.department;

----- How do you calculate the average salary of all employees in each department in a table named "employees"? -----
select E.department,avg(E.salary) as averageSalary from [Employees] E group by E.department;

----- How do you calculate the highest salary of all employees in each department in a table named "employees"? -----
select E.department,max(E.salary) as highestSalary from [Employees] E group by E.department;

----- How do you calculate the lowest salary of all employees in each department in a table named "employees"? -----
select E.department,min(E.salary) as lowestSalary from [Employees] E group by E.department;

----- How do you select the employees who have been hired in the last year from a table named "employees"? -----
select * from [Employees] E where E.hire_date >= DATEADD(year,-1,getdate());

----- How do you select the employees who have been hired in the last 6 months from a table named "employees"? -----
select * from [Employees] E WHERE e.hire_date >= DATEADD(month,-6,getdate());

----- How do you select the employees who have been hired in the last 3 months from a table named "employees"? -----
select * from [Employees] E WHERE e.hire_date >= DATEADD(month,-3,getdate());

----- How do you select the employees who have been hired in the last week from a table named "employees"?
select * from [Employees] E WHERE e.hire_date >= DATEADD(week,-1,getdate());

----- How do you select the employees who have a name that starts with the letter "A" in a table named "employees"? -----
select * from [Employees] E where E.employee_name like 'A%';

----- How do you select the employees who have a name that ends with the letter "s" in a table named "employees"? -----
select * from [Employees] E where E.employee_name like '%S';