create table Телефоны (
ID_Телефона int identity(1,1) primary key,
ID_Модели int not null,
ID_Заявки int not null,
ID_Ячейки int not null,
Серийный_номер nvarchar(50)
);