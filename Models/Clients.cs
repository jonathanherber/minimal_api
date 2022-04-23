namespace Comercio.Models
{
    public class Clients
    {
        public int Id { get; set; }
        public string? Name { get; set; } 
        public double Cpf { get; set; }      
        public DateTime CreatedAt { get; set; }
    }
}