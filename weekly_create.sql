use pomiary;
DECLARE @cnt INT = 1;
DECLARE @count INT = 20;
DECLARE @table_name nvarchar(50);
DECLARE @sql_create nvarchar(max);

WHILE @cnt <= @count
BEGIN
	SET @table_name = 'weekly_' + CONVERT(varchar(10),@cnt); 
	
	IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES
					WHERE TABLE_NAME = @table_name)
	BEGIN
		SET @sql_create = '';
		SET @sql_create = @sql_create + 'CREATE TABLE ' + @table_name + ' (';
		SET @sql_create = @sql_create + ' ID int, ' + ' Czas datetime, ' + 'P_day float, ' + 'Q_day float );';

		exec sp_executesql @sql_create
	END

	SET @cnt = @cnt + 1;
END;