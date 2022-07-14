use Pharmacy

--CRUD

update Medicines
set Price = 50
where name = 'Бинт' and name = 'Йод'

delete from Medicines
where price >= 900

select * from RegularCustomers
where AccumulatedPoints > 300

--GROUP BY + функции агрегации

--Выводит ценник и количество данных ценников
select Price, count(Price) as 'Count of prices' from Medicines 
group by Price

--GROUP BY + having

--Выводит ценник и количество повторяющихся ценников (т.е больше одного)
select Price, count(Price) as 'Count of prices' from Medicines 
group by Price
having count(Price) > 1

--JOIN таблиц

--Выводит имена постоянных клиентов и названия аптек к которым они привязаны
select 
	Pharmacy.Name as 'Название аптеки', 
	RegularCustomers.FullName as 'Имя постоянного клиента'
from 
	Pharmacy INNER JOIN RegularCustomers
	on Pharmacy.Id = RegularCustomers.PharmacyId