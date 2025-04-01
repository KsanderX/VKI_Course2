CREATE TABLE Лекарственные_препараты (
    ID_Препарата INT PRIMARY KEY IDENTITY(1,1),
    Название NVARCHAR(100) NOT NULL,
    Дозировка NVARCHAR(50) NOT NULL,
    Форма_выпуска NVARCHAR(50) NOT NULL,
    Описание NVARCHAR(255) NULL);

