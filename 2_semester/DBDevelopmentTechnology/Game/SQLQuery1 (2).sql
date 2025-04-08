create table Character
(
ID_character int primary key identity(1,1),
Name nvarchar(20),
Level int,
ID_Player int foreign key references Player(ID_Player)
);

create table Player
(
ID_Player int primary key identity(1,1),
Name nvarchar(20),
Region nvarchar(50),
Login nvarchar(20),
Password nvarchar(20)
);

create table Class
(
ID_Class int primary key identity(1,1),
Name nvarchar(50),
Description nvarchar(150)
);

create table Class_character
(
ID_Class int not null,
ID_character int not null,
primary key (ID_Class, ID_character),
foreign key (ID_Class) references Class(ID_Class),
foreign key (ID_character) references Character(ID_character)
);

create table Items
(
ID_Items int primary key identity(1,1),
Name nvarchar(50),
Description nvarchar(150)
);

create table Inventory
(
ID_character int not null,
ID_Items int not null,
primary key (ID_character, ID_Items),
foreign key (ID_character) references Character(ID_character),
foreign key (ID_Items) references Items(ID_Items)
);

Create table Quests
(
ID_Quests int primary key identity(1,1),
Name nvarchar(50),
Type nvarchar(50),
Status nvarchar(50),
Description nvarchar(150)
);

create table Journal
(
ID_quests int not null,
ID_character int not null,
primary key (ID_quests, ID_character),
foreign key (ID_quests) references Quests(ID_quests),
foreign key (ID_character) references Character(ID_character)
);

create table Statistic
(
ID_Statistic int primary key identity(1,1),
Description nvarchar (100),
Characteristic nvarchar(100),
);

create table Objects
(

)