use YashKotadiya327

---------- MyCountry Table ----------

create table MyCountry(
ID int primary key identity(1,1),
CountryName varchar(255)
);

---------- MyState Table ----------

create table MyState(
ID int primary key identity(1,1),
StateName varchar(255),
CountryId int foreign key references MyCountry(ID)
);

---------- MyCity Table ----------

create table MyCity(
ID int primary key identity(1,1),
CityName varchar(255),
StateId int foreign key references MyState(ID),
CountryId int foreign key references MyCountry(ID)
);

---------- MyUserType Table ----------

create table MyUserType(
ID int primary key identity(1,1),
UserTypeName varchar(255) not null
);

---------- MyUser Table ----------

create table MyUser(
ID int primary key identity(1,1),
FirstName varchar(255) not null,
LastName varchar(255) not null,
Email varchar(255) unique,
[Password] varchar(10) check(len([password]) >= 8 and len([password]) <= 10),
UserTypeId int foreign key references MyUserType(ID),
[Address] varchar(255) null,
MobileNo varchar(30) not null,
CountryId int foreign key references MyCountry(ID),
StateId int foreign key references MyState(ID),
CityId int foreign key references MyCity(ID)
); 

---------- MyDiagnosis Table ----------

create table MyDiagnosis(
ID int primary key identity(1,1),
DiagnosisDetails varchar(255) not null,
);

---------- MyMedicine Table ----------

create table MyMedicine(
ID int primary key identity(1,1),
MedicineName varchar(255) not null,
DiagosisId int foreign key references MyDiagnosis(ID)
);

---------- MyTreatmentDetails Table ----------

create table MyTreatmentDetails(
ID int primary key identity(1,1),
PatientId int foreign key references MyUser(ID),
DoctorId int foreign key references MyUser(ID),
NurseId int foreign key references MyUser(ID),
Diagnosis int foreign key references MyDiagnosis(ID),
Prescription int foreign key references MyMedicine(ID),
TreatmentFee decimal(10,2) not null,
DOT date,
Instructions varchar(max) null
);

---------- MyCountryInfo Proc ----------

create or alter procedure MyCountryInfo
(
@CountryName varchar(255)
)
as
begin
insert into MyCountry(CountryName) values (@CountryName);
end

exec MyCountryInfo 'India';
exec MyCountryInfo 'USA';
exec MyCountryInfo 'Australia';

select * from MyCountry

---------- MyStateInfo Proc ----------

create or alter procedure MyStatesInfo
(
@StateName varchar(255),
@countryName varchar(200)
)
as
begin
DECLARE @CountryID int
SET @CountryID = (select C1.ID from MyCountry C1 where C1.CountryName = @countryName);

insert into MyState(StateName,CountryId) values (@StateName,@CountryId);
end

exec MyStatesInfo 'Gujarat','India';
exec MyStatesInfo 'Florida','USA';
exec MyStatesInfo 'Melbron','Australia';

select * from MyState

---------- MyCityInfo Proc ----------

create or alter procedure MyCityInfo
(
@CityName varchar(255),
@stateName varchar(200),
@countryName VARCHAR(200)
)
as
begin
declare @CountryID int,@StateID int
set @CountryID = (select C1.ID from MyCountry C1 where C1.CountryName = @countryName);
set @StateID = (select S.ID from MyState S where S.StateName = @stateName);

insert into MyCity (CityName,StateId,CountryId) values (@CityName,@StateId,@CountryId);
end

exec MyCityInfo 'Ahemedabad','Gujarat','India';
exec MyCityInfo 'Las Vegas','Florida','USA';
exec MyCityInfo 'Perth','Melbron','Australia';

select * from MyCity

---------- MyUserTypeInfo Proc ----------

create or alter procedure MyUserTypeInfo
(
@UserTypeName varchar(255)
)
as
begin
insert into MyUserType (UserTypeName) values (@UserTypeName);
end

exec MyUserTypeInfo 'Doctor';
exec MyUserTypeInfo 'Nurse';
exec MyUserTypeInfo 'Patient';

select * from MyUserType

---------- MyUserInfo Proc ----------

create or alter procedure MyUserInfo
(
@FirstName varchar(255),
@LastName varchar(255),
@Email varchar(255),
@Password varchar(10),
@UserTypeId int,
@Address varchar(255),
@MobileNo varchar(30),
@CountryId int,
@StateId int,
@CityId int 
)
as
begin
insert into MyUser (FirstName,LastName,Email,[Password],UserTypeId,[Address],MobileNo,CountryId,StateId,CityId) values (@FirstName,@LastName,@Email,@Password,@UserTypeId,@Address,@MobileNo,@CountryId,@StateId,@CityId);
end

exec MyUserInfo 'Chirag','Patel','chirag@gmail.com','chirag123',1,null,'1234567890',1,1,1;
exec MyUserInfo 'Vivek','Vrade','vivek@gmail.com','vivek123',2,null,'1234567890',2,2,2;
exec MyUserInfo 'Bhavya','Joshi','bhavya@gmail.com','bhavya123',3,null,'1234567890',3,3,3;

select * from MyUser

---------- MyDiagnosis2Info  Proc ----------

create or alter procedure MyDiagnosis2Info 
(
@DiagnosisDetails varchar(255)
)
as
begin
insert into MyDiagnosis (DiagnosisDetails) values (@DiagnosisDetails);
end

exec MyDiagnosis2Info 'Fever';
exec MyDiagnosis2Info 'Cold';
exec MyDiagnosis2Info 'Headache';

select * from MyDiagnosis

---------- MyMedicine2Info  Proc ----------

create or alter procedure MyMedicine2Info
(
@MedicineName varchar(255),
@DiagosisId int
)
as
begin
insert into MyMedicine (MedicineName,DiagosisId) values (@MedicineName,@DiagosisId);
end

exec MyMedicine2Info 'Dolo600',1;
exec MyMedicine2Info 'Panadol',2;
exec MyMedicine2Info 'Paracetamol',3;

select * from MyMedicine

---------- MyTreatmentDetailsInfo  Proc ----------

create or alter procedure MyTreatmentDetailsInfo
(
@PatientnId int,
@DoctorId int,
@NurseId int,
@Diagnosis int,
@Prescription int,
@TreatmentFee decimal(10,2),
@DOT date,
@Instructions varchar(max)
)
as
begin
insert into MyTreatmentDetails (PatientId,DoctorId,NurseId,Diagnosis,Prescription,TreatmentFee,DOT,Instructions) values (@PatientnId,@DoctorId,@NurseId,@Diagnosis,@Prescription,@TreatmentFee,@DOT,@Instructions)
end

exec MyTreatmentDetailsInfo 3,1,2,1,1,200,'2022-12-12',null;
exec MyTreatmentDetailsInfo 3,1,2,2,2,300,'2021-12-12',null;
exec MyTreatmentDetailsInfo 3,1,2,3,3,400,'2020-12-12',null;

select * from MyTreatmentDetails;

---------- Second Question ----------

create or alter procedure allDoctor
(
@userid int = null
)
as
begin 
if(@userid is not null)
begin
select ('Dr.' + U.FirstName + ' ' + U.LastName) as DoctorName, (CO.CountryName + ',' + S.StateName + ',' + CI.CityName) as [Address], U.MobileNo from MyUser U inner join MyUserType UT on U.UserTypeId = UT.ID inner join MyCountry CO on U.CountryId = CO.ID inner join MyState S on U.StateId = S.ID inner join MyCity CI on U.CityId = CI.ID where U.ID = @userid and UT.UserTypeName = 'Doctor';
end
else
begin 
select ('Dr.' + U.FirstName + U.LastName) as DoctorName,(CO.CountryName + ',' + S.StateName + ',' + CI.CityName) as [Address], U.MobileNo from MyUser U inner join MyUserType UT on U.UserTypeId = UT.ID inner join MyCountry CO on U.CountryId = CO.ID inner join MyState S on U.StateId = S.ID inner join MyCity CI on U.CityId = CI.ID
end
end

exec allDoctor;
--exec allDoctor null;

---------- Third Question ComaSapreted----------

create or alter function Medicine_as_per_Diagnosis(
@DiagnosisDetails varchar(255)
)
returns varchar(255)
as
begin
	declare @Dig varchar(255); 
    select @Dig = stuff((select ','+ MedicineName from MyMedicine
    where Id in (select Id from MyDiagnosis
    where DiagnosisDetails in (select [value] from string_split(@DiagnosisDetails,',')))
    for xml path('')),1,1,'')
    return @Dig
end

select dbo.Medicine_as_per_Diagnosis('fever,cold') as MedicineName

---------- Third Question ----------

create or alter function getmedition(@DiagnosisDetails varchar (255))
returns table
as
     return (select m.MedicineName from MyMedicine m inner join MyDiagnosis d  on m.DiagosisId = d.ID 
	 where d.DiagnosisDetails in(select [value] from string_split(@DiagnosisDetails,',')))

select * from dbo.getmedition('fever,cold')

---------- Fourth Question ----------

--create or alter procedure allInfo
--(
--@FirstName varchar(255),
--@LastName varchar(255),
--@Email varchar(255),
--@Password varchar(255),
--@UserType varchar(255),
--@Address varchar(255),
--@mobileNo varchar(30),
--@CityName varchar(255),
--@DoctorName varchar(255),
--@NurseName varchar(255),
--@DiagnosisName varchar(255),
--@TreatmentFee decimal(10,2),
--@DOT date,
--@Instructions varchar(max)
--)
--as
--begin
--declare @utid int,@ctid int,@said int,@coid int
--set @utid = (select UT.ID from MyUserType UT where UT.UserTypeName = @UserType);
--set @ctid = (select CI.ID from MyCity CI  where CI.CityName = @CityName );
--set @said = (select S.ID from MyState S inner join MyCity CI on S.ID = CI.StateId where CI.ID= @ctid);
--set @coid = (select CO.ID from MyCountry CO inner join  MyState S  on CO.ID = S.CountryId where S.ID = @said);
--exec MyUserInfo @FirstName,@LastName,@Email,@Password,@utid,@Address,@mobileNo,@ctid,@said,@coid;

--declare @ptid int,@dtid int,@ntid int,@digid int,@preid int
--declare @id int, @patientName varchar(255)
--set @id = (select max(U.ID) FROM MyUser U)
--set @patientName = (SELECT U.FirstName FROM MyUser U WHERE U.ID = @id)
--set @ptid = (select U.ID from MyUserType UT inner join MyUser U on UT.ID = U.UserTypeId where U.FirstName = @Patientname);
--set @dtid = (select U.ID from MyUserType UT inner join MyUser U on UT.ID = U.UserTypeId where U.FirstName = @Doctorname);
--set @ntid = (select U.ID from MyUserType UT inner join MyUser U on UT.ID = U.UserTypeId where U.FirstName = @Nursename);
--set @digid = (select D.ID from MyDiagnosis D where D.DiagnosisDetails = @Diagnosisname);
--set @preid = (select M.ID from MyMedicine M inner join MyDiagnosis D on D.ID = M.DiagosisId where M.DiagosisId = @digid);
--exec MyTreatmentDetailsInfo @ptid,@dtid,@ntid,@digid,@preid,@TreatmentFee,@DOT,@Instructions

--end
--exec allInfo 'Vivek1','Varde','vivek1@gmail.com','vivek123','Patient',null,'1234567890','Perth','Chirag','Vivek','Fever',500,'2022-12-12',null
 
--select * from MyUser
--select * from MyTreatmentDetails

create or Alter proc addpatitent (
	@FName VARCHAR(255),
	@LName VARCHAR(255),
	@Email VARCHAR(255),
	@Password VARCHAR(255),
	@Address varchar(max),
	@MobileNo varchar(30),
	@city VARCHAR(255),
	@DoctorName varchar(255),
	@NurseName varchar(255),
	@Diagnosis varchar(255),
	@TreatmentFee int,
	@DOT date,
	@Instruction VARCHAR(255)
)
AS
BEGIN
	BEGIN TRY
		DECLARE @UTID INT,@CityID int,@StateId INT,@CountryId INT,@MaxId int
		SET @UTID = (SELECT [ID] FROM [MyUserType] WHERE [UserTypeName] = 'Patient')
		Set @cityID = (select id from MyCity where CityName = @city)
		SET @StateId = (SELECT [StateId] FROM [MyCity] WHERE [id] = @CityID)
		SET @CountryId = (SELECT [CountryId] FROM [MyCity] WHERE [ID] = @CityID)

		INSERT INTO [MyUser]([FirstName],[LastName],[Email],[Password],[UserTypeId],[Address],[MobileNo],[CountryId],[StateId],[CityId]) VALUES (@FName,@LName,@Email,@Password,@UTID,@Address,@MobileNo,@CountryId,@StateId,@CityID)
		
		declare @PatientId int
		set @PatientId = @@IDENTITY

		declare @DoctorId int, @NurseId int,@dig int,@pre int
		set @DoctorId = (select id from MyUser where UserTypeId = 1 and FirstName =@DoctorName);
		set @NurseId = (select id from MyUser where UserTypeId = 2 and FirstName = @NurseName);
		set @dig = (select id from MyDiagnosis where DiagnosisDetails = @Diagnosis);
		set @pre = (select id from MyMedicine where DiagosisId = @dig)

		insert into MyTreatmentDetails (PatientId,DoctorId,NurseId,Diagnosis,Prescription,TreatmentFee,DOT,Instructions) values (@PatientId,@DoctorId,@NurseId,@dig,@pre,@TreatmentFee,@DOT,@Instruction)

	END TRY
	BEGIN CATCH
		PRINT ERROR_MESSAGE();
	END CATCH
END


EXEC addpatitent 'krishna','bakri','bakri12@gmail.com','bakripur','bakri vas , bakri pur','25896374','Ahemedabad','Chirag','Vivek','Cold',500,'2023-03-01',null

------------

create or alter procedure ABC
(
@DName varchar(255),
@MName varchar(255)
)
as
begin
begin try
insert into MyDiagnosis (DiagnosisDetails) values (@DName)
declare @did int
set @did = Scope_Identity()
insert into MyMedicine (MedicineName,DiagosisId) values (@MName,@did);
SELECT m.MedicineName,d.DiagnosisDetails FROM MyMedicine m inner join MyDiagnosis d on m.DiagosisId = d.ID where d.ID = @did
end try

begin catch
print Error_message();
end catch
end

exec ABC 'vomit113','ABC113'
select * from MyMedicine
select * from MyDiagnosis