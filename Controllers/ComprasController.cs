using Microsoft.AspNetCore.Mvc;
using Comercio.Data;
using Comercio.Models;

namespace Comercio.Controllers
{
    [ApiController]
    public class ComprasController : ControllerBase
    {
        //[Route("/orders")]
        //GET
        [HttpGet("/compras")]
        public IActionResult Get([FromServices] AppDbContext context)=> Ok(context.Compras.ToList());

        //POST
        [HttpPost("/compras/{id:int}")]
        public IActionResult Post (
            [FromRoute] int id,
            [FromServices] AppDbContext context)
            {
                //var carrinhoValido = context.Carrinhos.FirstOrDefault(x=>x.Id==compras.CarrinhoId);
                //var idqtapegando = context.Carrinhos.Include(x=>x.Compras));
                // if (carrinhoValido == null)
                // {
                //     return NotFound(carrinhoValido);
                // }
                //     return Ok(carrinhoValido);
                //     compras.CompraFinalizada = true;
                //     var prod = carrinhoValido.ProdutoId;
                //     var preco = context.Produtos.FirstOrDefault(x=>x.Id==prod);
                //     var qtd = carrinhoValido.Quantidade;
                //     return Ok(prod);
                // }
                // else
                // {
                //     return NotFound("Carrinho não encontrado");
                // }
                //context.Compras.Add(compras);
                //context.SaveChanges();
                var total = 10;
                //return Created($"/compras/{compras.Id}",compras);
                return Ok($"Compra no valor de R${total} finalizada com sucesso");
            }

        //GET BY ID
        [HttpGet("/compras/{id:int}")]
        public IActionResult GetById(
            [FromRoute] int id,
            [FromServices] AppDbContext context){ 

            var ord = context.Compras.FirstOrDefault(x=>x.Id == id);
            if (ord == null)
                return NotFound();
            return Ok(ord);
        }

        //DELETE
        [HttpDelete("/compras/{id:int}")]
         public IActionResult Delete (
            [FromRoute] int id,
            [FromServices] AppDbContext context)
            {
                var model = context.Compras.FirstOrDefault(x=>x.Id==id);
                if (model == null)
                    return NotFound();
                context.Compras.Remove(model);
                context.SaveChanges();
                return Ok(model);
            }
        //PUT
        [HttpPut("/compras/{id:int}")]
         public IActionResult Put (
            [FromRoute] int id,
            [FromBody] Compra compras,
            [FromServices] AppDbContext context)
            {
                var model = context.Compras.FirstOrDefault(x=>x.Id==id);
                if (model == null){
                    return NotFound();
                }
                model.CompraFinalizada = compras.CompraFinalizada;
                
                context.Compras.Update(model);
                context.SaveChanges();
                return Ok(model);
            }
















    }
}