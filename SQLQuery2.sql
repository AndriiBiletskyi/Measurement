select MAX(P_day)/1000, MAX(Q_day)
from dbo."7" where Czas between '2021.01.01 00:00:00' and '2021.01.31 00:00:00' and P_day is not null
union all
select MAX(P_day)/1000, MAX(Q_day)
from dbo."7" where Czas between '2021.02.01 00:00:00' and '2021.02.28 00:00:00' and P_day is not null
union all
select MAX(P_day)/1000, MAX(Q_day)
from dbo."7" where Czas between '2021.03.01 00:00:00' and '2021.03.31 00:00:00' and P_day is not null
union all
select MAX(P_day)/1000, MAX(Q_day)
from dbo."7" where Czas between '2021.04.01 00:00:00' and '2021.04.30 00:00:00' and P_day is not null
union all
select SUM(P_day)/1000, SUM(Q_day)
from dbo."7" where Czas between '2021.05.01 00:00:00' and '2021.05.31 00:00:00' and P_day is not null
union all
select MAX(P_day)/1000, MAX(Q_day)
from dbo."7" where Czas between '2021.06.01 00:00:00' and '2021.06.30 00:00:00' and P_day is not null
--union all
