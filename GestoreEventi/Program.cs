// See https://aka.ms/new-console-template for more information


/*
Contesto e problema da risolvere:
Immaginate di lavorare in una software house, che ha diversi clienti. Vi è stato commissionato da parte della vostra azienda la creazione di un gestionale eventi 
per eventi come concerti, conferenze, spettacoli,... per un suo cliente. 
II cliente necessita di un semplice programma senza interfaccia grafica (ossia che venga eseguito in console o terminale) che si occupa di:
- Memorizzare e tenere traccia di tutti gli eventi in futuro che ha programmato
- Poter gestire le prenotazioni e le disdette delle sue conferenze e tenere traccia quindi dei posti prenotati e di quelli disponibili per un dato evento
- Poter gestire un intero programma di Eventi (ossia tenere traccia di tutti gli eventi che afferiscono ad serie di Conferenze)
*/


//--- Milestone 2 ---//

//nuovo evento
using GestoreEventi;

Console.Write("inserisci il nome dell'evento: ");
string titolo = Console.ReadLine();
Console.Write("inserisci la data dell'evento (gg/mm/yyyy): ");
DateTime data = DateTime.Parse(Console.ReadLine());
Console.Write("inserisci il numero di posti totali: ");
int capienzaMassima = int.Parse(Console.ReadLine());

Console.Write("quanti posti desideri prenotare? ");
int postiPrenotati = int.Parse(Console.ReadLine());

Evento nuovoEvento = new Evento(titolo, data, capienzaMassima, postiPrenotati);

//Stampare a video il numero di posti prenotati e quelli disponibili
Console.WriteLine();
Console.WriteLine("numero di posti prenotati = " + nuovoEvento.GetPostiPrenotati());
int postiDisponibili = capienzaMassima - postiPrenotati;
Console.WriteLine("numero di posti disponibili = " + postiDisponibili);

//chiedere all'utente quanti posti vuole disdire, stampare i posti residui e quelli prenotati
bool fineDisdetta = false;
while (fineDisdetta == false)
{
    Console.WriteLine();
    Console.Write("vuoi disdire dei posti? (si/no): ");
    string inputUtente = Console.ReadLine();
    if(inputUtente == "no")
    {
        Console.WriteLine("ok, va bene");
        fineDisdetta = true;
    }
    else
    {
        Console.Write("indica il numero di posti da disdire: ");
        int postiDisdetti = int.Parse(Console.ReadLine());
        if(postiDisdetti < 0 || postiDisdetti > postiPrenotati)
        {
            throw new Exception("impossibile disdire questo numero di posti");
        }
        postiPrenotati = postiPrenotati - postiDisdetti;
        postiDisponibili = postiDisponibili + postiDisdetti;
    }
    Console.WriteLine();
    Console.WriteLine("numero di posti prenotati = " + postiPrenotati);
    Console.WriteLine("numero di posti disponibili = " + postiDisponibili);
}


//--- Milestone 4 ---//

