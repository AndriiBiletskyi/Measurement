--create index iP on dbo."1"(P);
CREATE NONCLUSTERED INDEX [iCzasPdayQday]
ON [dbo].[14] ([Czas])
INCLUDE ([P_day],[Q_day])
--select Czas, P_day,Q_day
--from dbo."1"
--where Czas between '04.03.2021 00:00:00' and '04.03.2021 01:00:00'
--drop index iCzas on dbo."1"