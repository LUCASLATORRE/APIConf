# APIConf

API Crud de controle de usuários com SQL Server LocalDB.

Para rodar o projeto é necessário o .NET Core SDK 2.2.100 (https://dotnet.microsoft.com/download/dotnet-core/2.2).

--------------------------------------------------------------------------------------------------------------------------------------

Crie um banco chamado ConfDB e execute o script abaixo no SQL Server Object Explorer para criar a tabela no SQL Server Local DB:

USE [ConfDB]
GO

/****** Object: Table [dbo].[User] Script Date: 15/11/2020 22:10:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[User] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]   NVARCHAR (MAX) NULL,
    [LastName]    NVARCHAR (MAX) NULL,
    [Email]       NVARCHAR (MAX) NULL,
    [DateofBirth] DATETIME2 (7)  NULL,
    [Schooling]   INT            NOT NULL
);


------------------------------------------------------------------------------------------------------

Execute o projeto e consulte o swagger para verificar os métodos da API.

