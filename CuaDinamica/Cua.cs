using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaDinamica
{
    public class Cua<T> : IEnumerable
    {
        class Contenidor
        {
            T dada;
            Contenidor seguent;

            public T Dada { get => dada; set => dada = value; }
            public Contenidor Seguent { get => seguent; set => seguent = value; }

            public Contenidor(T dada)
            {
                this.Dada = dada;
                this.Seguent = null;
            }

            public Contenidor(T dada, Contenidor anterior)
            {
                Dada = dada;
                Seguent = null;
                anterior.Seguent = this;
            }
        }

        Contenidor centinella;
        Contenidor final;
        int nDades = 0;

        /// <summary>
        /// Afegeix un contenidor al final de la cua.
        /// </summary>
        /// <param name="dada">Dada per el contenidor</param>
        public void Encua(T dada)
        {
            if (centinella == null)
            {
                centinella = new Contenidor(dada);
                final = centinella;
            }
            else final = new Contenidor(dada, final);
            nDades++;
        }

        /// <summary>
        /// Si la cua no és buida esborra el primer contenidor de la cua.
        /// </summary>
        /// <exception cref="Exception">Si la cua esta buida salta</exception>
        public void Desencua()
        {
            if (EsBuida())
            {
                throw new Exception("La cua està buida.");
            }

            T dada = centinella.Dada;
            centinella = centinella.Seguent;
        }

        /// <summary>
        /// Retorna la dada del primer contenidor si la cua no és buida.
        /// </summary>
        /// <returns>la dada del primer contenidor</returns>
        /// <exception cref="Exception">Si la cua esta buida salta</exception>
        public T Primer()
        {
            if (nDades == 0) throw new Exception("La cua està buida");
            return centinella.Dada;
        }

        /// <summary>
        /// Retorna cert si la cua és buida, fals altrament
        /// </summary>
        /// <returns>nDades == 0</returns>
        public bool EsBuida()
        {
            return nDades == 0;
        }

        /// <summary>
        /// Sempre fals
        /// </summary>
        /// <returns>false</returns>
        public bool EsPlena()
        {
            return false;
        }

        /// <summary>
        /// Retorna la cua en forma: [1,2,3,4...,n]
        /// </summary>
        /// <returns>[1,2,3,4...,n]</returns>
        /// <exception cref="Exception"></exception>
        public override string ToString()
        {
            if (EsBuida()) throw new Exception("La pila està buida.");
            string resultat = "[";
            Contenidor c = centinella;
            while (c != null)
            {
                resultat += c.Dada + ",";
                c = c.Seguent;
            }
            resultat = resultat.Remove(resultat.Length - 1);
            resultat += "]";
            return resultat;
        }

        /// <summary>
        /// Retorna cert si les adreçes són les mateixes, fals altrament.
        /// </summary>
        /// <param name="cua"></param>
        /// <returns>esIgual</returns>
        public override bool Equals(object cua)
        {
            bool esIgual = cua is Cua<T>;
            Cua<T> unaCua = null;
            Contenidor inici = null, unCentinella = null;

            if (esIgual)
            {
                unaCua = (Cua<T>)cua;
                inici = centinella;
                unCentinella = unaCua.centinella;
            }
            while (esIgual && inici != null && unCentinella != null)
            {
                esIgual = Equals(inici, unCentinella);
                inici = inici.Seguent;
                unCentinella = unCentinella.Seguent;
            }
            return esIgual;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Contenidor actual = centinella;
            while (actual != null)
            {
                T result = actual.Dada;
                actual = actual.Seguent;

                yield return result;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
