// 4 players
List<Player> players = new List<Player>()
{
    new Player("Joe", 32),
    new Player("Jack", 30),
    new Player("William", 37),
    new Player("Averell", 25)
};

// Initialize search
Player elder = players.First();
int biggestAge = elder.Age;

// search
foreach (Player p in players)
{
    if (p.Age > biggestAge) // memorize new elder
    {
        elder = p;
        biggestAge = p.Age; // for future loops
    }
}

Player p1 = players[0].Age > players[1].Age ? players[0] : players[1]; 
Player p2 = players[2].Age < players[3].Age ? players[3] : players[4];
Player p3 = p1.Age > p2.Age ? p1 : p2;

Console.WriteLine($"Le plus agé est {p3.Name} qui a {p3.Age} ans");

Console.ReadKey();

public class Player
{
    private readonly string _name;
    private readonly int _age;

    public Player(string name, int age)
    {
        _name = name;
        _age = age;
    }

    public string Name => _name;

    public int Age => _age;
}