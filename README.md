# Projeto C# Console Application / SqlServer
Sistema criado para acesso ao SqlServer com Dapper.

## Requisitos necessários:

* VisualStudio 2022
* SqlServer

## Script do banco de dados:

```sql
	CREATE TABLE [dbo].[PESSOA] (
    		[IDPESSOA]       UNIQUEIDENTIFIER NOT NULL,
    		[NOME]           NVARCHAR (150)   NOT NULL,
    		[CPF]            NVARCHAR (11)    NOT NULL,
    		[DATANASCIMENTO] DATE             NOT NULL,
    		PRIMARY KEY CLUSTERED ([IDPESSOA] ASC)
	);
```