using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

// Definicja klasy bazowej Osoba
[Serializable]
public class Osoba
{
    public string Imie { get; set; } // Właściwość reprezentująca imię osoby
    public string Nazwisko { get; set; } // Właściwość reprezentująca nazwisko osoby
    public int Wiek { get; set; } // Właściwość reprezentująca wiek osoby
    public DateTime DataUrodzenia { get; set; } // Właściwość reprezentująca datę urodzenia osoby

    public Osoba() { } // Domyślny konstruktor bezparametrowy wymagany do serializacji

    public Osoba(string imie, string nazwisko, int wiek, DateTime dataUrodzenia)
    {
        Imie = imie; // Inicjalizacja pola Imie
        Nazwisko = nazwisko; // Inicjalizacja pola Nazwisko
        Wiek = wiek; // Inicjalizacja pola Wiek
        DataUrodzenia = dataUrodzenia; // Inicjalizacja pola DataUrodzenia
    }
}

// Definicja klasy pochodnej Student dziedziczącej po klasie Osoba
[Serializable]
public class Student : Osoba
{
    public string NumerIndeksu { get; set; } // Właściwość reprezentująca numer indeksu studenta
    public string NumerGrupy { get; set; } // Właściwość reprezentująca numer grupy studenta

    public Student() { } // Domyślny konstruktor bezparametrowy wymagany do serializacji

    public Student(string imie, string nazwisko, int wiek, DateTime dataUrodzenia, string numerIndeksu, string numerGrupy)
        : base(imie, nazwisko, wiek, dataUrodzenia) // Wywołanie konstruktora klasy bazowej
    {
        NumerIndeksu = numerIndeksu; // Inicjalizacja pola NumerIndeksu
        NumerGrupy = numerGrupy; // Inicjalizacja pola NumerGrupy
    }
}

// Klasa główna programu
class Program
{
    // Metoda główna programu
    static void Main()
    {
        // Tworzymy przykładowe obiekty klasy Osoba
        List<Osoba> osoby = new List<Osoba>
        {
            new Osoba("Jan", "Kowalski", 30, new DateTime(1994, 5, 15)), // Tworzenie pierwszej osoby
            new Osoba("Anna", "Nowak", 25, new DateTime(1999, 3, 10)), // Tworzenie drugiej osoby
            new Osoba("Adam", "Wiśniewski", 40, new DateTime(1984, 11, 23)), // Tworzenie trzeciej osoby
            new Osoba("Julia", "Kwaśniewska", 30, new DateTime(1994, 11, 23)) // Tworzenie czwartej osoby
        };

        // Tworzymy przykładowe obiekty klasy Student
        List<Student> studenci = new List<Student>
        {
            new Student("Marek", "Kowalczyk", 22, new DateTime(2002, 7, 12), "12345", "INF-1"), // Tworzenie pierwszego studenta
            new Student("Alicja", "Zielińska", 21, new DateTime(2003, 4, 18), "67890", "INF-2"), // Tworzenie drugiego studenta
            new Student("Piotr", "Dąbrowski", 23, new DateTime(2001, 9, 5), "54321", "INF-3"), // Tworzenie trzeciego studenta
            new Student("Karolina", "Lewandowska", 20, new DateTime(2004, 2, 28), "09876", "INF-1") // Tworzenie czwartego studenta
        };

        // Ścieżki plików dla klasy Osoba
        string xmlFilePathOsoby = "osoby.xml"; // Ścieżka do pliku XML dla osób
        string jsonFilePathOsoby = "osoby.json"; // Ścieżka do pliku JSON dla osób

        // Ścieżki plików dla klasy Student
        string xmlFilePathStudenci = "studenci.xml"; // Ścieżka do pliku XML dla studentów
        string jsonFilePathStudenci = "studenci.json"; // Ścieżka do pliku JSON dla studentów

        // Serializacja osób do XML
        XmlSerializer xmlSerializerOsoby = new XmlSerializer(typeof(List<Osoba>)); // Utworzenie serializatora XML dla listy osób
        using (FileStream fs = new FileStream(xmlFilePathOsoby, FileMode.Create))
        {
            xmlSerializerOsoby.Serialize(fs, osoby); // Serializacja listy osób do formatu XML
        }
        Console.WriteLine("Obiekty zostały zserializowane do pliku 'osoby.xml'."); // Informacja o wykonanej operacji

        // Serializacja osób do JSON
        JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true }; // Opcje formatowania JSON
        string jsonStringOsoby = JsonSerializer.Serialize(osoby, options); // Serializacja listy osób do ciągu JSON
        File.WriteAllText(jsonFilePathOsoby, jsonStringOsoby); // Zapisanie ciągu JSON do pliku
        Console.WriteLine("Obiekty zostały zserializowane do pliku 'osoby.json'."); // Informacja o wykonanej operacji

        // Serializacja studentów do XML
        XmlSerializer xmlSerializerStudenci = new XmlSerializer(typeof(List<Student>)); // Utworzenie serializatora XML dla listy studentów
        using (FileStream fs = new FileStream(xmlFilePathStudenci, FileMode.Create))
        {
            xmlSerializerStudenci.Serialize(fs, studenci); // Serializacja listy studentów do formatu XML
        }
        Console.WriteLine("Obiekty zostały zserializowane do pliku 'studenci.xml'."); // Informacja o wykonanej operacji

        // Serializacja studentów do JSON
        string jsonStringStudenci = JsonSerializer.Serialize(studenci, options); // Serializacja listy studentów do ciągu JSON
        File.WriteAllText(jsonFilePathStudenci, jsonStringStudenci); // Zapisanie ciągu JSON do pliku
        Console.WriteLine("Obiekty zostały zserializowane do pliku 'studenci.json'."); // Informacja o wykonanej operacji

        // Deserializacja osób z XML
        List<Osoba> osobyFromXml;
        using (FileStream fs = new FileStream(xmlFilePathOsoby, FileMode.Open))
        {
            osobyFromXml = (List<Osoba>)xmlSerializerOsoby.Deserialize(fs); // Deserializacja listy osób z pliku XML
        }

        Console.WriteLine("\nDane wczytane z pliku XML:"); // Nagłówek dla wyświetlanych danych
        foreach (var osoba in osobyFromXml)
        {
            Console.WriteLine($"Imię: {osoba.Imie}, Nazwisko: {osoba.Nazwisko}, Wiek: {osoba.Wiek}"); // Wyświetlenie danych każdej osoby
        }

        // Deserializacja osób z JSON
        string readJsonOsoby = File.ReadAllText(jsonFilePathOsoby); // Odczytanie zawartości pliku JSON
        List<Osoba> osobyFromJson = JsonSerializer.Deserialize<List<Osoba>>(readJsonOsoby); // Deserializacja listy osób z ciągu JSON

        Console.WriteLine("\nDane wczytane z pliku JSON:"); // Nagłówek dla wyświetlanych danych
        foreach (var osoba in osobyFromJson)
        {
            Console.WriteLine($"Imię: {osoba.Imie}, Nazwisko: {osoba.Nazwisko}, Wiek: {osoba.Wiek}"); // Wyświetlenie danych każdej osoby
        }

        // Deserializacja studentów z XML
        List<Student> studenciFromXml;
        using (FileStream fs = new FileStream(xmlFilePathStudenci, FileMode.Open))
        {
            studenciFromXml = (List<Student>)xmlSerializerStudenci.Deserialize(fs); // Deserializacja listy studentów z pliku XML
        }

        Console.WriteLine("\nStudenci wczytani z pliku XML:"); // Nagłówek dla wyświetlanych danych studentów
        foreach (var student in studenciFromXml)
        {
            Console.WriteLine($"Imię: {student.Imie}, Nazwisko: {student.Nazwisko}, Wiek: {student.Wiek}, " +
                            $"Numer Indeksu: {student.NumerIndeksu}, Grupa: {student.NumerGrupy}"); // Wyświetlenie danych każdego studenta
        }

        // Deserializacja studentów z JSON
        string readJsonStudenci = File.ReadAllText(jsonFilePathStudenci); // Odczytanie zawartości pliku JSON
        List<Student> studenciFromJson = JsonSerializer.Deserialize<List<Student>>(readJsonStudenci); // Deserializacja listy studentów z ciągu JSON

        Console.WriteLine("\nStudenci wczytani z pliku JSON:"); // Nagłówek dla wyświetlanych danych studentów
        foreach (var student in studenciFromJson)
        {
            Console.WriteLine($"Imię: {student.Imie}, Nazwisko: {student.Nazwisko}, Wiek: {student.Wiek}, " +
                            $"Numer Indeksu: {student.NumerIndeksu}, Grupa: {student.NumerGrupy}"); // Wyświetlenie danych każdego studenta
        }
    }
}
