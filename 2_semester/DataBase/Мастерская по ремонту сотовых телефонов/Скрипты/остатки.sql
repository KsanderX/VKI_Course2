CREATE TABLE �������� (
    ID_�������� INT IDENTITY(1,1) PRIMARY KEY,
    ID_������ INT NOT NULL
);

CREATE TABLE ����������_��������� (
    ID_�������� INT PRIMARY KEY,
    �������� VARCHAR(50) NOT NULL,
    ID_������ INT NOT NULL
);

CREATE TABLE ��������� (
    ID_��������� INT IDENTITY(1,1) PRIMARY KEY,
    ID_������ INT NOT NULL
);

CREATE TABLE ������ (
    ID_������ INT IDENTITY(1,1) PRIMARY KEY,
    �������� VARCHAR(50) NOT NULL,
    ��������� INT NOT NULL
);

CREATE TABLE ������_������ (
    ID_������� INT NOT NULL,
    ID_������ INT NOT NULL,
    PRIMARY KEY (ID_�������, ID_������)
);