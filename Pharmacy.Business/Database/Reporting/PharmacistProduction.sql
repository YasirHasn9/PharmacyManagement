SELECT w.Name AS 'Warehouse Name',
        SUM(del.TotalPrice) AS 'Total Delivery Revenue', 
        SUM(del.UnitCount) AS 'Total Unit Count', 
        AVG(del.TotalPrice / NULLIF(del.UnitCount, 0)) AS 'Average Profit Per Unit'
FROM Deliveries del
         JOIN Warehouses w ON del.WarehouseId = w.WarehouseId
GROUP BY w.Name
ORDER BY 'Total Delivery Revenue' DESC;