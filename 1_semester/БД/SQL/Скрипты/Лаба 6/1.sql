SELECT 
    �������.���_�����,
    �������.�������,
    �������������.����� AS �������������,
    �������.�������� AS �������
FROM 
    �������
JOIN 
    ������������� ON �������.����� = �������������.�����
JOIN 
    ������� ON �������������.���� = �������.����
WHERE 
    �������.��������� = '��';