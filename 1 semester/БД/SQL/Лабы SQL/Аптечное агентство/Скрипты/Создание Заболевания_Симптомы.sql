CREATE TABLE �����������_�������� (
    ID_�����������_�������� INT PRIMARY KEY IDENTITY(1,1),
    ID_����������� INT FOREIGN KEY REFERENCES �����������(ID_�����������),
    ID_�������� INT FOREIGN KEY REFERENCES ��������(ID_��������));