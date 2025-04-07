-- ��� ��������
CREATE TABLE ���_�������� (
    ID_���� INT PRIMARY KEY IDENTITY(1,1),
    �������� VARCHAR(50)
);

-- ������
CREATE TABLE ������ (
    ID_������� INT PRIMARY KEY IDENTITY(1,1),
    ��� VARCHAR(100),
    ������� VARCHAR(20),
    Email VARCHAR(100)
);

-- ��������� ���������
CREATE TABLE ��������� (
    ID_���������� INT PRIMARY KEY IDENTITY(1,1),
    ��� VARCHAR(100),
    ��������� VARCHAR(50)
);

-- �������
CREATE TABLE ������� (
    ID_�������� INT PRIMARY KEY IDENTITY(1,1),
    ����_���������� DATE,
    FK_���_�������� INT FOREIGN KEY REFERENCES ���_��������(ID_����)
);

-- ������� �������� ����� �������
CREATE TABLE �������_�����_������� (
    ID_�������� INT PRIMARY KEY,
    FK_������� INT FOREIGN KEY REFERENCES ������(ID_�������),
    FK_���������� INT FOREIGN KEY REFERENCES ���������(ID_����������),
    FK_���_�������� INT FOREIGN KEY REFERENCES ���_��������(ID_����)
);

-- ������� �������� ����� �������
CREATE TABLE �������_�����_������� (
    ID_�������� INT PRIMARY KEY,
    FK_������� INT FOREIGN KEY REFERENCES ������(ID_�������),
    FK_���������� INT FOREIGN KEY REFERENCES ���������(ID_����������),
    FK_���_�������� INT FOREIGN KEY REFERENCES ���_��������(ID_����)
);

-- ������� �����-�������
CREATE TABLE �������_�����_������� (
    ID_�������� INT PRIMARY KEY,
    ����_���������� DATE,
    FK_������� INT FOREIGN KEY REFERENCES ������(ID_�������)   
);

-- �������� �������
CREATE TABLE �������� (
    ID_�������� INT PRIMARY KEY IDENTITY(1,1),
    �������� VARCHAR(100),
    �������� VARCHAR(100)   
);

-- ��������������
CREATE TABLE �������������� (
    ID_�������������� INT PRIMARY KEY IDENTITY(1,1),
    �������� VARCHAR(100),
	FK_�������� INT FOREIGN KEY REFERENCES ��������(ID_��������)
);

-- ������ ������������
CREATE TABLE ������_������������ (
    ID_������� INT PRIMARY KEY IDENTITY(1,1),
    ����� VARCHAR(150),
    ��� VARCHAR(50),
    ������� INT,
    FK_�������������� INT FOREIGN KEY REFERENCES ��������������(ID_��������������)
);

-- ����� �������������
CREATE TABLE �����_������������� (
    ID_����� INT PRIMARY KEY IDENTITY(1,1),
    FK_������� INT FOREIGN KEY REFERENCES ������(ID_�������),
    FK_������� INT FOREIGN KEY REFERENCES ������_������������(ID_�������),
    FK_��� INT FOREIGN KEY REFERENCES �������_�����_�������(ID_��������)
);

-- ������ �������
CREATE TABLE ������ (
    ID_������� INT PRIMARY KEY IDENTITY(1,1),
    ���� VARCHAR(100),
    ������ INT,
    FK_��������_�����_������� INT FOREIGN KEY REFERENCES �������_�����_�������(ID_��������)
);

-- ������ -> �������� �������
CREATE TABLE ������_�������� (
    ID INT PRIMARY KEY IDENTITY(1,1),
    FK_������� INT FOREIGN KEY REFERENCES ������(ID_�������),
    FK_�������� INT FOREIGN KEY REFERENCES ��������(ID_��������)
);
