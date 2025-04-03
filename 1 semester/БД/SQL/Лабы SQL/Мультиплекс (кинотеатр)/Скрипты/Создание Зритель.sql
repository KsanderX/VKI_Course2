CREATE TABLE Зритель (
    ЗрительID INT PRIMARY KEY IDENTITY(1,1),
    Имя NVARCHAR(100) NOT NULL,
    Фамилия NVARCHAR(100) NOT NULL,
    Дата_рождения DATE,
    Телефон NVARCHAR(20) NULL);