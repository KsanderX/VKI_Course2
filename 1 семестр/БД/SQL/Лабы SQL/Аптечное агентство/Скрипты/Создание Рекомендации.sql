CREATE TABLE ������������ (
    ID_������������ INT PRIMARY KEY IDENTITY(1,1),
    ID_������������ INT FOREIGN KEY REFERENCES ������������(ID_������������),
    ID_A�����_�������������_��������� INT FOREIGN KEY REFERENCES ������_���������(ID_������_�������������_���������),
    ���������� INT DEFAULT 1,
    ���������� NVARCHAR(255) NULL);