CREATE TABLE Заболевания_Препараты (
    ID_Заболевания_Препараты INT PRIMARY KEY IDENTITY(1,1),
    ID_Заболевания INT FOREIGN KEY REFERENCES Заболевания(ID_Заболевания),
    ID_Препарата INT FOREIGN KEY REFERENCES Лекарственные_препараты(ID_Препарата),
    Рекомендованная_дозировка NVARCHAR(50) NULL);