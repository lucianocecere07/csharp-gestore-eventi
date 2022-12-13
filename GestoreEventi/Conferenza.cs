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
            if (relatore == "" || relatore == " ")
            {
                throw new ArgumentException("il campo del relatore non può essere vuoto");
            }
            this.relatore = relatore;
            if (prezzo < 0)
            {
                throw new ArgumentOutOfRangeException("il prezzo non può essere negativo");
            }
            this.prezzo = prezzo;
        }

        //getter 
        public string GetRelatore()
        {
            return relatore;
        }
        public double GetPrezzo()
        {
            return prezzo;
        }

        //setter
        public void SetRelatore(string relatore)
        {
            if (relatore == "" || relatore == " ")
            {
                throw new ArgumentException("il campo del relatore non può essere vuoto");
            }
            this.relatore = relatore;
        }
        public void SetPrezzo(double prezzo)
        {
            if(prezzo < 0)
            {
                throw new ArgumentOutOfRangeException("il prezzo non può essere negativo");
            }
            this.prezzo = prezzo;
        }

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
           return base.ToString() + " - " + relatore + " - " + prezzo.ToString("F") + " euro";
        }
    }
}
