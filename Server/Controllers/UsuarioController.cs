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
        public async Task<IActionResult> Buscar([FromQuery] UsuarioDTO usuario)
        {
            var responseApi = new ResponseAPI<UsuarioDTO>();

            var miobjeto = await _context.Usuarios
                .FirstOrDefaultAsync(ob => ob.Username == usuario.Username && ob.Password == usuario.Password);

            if (miobjeto == null)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = "Usuario no encontrado";
            }
            else
            {
                HttpContext.Session.SetInt32("UsuarioId", miobjeto.Id);

                responseApi.EsCorrecto = true;
                responseApi.Valor = new UsuarioDTO
                {
                    Id = miobjeto.Id,
                    Username = miobjeto.Username,
                    Password = miobjeto.Password // Asegúrate de ajustar según la estructura real de tu clase Usuario
                };
                
            }

            return Ok(responseApi);
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
