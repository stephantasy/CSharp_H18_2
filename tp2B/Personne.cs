using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp2B
{
    class Personne
    {
        private string naissance;   // format "jj/mm/aaaa", ex : "25/12/1993"
        private char sexe;
        private int nbCafe;

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

        public char Sexe
        {
            get
            {
                return sexe;
            }
        }

        public string Genre {
            get{
                return sexe == 'M' ? "Homme" : "Femme";
            }
        }

        public Personne(char sexe, string naissance, int cafe)
        {
            this.sexe = sexe;
            this.naissance = naissance;
            this.nbCafe = cafe;
        }

        public Personne(char sexe, string naissance) : this(sexe, naissance, 0)
        {
        }

        public void Afficher(string msg)
        {
            Console.WriteLine("{0} :\n{1} {2} le {3}, consomme {4} tasse(s) de café\n", msg, 
                        Genre, (sexe == 'M' ? "né" : "née"), GetDateNaissance(), nbCafe);
        }

        private object GetDateNaissance()
        {
            string[] nomMois = {"janvier", "février", "mars", "avril", "mai", "juin",
                          "juillet", "août", "septembre", "octobre", "novembre", "décembre"};

            return naissance.Substring(0, 2) + " " + Mois + " " + naissance.Substring(6);
        }

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


        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", sexe, naissance, nbCafe, nbCafe > 1 ? "tasses" : "tasse");
        }

    }
}
