using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{
    //--- Milestone 1 ---//
    public class Evento
    {
        //proprietà
        private string titolo;
        private DateTime data;
        private int capienzaMassima;
        private int postiPrenotati;

        //costruttori
        public Evento(string titolo, DateTime data, int capienzaMassima, int postiPrenotati = 0)
        {
            if (titolo == "" || titolo == " ")
            {
                throw new ArgumentException("il campo del titolo non può essere vuoto");
            }
            this.titolo = titolo;
            if (data < DateTime.Now)
            {
                throw new Exception("la data è già passata");
            }
            this.data = data;
            if (capienzaMassima <= 0)
            {
                throw new ArgumentOutOfRangeException("la capienza massima non può essere 0 o inferiore");
            }
            this.capienzaMassima = capienzaMassima;
            if (postiPrenotati < 0 || postiPrenotati > capienzaMassima)
            {
                throw new ArgumentOutOfRangeException("il numero di posti prenotati è errato");
            }
            this.postiPrenotati = postiPrenotati;
        }

        //getter
        public string GetTitolo()
        {
            return titolo;
        }
        public DateTime GetData()
        {
            return data;
        }
        public int GetCapienzaMassima()
        {
            return capienzaMassima;
        }
        public int GetPostiPrenotati()
        {
            return postiPrenotati;
        }

        //setter
        public void SetTitolo(string titolo)
        {
            if(titolo == "" || titolo == " ")
            {
                throw new ArgumentException("il campo del titolo non può essere vuoto");
            }
            this.titolo = titolo;
        }
        public void SetData(DateTime data)
        {
            if(data < DateTime.Now)
            {
                throw new Exception("la data è già passata");
            }
            this.data = data;
        }
        private void SetCapienzaMassima(int capienzaMassima)
        {
            if(capienzaMassima <= 0)
            {
                throw new ArgumentOutOfRangeException("la capienza massima non può essere 0 o inferiore");
            }
            this.capienzaMassima = capienzaMassima;
        }
        private void SetPostiPrenotati(int postiPrenotati)
        {
            if (postiPrenotati < 0 || postiPrenotati > capienzaMassima)
            {
                throw new ArgumentOutOfRangeException("il numero di posti prenotati è errato");
            }
            this.postiPrenotati = postiPrenotati;
        }
        
        //metodi
        public int PrenotaPosti(int postiInPiu)
        {
            if(postiInPiu <= 0)
            {
                throw new ArgumentOutOfRangeException("impossibile prenotare 0 o inferiore posti");
            }
            if(postiInPiu <= capienzaMassima-postiPrenotati)
            {
                this.postiPrenotati += postiInPiu;
            }
            else
            {
                throw new ArgumentOutOfRangeException("impossibile prenotare questo numero di posti");
            }
            return this.postiPrenotati;
        }
        public int DisdiciPosti(int postiInMeno)
        {
            if (postiInMeno <= 0)
            {
                throw new ArgumentOutOfRangeException("impossibile disdire 0 o inferiore posti");
            }
            if (postiInMeno <= postiPrenotati && data >= DateTime.Now)
            {
                this.postiPrenotati -= postiInMeno;
            }
            else
            {
                throw new ArgumentOutOfRangeException("impossibile disdire questo numero di posti");
            }
            return this.postiPrenotati;
        }
        public override string ToString()
        {
            return data.ToString("dd/MM/yyyy") + " - " + titolo;
        }
    }
}
