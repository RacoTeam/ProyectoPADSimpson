using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using static ProyectoPAD_Simpson.Pages.Simpson;

public class ServicioApi
{
    private readonly HttpClient _httpClient;

    public ServicioApi(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Episode>> ObtenerEpisodios(string query)
    {
        var resultado = await _httpClient.GetFromJsonAsync<List<Episode>>(query);

        // Verificar si resultado es nulo y devolver una lista vacía en su lugar
        return resultado ?? new List<Episode>();
    }
}