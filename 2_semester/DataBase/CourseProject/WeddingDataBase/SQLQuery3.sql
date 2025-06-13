Alter table Agency_Employee
add Login nvarchar(20),
Password nvarchar(20)

INSERT INTO Agency_Employee (First_Name, Last_Name, PhoneNumber, Email, Login, Password, FK_Position)
VALUES 
('Анна', 'Смирнова', '+79991112233', 'anna@agency.ru', 'anna', '12345', 1),
('Олег', 'Николаев', '+79995556677', 'oleg@agency.ru', 'oleg', 'qwerty', 2);