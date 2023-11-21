CREATE DATABASE BDCliente;
GO
USE BDCliente;


CREATE TABLE Cliente(
Id INT IDENTITY,
Nome VARCHAR(50) NOT NULL,
Email VARCHAR(50),
DtNascimento Date,
CEP VARCHAR(9),
Rua Varchar(50),
Bairro Varchar(30),
Cidade Varchar(40),
Estado Varchar(2)
Constraint PK_Cliente PRIMARY KEY (Id)
);

GO

