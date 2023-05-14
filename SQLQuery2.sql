

insert into Players (first_name, last_name) values ('john','smith')


CREATE TABLE Persons (
Id INT PRIMARY KEY IDENTITY(1,1),
FirstName NVARCHAR(50) NOT NULL,
LastName NVARCHAR(50) NOT NULL
);


Insert into Persons (FirstName, LastName) values ('John', 'Smith')
SELECT * FROM Persons

DELETE  Players where id is null
SELECT * FROM Players

INSERT INTO Players (first_name, last_name) values ('John','Adams')
SELECT * FROM Coaches