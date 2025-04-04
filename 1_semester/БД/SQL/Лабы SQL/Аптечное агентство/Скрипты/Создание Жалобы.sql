CREATE TABLE Жалобы (
    ID_Жалоба  INT PRIMARY KEY IDENTITY(1,1),
    ID_Симптомы INT FOREIGN KEY REFERENCES Симптомы(ID_Симптома));