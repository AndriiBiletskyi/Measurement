declare @table VARCHAR(max) = 'pomiary.dbo.EQ_';
declare @currentTable VARCHAR(max) = '';
declare @table_cnt int = 1;
declare @table_to_count int = 20;

while @table_cnt <= @table_to_count
begin
	set @currentTable = @table + CAST(@table_cnt as varchar(max));
	
	declare @cmd varchar(max) = 'CREATE NONCLUSTERED INDEX [iIDStatusPL1PL2PL3]
	ON ' + @currentTable + ' (ID)
	INCLUDE (Status,P_L1,P_L2,P_L3)';
	exec (@cmd);
	set @table_cnt = @table_cnt + 1;

end;