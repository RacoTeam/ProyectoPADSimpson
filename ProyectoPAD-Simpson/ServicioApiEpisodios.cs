using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using static ProyectoPAD_Simpson.Pages.Simpson;

public class ServicioApiEpisodios
{
    private readonly HttpClient _httpClient;

    public ServicioApiEpisodios(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Episodio>> ObtenerEpisodios(string query)
    {
        var resultado = await _httpClient.GetFromJsonAsync<List<Episodio>>(query);

        // Verificar si resultado es nulo y devolver una lista vacía en su lugar
        return resultado ?? new List<Episodio>();
    }
    public async Task<Episodio?> ObtenerEpisodio(string query)
    {
        var episodios = await _httpClient.GetFromJsonAsync<List<Episodio>>(query);

        var resultado = episodios?.FirstOrDefault();

        // Verificar si resultado es nulo y devolver una lista vacía en su lugar
        return resultado;
    }
}