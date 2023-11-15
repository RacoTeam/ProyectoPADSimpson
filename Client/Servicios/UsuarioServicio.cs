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

        public async Task<Usuario> Crear(Usuario modelo)
        {
            var response = await _httpClient.PostAsJsonAsync("Usuario/Crear", modelo);
            var result = await response.Content.ReadFromJsonAsync<Usuario>();
            return result!;

        }
        public async Task<bool> Editar(Usuario modelo)
        {
            var response = await _httpClient.PutAsJsonAsync("Usuario/Editar", modelo);
            var result = await response.Content.ReadFromJsonAsync<bool>();
            return result!;
        }


        public async Task<List<Usuario>> Lista(string rol, string buscar)
        {
            return await _httpClient.GetFromJsonAsync<List<Usuario>>($"Usuario/Lista/{rol}/{buscar}");
        }

        public async Task<Usuario> Obtener(int id)
        {
            return await _httpClient.GetFromJsonAsync<Usuario>($"Usuario/Obtener/{id}");
        }
    }
}
