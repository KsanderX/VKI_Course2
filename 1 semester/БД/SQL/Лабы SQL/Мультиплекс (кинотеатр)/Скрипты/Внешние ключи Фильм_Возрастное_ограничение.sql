ALTER TABLE Фильм
ADD Возрастное_ограничение_ID INT;

ALTER TABLE Фильм
ADD CONSTRAINT FK_Фильм_Возрастное_ограничение
FOREIGN KEY (Возрастное_ограничение_ID) REFERENCES Возрастное_ограничение(Возрастное_ограничение_ID);