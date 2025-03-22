using System;
using System.Collections;
using System.Collections.Generic;

// Klasa Ciasto - reprezentuje ciasto, czyli nazwę, rodzaj i składniki
public class Ciasto
{
    public string Nazwa { get; set; } // Nazwa ciasta
    public string Rodzaj { get; set; } // Rodzaj ciasta
    public List<string> Skladniki { get; set; } // Lista składników ciasta

    // Konstruktor klasy Ciasto - inicjalizuje właściwości nazwa, rodzaj i składniki
    public Ciasto(string nazwa, string rodzaj, List<string> skladniki)
    {
        Nazwa = nazwa; // Ustawia nazwę ciasta
        Rodzaj = rodzaj; // Ustawia rodzaj ciasta
        Skladniki = skladniki; // Ustawia składniki ciasta
    }
}

// Interfejs IFabrykaCiasta - definiuje metodę, która tworzy ciasto
public interface IFabrykaCiasta
{
    Ciasto StwórzCiasto(); // Metoda do tworzenia ciasta
}

// Klasa FabrykaCiastaCzekoladowego - implementuje interfejs IFabrykaCiasta
public class FabrykaCiastaCzekoladowego : IFabrykaCiasta
{
    // Metoda do tworzenia ciasta czekoladowego
    public Ciasto StwórzCiasto()
    {
        var skladniki = new List<string> { "Czekolada", "Mąka", "Jajka", "Masło" }; // Składniki ciasta czekoladowego
        return new Ciasto("Czekoladowe", "Kruche", skladniki); // Zwraca nowe ciasto czekoladowe
    }
}

// Klasa FabrykaCiastaJabłkowego - implementuje interfejs IFabrykaCiasta
public class FabrykaCiastaJabłkowego : IFabrykaCiasta
{
    // Metoda do tworzenia ciasta jabłkowego
    public Ciasto StwórzCiasto()
    {
        var skladniki = new List<string> { "Jabłka", "Cynamon", "Mąka", "Cukier" }; // Składniki ciasta jabłkowego
        return new Ciasto("Jabłkowe", "Drożdżowe", skladniki); // Zwraca nowe ciasto jabłkowe
    }
}

// Klasa PlanPieczenia - reprezentuje plan pieczenia ciast
public class PlanPieczenia : IEnumerable<Ciasto>
{
    private List<Ciasto> ciasta = new List<Ciasto>(); // Lista ciast w planie pieczenia

    // Metoda do dodawania ciasta do planu pieczenia
    public void DodajCiasto(IFabrykaCiasta fabryka)
    {
        Ciasto ciasto = fabryka.StwórzCiasto(); // Tworzy ciasto za pomocą fabryki
        ciasta.Add(ciasto); //Dodaje ciasto do listy ciast
    }

    // Metoda do wyświetlania planu pieczenia
    public void WyświetlPlan()
    {
        foreach (var ciasto in ciasta) // Iteruje przez wszystkie ciasta w planie
        {
            // Wyświetla nazwę, rodzaj i składniki ciasta
            Console.WriteLine($"Nazwa: {ciasto.Nazwa}, Rodzaj: {ciasto.Rodzaj}, Składniki: {string.Join(", ", ciasto.Skladniki)}");
        }
    }

    // Implementacja interfejsu IEnumerable<Ciasto>
    public IEnumerator<Ciasto> GetEnumerator()
    {
        return ciasta.GetEnumerator(); // Zwraca enumerator dla listy ciast
    }

    // Implementacja interfejsu IEnumerable
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator(); // Zwraca enumerator dla listy ciast
    }
}

// Klasa główna programu
class Program
{   
    // Metoda główna programu
    static void Main(string[] args)
    {
        var planPieczenia = new PlanPieczenia(); // Tworzy nowy plan pieczenia

        var fabrykaCzekoladowego = new FabrykaCiastaCzekoladowego(); // Tworzy fabrykę ciasta czekoladowego
        var fabrykaJabłkowego = new FabrykaCiastaJabłkowego(); // Tworzy fabrykę ciasta jabłkowego

        planPieczenia.DodajCiasto(fabrykaCzekoladowego); // Dodaje ciasto czekoladowe do planu pieczenia
        planPieczenia.DodajCiasto(fabrykaJabłkowego); // Dodaje ciasto jabłkowe do planu pieczenia
 
        Console.WriteLine("Plan pieczenia:"); // Wyświetla nagłówek dla planu pieczenia
        planPieczenia.WyświetlPlan(); // Wywołuje metodę do wyświetlania planu pieczenia
    }
}