CREATE TABLE Deliveries
(
    DeliveryId  UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    WarehouseId  UNIQUEIDENTIFIER,
    PharmacyId   UNIQUEIDENTIFIER,
    DrugId       UNIQUEIDENTIFIER,
    UnitCount    INT,
    UnitPrice    DECIMAL(10, 2),
    TotalPrice AS (UnitCount * UnitPrice),
    DeliveryDate DATE,
    FOREIGN KEY (WarehouseId) REFERENCES Warehouses (WarehouseId),
    FOREIGN KEY (PharmacyId) REFERENCES Pharmacies (Id),
    FOREIGN KEY (DrugId) REFERENCES Drugs (DrugId)
);

-- fetch data from different tables and insert into Deliveries
SELECT TOP 1 WarehouseId FROM Warehouses;
SELECT TOP 1 Id FROM Pharmacies;
SELECT TOP 1 DrugId FROM Drugs;


-- insert data 
DECLARE @Count INT = 0;

WHILE @Count < 20
BEGIN
INSERT INTO Deliveries (WarehouseId, PharmacyId, DrugId, UnitCount, UnitPrice, DeliveryDate)
VALUES
    (
        '87246a4b-3c58-4613-b9d4-85a875ce4690', -- WarehouseId
        'ca966f56-6664-4980-8d21-08dc367b305e', -- PharmacyId
        'ecbecb64-a48d-4df5-bb6f-0d0fc73a342c', -- DrugId
        ROUND((RAND() * (100-20)+20), 0), 
        ROUND((RAND() * (50-5)+5), 2), 
        DATEADD(day, @Count * 2, '2023-01-01')
    );

SET @Count = @Count + 1;
END