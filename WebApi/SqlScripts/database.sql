create database Pharmacy
use Pharmacy

-- Tables creating

create table Brand(
	Id int identity (1,1) constraint PK_Brand primary key not null,
	Name nvarchar(50) not null
)

create table Pharmacy(
	Id int identity (1,1) constraint PK_Pharmacy primary key not null,
	IdBrand int references Brand(Id) not null,
	Address nvarchar(50) not null,
	PhoneNumber nvarchar(25) not null
)

create table Medicine(
	Id int identity (1,1) constraint PK_Medicine primary key not null,
	Name nvarchar(50) not null,
	Price int not null
)

create table PharmacyMedicine(
	IdPharmacy int references Pharmacy(Id) not null,
	IdMedicine int references Medicine(Id) on delete cascade,
	Quantity int null
)

-- Data inserting

insert into Brand
	(Name)
values
	('��������'),
	('������� ��������'),
	('��������'),
	('������ �1'),
	('�������� ��������')

insert into Pharmacy
	(IdBrand, Address, PhoneNumber)
values
	(1, '�.������-��� ��.�������� �.23', '627294'),
	(1, '�.��������� ��.����������� �.203', '649393'),
	(2, '�.������-��� ��.��������������� �.46', '583930'),
	(2, '�.������ ��.������� �.134', '674839'),
	(3, '�.������-��� ��.�����-����� �.101', '829592'),
	(3, '�.������ �������� ��.�������� �.33', '884266'),
	(4, '�.������-��� ��.������ �.82', '298472'),
	(4, '�.������ ��.����������� �.54', '674293'),
	(5, '�.������-��� ��.���������� ��������� �.31', '688539'),
	(5, '�.����� ��.�������� �.21', '995472')

insert into Medicine
	(Name, Price)
values
	('�������', 124),
	('���������', 378),
	('����', 38),
	('�����', 98),
	('�������', 459),
	('���', 39),
	('��������', 511),
	('��������', 399),
	('�������', 988),
	('��������', 156)

insert into PharmacyMedicine
	(IdPharmacy, IdMedicine, Quantity)
values
	--��������
	(1, 1, 200),
	(1, 2, 234),
	(1, 3, 345),
	(1, 4, 543),
	(1, 5, 34),
	--
	(2, 6, 300),
	(2, 9, 600),
	(2, 10, 350),
	--������� ��������
	(3, 3, 120),
	(3, 4, 100),
	(3, 1, 340),
	(3, 7, 220),
	--
	(4, 1, 120),
	(4, 4, 100),
	(4, 10, 340),
	(4, 9, 340),
	(4, 8, 220),
	--��������
	(5, 8, 120),
	(5, 9, 100),
	(5, 5, 340),
	(5, 2, 220),
	--
	(6, 7, 340),
	(6, 6, 220),
	--������ �1
	(7, 10, 200),
	(7, 7, 234),
	(7, 3, 345),
	(7, 4, 543),
	(7, 5, 34),
	--
	(8, 6, 300),
	(8, 7, 100),
	(8, 10, 350),
	--�������� ��������
	(9, 4, 200),
	(9, 7, 234),
	(9, 2, 345),
	(9, 9, 543),
	(9, 8, 34),
	--
	(10, 3, 300),
	(10, 4, 100),
	(10, 7, 600),
	(10, 5, 350)