using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

class Program
{
    static async Task Main(string[] args)
    {
        HttpClient client = new HttpClient();

        // récupération des données de l'API SWAPI
        var films = await GetDataFromApi("https://swapi.dev/api/films/", client);
        var people = await GetDataFromApi("https://swapi.dev/api/people/", client);
        var planets = await GetDataFromApi("https://swapi.dev/api/planets/", client);
        var starships = await GetDataFromApi("https://swapi.dev/api/starships/", client);

        // Quel est le film Star Wars dont le titre est le plus long ?
        var longestTitleFilm = films.OrderByDescending(f => f["title"].ToString().Length).FirstOrDefault();
        Console.WriteLine($"Film avec le titre le plus long: {longestTitleFilm?["title"]}");

        // Quel est le personnage qui est présent dans le plus de films ?
        var mostPresentCharacter = people.OrderByDescending(p => p["films"].Count()).FirstOrDefault();
        Console.WriteLine($"Personnage présent dans le plus de films: {mostPresentCharacter?["name"]}");

        // Quelle est la planète la plus peuplée ?
        var mostPopulatedPlanet = planets.OrderByDescending(p => (long)p["population"]).FirstOrDefault();
        Console.WriteLine($"Planète la plus peuplée: {mostPopulatedPlanet?["name"]} avec {mostPopulatedPlanet?["population"]} habitants.");

        // Combien de starfighter X-Wing est-ce que je peux m'acheter si je vends un Star Destroyer ?
        var starDestroyer = starships.FirstOrDefault(s => s["name"].ToString() == "Star Destroyer");
        var xWing = starships.FirstOrDefault(s => s["name"].ToString() == "X-wing");
        if (starDestroyer != null && xWing != null)
        {
            var xWingRatio = Math.Floor((decimal)starDestroyer["cost_in_credits"] / (decimal)xWing["cost_in_credits"]);
            Console.WriteLine($"Avec un Star Destroyer, je peux acheter {xWingRatio} X-wings.");
        }

        GenerateStarshipCsv(starships, films);
    }

    /// <summary>
    /// Récupère les données de l'API SWAPI
    /// </summary>
    /// <param name="apiUrl"></param>
    /// <param name="client"></param>
    /// <returns></returns>
    private static async Task<List<JObject>> GetDataFromApi(string apiUrl, HttpClient client)
    {
        List<JObject> dataList = new List<JObject>();
        var nextPage = apiUrl;
        while (nextPage != null)
        {
            Debug.Write(nextPage);
            var response = await client.GetStringAsync(nextPage);
            var result = JsonConvert.DeserializeObject<JObject>(response);
            dataList.AddRange(result["results"].ToObject<List<JObject>>());
            nextPage = result["next"]?.ToString();
        }
        return dataList;
    }

    /// <summary>
    /// créer un fichier CSV contenant les données des vaisseaux
    /// </summary>
    /// <param name="starships"></param>
    /// <param name="films"></param>
    private static void GenerateStarshipCsv(List<JObject> starships, List<JObject> films)
    {
        using (StreamWriter writer = new StreamWriter("vaisseau.txt"))
        {
            writer.WriteLine("Nom du vaisseau,Prix,Longueur,Films,Planètes survolées");
            foreach (var starship in starships)
            {
                var filmNames = string.Join("-", films.Where(f => starship["films"].ToObject<List<string>>().Contains(f["url"].ToString())).Select(f => f["title"].ToString().ToLower()));
                // Planètes survolées non disponibles directement, placeholder ici
                writer.WriteLine($"{starship["name"]},{starship["cost_in_credits"]},{starship["length"]},{filmNames},N/A");
            }
        }
        Console.WriteLine("Fichier CSV 'vaisseau.txt' généré.");
    }
}