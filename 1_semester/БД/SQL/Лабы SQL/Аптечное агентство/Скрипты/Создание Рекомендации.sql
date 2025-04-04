CREATE TABLE Рекомендации (
    ID_Рекомендации INT PRIMARY KEY IDENTITY(1,1),
    ID_Консультации INT FOREIGN KEY REFERENCES Консультация(ID_Консультации),
    ID_Aптеки_Лекарственные_препараты INT FOREIGN KEY REFERENCES Аптеки_Препараты(ID_Аптеки_Лекарственные_препараты),
    Количество INT DEFAULT 1,
    Примечания NVARCHAR(255) NULL);