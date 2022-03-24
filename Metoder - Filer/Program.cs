using System;
using System.IO;
using Helpers;

internal class Program
{
    static void Main(string[] args)
    {


        #region Exercise 1, 2 & 3

        // Create text file
        string hanShotFirst = "Han shot first.";
        File.WriteAllText(@".\StarWars.txt", hanShotFirst);

        // Read text file
        string content = File.ReadAllText(@".\StarWars.txt");
        Console.WriteLine(content);

        // Delete text file
        File.Delete(@".\StarWars.txt");

        Console.ReadKey();

        #endregion

        #region Exercise 4, 5 & 6

        Console.Clear();

        // Create new directory
        Directory.CreateDirectory(@".\Droids");
        File.WriteAllText(@".\Droids\R2D2.txt", "beep, boop");

        // Delete directory recursively, (i.e. all sub-directories and files).
        Directory.Delete(@".\Droids", true);

        // Read and enumerate all files in directory
        Directory.CreateDirectory(@".\Droids\Astromech");
        Directory.CreateDirectory(@".\Droids\Protocol");
        File.WriteAllText(@".\Droids\Astromech\R2D2.txt", "beep boop");
        File.WriteAllText(@".\Droids\Protocol\CP30.txt", "sir!");

        string[] files = Directory.GetFiles(@".\Droids", "*.txt", SearchOption.AllDirectories);

        for (int i = 0; i < files.Length; i++) 
        {
            Console.WriteLine(files[i]);
        }

        Console.ReadKey();

        #endregion

        #region Exercise 7 & 8

        Console.Clear();

        // Read from filestream
        File.WriteAllText(@".\Movies.txt", "Star Wars\nThe Empire Strikes Back\nReturn of the Jedi");

        FileStream file = new FileStream(@".\Movies.txt", FileMode.Open);
        StreamReader reader = new StreamReader(file);

        while (!reader.EndOfStream)
        {
            string movie = reader.ReadLine();
            Console.WriteLine(movie);
        }

        reader.Close();

        // Write to filestream
        List<string> actors = new List<string>()
        {
            "Mark Hamill",
            "Harrison Ford",
            "Carrie Fisher"
        };

        FileStream newFile = new FileStream(@".\Movies.txt", FileMode.Create);
        StreamWriter writer = new StreamWriter(newFile);

        foreach (string actor in actors)
        {
            writer.WriteLine(actor);
        }

        writer.Close();

        #endregion
    }
}