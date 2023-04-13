use YK327YashKotadiya;

----------------------------------------------------------------------------

create or alter function BasicFunction()
returns table
as
return select * from emp_details;

select * from dbo.BasicFunction()

----------------------------------------------------------------------------

create or alter function AnotherFunction
(
@name varchar(50)
)
returns table
as
return select * from emp_details where EMP_FNAME = @name;

select * from dbo.AnotherFunction('Jhon')

----------------------------------------------------------------------------

create or alter proc myProc
(
@name varchar(50)
)
as
begin
select A.*,B.DPT_NAME,B.DPT_ALLOTMENT from dbo.AnotherFunction('Jhon') A inner join emp_department B on A.EMP_DEPT = B.DPT_CODE 
end

exec myProc @name = 'Jhon'

----------------------------------------------------------------------------

create or alter proc myProduct 
as
begin
select O_ID,P_Quantity, PaymentStatus,
case 
when PaymentStatus = 'Paid' then 0
else O_Amount*P_Quantity
end as PayableAmount  
from YKOrder;
end

exec myProduct
select * from YKOrder

----------------------------------------------------------------------------

--print char(round(65 + rand() * 25,0))

create or alter view vw_myView
as
select char(round(65 + rand() * 25,0)) as randomNumber
select * from vw_myView

----------------------------------------------------------------------------

create or alter function string
(
@length int
)
returns varchar(255)
as
begin
   declare @string varchar(255)
   set @string = ''
   declare @count int
   set @count=1
   while(@count<= @length)
   begin
   set @string += (select randomNumber from vw_myView)
   set @count += 1
   end
   return @string
end

select dbo.string(7)

----------------------------------------------------------------------------

create table [name] ([name] varchar(255),age int)

create or alter procedure myProc1(
	@length int,
	@limit int
)
as
begin
	declare @str varchar(255),@count int
	set @count = 0
		while(@count < @limit)
		begin
			set @str = (select dbo.string(@length))
		    insert into [name] ([name],age) values (@str,12)
		    set @count = @count + 1
		end
end

exec myProc1 50,25

select * from [name]

----------------------------------------------------------------------------

create table dept(
dept_id int primary key identity(1,1),
dept_name varchar(255) not null
)

create table emp(
emp_id int primary key identity(1,1),
dept_id int,
emp_name varchar(255) not null,
)

alter table emp add foreign key (dept_id) references dept(dept_id)
alter table emp add doj date

insert into dept (dept_name) values ('it');
insert into dept (dept_name) values ('sales');

select * from dept;

insert into emp (dept_id,emp_name) values (1,'yash');
insert into emp (dept_id,emp_name) values (2,'chirag');
insert into emp  values (2,'chirag','2021-12-13');

select * from emp;

create or alter procedure entry
(
@dept_name varchar(255),
@emp_name varchar(255),
@doj date
)
as
begin
insert into dept (dept_name) values (@dept_name)
declare @id int
select @id = scope_identity()
insert into emp (dept_id,emp_name,doj) values (@id,@emp_name,@doj)
end

exec entry 'sales','yash','2021-04-05'

select * from dept;
select * from emp;

----------------------------------------------------------------------------