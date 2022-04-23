namespace Comercio.Models
{

    public class Products 
    {
        public int Id { get; set; }
        public string? Name { get; set; } 
        public double Value { get; set; }    
        public int Amount { get; set; }   
        public DateTime CreatedAt { get; set; }
    }
}