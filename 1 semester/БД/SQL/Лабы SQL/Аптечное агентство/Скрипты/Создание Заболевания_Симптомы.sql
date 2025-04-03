CREATE TABLE Заболевания_Симптомы (
    ID_Заболевания_Симптомы INT PRIMARY KEY IDENTITY(1,1),
    ID_Заболевания INT FOREIGN KEY REFERENCES Заболевания(ID_Заболевания),
    ID_Симптома INT FOREIGN KEY REFERENCES Симптомы(ID_Симптома));