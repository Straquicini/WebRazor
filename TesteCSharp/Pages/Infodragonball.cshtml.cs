using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TesteCSharp.Models;
using System.Text.Json;

namespace TesteCSharp.Pages
{
    public class InfodragonballModel : PageModel {
        private readonly IHttpClientFactory _httpClientFactory;

        public InfodragonballModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory  = httpClientFactory;
        }

        public Personagem Infodragonball { get; set; }
        public string id { get; set; }

        public async Task<IActionResult> OnGetAsync(string cod) {
            id = cod;

            var client = _httpClientFactory.CreateClient("RestCountries");
            // pedir a API com a seguinte route, em que enviamos o 'cod' recebido
            var response = await client.GetAsync("https://dragonball-api.com/api/characters/{cod}");
            if (!response.IsSuccessStatusCode) {
                // Artigo não encontrado ou erro na API
                return NotFound();
            }

            var json = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            // reparar que aqui não temos uma lista !!
            var artigoResponse = JsonSerializer.Deserialize<List<PersonagemApiResponse>>(json, options)?.FirstOrDefault();

            // a maneira de como colocamos a Infodragonball com os dados recebidos também é diferente
            Infodragonball = new Personagem {
                Name = artigoResponse.name,
                Description = artigoResponse.description,
                Image = artigoResponse.image,
                Affiliation = artigoResponse.affiliation
            };

            return Page();
        }
    }
}
