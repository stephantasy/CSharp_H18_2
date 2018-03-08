using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp2
{
    public static class Tools
    {
        /***************************
         *  === QUICK SORT  ===
         ***************************/
        private static int Partitionner(Personne[] tab, int debut, int fin)
        {
            int g = debut, d = fin;
            int valPivot = tab[debut].Numero;
            Personne temp;
            do
            {
                while (g <= d && tab[g].Numero <= valPivot) g++;
                while (tab[d].Numero > valPivot) d--;

                if (g < d)
                {
                    temp = tab[g];
                    tab[g] = tab[d];
                    tab[d] = temp;
                }

            } while (g <= d);

            temp = tab[debut];
            tab[debut] = tab[d];
            tab[d] = temp;

            return d;
        }
        // Cette fonction est récursive car dans son corps on appelle cette même fonction (2 fois)
        public static void QuickSort(Personne[] tab, int gauche, int droite)
        {
            if (droite > gauche) /* au moins 2 éléments */
            {
                if (tab[gauche] == null) return;    // Si l'élément traité est null, on quitte la méthode
                int indPivot = Partitionner(tab, gauche, droite);
                QuickSort(tab, gauche, indPivot - 1);
                QuickSort(tab, indPivot + 1, droite);
            }
        }

        /*************************************
         *  === Recherce Dichotomique  ===
         *************************************/
        public static int RechercheDicho(int aChercher, int mini, int maxi, Personne[] tab)
        {
            if (mini > maxi)
            {
                return -1;
            }
            else
            {
                int milieu = (mini + maxi) / 2;
                if (tab[milieu] != null)    // Si l'élément traité est null, on passe
                {
                    if (aChercher < tab[milieu].Numero)
                    {
                        return RechercheDicho(aChercher, mini, milieu - 1, tab);
                    }
                    else if (aChercher > tab[milieu].Numero)
                    {
                        return RechercheDicho(aChercher, milieu + 1, maxi, tab);
                    }
                    else
                    {
                        return milieu;
                    }
                }
                else {
                    return milieu;
                }
            }
        }

    }
}
