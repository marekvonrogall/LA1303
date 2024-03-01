# LA-1303-SpielAPI

# Projekt-Dokumentation

Marek, Cyril, Dorian, Lorenzo

| Datum | Version | Zusammenfassung                                              |
| ----- | ------- | ------------------------------------------------------------ |
| 19.01.2024 | 0.0.1 | Heute haben wir mit der Roulette REST API angefangen. Wir benutzen für die Umsetzung des Backends Visual Studio Enterprise 2022. |
| 26.01.2024 | 0.0.2 | Wir haben weiter an der Umsetzung des Backends gearbeitet. Der heutige Fokus lag auf der Funktionalität der Datenbank. |
| 02.02.2024 | 0.0.3   |  Heute haben wir an den Controllern gearbeitet, welche die http-Anfragen übernehmen. Wir sind noch nicht ganz fertig mit der Logik des Roulette Spiels. |
| 23.02.2024 | 0.1.0 | Heute haben wir die Logik des Roulettespiels fertig programmiert. Das Backend ist jetzt voll funktionsfähig. |
| 01.03.2024 | 1.0.0 | Wir schaffen es leider nicht, das Backend mit Docker zu hosten. Das liegt daran, dass unsere Datenbank nicht auf Linux-Containern unterstützt wird. Die restliche Zeit haben wir in die Dokumentation / Portfolioeintrag investiert.  |

## 1 Informieren

### 1.1 Ihr Projekt

Wir erstellen eine REST API, welche man mit für ein Roulette-Programm benutzen kann.

### 1.2 User Stories

| US-№ | Verbindlichkeit | Typ  | Beschreibung                       |
| ---- | --------------- | ---- | ---------------------------------- |
| 1 |  Muss  | Funktional | Als Verwalter der REST-API möchte ich neue Benutzer registrieren können, damit mehr Leute Roulette spielen können. |
| 2 |  Muss  | Funktional | Als Verwalter der REST-API möchte ich neu registrierten Benutzer ein Startgehalt von 2000 Chips geben, damit sie damit Roulette spielen können. |
| 3 |  Muss  | Funktional | Als Verwalter der REST-API möchte ich alle Benutzernamen und deren Anzahl Chips anzeigen lassen, um zu wissen welcher Spieler wie viele Chips besitzt. |
| 4 |  Muss  | Funktional | Als Verwalter der REST-API möchte ich einen Benutzer löschen können, wenn dieser sich dazu entscheidet seinen Account zu löschen. |
| 5 |  Muss  | Funktional | Als Benutzer der REST-API möchte ich einen oder mehrere Einsätze setzen können, um Glücksspiel zu betreiben. |
| 6 |  Muss  | Funktional | Als Benutzer der REST-API möchte ich eine oder mehrere Wetten setzen können, um Glücksspiel zu betreiben. |
| 7 |  Muss  | Funktional | Als Verwalter der REST-API möchte ich alle Einsätze der Benutzer ansehen können, um zu sehen wer welchen Einsatz verwettet. |
| 8 |  Muss  | Funktional | Als Verwalter der REST-API möchte ich alle Wetten der Benutzer ansehen können, um zu sehen wer auf was wettet. | 
| 9 |  Muss  | Funktional | Als Benutzer der REST-API möchte ich einen Einsatz und Wette zurückziehen können, falls sich der Benutzer umentschieden hat. |
| 10|  Muss  | Funktional | Als Verwalter der REST-API möchte ich das Roulette Spiel starten, um Glücksspiel zu betreiben. |
| 11|  Muss  | Funktional | Als Verwalter der REST-API möchte ich, dass der Benutzer bei einer korrekten Wette auf eine einzelne Zahl das 35-fache seines Einsatzes zurück erhält, damit der Benutzer seinen rechtmässigen Gewinn erhält. |
| 12|  Muss  | Funktional | Als Verwalter der REST-API möchte ich, dass der Benutzer bei einer korrekten Wette auf eine Farbe das zweifache seines Einsatzes zurück erhält, damit der Benutzer seinen rechtmässigen Gewinn erhält. |
| 13|  Muss  | Funktional | Als Verwalter der REST-API möchte ich, dass der Benutzer bei einer korrekten Wette auf einen Sektor (1-12, 13-24, 25-36) das dreifache seines Einsatzes zurück erhält, damit der Benutzer seinen rechtmässigen Gewinn erhält. |
| 14|  Muss  | Funktional | Als Verwalter der REST-API möchte ich, dass dem Benutzer beim Platzieren eines Einsatzes die Chips welche er gewettet hat, von seinen Chips abgezogen werden, damit der Benutzer sein Geld verliert. |
| 15|  Kann  | Funktional | Als Verwalter der REST-API möchte ich, dass der Benutzer nur so viel Geld wetten kann wie er Chips besitzt, damit er sich nicht verschulden kann. |
| 16|  Muss  | Funktional | Als Verwalter der REST-API möchte ich, dass die API überprüft, ob ein Einsatz gültig ist, damit keine Fehler entstehen. |
| 17|  Muss  | Funktional | Als Verwalter der REST-API möchte ich, dass die API überprüft, ob eine Wette gültig ist, damit keine Fehler entstehen. |
| 18|  Muss  | Funktional | Als Verwalter der REST-API möchte ich, dass alle Daten in einer Datenbank gespeichert werden, damit Benutzer und deren Chips gespeichert bleiben. |
| 19|  Muss  | Qualität   | Als Benutzer möchte ich über ein Frontend mit der REST-API interagieren können, damit die Bedienung erleichtert wird. |
| 20|  Muss  | Randbedingung   | Front- und Backend werden mittels Docker lokal gehostet. |

### 1.3 Testfälle

| TC-№ | Ausgangslage | Eingabe | Erwartete Ausgabe |
| ---- | ------------ | ------- | ----------------- |
| 1.1  | Die REST-API wurde gestartet. | Eine Http-Anfrage zur Registrierung der Benutzer wurde gesendet (https://localhost:Port/Benutzer/register?username=INPUT&password=INPUT). | Ein neuer Benutzer wird registriert. |
| 2.1  | Die REST-API wurde gestartet. | Eine Http-Anfrage zur Registrierung der Benutzer wurde gesendet (https://localhost:Port/Benutzer/register?username=INPUT&password=INPUT). | Ein neuer Benutzer wird registriert und bekommt ein Startgehalt von 2000 Chips. |
| 3.1  | Die REST-API wurde gestartet. | Eine Http-Anfrage zum Abrufen aller Benutzer und deren Chips wurde gesendet (https://localhost:Port/Benutzer). | Alle Benutzer und deren Chips werden im JSON-Format ausgegeben. |
| 4.1  | Die REST-API wurde gestartet. | Eine Http-Anfrage zum Löschen eines Benutzers wurde gesendet (https://localhost:Port/Benutzer). | Der Benutzer wird gelöscht. |
| 5.1  | Die REST-API wurde gestartet. | Eine Http-Anfrage zum Hinzufügen eines Einsatzes wurde gesendet (https://localhost:Port/Einsatz?userEinsatz=INPUT&userName=INPUT). | Dem Benutzer wird ein Einsatz hinzugefügt. |
| 6.1  | Die REST-API wurde gestartet. | Eine Http-Anfrage zum Hinzufügen einer Wette wurde gesendet (https://localhost:Port/Wette?userWette=INPUT&userName=INPUT). | Dem Benutzer wird eine Wette hinzugefügt. |
| 7.1  | Die REST-API wurde gestartet. | Eine Http-Anfrage zum Ansehen aller Einsätze wurde gesendet (https://localhost:Port/Einsatz). | Alle Einsätze und der dazugehörige Name des Benutzers der den Einsatz platziert hat, werden im JSON-Format ausgegeben. |
| 8.1  | Die REST-API wurde gestartet. | Eine Http-Anfrage zum Ansehen aller Wetten wurde gesendet (https://localhost:Port/Wette). | Alle Wetten und der dazugehörige Name des Benutzers der die Wette platziert hat, werden im JSON-Format ausgegeben. |
| 9.1  | Die REST-API wurde gestartet. | Eine Http-Anfrage zum löschen eines Einsatzes (https://localhost:Port/Einsatz/{id}) / einer Wette (https://localhost:Port/Wette/{id}) wurde gesendet. | Der Einsatz / Die Wette wird gelsöcht. |
| 10.1 | Die REST-API wurde gestartet. | Eine Http-Anfrage zum starten des Roulette-Spiels wurde gesendet (https://localhost:Port/Roulette). | Das Backend wertet aus, welcher Benutzer Geld verliert / gewinnt |
| 11.1 | Die REST-API wurde gestartet. | Http-Anfragen zum setzen eines Einsatzes und einer Wette wurden gesendet. Die Wette ist eine einzelne Zahl. Ausserdem wurde das Roulette-Spiel mittels Http-Anfrage gestartet. | Der Benutzer erhält, falls die generierte Zahl des Roulette-Spiels die gewettete Zahl ist, den 35-fachen Einsatz als Gewinn gutgeschrieben. |
| 12.1 | Die REST-API wurde gestartet. | Http-Anfragen zum setzen eines Einsatzes und einer Wette wurden gesendet. Die Wette ist eine Farbe (rot/schwarz). Ausserdem wurde das Roulette-Spiel mittels Http-Anfrage gestartet. | Der Benutzer erhält, falls die generierte Zahl des Roulette-Spiels der selben Farbe wie der gewetteten Farbe entspricht, den zweifachen Einsatz als Gewinn gutgeschrieben. |
| 13.1 | Die REST-API wurde gestartet. | Http-Anfragen zum setzen eines Einsatzes und einer Wette wurden gesendet. Die Wette wurde auf einen Sektoren (Q1, Q2, Q3) abgeschlossen. Ausserdem wurde das Roulette-Spiel mittels Http-Anfrage gestartet. | Der Benutzer erhält, falls die generierte Zahl des Roulette-Spiels dem selben Sektor wie dem gewetteten Sektor entspricht, den dreifachen Einsatz als Gewinn gutgeschrieben. |
| 14.1 | Die REST-API wurde gestartet. | Eine Http-Anfrage zum Hinzufügen eines Einsatzes wurde gesendet (https://localhost:Port/Einsatz?userEinsatz=INPUT&userName=INPUT). | Dem Benutzer wird ein Einsatz hinzugefügt und bekommt anschliessend den gewetteten Einsatz von seinen Chips abgezogen. |
| 15.1 | Die REST-API wurde gestartet. | Eine Http-Anfrage zum Hinzufügen eines Einsatzes wurde gesendet (https://localhost:Port/Einsatz?userEinsatz=INPUT&userName=INPUT), in welcher der Einsatz jedoch die Anzahl verfügbarer Chips des Benutzers überschreitet. | Die Http-Anfrage gibt eine Fehlermeldung zurück ("Dieser Benutzer hat zu wenig Chips um diesen Einsatz zu platzieren."). |
| 16.1 | Die REST-API wurde gestartet. | Eine Http-Anfrage zum Hinzufügen eines Einsatzes wurde gesendet. Der Einsatz ist nicht gültig. (-2, "string") | Eine Nachricht "Ungültigen Einsatz erkannt." wird ausgegeben, bzw. es erscheint ein validation error. |
| 17.1 | Die REST-API wurde gestartet. | Eine Http-Anfrage zum Hinzufügen einer Wette wurde gesendet. Die Wette ist nicht gültig. (37, q4, blue) | Eine Nachricht "Ungültige Wette erkannt." wird ausgegeben. |
| 18.1 | Die Datenbank wurde erstellt (update-database in der PMK). | Eine beliebige Http-Anfrage (z.B. hinzufügen / löschen / abrufen einer Wette, eines Einsatzes oder eines Benutzers) wird ausgeführt. | Daten werden in der Datenbank gespeichert bzw. aus dieser gelöscht / abgerufen. |
| 19.1 | Die Website (Frontend) wurde gestartet. | https://localhost:Port2 wird im Browser aufgerufen. | Die Website öffnet sich und ermöglicht eine einfache Bedienung der REST-API. |
| 20.1 | Die Docker Container des Front- und Backends wurde gestartet | https://localhost:Port2 und https://localhost:Port im Browser ermöglichen den Zugang zum Front- und Backend. |

### 1.4 Diagramme



## 2 Planen

| AP-№ | Frist | Zuständig | Beschreibung | geplante Zeit |
| ---- | ----- | --------- | ------------ | ------------- |
| 1.A | 19.01.2024 |      |              |                |
| 2.A | 26.01.2024 |      |              |                |
| 3.A | 02.02.2024 |      |              |                |
| 4.A | 19.01.2024 |      |              |                |
| 5.A | 19.01.2024 |      |              |                |
| 6.A | 23.02.2024 |      |              |                |
| 7.A | 01.03.2024 |      |              |                |
| 8.A | 19.01.2024 |      |              |                |
| 9.A | 19.01.2024 |      |              |                |
| 10.A | 19.01.2024 |      |              |                |
| 11.A | 19.01.2024 |      |              |                |
| 12.A | 19.01.2024 |      |              |                |
| 13.A | 19.01.2024 |      |              |                |
| 14.A | 19.01.2024 |      |              |                |
| 15.A | 19.01.2024 |      |              |                |
| 16.A | 19.01.2024 |      |              |                |
| 17.A | 19.01.2024 |      |              |                |
| 18.A | 19.01.2024 |      |              |                |
| 19.A | 19.01.2024 |      |              |                |
| 20.A | 19.01.2024 |      |              |                |

## 3 Entscheiden

Wir haben uns trotz der Userstory 19.1 gegen ein Frontend entschieden. Das liegt daran, da wir Userstory 20.1 nicht umsetzen konnten.
Wir haben mit der Realisierung des Frontends begonnen, jedoch parallel bei der Entwicklung des Backends gemerkt, dass wir das Backend nicht mit Docker hosten können.
Da wir EntityFrameworkCore.SqlServer für unsere Datenbank benutzen, können wir unser Programm nicht dockerisieren, da der SqlServer nur auf Windows läuft, Docker aber Linux Container benutzt.
Mögliche Lösungen wären den SqlServer mit einem speziellen Image in einem eigenen Container laufen zu lassen und sich anschliessend damit zu verbinden oder Windows Container anstatt Linux Container für Docker zu verwenden.
Für beide dieser Lösungen haben wir zu wenig Zeit.
Da wir unser Backend nicht mit Docker containerisieren können, macht ein Frontend wenig Sinn, da wir nicht auf unsere REST-API zugreifen können.

## 4 Realisieren

| AP-№ | Datum | Zuständig | geplante Zeit | tatsächliche Zeit |
| ---- | ----- | --------- | ------------- | ----------------- |
| 1.A | 19.01.2024 |      |              |                |
| 2.A | 26.01.2024 |      |              |                |
| 3.A | 02.02.2024 |      |              |                |
| 6.A | 23.02.2024 |      |              |                |
| 7.A | 01.03.2024 |      |              |                |

## 5 Kontrollieren

### 5.1 Testprotokoll

| TC-№ | Datum | Resultat | Tester |
| ---- | ----- | -------- | ------ |
| 1.1  | 01.03.2024 | OK |   |
| 2.1  | 01.03.2024 | OK |   |
| 3.1  | 01.03.2024 | OK |   |
| 4.1  | 01.03.2024 | OK |   |
| 5.1  | 01.03.2024 | OK |   |
| 6.1  | 01.03.2024 | OK |   |
| 7.1  | 01.03.2024 | OK |   |
| 8.1  | 01.03.2024 | OK |   |
| 9.1  | 01.03.2024 | OK |   |
| 10.1  | 01.03.2024 | OK |   |
| 11.1  | 01.03.2024 | OK |   |
| 12.1  | 01.03.2024 | OK |   |
| 13.1  | 01.03.2024 | OK |   |
| 14.1  | 01.03.2024 | OK |   |
| 15.1  | 01.03.2024 | OK |   |
| 16.1  | 01.03.2024 | OK |   |
| 17.1  | 01.03.2024 | OK |   |
| 18.1  | 01.03.2024 | OK |   |
| 19.1  | 01.03.2024 | NOK |   |
| 20.1  | 01.03.2024 | NOK |   |

OK = Testfall erfolgreich.
NOK = Testfall nicht erfolgreich.

## 6 Auswerten

Was wir gut gemacht haben:
- Teamarbeit
  
Was wir nicht gut gemacht haben:
- Zu wenig über die Dockerisierung von Datenbanken informiert. Wir hätten eine andere Technologie verwenden sollen.

Verbesserungsvorschlag: