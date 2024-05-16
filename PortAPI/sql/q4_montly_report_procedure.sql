CREATE PROCEDURE GenererRapportMensuel
    @Mois INT,
    @Annee INT
AS
BEGIN
    SELECT 'Arrivees' AS Type, NomNavire, DateHeureArrivee AS DateHeure, PortOrigine AS Port, Terminal
    FROM Arrivees
    WHERE MONTH(DateHeureArrivee) = @Mois
    AND YEAR(DateHeureArrivee) = @Annee
    UNION ALL
    SELECT 'Departs' AS Type, NomNavire, DateHeureDepart AS DateHeure, PortDestination AS Port, Quai
    FROM Departs
    WHERE MONTH(DateHeureDepart) = @Mois
    AND YEAR(DateHeureDepart) = @Annee;
END;
GO
