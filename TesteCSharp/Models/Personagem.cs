namespace TesteCSharp.Models
{
    public class Personagem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description  { get; set; }
        public string Affiliation   { get; set; }
    }

    public class PersonagemApiResponse
    {
        public int id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public string description  { get; set; }
        public string affiliation   { get; set; }
    }

    public class DragonBallApiResponse
    {
        public List<PersonagemApiResponse> items { get; set; }
    }
}
