CREATE TABLE Запчасти (
    ID_Запчасти INT IDENTITY(1,1) PRIMARY KEY,
    ID_Ячейки INT NOT NULL
);

CREATE TABLE Справочник_запчастей (
    ID_Запчасти INT PRIMARY KEY,
    Название VARCHAR(50) NOT NULL,
    ID_Модели INT NOT NULL
);

CREATE TABLE Квитанции (
    ID_Квитанции INT IDENTITY(1,1) PRIMARY KEY,
    ID_Заявки INT NOT NULL
);

CREATE TABLE Услуги (
    ID_Услуги INT IDENTITY(1,1) PRIMARY KEY,
    Название VARCHAR(50) NOT NULL,
    Стоимость INT NOT NULL
);

CREATE TABLE Ремонт_Услуги (
    ID_Ремонта INT NOT NULL,
    ID_Услуги INT NOT NULL,
    PRIMARY KEY (ID_Ремонта, ID_Услуги)
);