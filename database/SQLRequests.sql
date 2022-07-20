use Pharmacy

--CRUD

update Medicine
set Price = 50
where name = 'Бинт' and name = 'Йод'

select * from RegularCustomer
where AccumulatedPoints > 300

--GROUP BY + функции агрегации

--Выводит ценник и количество данных ценников
select IdPharmacy, Count(IdMedicine) 'Количество видос препаратов находящихся в аптеке' from PharmacyMedicine
group by IdPharmacy

--GROUP BY + having

--Выводит ценник и количество повторяющихся ценников (т.е больше одного)
select IdPharmacy, Count(IdMedicine) 'Количество видос препаратов находящихся в аптеке' from PharmacyMedicine
group by IdPharmacy
having Count(IdMedicine) > 2

--JOIN таблиц

--Выводит названия и адреса аптек в которых есть аспирин, его количество и стоимость
select b.Name 'BrandName', p.Address, m.Name 'MedicineName', pm.Quantity, m.Price 
from Brand b
inner join Pharmacy p on b.Id = p.IdBrand 
inner join PharmacyMedicine pm on p.Id = pm.IdPharmacy 
inner join Medicine m on m.Id = pm.IdMedicine 
where m.Name = 'Аспирин'