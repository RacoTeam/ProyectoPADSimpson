using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoPADSimpson.Server.Interfaces;
using ProyectoPADSimpson.Shared.Models;
using System.Collections.Generic;

namespace ProyectoPADSimpson.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FraseController : ControllerBase
    {

        private readonly IFraseServicio _IFraseServicio;
        public FraseController(IFraseServicio IFraseServicio)
        {
            _IFraseServicio = IFraseServicio;
        }
        [HttpGet]
        public async Task<List<FraseDTO>> Get()
        {
            return await Task.FromResult(_IFraseServicio.GetFraseDetails());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            FraseDTO Frase = _IFraseServicio.GetFraseData(id);
            if (Frase != null)
            {
                return Ok(Frase);
            }
            return NotFound();
        }
        [HttpPost]
        public void Post(FraseDTO Frase)
        {
            _IFraseServicio.AddFrase(Frase);
        }
        [HttpPut]
        public void Put(FraseDTO Frase)
        {
            _IFraseServicio.UpdateFraseDetails(Frase);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _IFraseServicio.DeleteFrase(id);
            return Ok();
        }
    }
}
