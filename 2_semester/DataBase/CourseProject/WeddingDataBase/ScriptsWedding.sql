create table Client(
Id_Client int primary key identity(1,1),
First_Name varchar(50),
Last_Name varchar(50),
);

Create table Contract(
Id_Contract int primary key identity(1,1),
)

Create table Agency_Employee(
Id_Agency_Employee int primary key identity(1,1),
)

Create table Position(
Id_Position int primary key identity(1,1),
)

Create table Location(
Id_Location int primary key identity(1,1),
)

Create table Menu(
Id_Menu int primary key identity(1,1),
)

Create table Freelance_Employee(
Id_Freelance_Employee int primary key identity(1,1),
)

Create table Catering(
Id_Catering int primary key identity(1,1),
)

Create table Catering_Employee (
Id  int primary key identity(1,1),
)

Create table Decoration (
Id_Decoration  int primary key identity(1,1),
)

Create table Wedding_Freelance_Employee (
Id int primary key identity(1,1),
)

Create table Wedding_Agency_Employee (
Id int primary key identity(1,1),
)

Create table Position_Freelance_Employees (
Id_Position_Freelance_Employees  int primary key identity(1,1),
)

Create table Menu_Catering(
Id_Menu_Catering int primary key identity(1,1),
)

Create table Design_Location(
Id_Design_Location int primary key identity(1,1)
)

Create table Booking_Location(
Id_Booking_Location int primary key identity(1,1)
)

Alter table Contract
add FK_Client int foreign key references Client(Id_Client)

Alter table Wedding_Agency_Employee
add FK_Contract int,
FK_Agency_Employee int
foreign key(FK_Contract) references Contract(Id_Contract),
foreign key(FK_Agency_Employee) references Agency_Employee(Id_Agency_Employee)

Alter table Agency_Employee
add FK_Position int foreign key references Position(Id_Position)

Alter table Wedding_Freelance_Employee
add FK_Contract int,
FK_Freelance_Employee int
foreign key(FK_Contract) references Contract(Id_Contract),
foreign key(FK_Freelance_Employee) references Freelance_Employee(Id_Freelance_Employee)

Alter table Freelance_Employee
add FK_Position int
foreign key(FK_Position) references Position_Freelance_Employees(Id_Position_Freelance_Employees)

Alter table Freelance_Employee
add FK_Design_Location int
foreign key(FK_Design_Location) references Design_Location(Id_Design_Location)

Alter table Booking_Location
add FK_Contract int,
FK_Location int
foreign key(FK_Contract) references Contract(Id_Contract),
foreign key(FK_Location) references Location(Id_Location)

Alter table Design_Location
add FK_Location int
foreign key(FK_Location) references Location(Id_Location)

Alter table Decoration
add FK_Design_Location int
foreign key(FK_Design_Location) references Design_Location(Id_Design_Location)

Alter table Catering_Employee
add FK_Catering int,
FK_Freelance_Employee int
foreign key(FK_Catering) references Catering(Id_Catering),
foreign key(FK_Freelance_Employee) references Freelance_Employee(Id_Freelance_Employee)

Alter table Catering
add FK_Contract int
foreign key(FK_Contract) references Contract(Id_Contract)

Alter table Menu_Catering
add FK_Menu int,
FK_Catering int
foreign key(FK_Menu) references Menu(Id_Menu),
foreign key(FK_Catering) references Catering(Id_Catering)

-----------------------------------------------------------------few

-- CLIENT
ALTER TABLE Client
ADD
    PhoneNumber VARCHAR(20),
    Email VARCHAR(100),
    PassportData VARCHAR(100); -- по договору

-- CONTRACT
ALTER TABLE Contract
ADD
    ContractDate DATE,
    WeddingDate DATE,
    WeddingTime TIME,
    TotalBudget INT,
    PrepaymentAmount INT,
    Description VARCHAR(500);

-- AGENCY_EMPLOYEE
ALTER TABLE Agency_Employee
ADD
    First_Name VARCHAR(50),
    Last_Name VARCHAR(50),
    PhoneNumber VARCHAR(20),
    Email VARCHAR(100);

-- POSITION
ALTER TABLE Position
ADD
    Title VARCHAR(100),
    Responsibilities VARCHAR(500);

-- LOCATION
ALTER TABLE Location
ADD
    Name VARCHAR(100),
    Address VARCHAR(200),
    Capacity INT,
    HasParking BIT,
    IsOutdoor BIT;

-- MENU
ALTER TABLE Menu
ADD
    Name VARCHAR(100),
    Type VARCHAR(50), -- банкет, фуршет, веган и т.п.
    Description VARCHAR(500);

-- FREELANCE_EMPLOYEE
ALTER TABLE Freelance_Employee
ADD
    First_Name VARCHAR(50),
    Last_Name VARCHAR(50),
    PhoneNumber VARCHAR(20),
    Email VARCHAR(100);

-- CATERING
ALTER TABLE Catering
ADD
    CompanyName VARCHAR(100),
    ContactPerson VARCHAR(100),
    PhoneNumber VARCHAR(20);

-- CATERING_EMPLOYEE
ALTER TABLE Catering_Employee
ADD
    First_Name VARCHAR(50),
    Last_Name VARCHAR(50),
    Role VARCHAR(50); -- повар, официант и т.п.

-- DECORATION
ALTER TABLE Decoration
ADD
    Name VARCHAR(100),
    Type VARCHAR(50), -- арка, фотозона и т.д.
    Material VARCHAR(100),
    ColorTheme VARCHAR(100);

-- WEDDING_FREELANCE_EMPLOYEE
ALTER TABLE Wedding_Freelance_Employee
ADD
    RoleDescription VARCHAR(200);

-- WEDDING_AGENCY_EMPLOYEE
ALTER TABLE Wedding_Agency_Employee
ADD
    RoleDescription VARCHAR(200);

-- POSITION_FREELANCE_EMPLOYEES
ALTER TABLE Position_Freelance_Employees
ADD
    Title VARCHAR(100),
    Responsibilities VARCHAR(500);

-- MENU_CATERING
ALTER TABLE Menu_Catering
ADD
    PortionSize VARCHAR(50),
    CostPerPerson INT;

-- DESIGN_LOCATION
ALTER TABLE Design_Location
ADD
    Style VARCHAR(100),
    ColorScheme VARCHAR(100),
    Notes VARCHAR(300);

-- BOOKING_LOCATION
ALTER TABLE Booking_Location
ADD
    BookingDate DATE,
    TimeFrom TIME,
    TimeTo TIME,
    TotalCost INT;
