using System;

/* ************************
 *      IFT1179 - TP2
 * Stéphane Barthélemy
 *        20084771
 ************************ */

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

        /*************************************
         *  === Suppression d'une ligne  ===
         *************************************/
        public static void SupprimerLigneDansTableau(Personne[] tab, int index)
        {
            if(index <= tab.Length)
            {
                // On copie le tableau
                Personne[] tabTemp = new Personne[tab.Length];
                Array.Copy(tab, tabTemp, tab.Length);

                // On remplace les données du tableau d'origine avec les éléments du tableau copié
                // depuis la ligne à supprimer jusqu'à la fin
                Array.Copy(tabTemp, index+1, tab, index, tab.Length-index-1);
            }
        }

        /*************************************
         *  === Insertion d'une ligne  ===
         *************************************/
        public static void InsererLigneDansTableau(Personne[] tab, Personne nouvellePersonne, int index)
        {
            if (index <= tab.Length)
            {
                // On copie le tableau
                Personne[] tabTemp = new Personne[tab.Length];
                Array.Copy(tab, tabTemp, tab.Length);

                // On place la nouvelle personne dans le tabelau
                tab[index] = nouvellePersonne;

                // On rempli le reste du tableau d'origine avec les éléments du tableau copié
                // depuis la ligne insérée +1 jusqu'à la fin
                Array.Copy(tabTemp, index, tab, index + 1, tab.Length - index-1);
            }
        }

    }
}
