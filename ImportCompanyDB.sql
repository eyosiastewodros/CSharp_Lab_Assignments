CREATE DATABASE ElectronicsImportCompany

CREATE TABLE Products (
	Number smallint,
	ItemName nvarchar(50),
	InventoryNum nvarchar (50) primary key,
	Count smallint,
	Price smallmoney,
	Date date,
	TargetDemogrGender nvarchar (10),
	TargetDemogrAge nvarchar (50),
);

INSERT INTO Products VALUES (1, 'Samsung Mobile', 'IN-1', 20, 30, '2022-09-02', 'Male', '19-24')

SELECT * FROM Products