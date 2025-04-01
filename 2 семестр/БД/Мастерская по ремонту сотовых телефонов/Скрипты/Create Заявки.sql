Create table Заявки (
ID_Заявки int identity(1,1) primary key,
ID_Клиента int not null,
Описание_проблемы text not null
)