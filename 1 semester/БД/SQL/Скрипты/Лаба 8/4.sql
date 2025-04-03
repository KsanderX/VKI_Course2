SELECT COUNT(*) AS Количество_Стран
FROM Страны
WHERE Название LIKE '%ан' AND Название NOT LIKE '%стан';