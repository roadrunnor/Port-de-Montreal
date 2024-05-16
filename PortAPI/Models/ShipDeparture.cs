namespace PortAPI.Models
{
    using System;

    public class ShipDeparture
    {
        public int Id { get; set; }
        public string NomNavire { get; set; }
        public DateTime DateHeureDepart { get; set; }
        public string PortDestination { get; set; }
        public string Quai { get; set; }
        public string TypeCargaison { get; set; }
    }
}
