using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{
    //--- Bonus ---//
    public class Conferenza : Evento
    {
        //proprietà
        private string relatore;
        private double prezzo;

        //costruttori
        public Conferenza(string titolo, DateTime data, int capienzaMassima, string relatore, double prezzo) : base(titolo,data,capienzaMassima)
        {
            this.relatore = relatore;
            this.prezzo = prezzo;
        }

        //getter setter
        public string Relatore { get => relatore; set => relatore = value; }
        public double Prezzo { get => prezzo; set => prezzo = value; }

        //metodi
        public void DataFormattata(DateTime data)
        {
            data.ToString("dd/MM/yyyy");
        }
        public void PrezzoFormattato(double prezzo)
        {
            this.prezzo = Math.Round(prezzo, 2);
        }
        public override string ToString()
        {
           return base.ToString() + " - " + relatore + " - " + Math.Round(prezzo, 2) + " euro";
        }
    }
}
