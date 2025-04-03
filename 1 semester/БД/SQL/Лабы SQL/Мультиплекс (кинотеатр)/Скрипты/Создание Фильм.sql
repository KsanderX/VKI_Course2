CREATE TABLE Фильм (
    ФильмID INT PRIMARY KEY IDENTITY(1,1),
    Название NVARCHAR(200),
    ГодВыпуска INT,
    Продолжительность INT,
    Рейтинг FLOAT);