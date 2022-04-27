using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Comercio.Models
{
    [Table("Compra")]
    public class Compra
    {
        [Key] //PK
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }


        [ForeignKey("CarrinhoId")] //referencia para FK, onde Produto (classe) Id (propriedade)
        [Required(ErrorMessage="Campo obrigatório")]
        public int CarrinhoId { get; set; } //FK


        [Column("ValorTotal",TypeName = "decimal(6,2)")]
        public decimal ValorTotal { get; set; }


        [JsonIgnore]
        public Carrinho? Carrinho { get; set; } //propriedade de navegacao para buscar todos os dados no join
        

        public bool CompraFinalizada { get; set; } = false;


        [JsonIgnore]
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
    }
}