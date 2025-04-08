
create table Players(
ID_Player int primary key identity(1,1),
Login nvarchar(20) not null,
Password nvarchar(20) not null,
IP nvarchar(20),
Email nvarchar(20),
)

create table Characters (
ID int primary key identity(1,1),
Nickname nvarchar(50),
Level int,
Origin nvarchar(30),
Sex nvarchar(10),
ID_Player int foreign key references Players(ID_Player)
)

create table  Class(
ID int primary key identity(1,1),
Title nvarchar(50),
Discription nvarchar(100)
);

create table Enemy(
ID int primary key identity(1,1),
Features nvarchar(100),
Level int not null
)

create table List(
ID_class int,
ID_character int,
primary key (ID_class, ID_character),
foreign key (ID_class) references Class(ID),
foreign key (ID_character) references Characters(ID)
);

create table Locations(
ID int primary key identity(1,1),
Level int,
Discription nvarchar(200),
Biom nvarchar(20),
);

Create table PositionEnemy(
ID_enemy int,
ID_location int,
primary key (ID_enemy, ID_location),
foreign key (ID_enemy) references Enemy(ID),
foreign key (ID_location) references Locations(ID)
);

create table PositionCharacter(
ID_location int,
ID_character int,
primary key (ID_location, ID_character),
foreign key (ID_location) references Locations(ID),
foreign key (ID_character) references Characters(ID)
);

