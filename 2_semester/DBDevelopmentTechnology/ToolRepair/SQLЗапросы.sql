-- Create Tools table
CREATE TABLE Tools (
    ID_����������� INT PRIMARY KEY,
    FK_������ INT
);

-- Create Types table
CREATE TABLE Types (
    ID_���� INT PRIMARY KEY,
    �������� NVARCHAR(100),
    �������� NVARCHAR(500)
);

-- Create Employees table
CREATE TABLE Employees (
    ID_��������� INT PRIMARY KEY,
    ��� NVARCHAR(100),
    ����������_������ NVARCHAR(100),
    ��������� NVARCHAR(100),
    ����� NVARCHAR(50),
    ������ NVARCHAR(50)
);

-- Create Services table
CREATE TABLE Services (
    ID_������ INT PRIMARY KEY,
    �������� NVARCHAR(100),
    �������� NVARCHAR(500)
);

-- Create Components table
CREATE TABLE Components (
    ID_������������� INT PRIMARY KEY,
    �������� NVARCHAR(100),
    �������� NVARCHAR(500),
	FK_������������� int
);

-- Create Requests table
CREATE TABLE Requests (
    ID_������ INT PRIMARY KEY,
    FK_������� INT,
    FK_��������� INT,
	FK_����������� int,
	FK_������ int,
    ����_�������� DATETIME
);

-- Create Clients table
CREATE TABLE Clients (
    ID_������� INT PRIMARY KEY,
    ��� NVARCHAR(100),
    ����������_������ NVARCHAR(100),
	����� nvarchar(50),
	������ nvarchar(50)
);

-- Create Manufacturers table
CREATE TABLE Manufacturers (
    ID_������������� INT PRIMARY KEY,
    �������� NVARCHAR(100)
);

-- Create CompletedServices table
CREATE TABLE CompletedServices (
    ID_�����������_����� INT PRIMARY KEY,
    FK_������ INT,
    FK_������ INT
);

-- Create RequiredComponents table
CREATE TABLE RequiredComponents (
    ID INT PRIMARY KEY,
    FK_������ INT,
    FK_������������� INT
);

-- Create Models table
CREATE TABLE Models (
    ID_������ INT PRIMARY KEY,
    �������� NVARCHAR(100),
    FK_���� INT
);

alter table Models
add foreign key(FK_����) references Types(ID_����)

alter table Tools
add foreign key(FK_������) references Models(ID_������)

alter table Components
add foreign key(ID_�������������) references Manufacturers(ID_�������������)

alter table RequiredComponents
add foreign key(FK_������) references Services(ID_������),
foreign key(FK_�������������) references Components(ID_�������������)

alter table CompletedServices
add foreign key(FK_������) references Services(ID_������),
foreign key(FK_������) references Requests(ID_������)

alter table Requests
add foreign key(FK_������) references Services(ID_������),
foreign key(FK_�����������) references Tools(ID_�����������),
foreign key(FK_���������) references Employees(ID_���������),
foreign key(FK_�������) references Clients(ID_�������)