create database hrdb;
use hrdb;

create table ET(
Employee_ID int Primary key identity(1,1),
Name varchar(30),
Department varchar(30),
Salary int
)

insert into ET values('Biswanth','HR',10000)

select * from ET;
drop table ET;