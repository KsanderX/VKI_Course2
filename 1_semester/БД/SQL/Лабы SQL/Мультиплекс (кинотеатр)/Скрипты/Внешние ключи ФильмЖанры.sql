ALTER TABLE ‘ильм∆анры
ADD CONSTRAINT FK_‘ильм∆анры_‘ильм
FOREIGN KEY (‘ильмID) REFERENCES ‘ильм(‘ильмID);

ALTER TABLE ‘ильм∆анры
ADD CONSTRAINT FK_‘ильм∆анры_∆анры
FOREIGN KEY (∆анрID) REFERENCES ∆анры(∆анрID);