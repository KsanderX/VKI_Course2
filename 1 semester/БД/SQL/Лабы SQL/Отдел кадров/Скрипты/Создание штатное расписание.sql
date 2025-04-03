CREATE TABLE Штатное_расписание (
    ID INT PRIMARY KEY IDENTITY(1,1),
    FK_Сотрудники INT,
    FK_Отделы INT,
    FK_Должности INT,
    График_работы VARCHAR(255));
  

