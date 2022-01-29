declare @P_res_min float = 0;
declare @P_res_max float = 0;
declare @P_res float = 0;
declare @Q_res_min float = 0;
declare @Q_res_max float = 0;
declare @Q_res float = 0;
declare @time_to datetime;
declare @time_to_cnt datetime;
declare @time_from datetime = '2021.01.03 00:00:00';
declare @time_to_count datetime = '2021.31.10 23:59:59';
declare @cnt int = 1;

set @time_to_cnt = @time_from;

while @time_to_cnt <= @time_to_count
begin
	set @time_to = DATEADD(MONTH, 1, @time_from);
	set @time_to_cnt = @time_to;
	set @P_res_min = (select top 1 [P_day]
	from pomiary.dbo.EQ_7
	where [Czas] between @time_from and @time_to and [P_day] is not null
	order by [ID])
	set @P_res_max = (select top 1 [P_day]
	from pomiary.dbo.EQ_7
	where [Czas] between @time_from and @time_to and [P_day] is not null
	order by [ID] desc)
	set @P_res = @P_res_max - @P_res_min;

	set @Q_res_min = (select top 1 [Q_day]
	from pomiary.dbo.EQ_7
	where [Czas] between @time_from and @time_to and [Q_day] is not null
	order by [ID])
	set @Q_res_max = (select top 1 [Q_day]
	from pomiary.dbo.EQ_7
	where [Czas] between @time_from and @time_to and [Q_day] is not null
	order by [ID] desc)
	set @Q_res = @Q_res_max - @Q_res_min;

	insert into pomiary.dbo.monthly_7(ID,Czas,P_day,Q_day) values (@cnt,@time_from,@P_res,@Q_res);

	set @cnt = @cnt + 1;
	set @time_from = @time_to;
END;
































