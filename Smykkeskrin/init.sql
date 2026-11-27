CREATE TABLE Users (
                       Id INT IDENTITY(1,1) PRIMARY KEY, -- IDENTITY(1,1) betyder autoincrement (id 1, 2, 3...)
                       FirstName NVARCHAR(100) NOT NULL,
                       LastName NVARCHAR(100) NOT NULL,
                       Username NVARCHAR(50) NOT NULL UNIQUE,
                       Password NVARCHAR(255) NOT NULL,
                       Email NVARCHAR(150) NOT NULL,
                       PhoneNumber NVARCHAR(20),
                       UserRole INT NOT NULL -- Vi gemmer jeres Enum (Vip, Admin, Bruger) som et tal
);
CREATE TABLE Jewlery (
                         Jewleryid INT IDENTITY(1,1) PRIMARY KEY,
                         Name NVARCHAR(100) NOT NULL,
                         Material NVARCHAR(50) NOT NULL,
                         Brand NVARCHAR(100) NOT NULL,
                         Price FLOAT NOT NULL,          
                         IsActive BIT NOT NULL DEFAULT 1, -- Matcher C# bool (1 = true, 0 = false)
                         ImgPth NVARCHAR(255), 
                         Type INT NOT NULL                
);
GO
CREATE TABLE UserJewlery (
                             UserId INT NOT NULL FOREIGN KEY REFERENCES Users(Id) ON DELETE CASCADE,
                             Jewleryid INT NOT NULL FOREIGN KEY REFERENCES Jewlery(Jewleryid) ON DELETE CASCADE,
                             PRIMARY KEY (UserId, Jewleryid)
);
GO

INSERT INTO Users (FirstName, LastName, Username, Password, Email, PhoneNumber, UserRole)
VALUES
    ('Anders', 'Møller', 'admin_anders', 'Admin1234!', 'anders@smykkeskrin.dk', '11223344', 1),
    ('Freja', 'Lindqvist', 'freja_design', 'Vip1234!', 'freja@guldsmed.dk', '22334455', 0),
    ('Kasper', 'Vestergaard', 'kasper_guld', 'Vip1234!', 'kasper@smykkekunst.dk', '33445566', 0),
    ('Sofie', 'Hansen', 'sofie_h', 'Bruger1234!', 'sofie@mail.dk', '44556677', 2),
    ('Emma', 'Nielsen', 'emma_n', 'Bruger1234!', 'emma@mail.dk', NULL, 2);

GO

INSERT INTO Jewlery ( Name, Material, Brand, Price, IsActive, ImgPth, Type)
VALUES
    (N'Glat Guld Ring', N'Guld', N'Nordic Atelier', 1299.00, 1, N'/images/ring1.png', 1),
    (N'Snoet Guld Ring', N'Guld', N'Nordic Atelier', 999.00, 1, N'/images/ring2.png', 1),
    (N'Klassisk Sølv Ring', N'Sølv', N'Kyst & Form', 749.00, 1, N'/images/ring3.png', 1),
    (N'Hamret Bred Sølv Ring', N'Sølv', N'Kyst & Form', 1149.00, 1, N'/images/ring4.png', 1),
    (N'Minimalistisk Ring med Sten', N'Guld', N'Lumen Jewelry', 1499.00, 1, N'/images/ring5.png', 1),
    (N'Børstet Sølv Ring', N'Sølv', N'Kyst & Form', 849.00, 1, N'/images/ring6.png', 1),
    (N'Tynd Guld Ring', N'Guld', N'Nordic Atelier', 699.00, 1, N'/images/ring7.png', 1),
    (N'Signetring i Sølv', N'Sølv', N'Lumen Jewelry', 1399.00, 1, N'/images/ring8.png', 1);

GO