/*
USE master
GO
*/
USE Rabbits
Go

DROP DATABASE IF EXISTS Rabbits

CREATE DATABASE Rabbits

DROP TABLE IF EXISTS Rabbits

CREATE TABLE RabbitsTable (
    RabbitID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    RabbitName varchar(55) NULL,
    RabbitAge int NULL,
)

INSERT INTO RabbitsTable (RabbitName, RabbitAge)
VALUES ('Fluffy', 12)

INSERT INTO RabbitsTable (RabbitName, RabbitAge)
VALUES ('Angry', 25)

INSERT INTO RabbitsTable (RabbitName, RabbitAge)
VALUES ('Sleepy', 55)

SELECT * FROM RabbitsTable

DROP TABLE RabbitsTable

CREATE TABLE TestTable (
    RabbitID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    RabbitName varchar(55) NULL,
    RabbitAge int NULL,
) 