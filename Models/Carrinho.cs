using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;
using System;

namespace Comercio.Models
{
    [Table("Carrinho")]
    public class Carrinho
    {   
        [Key] //PK
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        

        [Required(ErrorMessage="Campo obrigatório")]
        [Column("Quantidade",TypeName = "int")]
        public int Quantidade { get; set; }


        [ForeignKey("ClienteId")] //referencia para FK, onde Produto (classe) Id (propriedade) 
        public int ClienteId { get; set; } //FK


        [JsonIgnore]
        public Cliente? Cliente { get; set; } //propriedade de navegacao para buscar todos os dados no join
        
        
        [ForeignKey("ProdutoId")] //referencia para FK, onde Produto (classe) Id (propriedade)
        public int ProdutoId { get; set; } //FK


        [JsonIgnore]
        public Produto? Produto { get; set; } //propriedade de navegacao para buscar todos os dados no join


        [JsonIgnore]
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
    }
}