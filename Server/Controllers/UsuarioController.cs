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
    public class UsuarioController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsuarioController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<UsuarioDTO>>> GetSingleUsuario(int id)
        {
            var miobjeto = await _context.Usuarios.FirstOrDefaultAsync(ob => ob.Id == id);
            if (miobjeto == null)
            {
                return NotFound(" :/");
            }

            return Ok(miobjeto);
        }

        [HttpPost]
        public async Task<ActionResult> Guardar(UsuarioDTO usuario)
        {
            var responseApi = new ResponseAPI<int>();
            try
            {
                var dbUsuario = new Usuario
                {
                    Username = usuario.Username,
                    Password = usuario.Password,
                };

                _context.Usuarios.Add(dbUsuario);
                await _context.SaveChangesAsync();

                if (dbUsuario.Id != 0)
                {
                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbUsuario.Id;
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
    }
}
