Błażej Czarnecki - specyfikacja techniczna projektu "lista kontaktów".

Projekt zawiera 3 główne strony: Home, Logowanie, Testing
	  oraz główny komponent: KontaktFormularz.

REST API zawiera 3 kontrolery: KontaktController, LogowanieController, SlownikKategoriiController
		oraz 3 modele: Kontakt, SlownikKategorii, User

Loginy i hasła znajdziesz w bazie danych.
W celu przetestowania logowania, nie użyłem szyfrowania hasła w bazie danych.

Sposób kompilacji:
- Uruchom serwer XAMPP, klikając na przyciski "start" obok Apache, oraz MySQL.
- Kliknij przycisk "Admin" przy MySQL. Ten przycisk przenosi na adres http://localhost/phpmyadmin/
- Na górnym pasku znajduje się przycisk Import. Po kliknięciu go należy wybrać plik "kontaktydb.sql",
  oraz na samym dole strony znajduje się przycisk Import, którego należy kliknąć.
- Uruchom terminal.
- Skopiuj ścieżkę pliku "ListaKontaktowAPI\ListaKontaktowAPI", a następnie wpisz w terminalu "cd" i finalnie wklej ścieżkę.
- Komenda powinna wyglądać mniej więcej w taki sposób: cd C:\repos\ListaKontaktowAPI\ListaKontaktowAPI
- Uruchom api za pomocą komendy "dotnet run", w konsoli powinno pojawić się "Trwa kompilowanie..."
- Znajdź w konsoli komunikat "Now listening on: http://localhost:[tutaj twój port]", oraz skopiuj ten adres
- W katalogu ListaKontaktow/ListaKontaktow znajduje sie plik program.cs - w tym pliku jest zmienna SERVERADDRESS.
  jeżeli adres się różni, zmień port tego adresu.
- Uruchom kolejny terminal, postępuj tak samo jak z ListaKontaktowAPI - skopiuj ścieżkę, wpisz cd C:\repos\ListaKontaktow\ListaKontaktow, uruchom projekt.
- Otwórz w przeglądarce adres komunikatu: "Now listening on: http://localhost:[tutaj twój port]"

Użyte Frameworki: Blazor (C#), REST API (C#).
Baza danych: MySQL - postawiona na darmowej aplikacji XAMPP v3.3.0.
Użyte biblioteki po stronie SPA: HttpClient, Bootstrap
Użyte biblioteki po stronie REST API: 
- Microsoft.AspNetCore.Authentication.JwtBearer,
- Microsoft.EntityFrameworkCore
- Pomelo.EntityFrameworkCore.MySql
- Swashbuckle.AspNetCore

Single Page Application:

Strony:

Home.razor dla niezalogowanego użytkownika:
- wyświetlanie podstawowych danych, takie jak imie i nazwisko.

Home.razor dla zalogowanego użytownika posiada:
- wyświetlanie szczegółów
- edytowanie kontaktu
- usuwanie kontaktu
- dodawanie kontaktu
- pobranie z api danych użytkowników, oraz listy kategorii.

Logowanie.razor posiada:
- formularz logowania
- walidacje czy formularz nie jest pusty
- pobieranie danych logowania, takich jak token JWT, oraz podstawowe informacje o użytkowniku.

Testing.razor posiada:
- Input do edycji tokena, w celu sprawdzenia zabezpieczeń serwera (rest api)
- wyświetlanie danych osoby zalogowanej.

Komponent:

KontaktFormularz posiada:
- wpisanie danych do obiektu Kontakt
- walidacje danych (email, hasło)
- zabezpieczenie przed powtarzającym się emailem
- po wybraniu kategorii "służbowy" pokazuje się wybór podkategorii: Klient, Szef, Współpracownik
- po wybraniu kategorii "inny" możemy wpisać dowolną podkategorię.

Klasy:

Validate: posiada 2 metody, które odpowiadają za walidacje hasła oraz email
Dane: posiada metodę, która zwraca czy token jest "pusty"
SlownikKategorii: posiada podstawowe metody get; set
Kontakt: posiada podstawowe metody get; set.

REST API:

Kontakt: posiada podstawowe metody get; set
SlownikKategorii: posiada podstawowe metody get; set
User: posiada podstawowe metody get; set.

KontaktController: posiada pobieranie danych z bazy danych, edytowanie, usuwanie, dodawanie danych do bazy danych
SlownikKategoriiController: posiada pobieranie danych z bazy danych
LogowanieController: posiada pobieranie tokena JWT przy poprawnym zalogowaniu.

JsonWebToken: posiada logikę generowania tokena JWT
Validate: posiada 2 metody, które odpowiadają za walidacje hasła oraz email
ApiContext: posiada ustawienia oraz pola do prawidłowego pobierania bazy danych.
