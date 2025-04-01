SELECT 
    LEFT(ิศฮ, CHARINDEX(' ', ิศฮ) - 1) + ' ' + 
    LEFT(SUBSTRING(ิศฮ, CHARINDEX(' ', ิศฮ) + 1, CHARINDEX(' ', ิศฮ, CHARINDEX(' ', ิศฮ) + 1) - CHARINDEX(' ', ิศฮ) - 1), 1) + '.' + 
    LEFT(SUBSTRING(ิศฮ, LEN(ิศฮ) - CHARINDEX(' ', REVERSE(ิศฮ)) + 2, LEN(ิศฮ)), 1) + '.' AS ิศฮ_ศํ่๖่เ๋๛
 
FROM 
    ภ๊เไๅ์่๊่;