CREATE TABLE Заболевания (
    ID_Заболевания INT PRIMARY KEY IDENTITY(1,1),
    Название NVARCHAR(100) NOT NULL,
    Описание NVARCHAR(255) NOT NULL);