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
        private string naissance;   // format "jj/mm/aaaa", ex : "25/12/1993"
        private char sexe;          // F ou M
        private int nbCafe;         // Nombre de café consommé par jour

        // Nombre de café consommé par jour
        public int Cafe
        {
            get
            {
                return nbCafe;
            }
            set
            {
                if (value >= 0)
                    nbCafe = value;
                else
                    nbCafe = 0;
            }
        }

        // Sexe de la personne
        public char Sexe
        {
            get
            {
                return sexe;
            }
        }

        // Renvoie le genre associé au sexe
        public string Genre {
            get{
                return sexe == 'M' ? "Homme" : "Femme";
            }
        }

        // Constructeur
        public Personne(char sexe, string naissance, int cafe)
        {
            this.sexe = sexe;
            this.naissance = naissance;
            this.nbCafe = cafe;
        }

        // Constructeur sans le nombre de café
        public Personne(char sexe, string naissance) : this(sexe, naissance, 0)
        {
        }

        // Affichage des information sur la personne
        public void Afficher(string msg)
        {
            Console.WriteLine("{0} :\n{1} {2} le {3}, consomme {4} tasse(s) de café\n", msg, 
                        Genre, (sexe == 'M' ? "né" : "née"), GetDateNaissance(), nbCafe);
        }

        // Renvoie le mois de naissance de la personne
        public string Mois
        {
            get
            {
                int mois = int.Parse(naissance.Substring(3, 2));
                string[] nomMois = {"janvier", "février", "mars", "avril", "mai", "juin",
                          "juillet", "août", "septembre", "octobre", "novembre", "décembre"};
                return nomMois[mois - 1];
            }
        }

        // Affichage des information sur la personne
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", sexe, naissance, nbCafe, nbCafe > 1 ? "tasses" : "tasse");
        }        

        // Renvoie la date de naissance au format "01 janvier 1970"
        private string GetDateNaissance()
        {
            return naissance.Substring(0, 2) + " " + Mois + " " + naissance.Substring(6);
        }
    }
}
