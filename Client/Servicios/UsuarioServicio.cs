using Microsoft.EntityFrameworkCore;
using ProyectoPADSimpson.Client.Servicio;
using ProyectoPADSimpson.Shared.Models;
using System.Net.Http;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace ProyectoPADSimpson.Client.Servicio
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly HttpClient _httpClient;
        public UsuarioServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        //To Get all Usuario details

        public async Task<UsuarioDTO> Crear(UsuarioDTO modelo)
        {
            var response = await _httpClient.PostAsJsonAsync("Usuario/Crear", modelo);
            var result = await response.Content.ReadFromJsonAsync<UsuarioDTO>();
            return result!;

        }
        public async Task<bool> Editar(UsuarioDTO modelo)
        {
            var response = await _httpClient.PutAsJsonAsync("Usuario/Editar", modelo);
            var result = await response.Content.ReadFromJsonAsync<bool>();
            return result!;
        }


        public async Task<List<UsuarioDTO>> Lista(string rol, string buscar)
        {
            return await _httpClient.GetFromJsonAsync<List<UsuarioDTO>>($"Usuario/Lista/{rol}/{buscar}");
        }

        public async Task<UsuarioDTO> Obtener(int id)
        {
            return await _httpClient.GetFromJsonAsync<UsuarioDTO>($"Usuario/Obtener/{id}");
        }
    }
}
