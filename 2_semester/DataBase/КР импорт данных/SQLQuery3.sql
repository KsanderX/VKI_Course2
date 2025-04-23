Alter table Books
add foreign key (fk_GenreID) references Genres(Id);

alter table Loans 
add foreign key (fk_UserID) references Users(UsersId),
foreign key(fk_BookID) references Books(ID);

alter table Authors_Books
add foreign key(fk_AuthorID) references Authors(AuthorID),
foreign key(fk_BookID) references Books(ID);