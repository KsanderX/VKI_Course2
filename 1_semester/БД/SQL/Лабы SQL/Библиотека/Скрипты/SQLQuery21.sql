

ALTER TABLE ���������
ADD FK����������_����� INT,
FOREIGN KEY(FK����������_�����) REFERENCES ����������_�����(ID_����������);

ALTER TABLE ���������
ADD FK�������� INT,
FOREIGN KEY(FK��������) REFERENCES ��������(ID_��������);


ALTER TABLE ����������_�����
ADD FK����� INT,
FOREIGN KEY(FK�����) REFERENCES �����(ID_�����);

ALTER TABLE ����������_�����
ADD FK����� INT,
FOREIGN KEY(FK�����) REFERENCES �����(ID_�����);

ALTER TABLE ����������_�����
ADD FK������ INT,
FOREIGN KEY(FK������) REFERENCES ������(ID_������);

ALTER TABLE ������_�����
ADD FK����� INT,
FOREIGN KEY(FK�����) REFERENCES �����(ID_�����);

ALTER TABLE ������_�����
ADD FK������ INT,
FOREIGN KEY(FK������) REFERENCES ������(ID_������);

ALTER TABLE �����_�����
ADD FK����� INT,
FOREIGN KEY(FK�����) REFERENCES �����(ID_�����);

ALTER TABLE �����_�����
ADD FK����� INT,
FOREIGN KEY(FK�����) REFERENCES �����(ID_�����);

ALTER TABLE ������������_�����
ADD FK����� INT,
FOREIGN KEY(FK�����) REFERENCES �����(ID_�����);

ALTER TABLE ������������_�����
ADD FK������������ INT,
FOREIGN KEY(FK������������) REFERENCES ������������(ID_������������);

ALTER TABLE ������
ADD FK������ INT,
FOREIGN KEY(FK������) REFERENCES �����(ID_�����);

ALTER TABLE �����
ADD FK���� INT,
FOREIGN KEY(FK����) REFERENCES ����(ID_����);

ALTER TABLE ����
ADD FK������ INT,
FOREIGN KEY(FK������) REFERENCES ������(ID_������);

ALTER TABLE ������
ADD FK������� INT,
FOREIGN KEY(FK�������) REFERENCES �������(ID_�������);
