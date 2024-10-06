namespace filter
{
    internal class Program
    {
        class Movie
        {
            public string Title { get; set; }
            public string Genre { get; set; }
            public double Rating { get; set; }
            public int Year { get; set; }
            public string[] LanguageOptions { get; set; }
            public string[] StreamingPlatforms { get; set; }
        }

        class ComputerHardware
        {
            public string Name { get; set; }
            public string Type { get; set; }
            public double Price { get; set; }
            public double ClockSpeed { get; set; }
            public int Cores { get; set; }
            public string Brand { get; set; }
        }

        static void Main(string[] args)
        {
            // partie 1
            string[] words = { "bonjour", "hello", "monde", "vert", "rouge", "bleu", "jaune" };

            var dontContainX = words.Where(w => !w.Contains("x"));

            var contain4Chars = words.Where(w => w.Length == 4);

            var sameCharsAsAverage = words.Where(w => w.Length == words.Average(w => w.Length));

            //partie 2
            var letterFrequencies = new Dictionary<char, double>
            {
                {'A', 8.15}, {'B', 0.97}, {'C', 3.15}, {'D', 3.55}, {'E', 17.45},
                {'F', 1.05}, {'G', 1.30}, {'H', 0.95}, {'I', 7.55}, {'J', 0.60},
                {'K', 0.05}, {'L', 5.45}, {'M', 3.00}, {'N', 7.10}, {'O', 5.35},
                {'P', 3.00}, {'Q', 0.85}, {'R', 6.45}, {'S', 7.90}, {'T', 7.10},
                {'U', 6.35}, {'V', 1.05}, {'W', 0.05}, {'X', 0.45}, {'Y', 0.30},
                {'Z', 0.15}
            };

            static double CalculateEpsilon(string word, Dictionary<char, double> letterFrequencies)
            {
                return word
                    .GroupBy(c => c)
                    .Sum(g => letterFrequencies[g.Key] * g.Count() / word.Length);
            }

            foreach (var word in words)
            {
                Console.WriteLine($"{word} : {CalculateEpsilon(word, letterFrequencies)}");
            }

            //partie 3
            List<string> frenchWords = new List<string>()
            {
                "Merci", "Hotdog", "Oui", "Non", "Désolé", "Réunion", "Manger", "Boire", "Téléphone", "Ordinateur",
                "Internet", "Email", "Sandwich", "Hello", "Taxi", "Hotel", "Gare", "Train", "Bus", "Métro", "Tramway",
                "Vélo", "Voiture", "Piéton", "Feu rouge", "Cédez", "Ralentir", "gauche", "droite", "Continuer",
                "Sandwich", "Retourner", "Arrêter", "Stationnement", "Parking", "Interdit", "Péage", "Trafic", "Route",
                "Rond-point", "Football", "Carrefour", "Feu", "Panneau", "Vitesse", "Tramway", "Aéroport", "Héliport",
                "Port", "Ferry", "Bateau", "Canot", "Kayak", "Paddle", "Surf", "Plage", "Mer", "Océan", "Rivière",
                "Lac", "Étang", "Marais", "Forêt", "Hello", "Montagne", "Vallée", "Plaine", "Désert", "Jungle",
                "Savane", "Volleyball", "Tundra", "Glacier", "Neige", "Pluie", "Soleil", "Nuage", "Vent", "Tempête",
                "Ouragan", "Tornade", "Séisme", "Tsunami", "Volcan", "Éruption", "Ciel"
            };

            List<string> englishWords = new List<string>()
            {
                "Thank you", "Hotdog", "Yes", "No", "Sorry", "Meeting", "Eat", "Drink", "Phone", "Computer",
                "Internet", "Email", "Sandwich", "Hello", "Taxi", "Hotel", "Station", "Train", "Bus", "Subway",
                "Tramway", "Bike", "Car", "Pedestrian", "Red light", "Yield", "Slow down", "Left", "Right", "Continue",
                "Sandwich", "Return", "Stop", "Parking", "Parking", "Forbidden", "Toll", "Traffic", "Road", "Roundabout",
                "Soccer", "Intersection", "Light", "Sign", "Speed", "Tramway", "Airport", "Heliport", "Port", "Ferry",
                "Boat", "Canoe", "Kayak", "Paddle", "Surf", "Beach", "Sea", "Ocean", "River", "Lake", "Pond", "Swamp",
                "Forest", "Hello", "Mountain", "Valley", "Plain", "Desert", "Jungle", "Savannah", "Volleyball", "Tundra",
                "Glacier", "Snow", "Rain", "Sun", "Cloud", "Wind", "Storm", "Hurricane", "Tornado", "Earthquake",
                "Tsunami", "Volcano", "Eruption", "Sky"
            };

            var sameWordsFrenchEnglish = frenchWords.Intersect(englishWords).ToList();
            foreach (var word in sameWordsFrenchEnglish)
            {
                Console.WriteLine(word);
            }

            //partie 4
            List<Movie> frenchMovies = new List<Movie>()
            {
                new Movie() { Title = "Le fabuleux destin d'Amélie Poulain", Genre = "Comédie", Rating = 8.3, Year = 2001, LanguageOptions = new string[] {"Français", "English"}, StreamingPlatforms = new string[] {"Netflix", "Hulu"} },
                new Movie() { Title = "Intouchables", Genre = "Comédie", Rating = 8.5, Year = 2011, LanguageOptions = new string[] {"Français"}, StreamingPlatforms = new string[] {"Netflix", "Amazon"} },
                new Movie() { Title = "The Matrix", Genre = "Science-Fiction", Rating = 8.7, Year = 1999, LanguageOptions = new string[] {"English", "Español"}, StreamingPlatforms = new string[] {"Hulu", "Amazon"} },
                new Movie() { Title = "La Vie est belle", Genre = "Drame", Rating = 8.6, Year = 1946, LanguageOptions = new string[] {"Français", "Italiano"}, StreamingPlatforms = new string[] {"Netflix"} },
                new Movie() { Title = "Gran Torino", Genre = "Drame", Rating = 8.2, Year = 2008, LanguageOptions = new string[] {"English"}, StreamingPlatforms = new string[] {"Hulu"} },
                new Movie() { Title = "La Haine", Genre = "Drame", Rating = 8.1, Year = 1995, LanguageOptions = new string[] {"Français"}, StreamingPlatforms = new string[] {"Netflix"} },
                new Movie() { Title = "Oldboy", Genre = "Thriller", Rating = 8.4, Year = 2003, LanguageOptions = new string[] {"Coréen", "English"}, StreamingPlatforms = new string[] {"Amazon"} }
            };

            //Filtrer les films qui ne sont pas du genre "Comédie" or "Drame".
            var notComedyOrDrama = frenchMovies.Where(m => m.Genre != "Comédie" && m.Genre != "Drame").ToList();

            //Identifier les films dont le rating est inférieur à 7.
            var ratingLessThan7 = frenchMovies.Where(m => m.Rating < 7).ToList();

            //Afficher les films réalisés avant 2000.
            var before2000 = frenchMovies.Where(m => m.Year < 2000).ToList();

            //Trouver les films qui n'ont pas de doublage en français.
            var noFrenchDubbing = frenchMovies.Where(m => !m.LanguageOptions.Contains("Français")).ToList();

            //Identifier les films non présents sur netflix
            var notOnNetflix = frenchMovies.Where(m => !m.StreamingPlatforms.Contains("Netflix")).ToList();

            //tout les filtres précédents
            var allFilters = frenchMovies.Where(m => m.Genre != "Comédie" && m.Genre != "Drame" && m.Rating < 7 && m.Year < 2000 && !m.LanguageOptions.Contains("Français") && !m.StreamingPlatforms.Contains("Netflix")).ToList();


            // partie 5

            List<ComputerHardware> computerHardware = new List<ComputerHardware>() 
            {
                new ComputerHardware() { Name = "Intel Core i7-9700K", Type = "CPU", Price = 400, ClockSpeed = 3.6, Cores = 8, Brand = "Intel" },
                new ComputerHardware() { Name = "AMD Ryzen 9 5950X", Type = "CPU", Price = 700, ClockSpeed = 3.4, Cores = 16, Brand = "AMD" },
                new ComputerHardware() { Name = "NVIDIA GeForce RTX 3080", Type = "GPU", Price = 700, ClockSpeed = 1.7, Cores = 8704, Brand = "NVIDIA" },
                new ComputerHardware() { Name = "AMD Radeon RX 6800 XT", Type = "GPU", Price = 650, ClockSpeed = 2.0, Cores = 72, Brand = "AMD" },
                new ComputerHardware() { Name = "Intel Core i5-10400", Type = "CPU", Price = 200, ClockSpeed = 2.9, Cores = 6, Brand = "Intel" },
                new ComputerHardware() { Name = "AMD Ryzen 5 5600X", Type = "CPU", Price = 300, ClockSpeed = 3.7, Cores = 6, Brand = "AMD" },
                new ComputerHardware() { Name = "NVIDIA GeForce RTX 3060 Ti", Type = "GPU", Price = 400, ClockSpeed = 1.6, Cores = 4864, Brand = "NVIDIA" },
                new ComputerHardware() { Name = "AMD Radeon RX 6700 XT", Type = "GPU", Price = 400, ClockSpeed = 2.4, Cores = 40, Brand = "AMD" },
                new ComputerHardware() { Name = "Intel Core i9-11900K", Type = "CPU", Price = 500, ClockSpeed = 3.2, Cores = 10, Brand = "Intel" },
                new ComputerHardware() { Name = "AMD Ryzen 7 5800X", Type = "CPU", Price = 350, ClockSpeed = 3.9, Cores = 8, Brand = "AMD" },
                new ComputerHardware() { Name = "NVIDIA GeForce RTX 3090", Type = "GPU", Price = 1500, ClockSpeed = 1.4, Cores = 10496, Brand = "NVIDIA" },
                new ComputerHardware() { Name = "AMD Radeon RX 6900 XT", Type = "GPU", Price = 1000, ClockSpeed = 2.0, Cores = 80, Brand = "AMD" },
                new ComputerHardware() { Name = "Intel Core i3-10100", Type = "CPU", Price = 150, ClockSpeed = 3.6, Cores = 4, Brand = "Intel" },
                new ComputerHardware() { Name = "AMD Ryzen 3 5600X", Type = "CPU", Price = 250, ClockSpeed = 3.6, Cores = 6, Brand = "AMD" },
                new ComputerHardware() { Name = "NVIDIA GeForce RTX 3070", Type = "GPU", Price = 500, ClockSpeed = 1.5, Cores = 5888, Brand = "NVIDIA" },
                new ComputerHardware() { Name = "AMD Radeon RX 6700", Type = "GPU", Price = 350, ClockSpeed = 2.3, Cores = 36, Brand = "AMD" },
                new ComputerHardware() { Name = "Intel Core i9-9900K", Type = "CPU", Price = 450, ClockSpeed = 3.2, Cores = 8, Brand = "Intel" },
                new ComputerHardware() { Name = "AMD Ryzen 7 3700X", Type = "CPU", Price = 300, ClockSpeed = 3.6, Cores = 8, Brand = "AMD" },
                new ComputerHardware() { Name = "NVIDIA GeForce RTX 3080 Ti", Type = "GPU", Price = 1200, ClockSpeed = 1.6, Cores = 5888, Brand = "NVIDIA" },
                new ComputerHardware() { Name = "AMD Radeon RX 6800", Type = "GPU", Price = 600, ClockSpeed = 1.8, Cores = 64, Brand = "AMD" }
            };
            //Les pièces n'étaint pas des "centre de calculs"
            var notCpu = computerHardware.Where(h => h.Type != "CPU").ToList();

            //Les pièces qui dépassent un prix de 500
            var priceOver500 = computerHardware.Where(h => h.Price > 500).ToList();

            //Les CPUs mauvais pour jouer (qui ont une horloge < 3ghz et moins que 4 coeurs).
            var badCpu = computerHardware.Where(h => h.Type == "CPU" && h.ClockSpeed < 3 && h.Cores < 4).ToList();

            //Les configs potables : Les GPUs qui ont au moins 32 coeurs et les CPUs avec au moins 8 coeurs.
            var goodConfig = computerHardware.Where(h => (h.Type == "GPU" && h.Cores >= 32) || (h.Type == "CPU" && h.Cores >= 8)).ToList();

            //Les configs AMD
            var amdConfig = computerHardware.Where(h => h.Brand == "AMD").ToList();

        }
    }
}
