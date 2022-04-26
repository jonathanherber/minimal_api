using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Comercio.Models
{
    [Table("Clients")]
    //[DataContract]
    public class Clients
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        [Required]
        [MaxLength(30, ErrorMessage="Name must be 5 characters or more")]
        [Column(TypeName = "varchar(30)")]
        //[DataMember]
        public string Name { get; set; }  

        //[JsonIgnore]
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    }
}