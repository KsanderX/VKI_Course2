ALTER TABLE �����
ADD ����������_�����������_ID INT;

ALTER TABLE �����
ADD CONSTRAINT FK_�����_����������_�����������
FOREIGN KEY (����������_�����������_ID) REFERENCES ����������_�����������(����������_�����������_ID);