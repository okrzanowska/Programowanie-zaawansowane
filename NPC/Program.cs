namespace NPC {

    //Interfejs NPC - posiada metodę PrzedstawSię
    public interface INPC {
        void PrzedstawSię(); //Metoda PrzedstawSię
    }

    // Klasa Wojownik - implementuje interfejs INPC
    public class Wojownik : INPC {
        //Implementacja metody PrzedstawSię dla klasy Wojownik
        public void PrzedstawSię() {
            Console.WriteLine("Jestem Wojownikiem, walczę mieczem"); // Wyświetla przedstawienie Wojownika
        }
    }

    // Klasa Mag - implementuje interfejs INPC
    public class Mag : INPC {
        // Implementacja metody PrzedstawSię dla klasy Mag
        public void PrzedstawSię() {
            Console.WriteLine("Jestem Magiem, władającym magią żywiołów"); // Wyświetla przedstawienie Maga
        }
    }
    // Klasa Złodziej - implementuje interfejs INPC
    public class Złodziej : INPC {
        // Implementacja metody PrzedstawSię dla klasy Złodziej
        public void PrzedstawSię() {
            Console.WriteLine("Jestem Złodziejem, nie mam atrybutów"); // Wyświetla przedstawienie Złodzieja
        }
    }

    // Interfejs IFabrykaNPC - definiuje metodę fabryki, która tworzy NPC
    public interface IFabrykaNPC {
        INPC StwórzNPC(); // Metoda do tworzenia NPC
    }

    // Klasa FabrykaWojownika - implementuje interfejs IFabrykaNPC
    public class FabrykaWojownika : IFabrykaNPC {
        // Implementacja metody StwórzNPC, która zwraca nowego NPC - Wojownika
        public INPC StwórzNPC() {
            return new Wojownik(); // Zwraca nowego Wojownika
        }
    }

    // Klasa FabrykaMaga - implementuje interfejs IFabrykaNPC
    public class FabrykaMaga : IFabrykaNPC {
        // Implementacja metody StwórzNPC, która zwraca nowego NPC - Maga
        public INPC StwórzNPC() {
            return new Mag(); // Zwraca nowego Maga
        }
    }

    // Klasa FabrykaZłodzieja - implementuje interfejs IFabrykaNPC
    public class FabrykaZłodzieja : IFabrykaNPC {
        // Implementacja metody StwórzNPC, która zwraca nowego NPC - Złodzieja
        public INPC StwórzNPC() {
            return new Złodziej(); // Zwraca nowego Złodzieja
        }
    }

    // Klasa główna programu
    public class Program {
        // Metoda główna programu
        public static void Main() {
            Random random = new Random(); // Inicjalizacja generatora liczb losowych
            int typPostaci = random.Next(0, 3); // Losowanie typu postaci (0 - Wojownik, 1 - Mag, 2 - Złodziej)

            IFabrykaNPC fabryka; // Deklaracja zmiennej fabryki NPC

            // Wybór fabryki na podstawie wylosowanego typu postaci
            switch(typPostaci) {
                case 0:
                fabryka = new FabrykaWojownika(); // Ustawienie fabryki na Wojownika
                break;
                case 1:
                fabryka = new FabrykaMaga(); // Ustawienie fabryki na Maga
                break;
                case 2:
                fabryka = new FabrykaZłodzieja(); // Ustawienie fabryki na Złodzieja
                break;
                default:
                throw new Exception("Nieznany typ postaci"); // Obsługa nieznanego typu postaci
            }

            INPC npc = fabryka.StwórzNPC(); // Tworzenie NPC za pomocą wybranej fabryki
            npc.PrzedstawSię(); // Wywołanie metody przedstawiającej NPC
        }
    }
}