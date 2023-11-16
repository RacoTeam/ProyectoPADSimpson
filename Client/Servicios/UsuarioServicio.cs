using ProyectoPADSimpson.Shared;
using ProyectoPADSimpson.Shared.Models;
using System.Net.Http.Json;

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

        public async Task<UsuarioDTO> Buscar(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<ResponseAPI<UsuarioDTO>>($"api/Usuario/{id}");

            if (result!.EsCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);
        }
        public async Task<int> Guardar(UsuarioDTO empleado)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Usuario", empleado);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.EsCorrecto)
                return response.Valor!;
            else
                throw new Exception(response.Mensaje);
        }
    }
}
