using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{
    //--- Milestone 3 ---//
    public class ProgrammaEventi
    {
        //proprietà
        private string Titolo;
        private List<Evento> eventi = new List<Evento>();
        //contare il numero di eventi presenti
        private static int numeroEventiPresenti = 0;

        //costruttori
        public ProgrammaEventi(string Titolo, List<Evento> eventi)
        {
            this.Titolo = Titolo;
            this.eventi = eventi;
        }

        //getter
        private string GetTitolo()
        {
            return Titolo;
        }
        private List<Evento> GetEventi()
        {
            return eventi;
        }
        public static int GetNumeroEventiPresenti()
        {
            return numeroEventiPresenti;
        }


        //setter
        private void SetTitolo(string Titolo)
        {
            this.Titolo = Titolo;
        }
        private void SetEventi(List<Evento> value)
        {
            eventi = value;
        }

        //metodi
        public void AggiungiEvento(Evento eventoAggiunto)
        {
            eventi.Add(eventoAggiunto);
            numeroEventiPresenti++;
        }
        
        public void EventiInData(DateTime dataScelta)
        {
            foreach (Evento evento in this.eventi)
            {
                if(dataScelta == evento.GetData())
                {
                    Console.WriteLine(evento);
                }
            }
        }

        public void StampaLista()
        {
            Console.WriteLine("ecco il programma degli eventi: " + "\n" + Titolo);
            foreach (Evento evento in this.eventi)
            {
                Console.WriteLine(evento);
            }
        }
        public void StampaNumeroEventi()
        {
            Console.WriteLine("il numero di eventi nel programma è: " + GetNumeroEventiPresenti());
        }
        public void SvuotaLista()
        {
            this.eventi = new List<Evento>() { };
        }
        public override string ToString()
        {
            return Titolo + ": " + base.ToString(); 
        }
    }
}
