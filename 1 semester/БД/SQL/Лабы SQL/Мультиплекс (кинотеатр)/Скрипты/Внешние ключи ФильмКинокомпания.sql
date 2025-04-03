ALTER TABLE ФильмКинокомпания
ADD CONSTRAINT FK_ФильмКинокомпания_Фильм
FOREIGN KEY (ФильмID) REFERENCES Фильм(ФильмID);

ALTER TABLE ФильмКинокомпания
ADD CONSTRAINT FK_ФильмКинокомпания_Кинокомпания
FOREIGN KEY (КинокомпанияID) REFERENCES Кинокомпания(КинокомпанияID);