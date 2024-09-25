using System.IO;

int nbFolders = 0;

// Fonction impure

int NbFiles(string path)
{
    if (!Directory.Exists(path)) return 0;

    int res = Directory.GetFiles(path).Count();

    string[] subdirs = Directory.GetDirectories(path);

    nbFolders += subdirs.Length; // <----- EFFET DE BORD = impureté

    foreach (string subdir in subdirs)
    {
        res += NbFiles(subdir);
    }
    return res;
}

// Fonction pure

Tuple<int,int> PureNbFiles(string path)
{
    if (!Directory.Exists(path)) return new Tuple<int, int>(0, 0);

    string[] subdirs = Directory.GetDirectories(path);
    int nbFolders = subdirs.Length;
    int nbFiles = Directory.GetFiles(path).Count();

    foreach (string subdir in subdirs)
    {
        Tuple<int,int> subRes = PureNbFiles(subdir);
        nbFiles += subRes.Item1;
        nbFolders += subRes.Item2;
    }
    return new Tuple<int, int>(nbFiles,nbFolders);
}

Console.Write("Dossier: ");
string selectedDir = Console.ReadLine();
Tuple<int,int> res = PureNbFiles(selectedDir);

if (Directory.Exists(selectedDir))
{
    Console.WriteLine($"{selectedDir} contient {NbFiles(selectedDir)} fichiers et {nbFolders} dossiers");
    Console.WriteLine($"{selectedDir} contient {res.Item1} fichiers et {res.Item2} dossiers");
}
else
{
    Console.WriteLine("Ce dossier n'existe pas");
}

Console.ReadKey();
