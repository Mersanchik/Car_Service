--�������������� 
create table Roles(--������� ����
idRole int identity primary key,
NameRole nvarchar(max))

insert into Roles
values
('�������������'),
('���������');

create table Administrators(--������� ��������������
idAdministrator int identity primary key,
Fname nvarchar(max),
Name nvarchar(max),
Sname nvarchar(max),
Login nvarchar(max),
Password nvarchar(max),
id_Role int foreign key references Roles(idRole))

insert into Administrators
values
('��������1','����1','���������1','Admin1','APas1',1),
('��������2','����2','���������2','Admin2','APas2',1),
('��������3','����3','���������3','Admin3','APas3',1);

create table Customers(--������� �������
idCustomer int identity primary key,
Fname nvarchar(max),
Name nvarchar(max),
Sname nvarchar(max),
Phone nvarchar(max),
Email nvarchar(max))

insert into Customers
values
('�������1','���1','��������1','89111','�����1'),
('�������2','���2','��������2','89222','�����2'),
('�������3','���3','��������3','89333','�����3');

create table Cars(--������� ������
idCar int identity primary key,
Brand nvarchar(max),
Model nvarchar(max),
Year int,
Color nvarchar(max),
Number nvarchar(6),
id_Customer int foreign key references Customers(idCustomer))

insert into Cars
values
('KIA','K5','2020','������� ������','�065��',1),
('BMW','M3','2018','�����','�125��',2),
('BMW','M8','2022','������� ���','�778��',3);

create table Specializations(--��������� ����������
idSpecialization int identity primary key,
NameSpec nvarchar(max))

insert into Specializations
values
('2 ������'),
('3 ������'),
('4 ������');

create table Employee(--������� ����������
idEmployee int identity primary key,
Fname nvarchar(max),
Name nvarchar(max),
Sname nvarchar(max),
id_Specialization int foreign key references Specializations(idSpecialization),
Login nvarchar(max),
Password nvarchar(max),
id_Role int foreign key references Roles(idRole))

insert into Employee
values
('��������1','����1','���������1',1,'Sot1','SPas1',2),
('��������2','����2','���������2',2, 'Sot2','SPas2',2),
('��������3','����3','���������3',3, 'Sot3','SPas3',2);

create table Suppliers(--������� ����������
idSupplier int identity primary key,
Fname nvarchar(max),
Name nvarchar(max),
Sname nvarchar(max),
Phone nvarchar(max),
Product nvarchar(max))

insert into Suppliers
values
('��������1','����1','���������1','89444','�������1'),
('��������2','����2','���������2','89555','�������2'),
('��������3','����3','���������3','89666','�������3');

create table PartsWarehouse(--������� ����� ���������
idPart int identity primary key,
NamePart nvarchar(max),
Count int,
id_Supplier int foreign key references Suppliers(idSupplier))

insert into PartsWarehouse
values
('��������1',225,1),
('��������2',179,2),
('��������3',283,3);

create table Orders(--������� ������
idOrder int identity primary key,
id_Customer int foreign key references Customers(idCustomer),
id_Car int foreign key references Cars(idCar),
id_Employee int foreign key references Employee(idEmployee),
DescriptionProblem nvarchar(max),
DateAdmission date)

insert into Orders
values
(1,1,1,'��������1','2023/08/17'),
(2,2,2,'��������2','2023/09/08'),
(3,3,3,'��������3','2023/09/28');

create table UnderRepair(--������� � �������
idUnderRepair int identity primary key,
id_Car int foreign key references Cars(idCar),
id_Employee int foreign key references Employee(idEmployee),
id_Part int foreign key references PartsWarehouse(idPart),
DateStar date,
Status nvarchar(max)
check (Status = '�� ������������' or Status='� �������' or Status='��������'))

insert into UnderRepair
values
(1,1,1,'2023/08/18','�� ������������'),
(2,2,2,'2023/09/11','��������'),
(3,3,3,'2023/09/30','� �������');

create table Prices(--������� �����
idPrice int identity primary key,
Name nvarchar(max),
Price money,
Description nvarchar(max))

insert into Prices
values 
('������1',5000,'��������1'),
('������2',12000,'��������2'),
('������3',8000,'��������3');

create table CompletedWorks(--����������� ������
idCompleted int identity primary key,
id_Order int foreign key references Orders(idOrder),
id_Price int foreign key references Prices(idPrice),
DateComplite date)

insert into CompletedWorks
values
(1,1,'2023/08/25'),
(2,2,'2023/09/12'),
(3,3,'2023/10/02');


-------6 �������� 
-------�������� ������� 5 ������������� ��������� ��������� ���������, �� ��������� ��������� ������.
--1.�� ������ ���� �������: �������, ������, ������
go
create view OrdersCarsCustomer
as
select Cars.Brand, Cars.Model, Cars.Number, Customers.Fname, Customers.Name, Customers.Sname, 
Orders.DescriptionProblem
from Orders 
inner join Cars on Orders.id_Car = Cars.idCar
inner join Customers on Orders.id_Customer = Customers.idCustomer
go

select * 
from OrdersCarsCustomer

--2.�� ������ ������ �������: ������, ������, � �������
go
create view CarsUnderRepair
as
select Cars.Brand, Cars.Model, Cars.Number, Customers.Fname, Customers.Name, 
Customers.Sname, UnderRepair.Status
from UnderRepair 
inner join Cars on UnderRepair.id_Car = Cars.idCar
inner join Customers on UnderRepair.id_Car = Customers.idCustomer
go

select * 
from CarsUnderRepair

--3.�� ������ ������ �������: ������, ������, ����������� ������, �����
go
create view CompletedCars
as
select Cars.Brand, Cars.Model, Cars.Number, Customers.Fname, Customers.Name, 
Customers.Sname, Prices.Description, Prices.Price
from CompletedWorks
inner join Cars on CompletedWorks.id_Order = Cars.idCar
inner join Customers on CompletedWorks.id_Order = Customers.idCustomer
inner join Prices on CompletedWorks.id_Price = Prices.idPrice
go

select * 
from CompletedCars

