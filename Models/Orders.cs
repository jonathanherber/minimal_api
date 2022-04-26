using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Comercio.Data;
namespace Comercio.Models
{ 
    [Table("Orders")]
    public class Orders
    { 
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        public decimal TotalValue
        { 
            get { return TotalValue; }
            private set { TotalValue = value; } 
        }
               
        public bool SaleCompleted { get; private set; } = false;

        [Required]
        public int Amount { get; set; } = 0;
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        public int ClientId { get; private set; }

        [ForeignKey("ClientId")]
        public Clients Client { get; private set; }

        // public int ProductId { get; private set; }
        
        // [ForeignKey("ProductId")]
        // public Products Product { get; private set; }
    
    }
}