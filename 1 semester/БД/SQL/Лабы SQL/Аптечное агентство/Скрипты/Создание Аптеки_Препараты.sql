CREATE TABLE Аптеки_Препараты (
	ID_Аптеки_Лекарственные_препараты INT PRIMARY KEY IDENTITY(1,1),
    ID_Aптеки INT FOREIGN KEY REFERENCES Аптеки(ID_Аптеки),
    ID_Препарата INT FOREIGN KEY REFERENCES Лекарственные_препараты(ID_Препарата),
    Количество INT DEFAULT 0);
    