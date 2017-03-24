IF EXISTS(SELECT 1 FROM master.dbo.sysdatabases WHERE name = 'SCSYSDB')
BEGIN
  Print '' print  ' *** dropping database SCSYSDB'
  DROP DATABASE SCSYSDB
End
GO
print '' print '*** creating database SCSYSDB'
GO
CREATE DATABASE SCSYSDB
GO

print '' print '*** using database SCSYSDB'
GO
USE [SCSYSDB]
GO


Create table Solutions
(
	[SolutionsID] INT NOT NULL PRIMARY KEY IDENTITY,
	[Image] IMAGE,
	[Name] NVARCHAR(100) NOT NULL,
	[DESCRIPTION] NVARCHAR(512) NOT NULL,
)

Create table Services
(
	[ServicesID] INT NOT NULL PRIMARY KEY IDENTITY,
	[Image] IMAGE,
	[Name] NVARCHAR(100) NOT NULL,
	[DESCRIPTION] NVARCHAR(512) NOT NULL,
)

Create table Solutions_Services
(
	[SolutionsID]	INT,
	[ServicesID]	INT
)

print '' print '*** Creating Foreign Key Solutions_Services SolutionsID'
GO
ALTER TABLE [dbo].[Solutions_Services] with nocheck
  ADD CONSTRAINT[fk_SS_SolutionsID] FOREIGN KEY (SolutionsID)
  References [dbo].[Solutions](SolutionsID)
  ON UPDATE CASCADE
  ON DELETE CASCADE
GO

print '' print '*** Creating Foreign Key Solutions_Services ServicesID'
GO
ALTER TABLE [dbo].[Solutions_Services] with nocheck
  ADD CONSTRAINT[fk_SS_ServicesID] FOREIGN KEY (ServicesID)
  References [dbo].[Services](ServicesID)
  ON UPDATE CASCADE
  ON DELETE CASCADE
GO

print '*** Inserting Solutions Data ***'
GO
INSERT INTO [dbo].[Solutions]
	(Name, Description)
	VALUES
	('Agriculture', 'The need for agriculture has been at the epicenter of human survival since the beginning of time. Between 1990 and 2010, the world population grew by 30%. This has necessitated rethinking agriculture to cope with this global population growth.'),
	('MANUFACTURING TECHNOOGY', 'Manufacturing technology has evolved phenomenally since the industrial evolution. Human innovation has been the backbone of the modern life of everyone. Along with the constant increase in complexity and efficiency of manufacturing tech, has also been major leaps in engineering design methods.'),
	('RENEWABLE ENERGY', 'Renewable Energy is the future for energy generation in the near future. The transition from fossil fuel energy to renewables is globally being adopted to ensure a sustainable future. Renewable energy has now become an important component to consider to bridge the gap between globally declared goals on sustainability and our current reliance on fossil fuels for energy.')
GO

print '*** Inserting Services Data ***'
GO
INSERT INTO [dbo].[Services]
	(Name, Description)
	VALUES
	('Cad Drafting', 'The modern engineer or inventor in a world of increasing complexity and technology has one problem they have to overcome: to deliver.'),
	('Finite Element Analysis', 'Evolution of engineering since the industrial age has been hand-in-hand with increasing computational power. This has given us the ability to analyze and make predictions at an unprecedented pace.'),
	('Multiphysics Simulation', 'At SCCL, engineers are more dedicated to deliver and solve your engineering challenge to the highest precision possible. To ensure an ultimate solution to any engineering problem, this is the most assured way SCCL could help.')
GO

print '*** Inserting Solutions Services Data ***'
GO
INSERT INTO [dbo].[Solutions_Services]
	(SolutionsID, ServicesID)
	VALUES
	(1,1),
	(2,1),
	(2,2),
	(3,1),
	(3,2),
	(3,3)
GO


