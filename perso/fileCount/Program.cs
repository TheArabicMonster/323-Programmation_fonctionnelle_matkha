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

        var result = CountFileAndDir(dossierPath);
        Console.WriteLine($"Nombre de fichiers : {result.FileCount}");
        Console.WriteLine($"Nombre de dossiers : {result.DirCount}");
    }

    static (int FileCount, int DirCount) CountFileAndDir(string repo)
    {
        int fileCount = Directory.GetFiles(repo).Length;
        int dirCount = Directory.GetDirectories(repo).Length;

        foreach (string subDir in Directory.GetDirectories(repo))
        {
            var subResult = CountFileAndDir(subDir);
            fileCount += subResult.FileCount;
            dirCount += subResult.DirCount;
        }

        return (fileCount, dirCount);
    }
}
