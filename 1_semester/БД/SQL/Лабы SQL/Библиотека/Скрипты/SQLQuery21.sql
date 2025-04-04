

ALTER TABLE ‘ормул€ры
ADD FKэкземпл€ра_книги INT,
FOREIGN KEY(FKэкземпл€ра_книги) REFERENCES Ёкземпл€ры_книги(ID_экземпл€ра);

ALTER TABLE ‘ормул€ры
ADD FKчитател€ INT,
FOREIGN KEY(FKчитател€) REFERENCES „итатели(ID_читател€);


ALTER TABLE ѕопул€рные_книги
ADD FKкниги INT,
FOREIGN KEY(FKкниги) REFERENCES  ниги(ID_книги);

ALTER TABLE Ёкземпл€ры_книги
ADD FKкниги INT,
FOREIGN KEY(FKкниги) REFERENCES  ниги(ID_книги);

ALTER TABLE Ёкземпл€ры_книги
ADD FK€чейки INT,
FOREIGN KEY(FK€чейки) REFERENCES ячейки(ID_€чейки);

ALTER TABLE јвторы_книги
ADD FKкниги INT,
FOREIGN KEY(FKкниги) REFERENCES  ниги(ID_книги);

ALTER TABLE јвторы_книги
ADD FKавтора INT,
FOREIGN KEY(FKавтора) REFERENCES јвторы(ID_автора);

ALTER TABLE ∆анры_книги
ADD FKкниги INT,
FOREIGN KEY(FKкниги) REFERENCES  ниги(ID_книги);

ALTER TABLE ∆анры_книги
ADD FKжанра INT,
FOREIGN KEY(FKжанра) REFERENCES ∆анры(ID_жанра);

ALTER TABLE »здательства_книги
ADD FKкниги INT,
FOREIGN KEY(FKкниги) REFERENCES  ниги(ID_книги);

ALTER TABLE »здательства_книги
ADD FKиздательства INT,
FOREIGN KEY(FKиздательства) REFERENCES »здательства(ID_издательства);

ALTER TABLE ячейки
ADD FK€чейки INT,
FOREIGN KEY(FK€чейки) REFERENCES ѕолки(ID_полки);

ALTER TABLE ѕолки
ADD FKр€да INT,
FOREIGN KEY(FKр€да) REFERENCES –€ды(ID_р€да);

ALTER TABLE –€ды
ADD FKсекции INT,
FOREIGN KEY(FKсекции) REFERENCES —екции(ID_секции);

ALTER TABLE —екции
ADD FKкомнаты INT,
FOREIGN KEY(FKкомнаты) REFERENCES  омнаты(ID_комнаты);
