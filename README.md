# Programowanie Zaawansowane - Ćwiczenia Laboratoryjne

Repozytorium zawiera projekty realizowane w ramach ćwiczeń laboratoryjnych z przedmiotu **Programowanie Zaawansowane**. Każdy projekt ilustruje różne aspekty programowania obiektowego i wzorców projektowych w języku C#.

## Struktura Repozytorium

- **`NPC/`**  
  Projekt ilustrujący zastosowanie wzorca projektowego **Fabryka** do tworzenia obiektów reprezentujących różne typy NPC (Non-Player Characters).  
  - **`Program.cs`**: Główna logika programu, implementacja interfejsu `INPC`, klas (`Wojownik`, `Mag`, `Złodziej`) oraz fabryk (`FabrykaWojownika`, `FabrykaMaga`, `FabrykaZłodzieja`).
  - **`NPC.csproj`**: Plik projektu .NET.

- **`Ciasto/`**  
  Projekt demonstrujący zastosowanie wzorca projektowego **Fabryka** do tworzenia obiektów reprezentujących różne rodzaje ciast.  
  - **`Program.cs`**: Główna logika programu, implementacja klas `Ciasto`, fabryk (`FabrykaCiastaCzekoladowego`, `FabrykaCiastaJabłkowego`) oraz klasy `PlanPieczenia`.
  - **`Ciasto.csproj`**: Plik projektu .NET.

- **`SystemObsługującyProdukcjęPaczek/`**  
  Projekt demonstrujący zastosowanie wzorca projektowego **Singleton** do zarządzania produkcją paczek.  
  - **`Program.cs`**: Główna logika programu, implementacja interfejsu `IPaczka`, fabryk (`FabrykaMałychPaczek`, `FabrykaDużychPaczek`) oraz klasy `ZarządzaniePaczkami`.
  - **`SystemObsługującyProdukcjęPaczek.csproj`**: Plik projektu .NET.

- **`SystemZarządzaniaPrzesyłkami/`**  
  Projekt ilustrujący zastosowanie wzorca projektowego **Fabryka Abstrakcyjna** do zarządzania przesyłkami.  
  - **`Program.cs`**: Główna logika programu, implementacja interfejsów `IPaczka`, `IKurier`, fabryk (`FabrykaLogistykiPolska`, `FabrykaLogistykiUSA`) oraz klasy `ZarządzaniePrzesyłkami`.
  - **`SystemZarządzaniaPrzesyłkami.csproj`**: Plik projektu .NET.

- **`Programowanie zaawansowane.sln`**  
  Plik rozwiązania Visual Studio, łączący wszystkie projekty (`Ciasto`, `NPC`, `SystemObsługującyProdukcjęPaczek`, `SystemZarządzaniaPrzesyłkami`).

- **`.gitignore`**  
  Plik konfiguracyjny ignorujący pliki tymczasowe i wygenerowane przez Visual Studio.

## Wymagania

- **.NET SDK 8.0**  
  Projekty są zbudowane w oparciu o platformę .NET 8.0. Upewnij się, że masz zainstalowaną odpowiednią wersję SDK.

## Jak uruchomić?

1. Sklonuj repozytorium:
   ```bash
   git clone https://github.com/okrzanowska/Programowanie-zaawansowane.git
   cd Programowanie-zaawansowane
   ```

2. Przejdź do folderu projektu:
   - Aby uruchomić projekt `NPC`, przejdź do folderu `NPC`:
     ```bash
     cd NPC
     ```
   - Aby uruchomić projekt `Ciasto`, przejdź do folderu `Ciasto`:
     ```bash
     cd Ciasto
     ```
   - Aby uruchomić projekt `SystemObsługującyProdukcjęPaczek`, przejdź do folderu `SystemObsługującyProdukcjęPaczek`:
     ```bash
     cd SystemObsługującyProdukcjęPaczek
     ```
   - Aby uruchomić projekt `SystemZarządzaniaPrzesyłkami`, przejdź do folderu `SystemZarządzaniaPrzesyłkami`:
     ```bash
     cd SystemZarządzaniaPrzesyłkami
     ```

3. Zbuduj projekt za pomocą polecenia `dotnet build`:
   ```bash
   dotnet build
   ```

4. Uruchom projekt za pomocą polecenia `dotnet run`:
   ```bash
   dotnet run
   ```

5. Aby wrócić do głównego folderu repozytorium, użyj:
   ```bash
   cd ..
   ```

## Cele Edukacyjne

- Zrozumienie i implementacja wzorców projektowych, takich jak **Fabryka**, **Fabryka Abstrakcyjna**, **Singleton**.
- Praktyczne zastosowanie programowania obiektowego w języku C#.
- Organizacja kodu w projektach .NET.

## Zadania

### Zadanie nr 1: Program losujący postacie NPC

Twoim zadaniem jest stworzenie programu losującego postacie NPC (non-player character) w grze fantasy. Każdy NPC ma klasę postaci: wojownik, mag, złodziej.

1. Zaimplementuj interfejs `INPC`:
   ```csharp
   public interface INPC
   {
       void Przedstawsie();
   }
   ```

2. Stwórz klasy NPC:
   - **Wojownik**: „Jestem Wojownikiem, walczę mieczem”
   - **Mag**: „Jestem Magiem, władającym magią żywiołów”
   - **Złodziej**: „Jestem Złodziejem, nie mam atrybutów”

3. Stwórz interfejs fabryki:
   ```csharp
   public interface IFabrykaNPC
   {
       INPC CreateNPC();
   }
   ```

4. Stwórz klasy fabryk:
   - `FabrykaWojownika`
   - `FabrykaMaga`
   - `FabrykaZlodzieja`

5. W programie głównym:
   - Losowo wybierz klasę postaci i stwórz postać NPC za pomocą odpowiedniej fabryki.
   - Wypisz tekst `Przedstawsie()`.

---

### Zadanie nr 2: System zarządzania planem pieczenia ciast

Twoim zadaniem jest stworzenie systemu zarządzania planem pieczenia ciast w cukierni. System powinien umożliwiać dodawanie różnych ciast do planu, a także wyświetlanie planu pieczenia.

1. Zaimplementuj klasę `Ciasto`, która będzie zawierała następujące informacje:
   - `string Nazwa`: Nazwa ciasta.
   - `string Rodzaj`: Rodzaj ciasta.
   - `List<string> Składniki`: Lista składników ciasta.

2. Zdefiniuj interfejs `IFabrykaCiasta` z metodą `StwórzCiasto(): Ciasto`, która będzie zwracać obiekt klasy `Ciasto`.

3. Zaimplementuj dwie klasy fabryk:
   - **`FabrykaCiastaCzekoladowego`**:
     - `Nazwa = "Czekoladowe"`
     - `Rodzaj = "Kruche"`
     - `Składniki = new List<string> { "Czekolada", "Mąka", "Jajka", "Masło" }`
   - **`FabrykaCiastaJabłkowego`**:
     - `Nazwa = "Jabłkowe"`
     - `Rodzaj = "Drożdżowe"`
     - `Składniki = new List<string> { "Jabłka", "Cynamon", "Mąka", "Cukier" }`

4. Zaimplementuj klasę `PlanPieczenia`, która będzie przechowywać listę ciast i implementować interfejs `IEnumerable<Ciasto>`. Dodaj metody:
   - `DodajCiasto(IFabrykaCiasta fabryka)`: Dodaje ciasto do planu na podstawie fabryki.
   - `WyświetlPlan()`: Wyświetla informacje o wszystkich ciastach w planie.

5. W programie głównym:
   - Utwórz obiekt `PlanPieczenia` używając `var`.
   - Dodaj co najmniej dwie różne wariacje ciast za pomocą różnych fabryk.
   - Wyświetl plan pieczenia za pomocą pętli `foreach` i użyj metody `WyświetlPlan` na obiekcie `PlanPieczenia`.

---

### Zadanie nr 3: System obsługujący produkcję paczek

System obsługujący produkcję różnych rodzajów paczek w fabryce logistycznej. Twoim zadaniem jest zaimplementowanie wzorca Factory Method z użyciem Singleton’a.

1. Interfejs Produktu:
   - Zdefiniuj interfejs `IPaczka` z metodą `Przygotuj()`.

2. Konkretne Implementacje Produktów:
   - Stwórz kilka konkretnych implementacji produktów, takich jak `MałaPaczka`, `DużaPaczka`, implementujących interfejs `IPaczka`.

   Przykładowo:
   ```csharp
   class MałaPaczka : IPaczka
   {
      public void Przygotuj()
      {
         Console.WriteLine("Przygotowano małą paczkę.");
      }
   }
   ```

3. Singleton dla Zarządzania Produkcją:
   - Zaimplementuj Singleton, który będzie zarządzał procesem produkcji paczek.
   - Wprowadź metodę, która pozwoli na przekazanie konkretnej fabryki paczek.

   Kilka kluczowych punktów w implementacji Singleton’a:
   - **Prywatny Konstruktor**: Dostęp do konstruktora klasy jest ograniczony do samej klasy, co oznacza, że nie można utworzyć nowej instancji z zewnątrz.
   - **Pole Instancji**: Jest to prywatne pole przechowujące jedyną instancję klasy.
   - **Właściwość Instancji**: To publiczna właściwość, która umożliwia dostęp do instancji klasy. Jeśli instancja nie istnieje, jest tworzona w momencie pierwszego dostępu.

   Przykład:
   ```csharp
   class ZarządzaniePaczkami
   {
      private IFabrykaPaczek fabrykaPaczek;
      private static ZarządzaniePaczkami _instancja;
      private ZarządzaniePaczkami() { }
      public static ZarządzaniePaczkami Instancja
      {
         get
         {
               if (_instancja == null)
               {
                  _instancja = new ZarządzaniePaczkami();
               }
               return _instancja;
         }
      }
   }
   ```

4. Konkretne Kreatory:
   - Stwórz kilka konkretnych implementacji kreatorów, np. `FabrykaMałychPaczek`, `FabrykaDużychPaczek`, implementujących interfejs `IFabrykaPaczek`.

   Przykład:
   ```csharp
   interface IFabrykaPaczek
   {
      IPaczka UtwórzPaczkę();
   }
   ```

   - W każdym kreatorze zaimplementuj wzorzec Factory Method, który będzie odpowiedzialny za tworzenie konkretnej paczki.

   Przykład:
   ```csharp
   class FabrykaDużychPaczek : IFabrykaPaczek
   {
      public IPaczka UtwórzPaczkę()
      {
         return new DużaPaczka();
      }
   }
   ```

5. Testowanie:
   - Wprowadź kilka zamówień, używając Singleton’a do zarządzania produkcją różnych paczek.

---

### Zadanie nr 4: System zarządzania przesyłkami

Rozważ system zarządzania przesyłkami w międzynarodowej firmie logistycznej z różnymi rodzajami paczek i kurierów. Twoim zadaniem jest zaimplementowanie mechanizmu wyboru fabryki na podstawie lokalizacji klienta, wzorca Abstract Factory oraz Singleton’a.

1. **Interfejsy i Implementacje Produktów**:
   - Zdefiniuj interfejsy produktów: `IPaczka` z metodą `void Spakuj()` oraz `IKurier` z metodą `void Dostarcz()`.
   - Stwórz konkretne implementacje produktów: `MałaPaczka`, `DużaPaczka`, `DHLKurier`, `UPSKurier`. W środku metod wypisz odpowiednie komunikaty:
   ```csharp
   Console.WriteLine("Spakowano dużą/małą paczkę.");
   Console.WriteLine("Dostarczono przez kuriera DHL/UPS.");
   ```

2. **Interfejs dla Abstract Factory**:
   - Określ interfejs `IFabrykaLogistyki` z dwiema metodami typu Factory Method:
     - `IPaczka UtworzPaczkę()`
     - `IKurier UtworzKuriera()`

3. **Konkretne Implementacje Abstract Factory**:
   - Utwórz konkretne fabryki dla różnych lokalizacji, np. `FabrykaLogistykiPolska`, `FabrykaLogistykiUSA`.

4. **Singleton dla Zarządzania Przesyłkami**:
   - Dodaj Singleton do klasy `ZarządzaniePrzesyłkami`, aby zapewnić, że istnieje tylko jedna instancja w całym systemie.

   Przykład:
   ```csharp
   class ZarządzaniePrzesyłkami
   {
       private IFabrykaLogistyki fabrykaLogistyki;
       private static ZarządzaniePrzesyłkami _instancja;
       private ZarządzaniePrzesyłkami() { }
       public static ZarządzaniePrzesyłkami Instancja
       {
           get
           {
               if (_instancja == null)
               {
                   _instancja = new ZarządzaniePrzesyłkami();
               }
               return _instancja;
           }
       }
   }
   ```

5. **Metoda Przyjmująca Zamówienie**:
   - W klasie `ZarządzaniePrzesyłkami`, stwórz metodę `PrzyjmijZamówienie(string lokalizacja)`.
   - W metodzie dokonaj wyboru fabryki na podstawie lokalizacji klienta.

   Przykład:
   ```csharp
   if (lokalizacja == "Polska")
   {
      fabrykaLogistyki = new FabrykaLogistykiPolska();
   }
   ```

   - Użyj Abstract Factory do stworzenia paczki i kuriera.
   - Wywołaj metody `Spakuj()` i `Dostarcz()` na produktach.

   Przykład:
   ```csharp
   public enum Lokalizacja
   {
      Polska,
      USA
   }
   public void PrzyjmijZamówienie(Lokalizacja lokalizacja)
   {
      switch (lokalizacja)
      {
         case Lokalizacja.Polska:
            fabrykaLogistyki = new FabrykaLogistykiPolska();
            break;
         case Lokalizacja.USA:
            fabrykaLogistyki = new FabrykaLogistykiUSA();
            break;
         default:
            throw new ArgumentException("Nieobsługiwana lokalizacja.");
      }
      var paczka = fabrykaLogistyki.UtworzPaczkę();
      var kurier = fabrykaLogistyki.UtworzKuriera();
      paczka.Spakuj();
      kurier.Dostarcz();
   }
   ```

6. **Wybór Fabryki**:
   - Wprowadź możliwość wyboru fabryki na podstawie lokalizacji klienta.

   Przykład:
   ```csharp
   ZarządzaniePrzesyłkami.Instancja.PrzyjmijZamówienie("Polska");
   ```

7. **Testowanie**:
   - Przetestuj implementację, tworząc kilka zamówień dla różnych lokalizacji z różnymi paczkami i kurierami.

## Autorzy

Projekty zostały stworzone w ramach zajęć laboratoryjnych z przedmiotu **Programowanie Zaawansowane**.

- **Oliwia Krzanowska**: Autor repozytorium i realizator zadań.

## Licencja

Repozytorium jest przeznaczone wyłącznie do celów edukacyjnych.
