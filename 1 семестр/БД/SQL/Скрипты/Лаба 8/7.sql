SELECT Континент, COUNT (Название) AS Количество_Стран
FROM Страны
WHERE Население > 100000000
GROUP BY Континент
ORDER BY Количество_Стран DESC