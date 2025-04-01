CREATE TABLE Цветы_Aganichev (
    ID INT PRIMARY KEY, -- Основной ключ
    Название VARCHAR(255) NOT NULL,
    Цвет VARCHAR(255) NOT NULL,
    Класс VARCHAR(255) DEFAULT 'Двудольные' -- Значение по умолчанию
);