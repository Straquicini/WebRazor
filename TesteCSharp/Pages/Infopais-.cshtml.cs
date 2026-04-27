using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TesteCSharp.Models;
using System.Text.Json;

namespace TesteCSharp.Pages
{
    public class InfopaisModel : PageModel {
        private readonly IHttpClientFactory _httpClientFactory;

        public InfopaisModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory  = httpClientFactory;
        }

        public Pais InfoPais { get; set; }
        public string CodigoPais { get; set; }

        public async Task<IActionResult> OnGetAsync(string cod) {
            CodigoPais = cod;

            var client = _httpClientFactory.CreateClient("RestCountries");
            // pedir a API com a seguinte route, em que enviamos o 'cod' recebido
            var response = await client.GetAsync("v3.1/alpha/co/{cod}");
            if (!response.IsSuccessStatusCode) {
                // Artigo não encontrado ou erro na API
                return NotFound();
            }

            var json = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            // reparar que aqui não temos uma lista !!
            var artigoResponse = JsonSerializer.Deserialize<List<CountryApiResponse>>(json, options)?.FirstOrDefault();

            // a maneira de como colocamos a InfoPais com os dados recebidos também é diferente
            InfoPais = new Pais {
                OfficialName = artigoResponse.name?.official,
                Cca2 = artigoResponse.cca2,
                FlagUrl = artigoResponse.flags?.png
            };

            return Page();
        }
    }
}
