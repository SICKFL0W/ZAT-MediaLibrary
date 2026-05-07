Obhajoba vypracování úkolu: 2.1 Evidence knih a mediálních nosičů

Vážená komise,
předkládám vypracování vstupního testu pro pozici vývojáře. Z nabídky jsem si zvolil úlohu 2.1 (Evidence knih a mediálních nosičů), protože se jedná o klasickou CRUD aplikaci, na které lze výborně demonstrovat pochopení celého životního cyklu vývoje aplikace, od návrhu datového modelu až po uživatelské rozhraní.

Níže předkládám obhajobu k požadovaným bodům zadání:

1. Návrh systémového designu aplikace:
- Aplikace je navržena moderní architekturou MVC (Model-View-Controller).

- Pro zajištění čistého kódu jsem využil principů OOP. Vytvořil jsem abstraktní rodičovskou třídu MediaItem (obsahující společné vlastnosti: Název, Popis, Datum pořízení, Informace o zapůjčení). Z této třídy následně dědí specifické entity Book, CD a DVD, které přidávají vlastní atributy (Autor, Interpret, Režisér).

- Pro přenos dat mezi formuláři a Controller jsem implementoval vzor ViewModel (MediaViewModel), abych oddělil databázové entity od prezentační vrstvy.


2. Postupy použité při vývoji:
- Při vývoji jsem postupoval dle standardů vývoje v .NET:

  - Dependency Injection (DI): Využito pro injektování databázového kontextu do Controlleru, což zajišťuje snadnou testovatelnost a volnou vazbu.

  - Asynchronní programování: Operace s databází využívají async/await pro neblokující chod webového serveru.

  - Code-First přístup: Databáze nebyla tvořena ručně, ale byla generována automaticky na základě C# tříd pomocí EF Core Migration.

3. Kroky při realizaci
- Analýza a volba stacku: Rozhodnutí pro ASP.NET Core jakožto robustní a moderní framework splňující požadavky z vašeho inzerátu.

    - Datový model: Vytvoření C# entit a nastavení dědičnosti.

    - Konfigurace ORM: Zapojení Entity Framework Core a nastavení připojení ke SQLite.

    - Byznys logika: Tvorba MediaControlleru pro obsluhu CRUD operací.

    - Uživatelské rozhraní: Vytvoření Razor Views (.cshtml), oživení frontend pomocí Bootstrap 5 a využití knihovny DataTables.

4. Znalost použitých technologií
- Jazyk: C# (verze 12) / .NET 8.

- Web framework: ASP.NET Core MVC.

- Přístup k datům (ORM): Entity Framework Core.

- Frontend: HTML5, CSS (Bootstrap 5 pro responzivitu), JavaScript (jQuery, DataTables).

5. Vyvinuté funkcionality
- Aplikace splňuje všechny body zadání:

    - Zobrazení všech položek v interaktivní tabulce s možností dynamického filtrování, vyhledávání a řazení (implementováno pomocí DataTables).

    - Možnost filtrovat pouze konkrétní skupiny (knihy, CD, DVD) skrze integrované vyhledávání.

    - Plné CRUD operace – přidávání položek (dynamický formulář měnící se dle typu média), editace a mazání.

    - Evidence základních informací, včetně specifických dat (Režisér apod.) s využitím Pattern Matching v C# pro jejich chytré vykreslení.

    - Vedení evidence o zapůjčení položky (včetně vizuálního odlišení stavu).

6. Uložiště dat
- Pro účely tohoto testovacího projektu jsem zvolil relační databázi SQLite z důvodu zjednodušení testování aplikace. SQLite běží lokálně v jednom souboru a nevyžaduje žádnou instalaci či konfiguraci databázového serveru, přitom nabízí plnohodnotné SQL a relační vazby. Relační mapování dědičnosti (Table-per-Hierarchy) zajišťuje EF Core.

7. Celková realizace a spuštění
- Aplikace je plně připravena k otestování.
- Návod ke spuštění:

    - Naklonujte si repozitář z GitHubu (případně rozbalte přiložený ZIP archiv):
      - git clone https://github.com/SICKFL0W/ZAT-MediaLibrary.git

    - Otevřete soubor řešení (MediaLibraryApp.sln) v Visual Studio 2022 nebo JetBrains Rider.

    - Projekt stačí spustit (F5 / Play). Databáze je buď již přiložena v projektu (soubor .db), nebo si ji Entity Framework sám vygeneruje a aplikace okamžitě naběhne ve webovém prohlížeči.

Děkuji za příležitost pracovat na tomto zadání a těším se na případnou osobní obhajobu řešení. :)
