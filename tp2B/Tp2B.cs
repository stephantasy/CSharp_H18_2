using System;


/* ************************
 *      IFT1179 - TP2
 * Stéphane Barthélemy
 *        20084771
 ************************ */

namespace tp2
{
    class Tp2B
    {
        // Compte les personnes nées au mois "mois" et affiche le résultat
        private static void CompteAfficheMoisNaissance(Personne[] personnes, string mois)
        {
            int nb = 0;
            // On compte les personnes
            foreach (var p in personnes)
            {
                if (p.Mois.ToLower() == mois.ToLower())
                {
                    nb++;
                }
            }

            // Afficahge du résultat
            if (nb > 0)
            {
                Console.WriteLine("{0} personne(s) sont née(s) en {1}.", nb, mois);
            }
            else
            {
                Console.WriteLine("Personne n'est né en {0}...", mois);
            }
        }

        
        // Ôte "nombre" tasses de café à toutes les personnes de sexe "sexe"
        private static void ReduireCafe(Personne[] personnes, char sexe, int nombre)
        {
            foreach(var p in personnes)
            {
                if (p.Sexe == sexe)
                {
                    p.Cafe -= nombre;
                }
            }
        }


        // Permet de trouver et d'afficher les informations de la personne de sexe "sexe" qui consomme le plus de café
        private static void AfficheConsommePlusCafe(Personne[] personnes, char sexe)
        {
            int indexMaxCafe = -1, maxCafe = -1;
            // On cherche la personne de sexe "sexe" consommant le plus de café
            for (int i = 0; i < personnes.Length; i++)
            {
                if(personnes[i].Sexe == sexe)
                {
                    if (personnes[i].Cafe > maxCafe)
                    {
                        maxCafe = personnes[i].Cafe;
                        indexMaxCafe = i;
                    }
                }
            }

            // On affiche le résultat
            if(indexMaxCafe > 0)
            {
                personnes[indexMaxCafe].Afficher(String.Format("{0} consommant le plus de café", personnes[indexMaxCafe].Genre));
            }
            else
            {
                Console.WriteLine("Personne à afficher...");
            }
        }


        // Affiche le contenu du tableau passé en paramètre
        private static void AfficherTableau(Personne[] personnes)
        {
            Console.WriteLine("Contenu du tableau Personnes :\n");
            for (int i = 0; i < personnes.Length; i++)
            {
                Console.WriteLine(" {0,3})\t{1}", i, personnes[i]);
            }
        }


        // Permet d'afficher l'énnoncé de ce qui est attendu
        private static void AfficheTitre(string msg)
        {
            string tabs = new String('-', msg.Length);
            Console.WriteLine("\n\n{0}", msg);
            Console.WriteLine("{0}\n", tabs);
        }


        // Program Entry
        static void Main(string[] args)
        {
            // Donnée du TP
            Personne pers1 = new Personne('F', "19/02/1996", 3),
                     pers2 = new Personne('M', "27/07/1990");
            Personne[] personnes = {
                                        new Personne('F', "16/11/1992", 2),
                                        new Personne('F', "02/05/1990", 1),
                                        new Personne('M', "23/11/2000", 5),
                                        new Personne('F', "19/02/1985"),
                                        new Personne('F', "30/11/1991", 3),
                                        new Personne('M', "14/05/1997", 1)
                                    };


            // 0. Affichage des informations des personnes en utilisant la méthode "Afficher"
            AfficheTitre("0. Affichage des informations des personnes en utilisant la méthode Afficher() :");
            pers1.Afficher("Informations de pers1");
            pers2.Afficher("Informations de pers2");
            Console.WriteLine("");

            // 1. Afficher le contenu du tableau pers en utilisant de ToString
            AfficheTitre("1. Affiche le contenu du tableau pers en utilisant ToString :");
            AfficherTableau(personnes);
            Console.WriteLine("");

            // 2. Déterminer et afficher les informations de la femme qui consomme le plus de café
            AfficheTitre("2. Détermine et affiche les informations de la femme qui consomme le plus de café :");
            AfficheConsommePlusCafe(personnes, 'F');
            Console.WriteLine("");

            // 3. Réduire 1 tasse de moins pour les hommes en utilisant les propriétés ; réafficher le contenu du tableau
            AfficheTitre("3. Retranche 1 tasse de café à tous les hommes (puis réaffiche le tableau) :");
            ReduireCafe(personnes, 'M', 1);
            AfficherTableau(personnes);
            Console.WriteLine("");

            // 4. Trier le tableau selon le nombre de tasses de café, puis réafficher le tableau après le tri.
            AfficheTitre("4. Trie le tableau selon le nombre de tasses de café (puis réaffiche le tableau) :");
            Array.Sort(personnes, (Personne x, Personne y) => { return x.Cafe.CompareTo(y.Cafe); });
            AfficherTableau(personnes);
            Console.WriteLine("");

            // 5. Compter et afficher le nombre de personnes qui sont nées au mois de novembre.
            AfficheTitre("5. Compte et affiche le nombre de personnes qui sont nées au mois de novembre :");
            CompteAfficheMoisNaissance(personnes, "novembre");
            Console.WriteLine("");
        }
    }
}

// EXECUTION
/*

0. Affichage des informations des personnes en utilisant la méthode Afficher() :
--------------------------------------------------------------------------------

Informations de pers1 :
Femme née le 19 février 1996, consomme 3 tasse(s) de café

Informations de pers2 :
Homme né le 27 juillet 1990, consomme 0 tasse(s) de café




1. Affiche le contenu du tableau pers en utilisant ToString :
-------------------------------------------------------------

Contenu du tableau Personnes :

   0)   Femme née le 16 novembre 1992, consomme 2 tasse(s) de café
   1)   Femme née le 02 mai 1990, consomme 1 tasse(s) de café
   2)   Homme né le 23 novembre 2000, consomme 5 tasse(s) de café
   3)   Femme née le 19 février 1985, consomme 0 tasse(s) de café
   4)   Femme née le 30 novembre 1991, consomme 3 tasse(s) de café
   5)   Homme né le 14 mai 1997, consomme 1 tasse(s) de café



2. Détermine et affiche les informations de la femme qui consomme le plus de café :
-----------------------------------------------------------------------------------

Femme consommant le plus de café :
Femme née le 30 novembre 1991, consomme 3 tasse(s) de café




3. Retranche 1 tasse de café à tous les hommes (puis réaffiche le tableau) :
----------------------------------------------------------------------------

Contenu du tableau Personnes :

   0)   Femme née le 16 novembre 1992, consomme 2 tasse(s) de café
   1)   Femme née le 02 mai 1990, consomme 1 tasse(s) de café
   2)   Homme né le 23 novembre 2000, consomme 4 tasse(s) de café
   3)   Femme née le 19 février 1985, consomme 0 tasse(s) de café
   4)   Femme née le 30 novembre 1991, consomme 3 tasse(s) de café
   5)   Homme né le 14 mai 1997, consomme 0 tasse(s) de café



4. Trie le tableau selon le nombre de tasses de café (puis réaffiche le tableau) :
----------------------------------------------------------------------------------

Contenu du tableau Personnes :

   0)   Femme née le 19 février 1985, consomme 0 tasse(s) de café
   1)   Homme né le 14 mai 1997, consomme 0 tasse(s) de café
   2)   Femme née le 02 mai 1990, consomme 1 tasse(s) de café
   3)   Femme née le 16 novembre 1992, consomme 2 tasse(s) de café
   4)   Femme née le 30 novembre 1991, consomme 3 tasse(s) de café
   5)   Homme né le 23 novembre 2000, consomme 4 tasse(s) de café



5. Compte et affiche le nombre de personnes qui sont nées au mois de novembre :
-------------------------------------------------------------------------------

3 personne(s) sont née(s) en novembre.


 */

