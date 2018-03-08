using System;

namespace tp2
{
    class Tp2C
    {
        static void Main(string[] args)
        {
            string nomFichier = "met_cs_h18.txt";
            const int maxPers = 30;
            Personne[] pers = new Personne[maxPers];

            // 1. Lire le fichier, de remplir le tableau pers (tableau d’objets de la classe Personne) et de compter puis de transmettre par sortie le nombre de personnes lues;
            LireFichier(nomFichier, pers, out int nbPers);


            // 2. Afficher le contenu du tableau pers en utilisant la redéfinition de ToString;
            AfficherContenuTableau("Contenu du tableau : ", pers);


            // 3. Chercher puis modifier le sexe de la personne ayant le numéro 2325 (sexe féminin au lieu de masculin)
            ModifierSexe(pers, 2345, 'F');


            /* 4. Chercher séquentiellement et afficher les résultats de la recherche de:
                        Coutu Pierre, Robitaille Suzanne et Gagnon Daniel
                On affiche toutes les personnes trouvées s’il y en a plusieurs;*/
            string[] chercherPers = {"Coutu Pierre", "Robitaille Suzanne", "Gagnon Daniel"};
            ChercherAfficherRecherche(chercherPers, pers);


            // 5. Trier le tableau pers (avec QuickSort) selon les numéros des personnes;
            Tools.QuickSort(pers, 0, pers.Length - 1);


            // 6. Afficher le contenu du tableau pers qui vient d’être trié;
            AfficherContenuTableau("Contenu du tableau trié : ", pers);


            // 7. Chercher avec la recherche dichotomique et afficher les résultats de la recherche des personnes ayant des numéros suivants: 4612, 4371, 2325 et 9876
            int[] chercherNumero = { 4612, 4371, 2325, 9876 };
            RechercheDichoAffiche("", chercherNumero, pers);


            // 8. Supprimer la personne ayant le numéro 4371
            SupprimerPersonne(4371, pers);


            // 9. Ajouter 4 cm à la taille de la personne ayant le numéro 2636
            ModifierTaille(2636, 4, pers);


            /* 10. Insérer la personne suivante:
                        Gosselin Laurent, sexe masculin, taille 1.68 mètre, 72.1 kg, numéro 3430
                en conservant l’ordre trié des numéros du tableau. On réaffiche le contenu du tableau.*/
            Personne nouvellePersonne = new Personne("Gosselin Laurent", 'M', 1.68, 72.1, 3430);
            InsererPersonne(nouvellePersonne, pers);
            AfficherContenuTableau("Contenu du tableau après ajout : ", pers);
        }

        private static void InsererPersonne(Personne nouvellePersonne, Personne[] pers)
        {
        }

        private static void ModifierTaille(int numero, int cm, Personne[] pers)
        {
        }

        private static void SupprimerPersonne(int numero, Personne[] pers)
        {
            // + message !
        }

        private static void RechercheDichoAffiche(string message, int[] chercherNumero, Personne[] pers)
        {
            /*Remarques : Pour la recherche, si on trouve une personne, on affiche ses coordonnées,
                     Sinon, on affiche un message pertinent.*/

            // Recherche dichotomique
            //foreach...
            Tools.RechercheDicho(chercherNumero[0], 0, pers.Length - 1, pers);
        }

        private static void ChercherAfficherRecherche(string[] chercher, Personne[] pers)
        {
            /*Remarques : Pour la recherche, si on trouve une personne, on affiche ses coordonnées,
              Sinon, on affiche un message pertinent.*/

            int lastPos = 0;
            bool atLeastOneFound = false;
            for (int i = 0; i < chercher.Length; i++)
            {
                int pos = Array.IndexOf(pers, new Personne(chercher[i], ' ', 0.0, 0.0, 0), lastPos);
                if (pos != -1) // trouvé
                {
                    Console.WriteLine("{0} a été trouvé à la position {1}", chercher[i], i);
                    atLeastOneFound = true;
                }
                else
                {
                    if (!atLeastOneFound)
                    {
                        Console.WriteLine("{0} n'existe pas dans le tableau...", chercher[i]);
                    }
                }
            }
        }

        private static void ModifierSexe(Personne[] pers, int numero, char nouvelleValeur)
        {
            // Afficher message du résultat (positif ou négatif !)
        }

        private static void AfficherContenuTableau(string msg, Personne[] pers)
        {
            Console.WriteLine(msg);
            foreach (var item in pers)
            {
                if (item != null)
                {
                    Console.WriteLine(item);
                }
            }
        }

        // 
        // Note : La méthode employé ci-dessous n'est pas des plus efficace, mais dans ce genre de car, on utilise une List plutôt qu'un tableau...
        private static void LireFichier(string nomFichier, Personne[] tab, out int nb)
        {            
            nb = 0;            
        }
    }
}
