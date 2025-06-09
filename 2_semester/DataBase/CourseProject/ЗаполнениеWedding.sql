INSERT INTO Client (First_Name, Last_Name, PhoneNumber, Email, PassportData)
VALUES 
('Иван', 'Петров', '+79991234567', 'ivan.petrov@mail.ru', '1234 567890'),
('Мария', 'Сидорова', '+79999887766', 'maria.sid@mail.ru', '4321 098765');

INSERT INTO Position (Title, Responsibilities)
VALUES
('Координатор', 'Организация мероприятия и взаимодействие с клиентом'),
('Юрист', 'Заключение договоров и юридическое сопровождение');

INSERT INTO Agency_Employee (First_Name, Last_Name, PhoneNumber, Email, FK_Position)
VALUES
('Анна', 'Смирнова', '+79991112233', 'anna.smirnova@agency.ru', 1),
('Олег', 'Николаев', '+79995556677', 'oleg.nikolaev@agency.ru', 2);

INSERT INTO Contract (FK_Client, ContractDate, WeddingDate, WeddingTime, TotalBudget, PrepaymentAmount, Description)
VALUES
(1, '2025-05-01', '2025-08-15', '16:00:00', 1500000, 500000, 'Полная организация свадьбы в шатре с кейтерингом и декором'),
(2, '2025-06-05', '2025-09-10', '15:00:00', 2000000, 800000, 'Свадьба в ресторане с шоу-программой');

INSERT INTO Location (Name, Address, Capacity, HasParking, IsOutdoor)
VALUES
('Загородный клуб "Лесной"', 'Новосибирская обл., с. Краснообск, д. 25', 100, 1, 1),
('Ресторан "Версаль"', 'г. Новосибирск, ул. Ленина, 18', 80, 1, 0);

INSERT INTO Booking_Location (FK_Contract, FK_Location, BookingDate, TimeFrom, TimeTo, TotalCost)
VALUES
(1, 1, '2025-07-01', '15:00:00', '23:00:00', 250000),
(2, 2, '2025-08-01', '14:00:00', '22:00:00', 300000);

INSERT INTO Position_Freelance_Employees (Title, Responsibilities)
VALUES
('Флорист', 'Цветочное оформление мероприятий'),
('Фотограф', 'Проведение фото- и видеосъёмки');

INSERT INTO Freelance_Employee (First_Name, Last_Name, PhoneNumber, Email, FK_Position)
VALUES
('Светлана', 'Лилиянова', '+79991110000', 'sveta.florist@mail.ru', 1),
('Дмитрий', 'Орлов', '+79992220000', 'dima.photo@mail.ru', 2);

INSERT INTO Wedding_Freelance_Employee (FK_Contract, FK_Freelance_Employee, RoleDescription)
VALUES
(1, 1, 'Флорист для оформления зоны церемонии'),
(2, 2, 'Фотограф на свадьбу');

INSERT INTO Menu (Name, Type, Description)
VALUES
('Банкет европейский', 'Банкет', 'Горячее, салаты, десерты'),
('Фуршет лёгкий', 'Фуршет', 'Закуски, мини-бургеры, напитки');

INSERT INTO Catering (CompanyName, ContactPerson, PhoneNumber, FK_Contract)
VALUES
('Gourmet Food', 'Елена Васильева', '+79993334455', 1);

INSERT INTO Menu_Catering (FK_Menu, FK_Catering, PortionSize, CostPerPerson)
VALUES
(1, 1, 'Полная порция', 3500),
(2, 1, 'Мини-порция', 2000);

INSERT INTO Design_Location (FK_Location, Style, ColorScheme, Notes)
VALUES
(1, 'Бохо', 'Бежевый, белый, зелёный', 'Природные мотивы, минимализм');

INSERT INTO Decoration (FK_Design_Location, Name, Type, Material, ColorTheme)
VALUES
(1, 'Арка для регистрации', 'Арка', 'Дерево, ткань', 'Бежевый, белый');
