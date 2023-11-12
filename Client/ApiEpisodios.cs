using System.Net.Http.Json;
//using static ProyectoPADSimpson.Client.Pages.Simpson;

public class ApiEpisodios
{
    private readonly HttpClient _httpClient;

    public ApiEpisodios(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    //public async Task<List<Episodio>> ObtenerEpisodios(string query)
    //{
    //    var resultado = await _httpClient.GetFromJsonAsync<List<Episodio>>(query);

    //    // Verificar si resultado es nulo y devolver una lista vacía en su lugar
    //    return resultado ?? new List<Episodio>();
    //}
    //public async Task<Episodio?> ObtenerEpisodio(string query)
    //{
    //    var episodios = await _httpClient.GetFromJsonAsync<List<Episodio>>(query);

    //    var resultado = episodios?.FirstOrDefault();

    //    // Verificar si resultado es nulo y devolver una lista vacía en su lugar
    //    return resultado;
    //}
}