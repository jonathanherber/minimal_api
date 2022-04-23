using Microsoft.AspNetCore.Mvc;
using Comercio.Data;
using Comercio.Models;

namespace Comercio.Controllers
{
    [ApiController]
    //[Route("/produtos")]
    public class ProdutsController : ControllerBase
    {
        //GET
        [HttpGet("/produtos")]
        public IActionResult Get([FromServices] AppDbContext context)=> Ok(context.Product.ToList());
        
        //POST
        [HttpPost("/produtos")]
        public IActionResult Post (
            [FromBody] Products product,
            [FromServices] AppDbContext context)
            {
                context.Product.Add(product);
                context.SaveChanges();

                return Created($"/produtos/{product.Id}",product);
            }
        //GET BY ID
        [HttpGet("/produtos/{id:int}")]
        public IActionResult GetById(
            [FromRoute] int id,
            [FromServices] AppDbContext context){ 

            var prod = context.Product.FirstOrDefault(x=>x.Id == id);
            if (prod == null)
                return NotFound();
            return Ok(prod);
        }   
        //PUT
        [HttpPut("/produtos/{id:int}")]
         public IActionResult Put (
             [FromRoute] int id,
            [FromBody] Products product,
            [FromServices] AppDbContext context)
            {
                var model = context.Product.FirstOrDefault(x=>x.Id==id);
                if (model == null){
                    return NotFound();
                }
                model.Name = product.Name;
                model.Value = product.Value;
                model.Amount = product.Amount;
                
                context.Product.Update(model);
                context.SaveChanges();
                return Ok(model);
            }
            //DELETE
        [HttpDelete("/produtos/{id:int}")]
         public IActionResult Delete (
            [FromRoute] int id,
            [FromServices] AppDbContext context)
            {
                var model = context.Product.FirstOrDefault(x=>x.Id==id);
                if (model == null)
                    return NotFound();
                context.Product.Remove(model);
                context.SaveChanges();
                return Ok(model);
            }
    }
}