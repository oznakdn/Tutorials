using System.ComponentModel.DataAnnotations.Schema;

namespace _09_EntityConfiguration.Entities
{

    // Iki entity arasinda birden fazla iliski varsa (iki FK ayarlamak icin) asagidaki attirbute ile ayarlanmaktadir.
    public class Flight
    {
        public int FlightID { get; set; }
        public string FlightCode { get; set; }


        public int DepartureAirportId { get; set; }
        public int ArrivalAirportId { get; set; }

        public Airport DepartureAirport { get; set; }
        public Airport ArrivalAirport { get; set; }
    }

    public class Airport
    {
        public int AirportID { get; set; }
        public string AirportName { get; set; }


        [InverseProperty(nameof(Flight.DepartureAirport))]
        public virtual ICollection<Flight> DepartingFlights { get; set; }


        [InverseProperty(nameof(Flight.ArrivalAirport))]
        public virtual ICollection<Flight> ArrivingFlights { get; set; }


    }
}