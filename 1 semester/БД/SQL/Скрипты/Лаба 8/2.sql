SELECT TOP 1 Название
FROM Страны
WHERE Континент IN ('Северная Америка', 'Южная Америка')
ORDER BY Население DESC;