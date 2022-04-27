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

        // //POST
        // [HttpPost("/orders")]
        // public IActionResult Post (
        //     [FromBody] Order order,
        //     [FromServices] AppDbContext context)
        //     {
        //         // var clienteValido = context.Order.FirstOrDefault(x=>x.ClientId==order.ClientId);
        //         // if (clienteValido == null)
        //         //     return NotFound();
        //         // var produtoValido = context.Order.FirstOrDefault(x=>x.ProductId==order.ProductId);
        //         // if (produtoValido == null)
        //         //     return NotFound();
        //         //var produtoBanco = context.Product.Where(x=>x.Id==produtoValido.ProductId);
        //         //order.TotalValue.value *= order.Amount;

        //         context.Orders.Add(order);
        //         context.SaveChanges();

        //         return Created($"/clients/{order.Id}",order);
        //     }

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