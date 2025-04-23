-- Create Tools table
CREATE TABLE Tools (
    ID_Инструмента INT PRIMARY KEY,
    FK_Модели INT
);

-- Create Types table
CREATE TABLE Types (
    ID_Вида INT PRIMARY KEY,
    Название NVARCHAR(100),
    Описание NVARCHAR(500)
);

-- Create Employees table
CREATE TABLE Employees (
    ID_Работника INT PRIMARY KEY,
    ФИО NVARCHAR(100),
    Контактные_данные NVARCHAR(100),
    Должность NVARCHAR(100),
    Логин NVARCHAR(50),
    Пароль NVARCHAR(50)
);

-- Create Services table
CREATE TABLE Services (
    ID_Услуги INT PRIMARY KEY,
    Название NVARCHAR(100),
    Описание NVARCHAR(500)
);

-- Create Components table
CREATE TABLE Components (
    ID_Комплектующих INT PRIMARY KEY,
    Название NVARCHAR(100),
    Описание NVARCHAR(500),
	FK_Производителя int
);

-- Create Requests table
CREATE TABLE Requests (
    ID_Заявки INT PRIMARY KEY,
    FK_Клиента INT,
    FK_Работника INT,
	FK_Инструмента int,
	FK_Услуги int,
    Дата_создания DATETIME
);

-- Create Clients table
CREATE TABLE Clients (
    ID_Клиента INT PRIMARY KEY,
    ФИО NVARCHAR(100),
    Контактные_данные NVARCHAR(100),
	Логин nvarchar(50),
	Пароль nvarchar(50)
);

-- Create Manufacturers table
CREATE TABLE Manufacturers (
    ID_Производителя INT PRIMARY KEY,
    Название NVARCHAR(100)
);

-- Create CompletedServices table
CREATE TABLE CompletedServices (
    ID_Выполненных_услуг INT PRIMARY KEY,
    FK_Услуги INT,
    FK_Заявки INT
);

-- Create RequiredComponents table
CREATE TABLE RequiredComponents (
    ID INT PRIMARY KEY,
    FK_Услуги INT,
    FK_Комплектующие INT
);

-- Create Models table
CREATE TABLE Models (
    ID_Модели INT PRIMARY KEY,
    Название NVARCHAR(100),
    FK_Вида INT
);

alter table Models
add foreign key(FK_Вида) references Types(ID_Вида)

alter table Tools
add foreign key(FK_Модели) references Models(ID_Модели)

alter table Components
add foreign key(ID_Комплектующих) references Manufacturers(ID_Производителя)

alter table RequiredComponents
add foreign key(FK_Услуги) references Services(ID_Услуги),
foreign key(FK_Комплектующие) references Components(ID_Комплектующих)

alter table CompletedServices
add foreign key(FK_Услуги) references Services(ID_Услуги),
foreign key(FK_Заявки) references Requests(ID_Заявки)

alter table Requests
add foreign key(FK_Услуги) references Services(ID_Услуги),
foreign key(FK_Инструмента) references Tools(ID_Инструмента),
foreign key(FK_Работника) references Employees(ID_Работника),
foreign key(FK_Клиента) references Clients(ID_Клиента)