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
                         PictureSti NVARCHAR(255), 
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
    ('Emma', 'Nielsen', 'emma_n', 'Bruger1234!', 'emma@mail.dk', NULL, 2),
    ('Oliver', 'Møller', 'oliver_style', 'HypeKing99#', 'oliver@mollerstyle.dk', '30987654', 0),
    ('Iben', 'Vang', 'vang_guld', 'GoldSmith2026$', 'iben@vangguld.dk', '40112233', 0),
    ('Cecilie', 'Holm', 'holm_jewels', 'CecilieHolm*88', 'cecilie@holmjewels.dk', '50667788', 0),
    ('Clara', 'Jensen', 'clara_sparkle', 'SparkleClara!1', 'clara@clarajensen.dk', '60554433', 0),
    ('Hannah', 'Bruun', 'bruun_haandvaerk', 'HannahBruun#2', 'hannah@bruunguld.dk', '70889900', 0);
GO