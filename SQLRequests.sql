use Pharmacy

--CRUD

update Medicines
set Price = 50
where name = '����' and name = '���'

delete from Medicines
where price >= 900

select * from RegularCustomers
where AccumulatedPoints > 300

--GROUP BY + ������� ���������

--������� ������ � ���������� ������ ��������
select Price, count(Price) as 'Count of prices' from Medicines 
group by Price

--GROUP BY + having

--������� ������ � ���������� ������������� �������� (�.� ������ ������)
select Price, count(Price) as 'Count of prices' from Medicines 
group by Price
having count(Price) > 1

--JOIN ������

--������� ����� ���������� �������� � �������� ����� � ������� ��� ���������
select 
	Pharmacy.Name as '�������� ������', 
	RegularCustomers.FullName as '��� ����������� �������'
from 
	Pharmacy INNER JOIN RegularCustomers
	on Pharmacy.Id = RegularCustomers.PharmacyId