CREATE TABLE feed (
    postId INT IDENTITY(1,1) PRIMARY KEY,
    description VARCHAR(MAX), --Frihed til tekster længere end 255 tegn
    oprettelsesdato DATETIME2 NOT NULL, --Mere præcis date-info end datetime
    brugerId INT NOT NULL,
    CONSTRAINT FK_feed_Users FOREIGN KEY (brugerId) REFERENCES Users(Id)
);
