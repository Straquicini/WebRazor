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

        public async Task<IActionResult> OnGetAsync(string cod) {
            var client = _httpClientFactory.CreateClient("DragonBallApi");
            // pedir a API com a seguinte route, em que enviamos o 'cod' recebido
            var response = await client.GetAsync("characters/" + cod);
            if (!response.IsSuccessStatusCode) {
                // Artigo não encontrado ou erro na API
                return NotFound();
            }

            var json = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            // reparar que aqui não temos uma lista !!
            var personagemResponse = JsonSerializer.Deserialize<PersonagemApiResponse>(json, options);

            // a maneira de como colocamos a Infodragonball com os dados recebidos também é diferente
            Infodragonball = new Personagem {
                Name = personagemResponse.name,
                Description = personagemResponse.description,
                Image = personagemResponse.image,
                Affiliation = personagemResponse.affiliation
            };

            return Page();
        }
    }
}