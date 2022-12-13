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
using System;

Console.Write("inserisci il nome dell'evento: ");
string titolo = Console.ReadLine();
Console.Write("inserisci la data dell'evento (gg/mm/yyyy): ");
DateTime data = DateTime.Parse(Console.ReadLine());
Console.Write("inserisci il numero di posti totali: ");
int capienzaMassima = int.Parse(Console.ReadLine());

Console.Write("quanti posti desideri prenotare? ");
int postiPrenotati = int.Parse(Console.ReadLine());

Evento nuovoEvento = new Evento(titolo, data, capienzaMassima, postiPrenotati);

//stampare a video il numero di posti prenotati e quelli disponibili
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

//creare un nuovo programma di eventi
List<Evento> eventi = new List<Evento>();

Console.WriteLine();
Console.Write("inserisci il nome del tuo programma eventi: ");
string Titolo = Console.ReadLine();

ProgrammaEventi nuovoProgramma = new ProgrammaEventi(Titolo, eventi);

//quanti eventi aggiungere
Console.Write("indica il numero di eventi da inserire: ");
int numeroEventiDaInserire = int.Parse(Console.ReadLine());
if (numeroEventiDaInserire < 0)
{
    throw new Exception("impossibile inserire questo numero di eventi");
}

while (eventi.Count < numeroEventiDaInserire)
{
    try
    {
        Console.WriteLine();
        Console.Write("inserisci il nome dell'evento: ");
        string titoloEvento = Console.ReadLine();
        Console.Write("inserisci la data dell'evento (gg/mm/yyyy): ");
        DateTime dataEvento = DateTime.Parse(Console.ReadLine());
        Console.Write("inserisci il numero di posti totali: ");
        int capienzaMassimaEvento = int.Parse(Console.ReadLine());

        Evento eventoInserito = new Evento(titoloEvento, dataEvento, capienzaMassimaEvento);

        nuovoProgramma.AggiungiEvento(eventoInserito);
    }
    catch (ArgumentOutOfRangeException e)
    {
        Console.WriteLine(e.Message);
        Console.WriteLine("reinserire l'evento");
    }
    catch (ArgumentException e)
    {
        Console.WriteLine(e.Message);
        Console.WriteLine("reinserire l'evento");
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
        Console.WriteLine("reinserire l'evento");
    }
}

//Stampare il numero di eventi presenti nel programma eventi
Console.WriteLine();
nuovoProgramma.StampaNumeroEventi();

//Stampare la lista di eventi inseriti nel programma
nuovoProgramma.StampaLista();

/*Chiedere all'utente una data e stampate tutti gli eventi in quella data. Usate il metodo che vi restituisce 
una lista di eventi in una data dichiarata e 
create un metodo statico che si occupa di stampare una lista di eventi che gli arriva.
Passate dunque la lista dieventi in data al metodo statico, per poterla stampare.
Console.WriteLine();
Console.Write("inserisci una data per sapere che eventi ci saranno (gg/mm/yyyy): ");
DateTime dataScelta = DateTime.Parse(Console.ReadLine());*/

//Eliminare tutti gli eventi dal programma
//nuovoProgramma.SvuotaLista();

//--- Bonus ---//
Console.WriteLine();
Console.WriteLine("--- Bonus ---");
Console.WriteLine();
Console.WriteLine("aggiungiamo anche una conferenza");
try
{
    
    Console.Write("inserisci il nome della conferenza: ");
    string titoloConferenza = Console.ReadLine();
    Console.Write("inserisci la data della conferenza (gg/mm/yyyy): ");
    DateTime dataConferenza = DateTime.Parse(Console.ReadLine());
    Console.Write("inserisci il numero di posti per la conferenza: ");
    int capienzaMassimaConferenza = int.Parse(Console.ReadLine());
    Console.Write("inserisci il relatore della conferenza: ");
    string relatoreConferenza = Console.ReadLine();
    Console.Write("inserisci il prezzo del biglietto per la conferenza: ");
    double prezzoConferenza = double.Parse(Console.ReadLine());

    Conferenza nuovaConferenza = new Conferenza(titoloConferenza, dataConferenza, capienzaMassimaConferenza, relatoreConferenza, prezzoConferenza);

    nuovoProgramma.AggiungiEvento(nuovaConferenza);
}
catch (ArgumentOutOfRangeException e)
{
    Console.WriteLine(e.Message);
    Console.WriteLine("reinserire la conferenza");
}
catch (ArgumentException e)
{
    Console.WriteLine(e.Message);
    Console.WriteLine("reinserire la conferenza");
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
    Console.WriteLine("reinserire la conferenza");
}

//Stampare eventi e conferenza nel programma
Console.WriteLine();
nuovoProgramma.StampaLista();
