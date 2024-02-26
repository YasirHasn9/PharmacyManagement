CREATE TABLE Pharmacists
(
    PharmacistId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    PharmacyId   UNIQUEIDENTIFIER,
    Name         NVARCHAR(100),
    Age          INT,
    StartDate    DATE,
    EndDate      DATE,
    FOREIGN KEY (PharmacyId) REFERENCES Pharmacies (Id)
);


-- Insert  pharmacists for each pharmacy found in the Pharmacies table
-- Replace `PharmacyId` with the actual Guid of the Pharmacy
INSERT INTO Pharmacists (PharmacyId, Name, Age, StartDate, EndDate)
VALUES 
    ('ca966f56-6664-4980-8d21-08dc367b305e', 'John Doe', 35, '2023-01-10', '2023-12-31'),
    ('ca966f56-6664-4980-8d21-08dc367b305e', 'Jane Smith', 29, '2023-02-15', '2023-12-31'),

    ('230bef03-d8b7-478a-8d22-08dc367b305e', 'Emily Jones', 40, '2023-01-20', '2023-12-31'),
    ('230bef03-d8b7-478a-8d22-08dc367b305e', 'Chris Brown', 32, '2023-03-01', '2023-12-31'),

    ('d5f513ea-8084-43d4-8d23-08dc367b305e', 'David Wilson', 45, '2023-01-30', '2023-12-31'),
    ('d5f513ea-8084-43d4-8d23-08dc367b305e', 'Lisa Taylor', 37, '2023-02-20', '2023-12-31'),

    ('49696490-2d19-48c9-8d24-08dc367b305e', 'Michael Johnson', 41, '2023-02-10', '2023-12-31'),

    ('5019036f-1221-4b90-8d25-08dc367b305e', 'Angela White', 39, '2023-03-15', '2023-12-31'),
    ('5019036f-1221-4b90-8d25-08dc367b305e', 'Kevin Martin', 28, '2023-04-01', '2023-12-31');