SELECT
ФИО
,CASE
WHEN (YEAR(CAST(Дата_рождения AS DATE)) % 4 = 0 AND YEAR(CAST(Дата_рождения

AS DATE)) % 100 <> 0) OR (YEAR(CAST(Дата_рождения AS DATE)) % 400 = 0)

THEN 'да'
ELSE 'нет'
END AS Високосный_год
FROM
Академики