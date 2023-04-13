use YK327YashKotadiya;

create procedure Sp_insert (@ID int, @TempName varchar(max))
as 
begin  
Declare @SampleTable Table(id int, Name varchar(max))  
Insert into @SampleTable(id,Name)values(@ID,@TempName)  
select*from @SampleTable  
end

create procedure Sp_Call (@SID int,@Name varchar(max))
as
begin
exec Sp_insert @ID=@SID,@TempName=@Name
end

Exec Sp_Call @SID=1,@Name='Yash'