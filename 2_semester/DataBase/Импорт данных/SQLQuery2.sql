Alter table [dbo].[Договор$]
add foreign key(Тур) references Тур(Номер),
foreign key(Клиент) references Клиент$(ID_Клиента)

Select * FROM [dbo].[Договор$]

Select * FROM Клиент$

Select * FROM [dbo].[Отель]

Select * FROM [dbo].[Тур]