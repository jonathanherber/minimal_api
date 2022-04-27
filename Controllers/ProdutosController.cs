using Microsoft.AspNetCore.Mvc;
using Comercio.Data;
using Comercio.Models;

namespace Comercio.Controllers
{
    [ApiController]
    //[Route("/produtos")]
    public class ProdutosController : ControllerBase
    {
        //GET
        [HttpGet("/produtos")]
        public IActionResult Get([FromServices] AppDbContext context)=> Ok(context.Produtos.ToList());
        
        //POST
        [HttpPost("/produtos")]
        public IActionResult Post (
            [FromBody] Produto produtos,
            [FromServices] AppDbContext context)
            {
                context.Produtos.Add(produtos);
                context.SaveChanges();

                return Created($"/produtos/{produtos.Id}",produtos);
            }
        //GET BY ID
        [HttpGet("/produtos/{id:int}")]
        public IActionResult GetById(
            [FromRoute] int id,
            [FromServices] AppDbContext context){ 

            var prod = context.Produtos.FirstOrDefault(x=>x.Id == id);
            if (prod == null)
                return NotFound();
            return Ok(prod);
        }   
        //PUT
        [HttpPut("/produtos/{id:int}")]
         public IActionResult Put (
            [FromRoute] int id,
            [FromBody] Produto produtos,
            [FromServices] AppDbContext context)
            {
                var model = context.Produtos.FirstOrDefault(x=>x.Id==id);
                if (model == null){
                    return NotFound();
                }
                model.Nome = produtos.Nome;
                model.Preco = produtos.Preco;
                
                
                context.Produtos.Update(model);
                context.SaveChanges();
                return Ok(model);
            }
            //DELETE
        [HttpDelete("/produtos/{id:int}")]
         public IActionResult Delete (
            [FromRoute] int id,
            [FromServices] AppDbContext context)
            {
                var model = context.Produtos.FirstOrDefault(x=>x.Id==id);
                if (model == null)
                    return NotFound();
                context.Produtos.Remove(model);
                context.SaveChanges();
                return Ok(model);
            }
    }
}