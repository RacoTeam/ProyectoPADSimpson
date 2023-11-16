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
        public async Task<ActionResult<List<UsuarioDTO>>> GetUsuario()
        {
            var lista = await _context.Usuarios.ToListAsync();
            return Ok(lista);
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

        //[HttpPost("Crear")]
        //public async Task<ActionResult<UsuarioDTO>> Crear([FromBody] UsuarioDTO objeto)
        //{

        //    _context.Usuarios.Add(objeto);
        //    await _context.SaveChangesAsync();
        //    return Ok(await GetDbUsuario());
        //}

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

                if(dbUsuario.Id != 0)
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

        /*[HttpPut("{id}")]
        public async Task<ActionResult<List<UsuarioDTO>>> UpdateUsuario(UsuarioDTO objeto)
        {

            var DbObjeto = await _context.Usuarios.FindAsync(objeto.Id);
            if (DbObjeto == null)
                return BadRequest("no se encuentra");
            DbObjeto.Username = objeto.Username;


            await _context.SaveChangesAsync();

            return Ok(await _context.Usuarios.ToListAsync());
        }

        //[HttpDelete]
        //[Route("{id}")]
        //public async Task<ActionResult<List<UsuarioDTO>>> DeleteUsuario(int id)
        //{
        //    var DbObjeto = await _context.Usuarios.FirstOrDefaultAsync(Ob => Ob.Id == id);
        //    if (DbObjeto == null)
        //    {
        //        return NotFound("no existe :/");
        //    }

        //    _context.Usuarios.Remove(DbObjeto);
        //    await _context.SaveChangesAsync();

        //    return Ok(await GetDbUsuario());
        //}*/
    }
}
