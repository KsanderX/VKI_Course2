SELECT ���������, 
AVG(CAST(��������� AS FLOAT) / �������) AS ���������
FROM ������
WHERE
��������� > 1000000
GROUP BY ���������
HAVING
AVG(CAST(��������� AS FLOAT) / �������) > 30
ORDER BY ��������� DESC