using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

var client = new HttpClient();
client.BaseAddress = new Uri("http://localhost:5112"); // lub inny port

client.DefaultRequestHeaders.Add("X-Username", "uzytkownik");
client.DefaultRequestHeaders.Add("X-Api-Key", "320c3044-9097-4187-b86b-2c93d8b97fa5");

// GET all players
var response = await client.GetAsync("/api/PlayersApi");
var content = await response.Content.ReadAsStringAsync();
Console.WriteLine("Zawodnicy:\n" + content);

// POST new player
var newPlayer = new
{
    Imie = "Krzysztof",
    Nazwisko = "Rybka",
    Pozycja = "Napastnik",
    DruzynaId = 2
};
var json = new StringContent(JsonSerializer.Serialize(newPlayer), Encoding.UTF8, "application/json");
var createRes = await client.PostAsync("/api/PlayersApi", json);
Console.WriteLine("Dodano zawodnika: " + await createRes.Content.ReadAsStringAsync());
