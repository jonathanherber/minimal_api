using Microsoft.AspNetCore.Mvc;
using Comercio.Data;
using Comercio.Models;
using Microsoft.EntityFrameworkCore;

namespace Comercio.Controllers
{
    [ApiController]
    public class CarrinhoController : ControllerBase
    {
        //[Route("/orders")]
        //GET
        [HttpGet("/carrinho")]
       
        public IActionResult Get([FromServices] AppDbContext context)=> Ok(context.Carrinhos.ToList());


        //POST
        [HttpPost("/carrinho")]
        public IActionResult Post (
            [FromBody] Carrinho carrinho,
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

                context.Carrinhos.Add(carrinho);
                context.SaveChanges();

                return Created($"/carrinho/{carrinho.Id}",carrinho);
            }
        //GET BY ID
        [HttpGet("/carrinho/{id:int}")]
        public IActionResult GetById(
            [FromRoute] int id,
            [FromServices] AppDbContext context){ 

            //var ord = context.Carrinhos
            // .FromSqlRaw($@"SELECT Order.Id, Order.ClientId, Order.OrderDetails, Order.CreatedAt, Client.Id, Client.Name, Client.Phone, Client.CreatedAt,Client.Orders
            //             FROM Order 
            //             INNER JOIN Client
            //             ON Order.ClientId = Client.Id
            //             AND Order.Id={id};")
            // .ToList();
            var car = context.Carrinhos.FirstOrDefault(x=>x.Id == id);
            if (car == null)
                return NotFound();
            return Ok(car);
        }  

        //DELETE
        [HttpDelete("/carrinho/{id:int}")]
         public IActionResult Delete (
            [FromRoute] int id,
            [FromServices] AppDbContext context)
            {
                var model = context.Carrinhos.FirstOrDefault(x=>x.Id==id);
                if (model == null)
                    return NotFound();
                context.Carrinhos.Remove(model);
                context.SaveChanges();
                return Ok(model);
            }
        //PUT
        [HttpPut("/carrinho/{id:int}")]
         public IActionResult Put (
            [FromRoute] int id,
            [FromBody] Carrinho carrinho,
            [FromServices] AppDbContext context)
            {
                var model = context.Carrinhos.FirstOrDefault(x=>x.Id==id);
                if (model == null){
                    return NotFound();
                }
                model.ClienteId = carrinho.ClienteId;
                
                context.Carrinhos.Update(model);
                context.SaveChanges();
                return Ok(model);
            }
















    }
}