CREATE TABLE Feedpostsmykke (
    postId INT NOT NULL,
    Jewleryid INT NOT NULL,
    
    -- Samlet PK, så det samme smykke ikke kan linkes dobbelt til det samme opslag
    PRIMARY KEY (postId, Jewleryid),
    
    -- Fremmednøgle der peger på feed-tabel
    CONSTRAINT FK_Feedpostsmykke_Feed FOREIGN KEY (postId) REFERENCES feed(postId),
    
    -- Fremmednøgle der peger på Jewlery-tabellen 
    CONSTRAINT FK_Feedpostsmykke_Jewlery FOREIGN KEY (Jewleryid) REFERENCES Jewlery(Jewleryid)
);
