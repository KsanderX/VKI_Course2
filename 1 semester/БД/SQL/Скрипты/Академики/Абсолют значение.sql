DECLARE @result FLOAT;

SET @result = POWER(SIN(PI() / 2), 2) - COS(3 * PI() / 2);
SELECT ABS(@result) AS Абсолютное_значение;