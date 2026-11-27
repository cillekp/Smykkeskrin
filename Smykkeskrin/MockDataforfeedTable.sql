-- Mock data i feed-tabellen
-- OPRET BRUGER MED SAMME ID FØRST
INSERT INTO feed (description, oprettelsesdato, brugerId) VALUES
('Nyeste kollektion af håndlavede 18k guldringe er netop landet i værkstedet. Hvad synes I om detaljerne?', DATEADD(day, -5, GETDATE()), 2),
('Sneak peek på næste måneds store samarbejde med en af Danmarks største mode-influencere. Gør jer klar!', DATEADD(day, -4, GETDATE()), 3),
('Elsker processen med at forme det rå sølv om til fine, organiske former. Her er en lille smagsprøve på en ny halskæde.', DATEADD(day, -3, GETDATE()), 6),
('Husk at deltage i vores store konkurrence på Instagram, hvor du kan vinde dit yndlingssmykke fra det digitale skrin!', DATEADD(day, -3, GETDATE()), 7),
('Testing af ædelstene til et kommendeUnika-design. Safir eller smaragd? Hvad ville I vælge til et vedhæng?', DATEADD(day, -2, GETDATE()), 8),
('Behind the scenes fra gårsdagens photoshoot med de nye øreringe. Solen skinnede perfekt på diamanterne!', DATEADD(day, -1, GETDATE()), 9),
('Så blev den første prototype færdigpoleret og klar til godkendelse. Det her design har taget uger at perfektionere.', GETDATE(), 10);