CREATE DATABASE Test;
USE Test;

CREATE TABLE Posts
(IdPost UNIQUEIDENTIFIER PRIMARY KEY DEFAULT newsequentialid(),
NamePost VARCHAR(50));

CREATE TABLE TypesOfDep
(IdType UNIQUEIDENTIFIER PRIMARY KEY DEFAULT newsequentialid(),
NameType VARCHAR(50));

CREATE TABLE Departaments
(IdDep UNIQUEIDENTIFIER PRIMARY KEY DEFAULT newsequentialid(),
FullNameDep VARCHAR (100),
ShortNameDep VARCHAR (15),
TypeId UNIQUEIDENTIFIER FOREIGN KEY REFERENCES TypesOfDep(IdType));


CREATE TABLE Users
(IdUser UNIQUEIDENTIFIER PRIMARY KEY DEFAULT newsequentialid(),
NameUser VARCHAR(50),
SurnameUser VARCHAR(50),
LastnameUser VARCHAR(50),
PostId UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Posts(IdPost),
DepId UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Departaments(IdDep) NOT NULL,
TelUser NUMERIC,
NationalityUser VARCHAR(50));

INSERT INTO Posts (NamePost) VALUES
('��������� ������'),
('������� C# �����������'),
('������� �����������');

INSERT INTO TypesOfDep (NameType) VALUES
('IT �����'),
('�����������'),
('����� ������');

INSERT INTO Departaments (FullNameDep, ShortNameDep, TypeId) VALUES
('����� ������� �����', '���', (SELECT IdType FROM TypesOfDep WHERE NameType = 'IT �����'));

INSERT INTO Users (NameUser, SurnameUser, LastnameUser, PostId, DepId, TelUser, NationalityUser) VALUES
('����', '������', '����������', (SELECT IdPost FROM Posts WHERE NamePost = '������� �����������'),
(SELECT IdDep FROM Departaments WHERE ShortNameDep = '���'), 89295005050, '���������� ���������');

SELECT * FROM Users