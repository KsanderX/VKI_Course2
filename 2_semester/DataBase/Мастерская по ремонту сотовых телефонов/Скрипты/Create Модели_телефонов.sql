create table Модели_телефонов (
ID_Модели int identity(1,1) primary key, 
Название varchar(50) not null,
ID_Марки int not null 
);