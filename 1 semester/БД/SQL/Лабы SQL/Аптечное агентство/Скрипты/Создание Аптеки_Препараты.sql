CREATE TABLE ������_��������� (
	ID_������_�������������_��������� INT PRIMARY KEY IDENTITY(1,1),
    ID_A����� INT FOREIGN KEY REFERENCES ������(ID_������),
    ID_��������� INT FOREIGN KEY REFERENCES �������������_���������(ID_���������),
    ���������� INT DEFAULT 0);
    