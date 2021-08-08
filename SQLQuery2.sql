select top 1 ID as idfirst, count(P)  --where Czas between '2021.01.01 00:00:00' and '2021.05.01 00:00:00' order by ID asc
from dbo."1" where Czas between '2021.01.01 00:00:00' and '2021.05.01 00:00:00' order by ID asc
