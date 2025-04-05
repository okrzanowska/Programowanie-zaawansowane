namespace SystemObsługującyProdukcjęPaczek {

    // Interfejs Paczka - definiuje metodę Przygotuj
    public interface IPaczka
    {
        void Przygotuj(); // Metoda do przygotowania paczki
    }

    // Klasa MałaPaczka - implementuje interfejs IPaczka
    public class MałaPaczka : IPaczka
    {
        // Implementacja metody Przygotuj dla klasy MałaPaczka
        public void Przygotuj()
        {
            Console.WriteLine("Przygotowano małą paczkę."); // Wyświetla komunikat o przygotowaniu małej paczki
        }
    }

    // Klasa DużaPaczka - implementuje interfejs IPaczka
    public class DużaPaczka : IPaczka
    {
        // Implementacja metody Przygotuj dla klasy DużaPaczka
        public void Przygotuj()
        {
            Console.WriteLine("Przygotowano dużą paczkę."); // Wyświetla komunikat o przygotowaniu dużej paczki
        }
    }

    // Interfejs IFabrykaPaczek - definiuje metodę fabryki, która tworzy paczki
    public interface IFabrykaPaczek
    {
        IPaczka UtwórzPaczkę(); // Metoda do tworzenia paczki
    }

    // Klasa FabrykaMałychPaczek - implementuje interfejs IFabrykaPaczek
    public class FabrykaMałychPaczek : IFabrykaPaczek
    {
        // Implementacja metody UtwórzPaczkę, która zwraca nową paczkę - MałąPaczkę
        public IPaczka UtwórzPaczkę()
        {
            return new MałaPaczka(); // Zwraca nową MałąPaczkę
        }
    }

    // Klasa FabrykaDużychPaczek - implementuje interfejs IFabrykaPaczek
    public class FabrykaDużychPaczek : IFabrykaPaczek
    {
        // Implementacja metody UtwórzPaczkę, która zwraca nową paczkę - DużąPaczkę
        public IPaczka UtwórzPaczkę()
        {
            return new DużaPaczka(); // Zwraca nową DużąPaczkę
        }
    }

    // Klasa ZarządzaniePaczkami - Singleton zarządzający procesem produkcji paczek
    public class ZarządzaniePaczkami
    {
        private IFabrykaPaczek fabrykaPaczek; // Referencja do fabryki paczek
        private static ZarządzaniePaczkami _instancja; // Pole przechowujące jedyną instancję klasy

        // Prywatny konstruktor - ogranicza tworzenie instancji z zewnątrz
        private ZarządzaniePaczkami() { }

        // Właściwość Instancja - umożliwia dostęp do jedynej instancji klasy
        public static ZarządzaniePaczkami Instancja
        {
            get
            {
                // Tworzenie instancji tylko w razie potrzeby
                if (_instancja == null)
                {
                    _instancja = new ZarządzaniePaczkami();
                }
                return _instancja; // Zwraca jedyną instancję klasy
            }
        }

        // Metoda UstawFabrykę - pozwala na ustawienie konkretnej fabryki paczek
        public void UstawFabrykę(IFabrykaPaczek fabryka)
        {
            fabrykaPaczek = fabryka; // Przypisanie fabryki paczek
        }

        // Metoda ProdukujPaczkę - zarządza procesem produkcji paczki
        public void ProdukujPaczkę()
        {
            // Sprawdzenie, czy fabryka paczek jest ustawiona
            if (fabrykaPaczek != null)
            {
                IPaczka paczka = fabrykaPaczek.UtwórzPaczkę(); // Tworzenie paczki za pomocą fabryki
                paczka.Przygotuj(); // Wywołanie metody przygotowującej paczkę
            }
            else
            {
                Console.WriteLine("Fabryka paczek nie jest ustawiona."); // Wyświetla komunikat o braku fabryki
            }
        }
    }

    // Klasa główna programu
    public class Program
    {
        // Metoda główna programu
        public static void Main(string[] args)
        {
            // Inicjalizacja Singletona
            ZarządzaniePaczkami zarządzaniePaczkami = ZarządzaniePaczkami.Instancja;

            // Ustawienie fabryki na FabrykaMałychPaczek
            zarządzaniePaczkami.UstawFabrykę(new FabrykaMałychPaczek());
            zarządzaniePaczkami.ProdukujPaczkę(); // Wywołanie produkcji małej paczki

            // Ustawienie fabryki na FabrykaDużychPaczek
            zarządzaniePaczkami.UstawFabrykę(new FabrykaDużychPaczek());
            zarządzaniePaczkami.ProdukujPaczkę(); // Wywołanie produkcji dużej paczki
        }
    }
}