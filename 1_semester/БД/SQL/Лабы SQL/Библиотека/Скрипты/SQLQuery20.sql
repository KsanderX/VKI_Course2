


ALTER TABLE Формуляры
ADD FKэкземпляра_книги INT,
FOREIGN KEY(FKэкземпляра_книги) REFERENCES Экземпляры_книги(ID_экземпляра)

