create table Клиент(
ID_Клиента int primary key,
ФИО nvarchar(200) not null,
Телефон float not null,
Почта nvarchar(50) not null
);

create table Тур(
ID_Тура int primary key,
Наименование nvarchar(200), 
Описание nvarchar(200),
Цена decimal
);

create table Договор(
ID_договора int primary key identity(1,1),
Номер int,
Дата datetime,
Цена float,
Статус nvarchar(50),
FK_Тур int references Тур(ID_Тура),
FK_Клиент int references Клиент(ID_Клиента)
);

create table Отель(
ID_Отеля int primary key,
Название_отеля nvarchar(200),
Звезды float,
Тип_питания nvarchar(20)
);

