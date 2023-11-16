using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

using ProyectoPADSimpson.Shared.Models;
using ProyectoPADSimpson.Shared;
using ProyectoPADSimpson.Server.Models;

namespace ProyectoPADSimpson.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FraseController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public FraseController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Frase>>> ObtenerFrasesDelUsuario(int idUsuario)
        {
            var miobjeto = await _context.Frases.FirstOrDefaultAsync(ob => ob.IdUsuario == idUsuario);
            if (miobjeto == null)
            {
                return NotFound(" :/");
            }

            return Ok(miobjeto);
        }

        [HttpPost]
        public async Task<ActionResult> AgregarFrase(FraseDTO frase)
        {
            var responseApi = new ResponseAPI<int>();
            try
            {
                var dbFrase = new Frase
                {
                    IdUsuario = frase.IdUsuario,
                    Texto = frase.Texto,
                    Capitulo = frase.Capitulo,
                    Personaje = frase.Personaje
                };

                _context.Frases.Add(dbFrase);
                await _context.SaveChangesAsync();

                if (dbFrase.Id != 0)
                {
                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbFrase.Id;
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "No guardado";
                }
            }
            catch (Exception)
            {

                throw;
            }
            return Ok(responseApi);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarFrase(int id)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {

                var dbEmpleado = await _context.Frases.FirstOrDefaultAsync(f => f.Id == id);

                if (dbEmpleado != null)
                {
                    _context.Frases.Remove(dbEmpleado);
                    await _context.SaveChangesAsync();


                    responseApi.EsCorrecto = true;
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "Frase no encontrada";
                }

            }
            catch (Exception ex)
            {

                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }

            return Ok(responseApi);
        }
    }
}
