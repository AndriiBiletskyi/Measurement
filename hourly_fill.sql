declare @cnt INT = 1;
declare @count INT = 1000;
declare @P_res_min float = 0;
declare @P_res_max float = 0;
declare @P_res float = 0;
declare @Q_res_min float = 0;
declare @Q_res_max float = 0;
declare @Q_res float = 0;
declare @time_from datetime = '2021.12.03 19:00:00';
declare @time_to datetime;

while @cnt <= @count
begin
	set @time_to = DATEADD(hour, 1, @time_from);
	set @P_res_min = (select top 1 [P_day]
	from [pomiary].[dbo].[1]
	where [Czas] between @time_from and @time_to and [P_day] is not null
	order by [ID])
	set @P_res_max = (select top 1 [P_day]
	from [pomiary].[dbo].[1]
	where [Czas] between @time_from and @time_to and [P_day] is not null
	order by [ID] desc)
	set @P_res = @P_res_max - @P_res_min;

	set @Q_res_min = (select top 1 [Q_day]
	from [pomiary].[dbo].[1]
	where [Czas] between @time_from and @time_to and [Q_day] is not null
	order by [ID])
	set @Q_res_max = (select top 1 [Q_day]
	from [pomiary].[dbo].[1]
	where [Czas] between @time_from and @time_to and [Q_day] is not null
	order by [ID] desc)
	set @Q_res = @Q_res_max - @Q_res_min;

	insert into pomiary.dbo.hourly_1 (ID,Czas,P_day,Q_day) values (@cnt,@time_from,@P_res,@Q_res);

	set @cnt = @cnt + 1;
	set @time_from = @time_to;
END;
































