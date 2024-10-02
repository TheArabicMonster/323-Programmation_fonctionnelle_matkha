using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.Write("Répertoire : ");
        string dossierPath = Console.ReadLine();

        if (!Directory.Exists(dossierPath))
        {
            Console.WriteLine("Le répertoire spécifié n'existe pas.");
            return;
        }

        CountResult result = CountFileAndDir(dossierPath);
        Console.WriteLine($"Nombre de fichiers : {result.FileCount}");
        Console.WriteLine($"Nombre de dossiers : {result.DirCount}");
    }

    static CountResult CountFileAndDir(string repo)
    {
        CountResult result = new CountResult();

        result.FileCount += Directory.GetFiles(repo).Length;

        string[] dirs = Directory.GetDirectories(repo);
        result.DirCount += dirs.Length;

        foreach (string subDir in dirs)
        {
            CountResult subResult = CountFileAndDir(subDir);
            result.FileCount += subResult.FileCount;
            result.DirCount += subResult.DirCount;
        }

        return result;
    }

    class CountResult
    {
        public int FileCount { get; set; }
        public int DirCount { get; set; }
    }
}
