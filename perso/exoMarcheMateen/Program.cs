using IronXL;
namespace exoMarcheMateen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var excelMarche = WorkBook.Load("C:\\Users\\pq40rdc\\Documents\\GitHub\\323-Programmation_fonctionnelle\\exos\\marché\\exoMarcheMateen\\Place_du_marché.xlsx");

            var feuille = excelMarche.WorkSheets[1];

            var marches = new List<Marche>();

            for (int row = 1; row < feuille.RowCount; row++)
            {
                var marche = new Marche
                {
                    Emplacement = int.Parse(feuille.GetCellAt(row, 0).Text),
                    Producteur = feuille.GetCellAt(row, 1).Text,
                    Produit = feuille.GetCellAt(row, 2).Text,
                    Quantité = int.Parse(feuille.GetCellAt(row, 3).Text),
                    Unité = feuille.GetCellAt(row, 4).Text,
                    PrixParUnite = decimal.Parse(feuille.GetCellAt(row, 5).Text)
                };
                marches.Add(marche);
            }

            //foreach(var marche in marches)
            //{
            //    Console.WriteLine(marche.Emplacement);
            //}

            var anon = marches.Select(marche =>
                marche.Producteur.Length > 3
                    ? marche.Producteur.Substring(0, 3) + "..." + marche.Producteur.Substring(marche.Producteur.Length - 1, 1)
                    : marche.Producteur).Distinct().ToList();

            foreach (var marche in anon)
            {
                Console.WriteLine(marche);
            }
        }
    }
}