using Microsoft.AspNetCore.Mvc;
using Comercio.Data;
using Comercio.Models;

namespace Comercio.Controllers
{
    [ApiController]
    public class OrderController : ControllerBase
    {
        //[Route("/orders")]
        //GET
        [HttpGet("/orders")]
        public IActionResult Get([FromServices] AppDbContext context)=> Ok(context.Order.ToList());

        //POST
        [HttpPost("/orders")]
        public IActionResult Post (
            [FromBody] Orders order,
            [FromServices] AppDbContext context)
            {
                // var clienteValido = context.Order.FirstOrDefault(x=>x.ClientId==order.ClientId);
                // if (clienteValido == null)
                //     return NotFound();
                // var produtoValido = context.Order.FirstOrDefault(x=>x.ProductId==order.ProductId);
                // if (produtoValido == null)
                //     return NotFound();
                //var produtoBanco = context.Product.Where(x=>x.Id==produtoValido.ProductId);
                //order.TotalValue.value *= order.Amount;

                context.Order.Add(order);
                context.SaveChanges();

                return Created($"/clients/{order.Id}",order);
            }

        //DELETE
        [HttpDelete("/orders/{id:int}")]
         public IActionResult Delete (
            [FromRoute] int id,
            [FromServices] AppDbContext context)
            {
                var model = context.Order.FirstOrDefault(x=>x.Id==id);
                if (model == null)
                    return NotFound();
                context.Order.Remove(model);
                context.SaveChanges();
                return Ok(model);
            }

















    }
}