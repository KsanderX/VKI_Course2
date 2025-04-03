ALTER TABLE Билеты
ADD CONSTRAINT FK_Билеты_Места
FOREIGN KEY (ID_Места) REFERENCES Места(ID_Места);