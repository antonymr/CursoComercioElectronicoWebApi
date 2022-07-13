--use ComercioElectronico
--go

--update new 
--set new.Description = new.Name
--from Brands new
--where new.Id = new.Id
--go

--ALTER TABLE Brands DROP COLUMN [Name];
--go

--update new 
--set new.Code = new.Id
--from Brands new
--where new.Id = new.Id
--go

--ALTER TABLE [Brands] DROP COLUMN [Name];
--go

--ALTER TABLE [Brands] DROP CONSTRAINT [PK_Brands];
--GO

--ALTER TABLE [Brands] DROP COLUMN [Id];
--go

--ALTER TABLE [Brands] ADD CONSTRAINT [PK_Brands] PRIMARY KEY ([Code]);
--GO