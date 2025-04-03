SELECT Континент FROM Страны
GROUP BY Континент
HAVING MAX(Площадь) / MIN(Площадь) <= 10000