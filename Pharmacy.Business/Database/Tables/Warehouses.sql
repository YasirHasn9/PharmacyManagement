CREATE TABLE Warehouses
(
    WarehouseId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Name        NVARCHAR(100),
    Address     NVARCHAR(255)
);

-- Insert warehouses
INSERT INTO Warehouses (Name, Address)
VALUES
    ('Dallas Alpha', '123 Alpha StDallas Alpha, Dallas, State A, 10001'),
    ('Plano Beta', '456 Plano Beta, City B, Plano, 20002'),
    ('Frisco Gamma', '789 Frisco Gamma, Frisco, State C, 30003');
