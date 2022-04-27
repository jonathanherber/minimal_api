using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;
using System;

namespace Comercio.Models
{
    [Table("Produto")]
    public class Produto
    {   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }


        [Required(ErrorMessage="Campo obrigatório")]
        [MaxLength(30, ErrorMessage="Máximo 30 caracteres")]
        [Column("Nome",TypeName = "varchar")]
        public string Nome { get; set; } = null!;


        [Required(ErrorMessage="Campo obrigatório")]
        [Column("Preco",TypeName = "decimal(6,2)")]
        public string Preco { get; set; } = null!;

        
        [JsonIgnore]
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

    }
}