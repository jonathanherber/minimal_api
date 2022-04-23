using Microsoft.AspNetCore.Mvc;
using Comercio.Data;
using Comercio.Models;

namespace Comercio.Controllers
{
    [ApiController]
    //[Route("/clientes")]
    public class ClientsController : ControllerBase
    {
        //GET
        [HttpGet("/clientes")]
        public IActionResult Get([FromServices] AppDbContext context)=> Ok(context.Client.ToList());
        
        //POST
        [HttpPost("/clientes")]
        public IActionResult Post (
            [FromBody] Clients client,
            [FromServices] AppDbContext context)
            {
                context.Client.Add(client);
                context.SaveChanges();

                return Created($"/clientes/{client.Id}",client);
            }
        //GET BY ID
        [HttpGet("/clientes/{id:int}")]
        public IActionResult GetById(
            [FromRoute] int id,
            [FromServices] AppDbContext context){ 

            var clien = context.Client.FirstOrDefault(x=>x.Id == id);
            if (clien == null)
                return NotFound();
            return Ok(clien);
        }   
        //PUT
        [HttpPut("/clientes/{id:int}")]
         public IActionResult Put (
            [FromRoute] int id,
            [FromBody] Clients client,
            [FromServices] AppDbContext context)
            {
                var model = context.Client.FirstOrDefault(x=>x.Id==id);
                if (model == null){
                    return NotFound();
                }
                model.Name = client.Name;
                model.Cpf = client.Cpf;
                
                context.Client.Update(model);
                context.SaveChanges();
                return Ok(model);
            }
            //DELETE
        [HttpDelete("/clientes/{id:int}")]
         public IActionResult Delete (
            [FromRoute] int id,
            [FromServices] AppDbContext context)
            {
                var model = context.Client.FirstOrDefault(x=>x.Id==id);
                if (model == null)
                    return NotFound();
                context.Client.Remove(model);
                context.SaveChanges();
                return Ok(model);
            }
    }
}