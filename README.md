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

- **`Programowanie zaawansowane.sln`**  
  Plik rozwiązania Visual Studio, łączący oba projekty (`Ciasto` i `NPC`).

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

- Zrozumienie i implementacja wzorców projektowych, takich jak **Fabryka**.
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

## Autorzy

Projekty zostały stworzone w ramach zajęć laboratoryjnych z przedmiotu **Programowanie Zaawansowane**.

- **Oliwia Krzanowska**: Autor repozytorium i realizator zadań.

## Licencja

Repozytorium jest przeznaczone wyłącznie do celów edukacyjnych.
