using Microsoft.AspNetCore.Mvc;
using Comercio.Data;
using Comercio.Models;

namespace Comercio.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("/")]
        public string Get(){
            return "Tela Inicial!";
        }


    }
}