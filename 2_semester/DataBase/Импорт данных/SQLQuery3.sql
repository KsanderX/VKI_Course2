create table ������(
ID_������� int primary key,
��� nvarchar(200) not null,
������� float not null,
����� nvarchar(50) not null
);

create table ���(
ID_���� int primary key,
������������ nvarchar(200), 
�������� nvarchar(200),
���� decimal
);

create table �������(
ID_�������� int primary key identity(1,1),
����� int,
���� datetime,
���� float,
������ nvarchar(50),
FK_��� int references ���(ID_����),
FK_������ int references ������(ID_�������)
);

create table �����(
ID_����� int primary key,
��������_����� nvarchar(200),
������ float,
���_������� nvarchar(20)
);

