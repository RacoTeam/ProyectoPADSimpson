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

        [HttpGet]
        [Route("{idFrase}")]
        public async Task<ActionResult> ObtenerFrase(int idFrase)
        {
            var responseApi = new ResponseAPI<FraseDTO>();
            var FraseDTO = new FraseDTO();

            try
            {
                var dbFrase = await _context.Frases.FirstOrDefaultAsync(f => f.Id == idFrase);

                if (dbFrase != null)
                {
                    FraseDTO.Id = dbFrase.Id;
                    FraseDTO.Texto = dbFrase.Texto;
                    FraseDTO.Personaje = dbFrase.Personaje;
                    FraseDTO.Episodio = dbFrase.Episodio;
                    FraseDTO.IdUsuario = dbFrase.IdUsuario;

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = FraseDTO;
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "No encontrado";
                }
            }
            catch (Exception ex)
            {

                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }

            return Ok(responseApi);
        }

        [HttpGet]
        [Route("Usuario/{idUsuario}")]
        public async Task<ActionResult> ObtenerFrasesDelUsuario(int idUsuario)
        {
            var miobjeto = await _context.Frases.FirstOrDefaultAsync(ob => ob.IdUsuario == idUsuario);
            if (miobjeto == null)
            {
                return NotFound(":/");
            }

            var responseApi = new ResponseAPI<List<FraseDTO>>();
            var listaFraseDTO = new List<FraseDTO>();

            try
            {
                foreach (var item in await _context.Frases.Where(f => f.IdUsuario == idUsuario).ToListAsync())
                {
                    listaFraseDTO.Add(new FraseDTO
                    {
                        Id = item.Id,
                        Texto = item.Texto,
                        Episodio = item.Episodio,
                        Personaje = item.Personaje,
                        IdUsuario = item.IdUsuario
                    });
                }

                responseApi.EsCorrecto = true;
                responseApi.Valor = listaFraseDTO;
            }
            catch (Exception ex)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }

            return Ok(responseApi);
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
                    Episodio = frase.Episodio,
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
            catch (Exception ex)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }

            return Ok(responseApi);
        }

        [HttpDelete]
        [Route("{idFrase}")]
        public async Task<IActionResult> EliminarFrase(int idFrase)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbFrase = await _context.Frases.FirstOrDefaultAsync(f => f.Id == idFrase);

                if (dbFrase != null)
                {
                    _context.Frases.Remove(dbFrase);
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
