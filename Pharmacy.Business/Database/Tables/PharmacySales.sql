CREATE TABLE PharmacySales
(
    SaleId       UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    PharmacyId   UNIQUEIDENTIFIER,
    PharmacistId UNIQUEIDENTIFIER,
    DrugID       UNIQUEIDENTIFIER,
    UnitCount    INT,
    UnitPrice    DECIMAL(10, 2),
    SaleDate     DATE,
    FOREIGN KEY (PharmacyId) REFERENCES Pharmacies (Id),
    FOREIGN KEY (PharmacistId) REFERENCES Pharmacists (PharmacistId),
    FOREIGN KEY (DrugId) REFERENCES Drugs (DrugId)
);


-- fetch data from different tables and insert into PharmacySales
SELECT TOP 1 Id FROM Pharmacies;
SELECT TOP 1 PharmacistId FROM Pharmacists;
SELECT TOP 1 DrugId FROM Drugs;


INSERT INTO PharmacySales (PharmacyId, PharmacistId, DrugId, UnitCount, UnitPrice, SaleDate)
VALUES --  ('{PharmacyId}', '{PharmacistId}', '{DrugId}', {UnitCount}, {UnitPrice}, {SaleDate}),
    ('230bef03-d8b7-478a-8d22-08dc367b305e', 'e097b79a-1d1c-4a35-9f65-ec9d13fc9705', 'd4d5f91e-45ae-49f2-850f-e7778fdbcb8b', 10, 5.00, '2023-01-15'),
    ('ca966f56-6664-4980-8d21-08dc367b305e', '5afa1f97-a82b-4d89-acb5-4eb3396ac3c4', '8978bd76-5948-4ac1-b9df-a04270249423', 20, 10.00, '2023-01-20'),
    ('5019036f-1221-4b90-8d25-08dc367b305e', '76e3b5fe-59cc-43aa-871c-4db0482d0e60', '576c5247-29ae-4704-97bb-99b9ab3df74c}', 15, 8.50, '2023-02-05'),
    ('d5f513ea-8084-43d4-8d23-08dc367b305e', 'a5ed67e3-0642-4cea-bb93-f3cdc3cdf79b', '8046e49f-6323-41e2-9fd6-b7219386058a', 5, 12.00, '2023-02-10');
