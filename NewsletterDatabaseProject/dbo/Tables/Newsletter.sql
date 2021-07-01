CREATE TABLE [dbo].[Newsletter]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Email] NCHAR(50) NULL, 
    [HowTheyHeard] NCHAR(20) NULL, 
    [Reason] NCHAR(200) NULL
)
