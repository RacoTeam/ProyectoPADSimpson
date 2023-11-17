using ProyectoPADSimpson.Shared;
using ProyectoPADSimpson.Shared.Models;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace ProyectoPADSimpson.Client.Servicios
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly HttpClient _httpClient;
        public UsuarioServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        //To Get all Usuario details

        public async Task<bool> Buscar(UsuarioDTO usuario)
        {
            var result = await _httpClient.GetFromJsonAsync<ResponseAPI<UsuarioDTO>>(
    $"api/Usuario?Username={usuario.Username}&Password={usuario.Password}");

            if (result!.EsCorrecto)
                return result.EsCorrecto;
            else
                throw new Exception(result.Mensaje);
        }
        public async Task<int> Guardar(UsuarioDTO usuario)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Usuario", usuario);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.EsCorrecto)
                return response.Valor!;
            else
                throw new Exception(response.Mensaje);
        }
    }
}
