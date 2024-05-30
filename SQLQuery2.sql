--Автомастерская 
create table Roles(--таблица Роли
idRole int identity primary key,
NameRole nvarchar(max))

insert into Roles
values
('Администратор'),
('Сотрудник');

create table Administrators(--таблица Администраторы
idAdministrator int identity primary key,
Fname nvarchar(max),
Name nvarchar(max),
Sname nvarchar(max),
Login nvarchar(max),
Password nvarchar(max),
id_Role int foreign key references Roles(idRole))

insert into Administrators
values
('АФамилия1','АИмя1','АОтчество1','Admin1','APas1',1),
('АФамилия2','АИмя2','АОтчество2','Admin2','APas2',1),
('АФамилия3','АИмя3','АОтчество3','Admin3','APas3',1);

create table Customers(--таблица Клиенты
idCustomer int identity primary key,
Fname nvarchar(max),
Name nvarchar(max),
Sname nvarchar(max),
Phone nvarchar(max),
Email nvarchar(max))

insert into Customers
values
('Фамилия1','Имя1','Отчество1','89111','почта1'),
('Фамилия2','Имя2','Отчество2','89222','почта2'),
('Фамилия3','Имя3','Отчество3','89333','почта3');

create table Cars(--таблицы Машины
idCar int identity primary key,
Brand nvarchar(max),
Model nvarchar(max),
Year int,
Color nvarchar(max),
Number nvarchar(6),
id_Customer int foreign key references Customers(idCustomer))

insert into Cars
values
('KIA','K5','2020','Матовый зелёный','с065мк',1),
('BMW','M3','2018','Серая','м125ем',2),
('BMW','M8','2022','Майский жук','а778ам',3);

create table Specializations(--должность Сотрудника
idSpecialization int identity primary key,
NameSpec nvarchar(max))

insert into Specializations
values
('2 разряд'),
('3 разряд'),
('4 разряд');

create table Employee(--таблица Сотрудники
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
('СФамилия1','СИмя1','СОтечтсво1',1,'Sot1','SPas1',2),
('СФамилия2','СИмя2','СОтечтсво2',2, 'Sot2','SPas2',2),
('СФамилия3','СИмя3','СОтечтсво3',3, 'Sot3','SPas3',2);

create table Suppliers(--таблица Поставщики
idSupplier int identity primary key,
Fname nvarchar(max),
Name nvarchar(max),
Sname nvarchar(max),
Phone nvarchar(max),
Product nvarchar(max))

insert into Suppliers
values
('ПФамилия1','ПИмя1','ПОтчество1','89444','Продукт1'),
('ПФамилия2','ПИмя2','ПОтчество2','89555','Продукт2'),
('ПФамилия3','ПИмя3','ПОтчество3','89666','Продукт3');

create table PartsWarehouse(--таблица Склад запчастей
idPart int identity primary key,
NamePart nvarchar(max),
Count int,
id_Supplier int foreign key references Suppliers(idSupplier))

insert into PartsWarehouse
values
('Запчасть1',225,1),
('Запчасть2',179,2),
('Запчасть3',283,3);

create table Orders(--таблица Заказы
idOrder int identity primary key,
id_Customer int foreign key references Customers(idCustomer),
id_Car int foreign key references Cars(idCar),
id_Employee int foreign key references Employee(idEmployee),
DescriptionProblem nvarchar(max),
DateAdmission date)

insert into Orders
values
(1,1,1,'Описание1','2023/08/17'),
(2,2,2,'Описание2','2023/09/08'),
(3,3,3,'Описание3','2023/09/28');

create table UnderRepair(--таблица В ремонте
idUnderRepair int identity primary key,
id_Car int foreign key references Cars(idCar),
id_Employee int foreign key references Employee(idEmployee),
id_Part int foreign key references PartsWarehouse(idPart),
DateStar date,
Status nvarchar(max)
check (Status = 'Не обслуживался' or Status='В ремонте' or Status='Выполнен'))

insert into UnderRepair
values
(1,1,1,'2023/08/18','Не обслуживался'),
(2,2,2,'2023/09/11','Выполнен'),
(3,3,3,'2023/09/30','В ремонте');

create table Prices(--таблица Прайс
idPrice int identity primary key,
Name nvarchar(max),
Price money,
Description nvarchar(max))

insert into Prices
values 
('Услуга1',5000,'Описание1'),
('Услуга2',12000,'Описание2'),
('Услуга3',8000,'Описание3');

create table CompletedWorks(--выполненные работы
idCompleted int identity primary key,
id_Order int foreign key references Orders(idOrder),
id_Price int foreign key references Prices(idPrice),
DateComplite date)

insert into CompletedWorks
values
(1,1,'2023/08/25'),
(2,2,'2023/09/12'),
(3,3,'2023/10/02');


-------6 практика 
-------Создайте минимум 5 представлений выводящие несколько различных, но связанных логически данных.
--1.За основу берём таблицы: Клиенты, Машины, Заказы
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

--2.За основу возьмём таблицы: Машины, Клиент, В ремонте
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

--3.За основу возьмём таблицы: Машины, Клиент, Выполненные работы, Прайс
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

