CREATE TABLE Актеры (
    АктерID INT PRIMARY KEY IDENTITY(1,1),
    Имя NVARCHAR(100),
    Фамилия NVARCHAR(100),
    ДатаРождения DATE,
    Пол NVARCHAR(10));
