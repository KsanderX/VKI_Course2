CREATE TABLE ������������ (
    ID_������������ INT PRIMARY KEY IDENTITY(1,1),
    FK_�������� INT FOREIGN KEY REFERENCES ���������(ID_���������),
    FK_������ INT FOREIGN KEY REFERENCES �������(ID_�������),
    FK_������ INT FOREIGN KEY REFERENCES ������(ID_������),
    ����_������������ DATETIME DEFAULT GETDATE(),
    ���������� NVARCHAR(255) NULL);