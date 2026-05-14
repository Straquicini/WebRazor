using Microsoft.AspNetCore.Mvc.RazorPages;
using TesteCSharp.Models;

namespace TesteCSharp.Pages
{
    public class ListdragonballModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public List<Personagem> Personagens { get; set; } = new List<Personagem>();
        
        public ListdragonballModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task OnGetAsync()
        {
            var httpClient = _httpClientFactory.CreateClient("DragonBallApi");
            var response = await httpClient.GetAsync("characters");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var apiResponse = System.Text.Json.JsonSerializer.Deserialize<DragonBallApiResponse>(json, 
                    new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (apiResponse?.items != null)
                {
                    Personagens = apiResponse.items
                        .Select(p => new Personagem
                        {
                            Id = p.id,
                            Name = p.name,
                            Image = p.image
                        })
                        .ToList();
                }
            }
        }
    }
}
