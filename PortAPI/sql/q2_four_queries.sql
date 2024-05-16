SELECT * FROM Departs
WHERE MONTH(DateHeureDepart) = MONTH(GETDATE())
AND YEAR(DateHeureDepart) = YEAR(GETDATE());

SELECT COUNT(*) FROM Arrivees
WHERE PortOrigine = 'New York';

SELECT TOP 1 NomNavire FROM Arrivees
ORDER BY DateHeureArrivee DESC;

SELECT * FROM Arrivees
WHERE YEAR(DateHeureArrivee) = 2024
AND Terminal = 'Quai 72';

