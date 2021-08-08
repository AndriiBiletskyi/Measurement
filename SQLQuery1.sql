select (MAX(P_day) - MIN(P_day)) as resP,
(
	(select top 1 Q_day from dbo."1" where (Czas between '2021.01.01 00:00:00' and '2021.02.01 00:00:00') and Q_day is not null order by ID desc) - 
	(select top 1 Q_day from dbo."1" where (Czas between '2021.01.01 00:00:00' and '2021.02.01 00:00:00') and Q_day is not null order by ID asc)
) as resQ
from dbo."1" where (Czas between '2021.01.01 00:00:00' and '2021.02.01 00:00:00')
union all
select (MAX(P_day) - MIN(P_day)) as resP,
(
	(select top 1 Q_day from dbo."1" where (Czas between '2021.02.01 00:00:00' and '2021.03.01 00:00:00') and Q_day is not null order by ID desc) - 
	(select top 1 Q_day from dbo."1" where (Czas between '2021.02.01 00:00:00' and '2021.03.01 00:00:00') and Q_day is not null order by ID asc)
) as resQ
from dbo."1" where (Czas between '2021.02.01 00:00:00' and '2021.03.01 00:00:00')
union all
select (MAX(P_day) - MIN(P_day)) as resP,
(
	(select top 1 Q_day from dbo."1" where (Czas between '2021.03.01 00:00:00' and '2021.04.01 00:00:00') and Q_day is not null order by ID desc) - 
	(select top 1 Q_day from dbo."1" where (Czas between '2021.03.01 00:00:00' and '2021.04.01 00:00:00') and Q_day is not null order by ID asc)
) as resQ
from dbo."1" where (Czas between '2021.03.01 00:00:00' and '2021.04.01 00:00:00')
union all
select (MAX(P_day) - MIN(P_day)) as resP,
(
	(select top 1 Q_day from dbo."1" where (Czas between '2021.04.01 00:00:00' and '2021.05.01 00:00:00') and Q_day is not null order by ID desc) - 
	(select top 1 Q_day from dbo."1" where (Czas between '2021.04.01 00:00:00' and '2021.05.01 00:00:00') and Q_day is not null order by ID asc)
) as resQ
from dbo."1" where (Czas between '2021.04.01 00:00:00' and '2021.05.01 00:00:00')
union all
select (MAX(P_day) - MIN(P_day)) as resP,
(
	(select top 1 Q_day from dbo."1" where (Czas between '2021.05.01 00:00:00' and '2021.06.01 00:00:00') and Q_day is not null order by ID desc) - 
	(select top 1 Q_day from dbo."1" where (Czas between '2021.05.01 00:00:00' and '2021.06.01 00:00:00') and Q_day is not null order by ID asc)
) as resQ
from dbo."1" where (Czas between '2021.05.01 00:00:00' and '2021.06.01 00:00:00')
union all
select (MAX(P_day) - MIN(P_day)) as resP,
(
	(select top 1 Q_day from dbo."1" where (Czas between '2021.06.01 00:00:00' and '2021.07.01 00:00:00') and Q_day is not null order by ID desc) - 
	(select top 1 Q_day from dbo."1" where (Czas between '2021.06.01 00:00:00' and '2021.07.01 00:00:00') and Q_day is not null order by ID asc)
) as resQ
from dbo."1" where (Czas between '2021.06.01 00:00:00' and '2021.07.01 00:00:00')
union all
select (MAX(P_day) - MIN(P_day)) as resP,
(
	(select top 1 Q_day from dbo."1" where (Czas between '2021.07.01 00:00:00' and '2021.08.01 00:00:00') and Q_day is not null order by ID desc) - 
	(select top 1 Q_day from dbo."1" where (Czas between '2021.07.01 00:00:00' and '2021.08.01 00:00:00') and Q_day is not null order by ID asc)
) as resQ
from dbo."1" where (Czas between '2021.07.01 00:00:00' and '2021.08.01 00:00:00')
union all
select (MAX(P_day) - MIN(P_day)) as resP,
(
	(select top 1 Q_day from dbo."1" where (Czas between '2021.08.01 00:00:00' and '2021.09.01 00:00:00') and Q_day is not null order by ID desc) - 
	(select top 1 Q_day from dbo."1" where (Czas between '2021.08.01 00:00:00' and '2021.09.01 00:00:00') and Q_day is not null order by ID asc)
) as resQ
from dbo."1" where (Czas between '2021.08.01 00:00:00' and '2021.09.01 00:00:00')
union all
select (MAX(P_day) - MIN(P_day)) as resP,
(
	(select top 1 Q_day from dbo."1" where (Czas between '2021.09.01 00:00:00' and '2021.10.01 00:00:00') and Q_day is not null order by ID desc) - 
	(select top 1 Q_day from dbo."1" where (Czas between '2021.09.01 00:00:00' and '2021.10.01 00:00:00') and Q_day is not null order by ID asc)
) as resQ
from dbo."1" where (Czas between '2021.09.01 00:00:00' and '2021.10.01 00:00:00')
union all
select (MAX(P_day) - MIN(P_day)) as resP,
(
	(select top 1 Q_day from dbo."1" where (Czas between '2021.10.01 00:00:00' and '2021.11.01 00:00:00') and Q_day is not null order by ID desc) - 
	(select top 1 Q_day from dbo."1" where (Czas between '2021.10.01 00:00:00' and '2021.11.01 00:00:00') and Q_day is not null order by ID asc)
) as resQ
from dbo."1" where (Czas between '2021.10.01 00:00:00' and '2021.11.01 00:00:00')
union all
select (MAX(P_day) - MIN(P_day)) as resP,
(
	(select top 1 Q_day from dbo."1" where (Czas between '2021.11.01 00:00:00' and '2021.12.01 00:00:00') and Q_day is not null order by ID desc) - 
	(select top 1 Q_day from dbo."1" where (Czas between '2021.11.01 00:00:00' and '2021.12.01 00:00:00') and Q_day is not null order by ID asc)
) as resQ
from dbo."1" where (Czas between '2021.11.01 00:00:00' and '2021.12.01 00:00:00')