SELECT
���
,CASE
WHEN (YEAR(CAST(����_�������� AS DATE)) % 4 = 0 AND YEAR(CAST(����_��������

AS DATE)) % 100 <> 0) OR (YEAR(CAST(����_�������� AS DATE)) % 400 = 0)

THEN '��'
ELSE '���'
END AS ����������_���
FROM
���������