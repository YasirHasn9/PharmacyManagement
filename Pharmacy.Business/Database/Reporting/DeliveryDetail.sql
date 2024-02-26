SELECT W.Name AS WarehouseName,
       P.Name AS PharmacyName,
       D.Name AS DrugName,
       DL.UnitCount,
       DL.UnitPrice,
       DL.TotalPrice,
       DL.DeliveryDate
FROM Deliveries DL
         JOIN Warehouses W ON DL.WarehouseId = W.WarehouseId
         JOIN Pharmacies P ON DL.PharmacyId = P.Id
         JOIN Drugs D ON DL.DrugId = D.DrugId;