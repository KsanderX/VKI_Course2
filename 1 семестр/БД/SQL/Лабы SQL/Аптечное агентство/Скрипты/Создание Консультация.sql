CREATE TABLE Консультация (
    ID_Консультации INT PRIMARY KEY IDENTITY(1,1),
    FK_Оператор INT FOREIGN KEY REFERENCES Операторы(ID_Оператора),
    FK_Клиент INT FOREIGN KEY REFERENCES Клиенты(ID_Клиента),
    FK_Жалобы INT FOREIGN KEY REFERENCES Жалобы(ID_Жалоба),
    Дата_Консультации DATETIME DEFAULT GETDATE(),
    Примечания NVARCHAR(255) NULL);