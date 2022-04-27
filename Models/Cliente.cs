using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;
using System;

namespace Comercio.Models
{
    [Table("Cliente")]
    public class Cliente
    {   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }


        [Required(ErrorMessage="Campo obrigatório")]
        [MaxLength(30, ErrorMessage="Máximo 30 caracteres")]
        [Column("Nome",TypeName = "varchar")]
        public string Nome { get; set; } = null!;


        [Required(ErrorMessage="Campo obrigatório")]
        [MaxLength(15, ErrorMessage="Máximo 15 caracteres")]
        [Column("Telefone",TypeName = "varchar")]
        public string Telefone { get; set; } = null!;


        [JsonIgnore]
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;


    }
}