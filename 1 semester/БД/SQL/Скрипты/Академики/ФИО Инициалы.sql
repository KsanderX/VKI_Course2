SELECT 
    LEFT(���, CHARINDEX(' ', ���) - 1) + ' ' + 
    LEFT(SUBSTRING(���, CHARINDEX(' ', ���) + 1, CHARINDEX(' ', ���, CHARINDEX(' ', ���) + 1) - CHARINDEX(' ', ���) - 1), 1) + '.' + 
    LEFT(SUBSTRING(���, LEN(���) - CHARINDEX(' ', REVERSE(���)) + 2, LEN(���)), 1) + '.' AS ���_��������
 
FROM 
    ���������;