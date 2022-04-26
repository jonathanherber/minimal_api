using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Comercio.Models
{
    [Table("Product")]
    public class Products 
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[JsonIgnore]
        public int Id { get; private set; }


        [Required]
        [MaxLength(30, ErrorMessage="Name must be 5 characters or more")]
        [Column(TypeName = "varchar(30)")] 
        public string Name { get; set; } 


        [Required]
        [Column(TypeName = "decimal(6)")]
        public decimal Price { get; set; }  


        [Required]
        [Column(TypeName = "int(5)")]  
        public int Stock { get; set; } = 0;

        //[JsonIgnore]
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    }
}