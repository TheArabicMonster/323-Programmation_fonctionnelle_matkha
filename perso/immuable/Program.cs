using System.Numerics;

namespace immuable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 4 joueurs
            List<Player> players = new List<Player>()
            {
                new Player("Joe", 32),
                new Player("Jack", 30),
                new Player("William", 37),
                new Player("Joe", 82)
            };

            // Solution immuable sans variables mutables
            Player elder = FindElder(players[0], players[1], players[2], players[3]);

            Console.WriteLine($"Le plus âgé est {elder.Name} qui a {elder.Age} ans");
            Console.ReadKey();
        }

        // Fonction pour trouver le joueur le plus âgé sans mutation de variable
        static Player FindElder(Player p1, Player p2, Player p3, Player p4)
        {
            // Comparaison immuable
            return MaxAge(MaxAge(p1, p2), MaxAge(p3, p4));
        }

        // Fonction utilitaire pour comparer deux joueurs et renvoyer le plus âgé
        static Player MaxAge(Player p1, Player p2)
        {
            return p1.Age > p2.Age ? p1 : p2;
        }
    }
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
}