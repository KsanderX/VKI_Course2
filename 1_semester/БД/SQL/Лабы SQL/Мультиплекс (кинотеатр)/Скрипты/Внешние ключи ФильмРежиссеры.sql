ALTER TABLE ‘ильм–ежиссеры
ADD CONSTRAINT FK_‘ильм–ежиссеры_‘ильм
FOREIGN KEY (‘ильмID) REFERENCES ‘ильм(‘ильмID);

ALTER TABLE ‘ильм–ежиссеры
ADD CONSTRAINT FK_‘ильм–ежиссеры_–ежиссеры
FOREIGN KEY (–ежиссерID) REFERENCES –ежиссеры(–ежиссерID);