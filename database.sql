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
	('���� ������', '�. ������-���, ��. ������� �.34', '453452'),
	('������� ��������', '�. ������-���, ��. �������� �.84', '576434'),
	('��������', '�. ������-���, ��. ������� �.12', '837392')

insert into Medicines
	(Name, Price, Availability, PharmacyId)
values
	('�������', 150, 200, 1),
	('���������', 400, 100, 1),
	('����', 40, 1000, 1),
	('�����', 100, 250, 2),
	('�������', 500, 300, 2),
	('���', 40, 350, 2),
	('��������', 500, 100, 3),
	('��������', 400, 190, 3),
	('�������', 1000, 56, 3)

insert into RegularCustomers
	(FullName, PhoneNumber, CustomerCardNumber, AccumulatedPoints, PharmacyId)
values
	('���������� �����', '488384', '945774328', 500, 1),
	('�������� �������', '920291', '487547594', 900, 1),
	('������ �����', '920393', '888993913', 0, 1),
	('��������� �����', '002929', '222292929', 100, 2),
	('������� ������', '992823', '929292202', 423, 2),
	('������ ����', '939202', '398929293', 234, 2),
	('������ ����', '883930', '938423030', 340, 3),
	('������� �����', '859492', '848483929', 999, 3),
	('������� ����', '894722', '456294824', 358, 3)
