BEGIN
IF NOT EXISTS (SELECT * FROM pomiary.INFORMATION_SCHEMA.TABLES
					WHERE TABLE_NAME = N'equipments')
	BEGIN
		CREATE TABLE equipments (
			ID int not null unique, 
			NamePL nvarchar(50),
			NameEN nvarchar(50),
			RatedPower float,
			RatedCurrent float,
			RatedVoltage float,
			NumberOfPhases int,
			UnitOfPower nvarchar(10)
		);
	END
END