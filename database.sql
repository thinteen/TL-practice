create database Pharmacy
use Pharmacy

-- Tables creating

create table Pharmacy(
	Id int identity (1,1) constraint PK_Pharmacy primary key not null,
	Name varchar(50) not null,
	Address varchar(50) not null,
	PhoneNumber varchar(25) not null
)

create table Medicines(
	Id int identity (1,1) constraint PK_Medicines primary key not null,
	Name varchar(50) not null,
	Price int not null,
	Availability int null,
	PharmacyId int references Pharmacy(Id)
)

create table RegularCustomers(
	Id int identity (1,1) constraint PK_RegularCustomers primary key not null,
	FullName varchar(50) not null,
	PhoneNumber varchar(25) not null,
	CustomerCardNumber varchar(50) not null,
	AccumulatedPoints int null,
	PharmacyId int references Pharmacy(Id)
)

-- Data inserting

insert into Pharmacy
	(Name, Address ,PhoneNumber)
values
	('Будь здоров', 'г. Йошкар-Ола, ул. Петрова д.34', '453452'),
	('Планета здоровья', 'г. Йошкар-Ола, ул. Сидорова д.84', '576434'),
	('Марифарм', 'г. Йошкар-Ола, ул. Иванова д.12', '837392')

insert into Medicines
	(Name, Price, Availability, PharmacyId)
values
	('Аспирин', 150, 200, 1),
	('Пенталгин', 400, 100, 1),
	('Бинт', 40, 1000, 1),
	('Спирт', 100, 250, 2),
	('Венарус', 500, 300, 2),
	('Йод', 40, 350, 2),
	('Полисорб', 500, 100, 3),
	('Гексорал', 400, 190, 3),
	('Гербион', 1000, 56, 3)

insert into RegularCustomers
	(FullName, PhoneNumber, CustomerCardNumber, AccumulatedPoints, PharmacyId)
values
	('Третьякова Мария', '488384', '945774328', 500, 1),
	('Полякова Татьяна', '920291', '487547594', 900, 1),
	('Лукина Лаура', '920393', '888993913', 0, 1),
	('Капустина Софья', '002929', '222292929', 100, 2),
	('Поляков Максим', '992823', '929292202', 423, 2),
	('Петров Петр', '939202', '398929293', 234, 2),
	('Иванов Иван', '883930', '938423030', 340, 3),
	('Михеева Арина', '859492', '848483929', 999, 3),
	('Ерошкин Глеб', '894722', '456294824', 358, 3)
