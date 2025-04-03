use [Аптечное_агентство]
CREATE TABLE Операторы (
    ID_Оператора INT PRIMARY KEY IDENTITY(1,1),
    Имя NVARCHAR(100) NOT NULL,
    Фамилия NVARCHAR(100) NOT NULL,
    Телефон NVARCHAR(20) NULL,
    Дата_начала_работы DATE NULL);