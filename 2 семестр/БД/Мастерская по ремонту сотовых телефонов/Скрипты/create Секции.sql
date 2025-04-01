create table Секции (
    ID_Секции int identity(1,1) primary key,
    ID_Склада int NOT NULL,
    Название varchar(50) NOT NULL
);