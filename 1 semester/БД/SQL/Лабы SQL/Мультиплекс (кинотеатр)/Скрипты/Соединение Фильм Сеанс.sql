ALTER TABLE Сеанс
ADD CONSTRAINT FK_Сеанс_Фильм
FOREIGN KEY (ID_Фильма) REFERENCES Фильм(ФильмID);