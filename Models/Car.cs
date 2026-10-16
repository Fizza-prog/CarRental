
namespace CarRental.Models
{
    public class Car
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal PricePerDay { get; set; }
    }
}
