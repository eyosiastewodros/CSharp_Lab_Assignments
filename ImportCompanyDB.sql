CREATE DATABASE ElectronicsImportCompany

USE ElectronicsImportCompany

CREATE TABLE Products (
	Number smallint,
	ItemName nvarchar(50),
	InventoryNum nvarchar (50) primary key,
	Count smallint,
	Price smallmoney,
	Date nvarchar(50),
	TargetDemogrGender nvarchar (10),
	TargetDemogrAge nvarchar (50),
);

SELECT * FROM Products