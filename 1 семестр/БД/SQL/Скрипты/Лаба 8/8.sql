SELECT LEN(Название) AS Количество_букв,
COUNT(*) AS Количество_стран
FROM Страны
GROUP BY LEN(Название) ORDER BY Количество_стран DESC;




