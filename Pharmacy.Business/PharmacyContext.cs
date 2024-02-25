using Microsoft.EntityFrameworkCore;

namespace Pharmacy.Business;
public class PharmacyContext : DbContext
{
    public PharmacyContext(DbContextOptions<PharmacyContext> options) : base(options) { }
    
    public DbSet<Pharmacy> Pharmacies { get; set; } = null!;
    
    public DbSet<Pharmacist> Pharmacists { get; set; }
}

/*
```sql
-- Table 1: Pharmacists
CREATE TABLE Pharmacists
(
    PharmacistID INT PRIMARY KEY,
    PharmacyID INT,
    Name NVARCHAR(50),
    Age INT,
    StartDate DATE,
    EndDate DATE,
    FOREIGN KEY (PharmacyID) REFERENCES Pharmacies(PharmacyID)
);

-- Table 2: Warehouses
CREATE TABLE Warehouses
(
    WarehouseID INT PRIMARY KEY,
    Name NVARCHAR(50),
    Address NVARCHAR(100)
);

-- Table 3: Drug
CREATE TABLE Drugs
(
    DrugID INT PRIMARY KEY,
    Name NVARCHAR(50),
    Description NVARCHAR(255)
);

-- Table 4: Deliveries
CREATE TABLE Deliveries
(
    DeliveryID INT PRIMARY KEY,
    WarehouseID INT,
    PharmacyID INT,
    DrugID INT,
    UnitCount INT,
    UnitPrice DECIMAL(10, 2),
    TotalPrice AS (UnitCount * UnitPrice),
    DeliveryDate DATE,
    FOREIGN KEY (WarehouseID) REFERENCES Warehouses(WarehouseID),
    FOREIGN KEY (PharmacyID) REFERENCES Pharmacies(PharmacyID),
    FOREIGN KEY (DrugID) REFERENCES Drugs(DrugID)
);

-- Table 5: PharmacySales
CREATE TABLE PharmacySales
(
    SaleID INT PRIMARY KEY,
    PharmacyID INT,
    PharmacistID INT,
    DrugID INT,
    UnitCount INT,
    UnitPrice DECIMAL(10, 2),
    SaleDate DATE,
    FOREIGN KEY (PharmacyID) REFERENCES Pharmacies(PharmacyID),
    FOREIGN KEY (PharmacistID) REFERENCES Pharmacists(PharmacistID),
    FOREIGN KEY (DrugID) REFERENCES Drugs(DrugID)
);
```

Now, let's create the reports:

```sql
-- Report 1: Delivery Detail
SELECT 
    W.Name AS 'Warehouse From',
    P.Name AS 'Pharmacy To',
    D.DeliveryDate,
    D.UnitCount,
    D.UnitPrice,
    D.TotalPrice
FROM Deliveries D
INNER JOIN Warehouses W ON D.WarehouseID = W.WarehouseID
INNER JOIN Pharmacies P ON D.PharmacyID = P.PharmacyID;

-- Report 2: Warehouse Profit
SELECT 
    W.Name AS 'Warehouse',
    SUM(D.UnitCount) AS 'Total Unit Count',
    SUM(D.TotalPrice) AS 'Total Revenue',
    AVG(D.TotalPrice / D.UnitCount) AS 'Average Profit'
FROM Deliveries D
INNER JOIN Warehouses W ON D.WarehouseID = W.WarehouseID
GROUP BY W.Name
ORDER BY 'Total Revenue' DESC;

-- Report 3: Pharmacist Production
SELECT 
    Ph.Name AS 'Pharmacist',
    P.Name AS 'Pharmacy',
    D.Name AS 'Drug',
    SUM(PS.UnitCount) AS 'Total Unit Count',
    RANK() OVER (ORDER BY SUM(PS.UnitCount * PS.UnitPrice) DESC) AS 'Rank'
FROM PharmacySales PS
INNER JOIN Pharmacists Ph ON PS.PharmacistID = Ph.PharmacistID
INNER JOIN Pharmacies P ON PS.PharmacyID = P.PharmacyID
INNER JOIN Drugs D ON PS.DrugID = D.DrugID
GROUP BY Ph.Name, P.Name, D.Name;
```

Please replace the table and column names in the scripts with the actual ones in your database.
*/