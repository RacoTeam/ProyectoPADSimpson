using Blazorise;
using Microsoft.EntityFrameworkCore;
using ProyectoPADSimpson.Shared;
using ProyectoPADSimpson.Shared.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace ProyectoPADSimpson.Client.Services
{
    public class FraseServicio : IFraseServicio
    {
        private readonly HttpClient _httpClient;
        public FraseServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<FraseDTO>> ObtenerFrasesDelUsuario(int idUsuario)
        {
            var result = await _httpClient.GetFromJsonAsync<ResponseAPI<List<FraseDTO>>>($"api/Frase/Usuario/{idUsuario}");

            if (result!.EsCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);
        }

        public async Task<FraseDTO> ObtenerFrase(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<ResponseAPI<FraseDTO>>($"api/Frase/{id}");

            if (result!.EsCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);
        }

        public async Task<int> AgregarFrase(FraseDTO Frase)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Frase", Frase);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.EsCorrecto)
                return response.Valor!;
            else
                throw new Exception(response.Mensaje);
        }

        public async Task<bool> EliminarFrase(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/Frase/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.EsCorrecto)
                return response.EsCorrecto!;
            else
                throw new Exception(response.Mensaje);
        }
    }
}
