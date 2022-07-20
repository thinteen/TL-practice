use Pharmacy

--CRUD

update Medicine
set Price = 50
where name = '����' and name = '���'

select * from RegularCustomer
where AccumulatedPoints > 300

--GROUP BY + ������� ���������

--������� ������ � ���������� ������ ��������
select IdPharmacy, Count(IdMedicine) '���������� ����� ���������� ����������� � ������' from PharmacyMedicine
group by IdPharmacy

--GROUP BY + having

--������� ������ � ���������� ������������� �������� (�.� ������ ������)
select IdPharmacy, Count(IdMedicine) '���������� ����� ���������� ����������� � ������' from PharmacyMedicine
group by IdPharmacy
having Count(IdMedicine) > 2

--JOIN ������

--������� �������� � ������ ����� � ������� ���� �������, ��� ���������� � ���������
select b.Name 'BrandName', p.Address, m.Name 'MedicineName', pm.Quantity, m.Price 
from Brand b
inner join Pharmacy p on b.Id = p.IdBrand 
inner join PharmacyMedicine pm on p.Id = pm.IdPharmacy 
inner join Medicine m on m.Id = pm.IdMedicine 
where m.Name = '�������'