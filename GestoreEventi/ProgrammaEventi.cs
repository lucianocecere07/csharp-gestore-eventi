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
            numeroEventiPresenti++;
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
        }

        // un metodo che restituisce una lista di eventi con tutti gli eventi presenti in una certa data.
        /*
        public List<Evento> eventiInData(DateTime dataScelta)
        {
            return List<Evento> eventiData = new List<Evento>();
        }
        */

        public void StampaLista()
        {
            foreach(Evento evento in this.eventi)
            {
                Console.WriteLine(evento);
            }
        }
        public void StampaNumeroEventi()
        {
            Console.WriteLine("eventi presenti): " + numeroEventiPresenti);
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
