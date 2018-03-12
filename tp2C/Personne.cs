using System;

/* ************************
 *      IFT1179 - TP2
 * Stéphane Barthélemy
 *        20084771
 ************************ */

namespace tp2
{
    public class Personne
    {
        private string nom;
        private char sexe;
        private double taille;
        private double poids;
        private int numero;

        public Personne(string nom, char sexe, double taille, double poids, int numero)
        {
            this.nom = nom;
            this.sexe = sexe;
            this.taille = taille;
            this.poids = poids;
            this.Numero = numero;
        }

        public char Sexe
        {
            get
            {
                return sexe;
            }
            set
            {
                sexe = value;
            }
        }

        public string Genre {
            get{
                return sexe == 'M' ? "Masculin" : "Féminin";
            }
        }

        public int Numero { get => numero; set => numero = value; }

        public override string ToString()
        {
            return string.Format("{0}, sexe {1}, taille {2:F2} mètre, {3:F1} kg, numéro {4}", nom, Genre.ToLower(), taille, poids, Numero);
        }

        
        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            else if (this.GetType() != obj.GetType())
                return false;
            else
            {
                Personne autre = (Personne)obj;
                return nom.ToLower() == autre.nom.ToLower();    // On ignore la casse
            }
        }

    }
}
