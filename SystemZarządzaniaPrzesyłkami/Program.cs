namespace SystemZarządzaniaPrzesyłkami {

    // Interfejs Paczka - definiuje metodę Spakuj
    public interface IPaczka {
        void Spakuj(); // Metoda Spakuj
    }

    // Interfejs Kurier - definiuje metodę Dostarcz
    public interface IKurier {
        void Dostarcz(); // Metoda Dostarcz
    }

    // Klasa MałaPaczka - implementuje interfejs IPaczka
    public class MałaPaczka : IPaczka {
        // Implementacja metody Spakuj dla klasy MałaPaczka
        public void Spakuj() {
            Console.WriteLine("Spakowano małą paczkę."); // Wyświetlenie komunikatu o spakowaniu małej paczki
        }
    }

    // Klasa DużaPaczka - implementuje interfejs IPaczka
    public class DużaPaczka : IPaczka {
        // Implementacja metody Spakuj dla klasy DużaPaczka
        public void Spakuj() {
            Console.WriteLine("Spakowano dużą paczkę."); // Wyświetlenie komunikatu o spakowaniu dużej paczki
        }
    }

    // Klasa DHLKurier - implementuje interfejs IKurier
    public class DHLKurier : IKurier {
        // Implementacja metody Dostarcz dla klasy DHLKurier
        public void Dostarcz() {
            Console.WriteLine("Dostarczono przez kuriera DHL."); // Wyświetlenie komunikatu o dostarczeniu przez kuriera DHL
        }
    }

    // Klasa UPSKurier - implementuje interfejs IKurier
    public class UPSKurier : IKurier {
        // Implementacja metody Dostarcz dla klasy UPSKurier
        public void Dostarcz() {
            Console.WriteLine("Dostarczono przez kuriera UPS."); // Wyświetlenie komunikatu o dostarczeniu przez kuriera UPS
        }
    }

    // Interfejs IFabrykaLogistyki - definiuje metody fabryki, które tworzą paczki i kurierów
    public interface IFabrykaLogistyki {
        IPaczka UtwórzPaczkę(); // Metoda do tworzenia paczki
        IKurier UtwórzKuriera(); // Metoda do tworzenia kuriera
    }

    // Klasa FabrykaLogistykiPolska - implementuje interfejs IFabrykaLogistyki
    public class FabrykaLogistykiPolska : IFabrykaLogistyki {
        // Implementacja metody UtwórzPaczkę, która zwraca nową paczkę - DużaPaczka
        public IPaczka UtwórzPaczkę() {
            return new DużaPaczka(); // Zwraca nową instancję DużaPaczka
        }

        // Implementacja metody UtwórzKuriera, która zwraca nowego kuriera - DHLKurier
        public IKurier UtwórzKuriera() {
            return new DHLKurier(); // Zwraca nową instancję DHLKurier
        }
    }

    // Klasa FabrykaLogistykiUSA - implementuje interfejs IFabrykaLogistyki
    public class FabrykaLogistykiUSA : IFabrykaLogistyki {
        // Implementacja metody UtwórzPaczkę, która zwraca nową paczkę - MałaPaczka
        public IPaczka UtwórzPaczkę() {
            return new MałaPaczka(); // Zwraca nową instancję MałaPaczka
        }

        // Implementacja metody UtwórzKuriera, która zwraca nowego kuriera - UPSKurier
        public IKurier UtwórzKuriera() {
            return new UPSKurier(); // Zwraca nową instancję UPSKurier
        }
    }

    // Klasa ZarządzaniePrzesyłkami - zarządza procesem tworzenia paczek i kurierów
    public class ZarządzaniePrzesyłkami {
        private IFabrykaLogistyki fabrykaLogistyki; // Referencja do fabryki logistyki

        // Metoda PrzyjmijZamówienie - zarządza procesem tworzenia paczki i kuriera
        public void PrzyjmijZamówienie(string lokalizacja) {
            // Wybór fabryki na podstawie lokalizacji
            switch (lokalizacja) {
                case "Polska":
                    fabrykaLogistyki = new FabrykaLogistykiPolska(); // Ustawienie fabryki na FabrykaLogistykiPolska
                    break;
                case "USA":
                    fabrykaLogistyki = new FabrykaLogistykiUSA(); // Ustawienie fabryki na FabrykaLogistykiUSA
                    break;
                default:
                    throw new ArgumentException("Nieznana lokalizacja."); // Obsługa nieznanej lokalizacji
            }

            IPaczka paczka = fabrykaLogistyki.UtwórzPaczkę(); // Tworzenie paczki za pomocą fabryki
            IKurier kurier = fabrykaLogistyki.UtwórzKuriera(); // Tworzenie kuriera za pomocą fabryki

            paczka.Spakuj(); // Wywołanie metody Spakuj dla paczki
            kurier.Dostarcz(); // Wywołanie metody Dostarcz dla kuriera
        }
    }

    // Klasa główna programu
    public class Program {
        // Metoda główna programu
        public static void Main() {
            ZarządzaniePrzesyłkami zarzadzanie = new ZarządzaniePrzesyłkami(); // Inicjalizacja klasy ZarządzaniePrzesyłkami

            zarzadzanie.PrzyjmijZamówienie("Polska"); // Przyjęcie zamówienia z Polski
            zarzadzanie.PrzyjmijZamówienie("USA"); // Przyjęcie zamówienia z USA
        }
    }
}