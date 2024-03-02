# Anmerkung zur Verwendung externer Hilfestellungen:

Überprüfen ob ein String ein Integer ist. Beispiel:
```cs
int.TryParse(userBet, out int userNumber)
```
Quelle: https://stackoverflow.com/questions/1752499/c-sharp-testing-to-see-if-a-string-is-an-integer

Einen Eintrag in der Datenbank anhand einer Id / eines Namens finden. Beispiel(e):
```cs
var userEinsatzEntry = _context.Einsatz.FirstOrDefault(e => e.UserName == userBet.UserName);
```
```cs
var einsatz = await _context.Einsatz.FindAsync(id);
```
```cs
var benutzer = await _context.Benutzer
  .Where(b => b.Id == id)
  .Select(b => new { b.Id, b.Name, b.Chips })
  .FirstOrDefaultAsync();
```
Quelle: ChatGPT

Mehrere Einträge auf einmal aus der Datenbank entfernen. Beispiel:
```cs
_context.Einsatz.RemoveRange(_context.Einsatz);
```
Quelle: ChatGPT
