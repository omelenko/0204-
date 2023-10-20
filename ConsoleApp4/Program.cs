using System;
using System.Threading;

class Program
{
    static string ukrainianAlphabet = "абвгґдеєжзиіїйклмнопрстуфхцчшщьюя";
    static void Main()
    {
        Thread thread = new Thread(new ThreadStart(() => Worker()));
        thread.Start();
        thread.Join();
        Thread thread1 = new Thread(new ThreadStart(() => Worker1()));
        thread1.Start();
        thread1.Join();
    }

    static void Worker()
    {
        for (int i = 0; i < ukrainianAlphabet.Length; i++)
        {
            if (i != ukrainianAlphabet.Length - 1)
            { Console.Write(ukrainianAlphabet[i] + ", "); }
            else
            { Console.Write(ukrainianAlphabet[i]); }
            Thread.Sleep(100);
        }
    }

    static void Worker1()
    {
        using (StreamWriter writer = new StreamWriter("TextFile1.txt"))
        {
            for (int i = 0; i < ukrainianAlphabet.Length; i++)
            {
                if (i != ukrainianAlphabet.Length - 1)
                { writer.Write(ukrainianAlphabet[i] + ", "); }
                else
                { writer.Write(ukrainianAlphabet[i]); }
                Thread.Sleep(100);
            }
        }
        string readText = File.ReadAllText("TextFile1.txt");
        Console.WriteLine("\nТекст записавний у файл");
        Console.WriteLine(readText);
    }
}
