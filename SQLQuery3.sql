--create index iP on dbo."1"(P);
--CREATE NONCLUSTERED INDEX [iCzasP]
--ON [dbo].[1] ([Czas])
--INCLUDE ([P])
select Czas, P_day,Q_day
from dbo."1"
where Czas between '04.03.2021 00:00:00' and '04.03.2021 01:00:00'
--drop index iCzasP on dbo."1"