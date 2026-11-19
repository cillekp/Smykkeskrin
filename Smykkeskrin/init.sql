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
