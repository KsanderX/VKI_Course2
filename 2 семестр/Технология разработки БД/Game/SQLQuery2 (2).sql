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

