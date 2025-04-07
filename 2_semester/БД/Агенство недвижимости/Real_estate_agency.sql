-- Тип договора
CREATE TABLE Тип_договора (
    ID_Типа INT PRIMARY KEY IDENTITY(1,1),
    Название VARCHAR(50)
);

-- Клиент
CREATE TABLE Клиент (
    ID_Клиента INT PRIMARY KEY IDENTITY(1,1),
    ФИО VARCHAR(100),
    Телефон VARCHAR(20),
    Email VARCHAR(100)
);

-- Сотрудник агентства
CREATE TABLE Сотрудник (
    ID_Сотрудника INT PRIMARY KEY IDENTITY(1,1),
    ФИО VARCHAR(100),
    Должность VARCHAR(50)
);

-- Договор
CREATE TABLE Договор (
    ID_Договора INT PRIMARY KEY IDENTITY(1,1),
    Дата_заключения DATE,
    FK_Тип_договора INT FOREIGN KEY REFERENCES Тип_договора(ID_Типа)
);

-- Договор оказания услуг покупки
CREATE TABLE Договор_услуг_покупки (
    ID_Договора INT PRIMARY KEY,
    FK_Клиента INT FOREIGN KEY REFERENCES Клиент(ID_Клиента),
    FK_Сотрудника INT FOREIGN KEY REFERENCES Сотрудник(ID_Сотрудника),
    FK_Тип_договора INT FOREIGN KEY REFERENCES Тип_договора(ID_Типа)
);

-- Договор оказания услуг продажи
CREATE TABLE Договор_услуг_продажи (
    ID_Договора INT PRIMARY KEY,
    FK_Клиента INT FOREIGN KEY REFERENCES Клиент(ID_Клиента),
    FK_Сотрудника INT FOREIGN KEY REFERENCES Сотрудник(ID_Сотрудника),
    FK_Тип_договора INT FOREIGN KEY REFERENCES Тип_договора(ID_Типа)
);

-- Договор купли-продажи
CREATE TABLE Договор_купли_продажи (
    ID_Договора INT PRIMARY KEY,
    Дата_подписания DATE,
    FK_Клиента INT FOREIGN KEY REFERENCES Клиент(ID_Клиента)   
);

-- Свойство объекта
CREATE TABLE Свойство (
    ID_Свойства INT PRIMARY KEY IDENTITY(1,1),
    Название VARCHAR(100),
    Значение VARCHAR(100)   
);

-- Характеристика
CREATE TABLE Характеристика (
    ID_Характеристики INT PRIMARY KEY IDENTITY(1,1),
    Описание VARCHAR(100),
	FK_Свойства INT FOREIGN KEY REFERENCES Свойство(ID_Свойства)
);

-- Объект недвижимости
CREATE TABLE Объект_недвижимости (
    ID_Объекта INT PRIMARY KEY IDENTITY(1,1),
    Адрес VARCHAR(150),
    Тип VARCHAR(50),
    Площадь INT,
    FK_Характеристика INT FOREIGN KEY REFERENCES Характеристика(ID_Характеристики)
);

-- Право собственности
CREATE TABLE Право_собственности (
    ID_Права INT PRIMARY KEY IDENTITY(1,1),
    FK_Клиента INT FOREIGN KEY REFERENCES Клиент(ID_Клиента),
    FK_Объекта INT FOREIGN KEY REFERENCES Объект_недвижимости(ID_Объекта),
    FK_ДКП INT FOREIGN KEY REFERENCES Договор_купли_продажи(ID_Договора)
);

-- Запрос клиента
CREATE TABLE Запрос (
    ID_Запроса INT PRIMARY KEY IDENTITY(1,1),
    Цель VARCHAR(100),
    Бюджет INT,
    FK_Договора_услуг_покупки INT FOREIGN KEY REFERENCES Договор_услуг_покупки(ID_Договора)
);

-- Запрос -> Свойство объекта
CREATE TABLE Запрос_Свойство (
    ID INT PRIMARY KEY IDENTITY(1,1),
    FK_Запроса INT FOREIGN KEY REFERENCES Запрос(ID_Запроса),
    FK_Свойства INT FOREIGN KEY REFERENCES Свойство(ID_Свойства)
);
