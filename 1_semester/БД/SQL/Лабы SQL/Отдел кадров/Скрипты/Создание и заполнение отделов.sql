CREATE TABLE ������ (
    ID_������ INT PRIMARY KEY IDENTITY(1,1),
    ��������_������ NVARCHAR(100) NOT NULL,
    �����_������ NVARCHAR(255),
    ������������_������ NVARCHAR(100),
    �������_������ VARCHAR(20));


INSERT INTO ������ (��������_������, �����_������, ������������_������, �������_������)
VALUES
('IT', '��. �������, �. 10', '������ ���� ��������', '+74951234567'),
('���������', '��. ������, �. 5', '������� ����� ���������', '+74959876543'),
('�������', '��. ���������, �. 20', '������� ������� ��������', '+74951112233'),
('HR', '��. ������, �. 15', '��������� ���� ��������', '+74954445566');



SELECT * FROM ������;
