SELECT
    ph.Name AS 'Pharmacist Name',
        p.Name AS 'Pharmacy Name',
        d.Name AS 'Drug Name',
        SUM(ps.UnitCount) AS 'Total Unit Count',
        SUM(ps.UnitCount * ps.UnitPrice) AS 'Total Sales Amount',
        RANK() OVER (ORDER BY SUM(ps.UnitCount * ps.UnitPrice) DESC) AS 'Rank'
FROM PharmacySales ps
         JOIN Pharmacists ph ON ps.PharmacistId = ph.PharmacistID
         JOIN Pharmacies p ON ps.PharmacyId = p.Id
         JOIN Drugs d ON ps.DrugID = d.DrugID
GROUP BY ph.Name, p.Name, d.Name
ORDER BY 'Total Sales Amount' DESC;