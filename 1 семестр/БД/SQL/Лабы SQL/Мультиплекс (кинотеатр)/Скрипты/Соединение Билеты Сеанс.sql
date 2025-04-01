ALTER TABLE Билеты
ADD CONSTRAINT FK_Билеты_Сеанс
FOREIGN KEY (ID_Сеанса) REFERENCES Сеанс(ID_Сеанса);