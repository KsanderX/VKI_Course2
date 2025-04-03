create table Клиенты (
ID_Клиента int identity(1,1) primary key,
Имя varchar(50) not null,
Фамилия varchar(50) not null, 
Номер_телефона varchar(20) not null
)