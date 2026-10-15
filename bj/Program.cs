using System.Diagnostics;
//tworzenie listy z kartami
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
//przypisywanie po 2 karty do ręki krupiera i gracza
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

//funkcja sumowanie ręki
static int WartoscKarty(string karta, int aktualnaSuma)
{
    string figura = karta.Substring(0, karta.Length - 1);

    switch (figura)
    {
        case "A":
            return aktualnaSuma + 11 > 21 ? 1 : 11;
        case "K":
        case "Q":
        case "J":
            return 10;
        default:
            return int.Parse(figura);
    }
}

static int SumaReki(List<string> reka)
{
    int suma = 0;

    foreach (string karta in reka)
    {
        if (!karta.StartsWith("A"))
        {
            suma += WartoscKarty(karta, suma);
        }
    }

    foreach (string karta in reka)
    {
        if (karta.StartsWith("A"))
        {
            suma += WartoscKarty(karta, suma);
        }
    }

    return suma;
}

//sumowanie i wypisanie ręki gracza
Console.WriteLine(string.Join(" ", rekaGracza));
int sumaGracza = SumaReki(rekaGracza);
Console.WriteLine($"Suma pkt gracza: {sumaGracza}\n");

//sumowanie i wypisanie ręki krupiera
Console.WriteLine(string.Join(" ", rekaKrupiera));
int sumaKrupiera = SumaReki(rekaKrupiera);
Console.WriteLine($"Suma pkt krupiera: {sumaKrupiera}\n");

//jeśli blackjack
if (sumaGracza == 21)
{
    Console.WriteLine("BLACK JACK");
    return;
}

//jeśli krupier ma blackjack
if (sumaKrupiera == 21)
{
    return;
}

//dokonywanie wyboru stand/hit
while (sumaGracza <= 21)
{
    Console.WriteLine("s/h?");
    string wybor = Console.ReadLine()!;
    if (wybor == "s")
    {
        break;
    }
    else
    {
        liczba = rnd.Next(0, talia.Count);
        rekaGracza.Add(talia[liczba]);
        talia.RemoveAt(liczba);
        Console.WriteLine(string.Join(" ", rekaGracza));
        sumaGracza = SumaReki(rekaGracza);

        Console.WriteLine($"Suma pkt gracza: {sumaGracza}");
        if (sumaGracza > 21)
        {
            Console.WriteLine("BUSTED");
            return;
        }
    }
}

//runda krupiera
while (sumaKrupiera <= 21)
{
    if (sumaKrupiera >= 17)
    {
        break;
    }
    else
    {
        liczba = rnd.Next(0, talia.Count);
        rekaKrupiera.Add(talia[liczba]);
        talia.RemoveAt(liczba);
        Console.WriteLine(string.Join(" ", rekaKrupiera));
        sumaKrupiera = SumaReki(rekaKrupiera);
        Console.WriteLine($"Suma pkt krupiera: {sumaKrupiera}");
        if (sumaKrupiera > 21)
        {
            break;
        }
    }
}

//porównywanie wyników
if (sumaKrupiera > 21)
{
    Console.WriteLine("Wygrałeś");
    return;
}
else if (sumaKrupiera > sumaGracza)
{
    Console.WriteLine("Przegrałeś");
    return;
}
else if (sumaKrupiera == sumaGracza)
{
    Console.WriteLine("Remis");
    return;
}
else
{
    Console.WriteLine("Wygrałeś");
    return;
}

//zasłonić drugą kartę krupiera
//dodać opcję double
//Dodać endless mode