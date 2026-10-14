using System.Diagnostics;

List<string> talia = new List<string>()
{
    "AC", "AD", "AH", "AS",
    "KC", "KD", "KH", "KS",
    "QC", "QD", "QH", "QS",
    "JC", "JD", "JH", "JS",
    "10C", "10D", "10H", "10S",
    "9C", "9D", "9H", "9S",
    "8C", "8D", "8H", "8S",
    "7C", "7D", "7H", "7S",
    "6C", "6D", "6H", "6S",
    "5C", "5D", "5H", "5S",
    "4C", "4D", "4H", "4S",
    "3C", "3D", "3H", "3S",
    "2C", "2D", "2H", "2S"
};
List<string> rekaGracza = new List<string>();
List<string> rekaKrupiera = new List<string>();
Random rnd = new Random();
int liczba = 0;
liczba = rnd.Next(0, talia.Count);
rekaGracza.Add(talia[liczba]);
talia.RemoveAt(liczba);
liczba = rnd.Next(0, talia.Count);
rekaKrupiera.Add(talia[liczba]);
talia.RemoveAt(liczba);
liczba = rnd.Next(0, talia.Count);
rekaGracza.Add(talia[liczba]);
talia.RemoveAt(liczba);
liczba = rnd.Next(0, talia.Count);
rekaKrupiera.Add(talia[liczba]);
talia.RemoveAt(liczba);
Console.WriteLine(string.Join(" ", rekaGracza));

//sumowanie ręki
static int WartoscKarty(string karta)
{
    string figura = karta.Substring(0, karta.Length - 1);

    switch (figura)
    {
        case "A":
            return 11;
        case "K":
        case "Q":
        case "J":
            return 10;
        default:
            return int.Parse(figura);
    }
}

int suma = 0;
foreach (string karta in rekaGracza)
{
    suma += WartoscKarty(karta);
}

Console.WriteLine($"Suma pkt: {suma}");
if (suma == 21)
{
    Console.WriteLine("BLACK JACK");
    return;
}

while (suma <= 21)
{
    Console.WriteLine("Stand/Hit?");
    string wybor = Console.ReadLine()!;
    if (wybor == "Stand")
    {
        return;
    }
    else
    {
        liczba = rnd.Next(0, talia.Count);
        rekaGracza.Add(talia[liczba]);
        talia.RemoveAt(liczba);
        Console.WriteLine(string.Join(" ", rekaGracza));
        suma = 0;
        foreach (string karta in rekaGracza)
        {
            suma += WartoscKarty(karta);
        }

        Console.WriteLine($"Suma pkt: {suma}");
        if (suma > 21)
        {
            Console.WriteLine("BUSTED");
        }
    }
}
//Dodać rywalizacje z krupierem
//Dodać endless mode