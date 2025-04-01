SELECT DISTINCT
    Специализация,
    CASE 
        WHEN LEN(Специализация) > 10
		THEN 'длинный'
        ELSE 'короткий'
    END AS Длина
FROM Академики;