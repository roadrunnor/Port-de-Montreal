namespace PortAPI.Models
{
    using System;

    public class ShipArrival
    {
        public int Id { get; set; }
        public string NomNavire { get; set; }
        public DateTime DateHeureArrivee { get; set; }
        public string PortOrigine { get; set; }
        public string Terminal { get; set; }
        public string TypeCargaison { get; set; }
    }
}
