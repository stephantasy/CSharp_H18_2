using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace tp2
{
    class Tp2C
    {

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


        // Recherche tous les éléments de "chercher" dans "pers" et affiche le résultat
        private static void ChercherAfficherRecherche(string[] chercher, Personne[] pers)
        {
            int pos;                // Position de l'élément trouvé
            bool atLeastOneFound;   // Si l'élément courant a été trouvé au moins 1 fois

            // On cherche tous les éléments demandés
            for (int i = 0; i < chercher.Length; i++)
            {
                pos = 0;
                atLeastOneFound = false;
                // On cherche tant qu'on en trouve
                while (pos >= 0)
                {
                    pos = Array.IndexOf(pers, new Personne(chercher[i], ' ', 0.0, 0.0, 0), pos);                    
                    if (pos != -1) // trouvé
                    {
                        Console.WriteLine("{0} a été trouvé à la position {1}", chercher[i], pos);
                        atLeastOneFound = true;
                        pos++;
                    }
                }
                if (!atLeastOneFound)
                {
                    Console.WriteLine("{0} n'existe pas dans le tableau...", chercher[i]);
                }                
            }
        }


        // Modifie le sexe de la personne correspondant au numéro avec la nouvelle valeur
        private static void ModifierSexe(Personne[] pers, int numero, char nouvelleValeur)
        {
            bool found = false;
            char previousValue = ' ';
            foreach (var p in pers)
            {
                if(p!= null && p.Numero == numero)
                {
                    previousValue = p.Sexe;
                    p.Sexe = nouvelleValeur;
                    found = true;
                    break;  // Une seule personne ne peut correspondre au numéro
                }
            }
            if (found)
            {
                Console.WriteLine("Le sexe de la personne avec le numéro {0} a été modifié :\n\t-Ancienne valeur : {1}\n\t-Nouvelle valeur : {2}", numero, previousValue, nouvelleValeur);
            }
            else{
                Console.WriteLine("Aucune personne avec le numéro {0} n'a été trouvée...", numero);
            }
        }


        // Affiche le contenu du tableau passé en paramètre
        private static void AfficherContenuTableau(Personne[] pers)
        {
            int index = 0;
            foreach (var item in pers)
            {
                if (item != null)
                {
                    Console.WriteLine("{0,3})\t{1}", index++, item);
                }
            }
        }


        // Lit le fichier passé en paramètre, rempli le tableau avec les données lues et compte le nombre de personnes
        private static void LireFichier(string nomFichier, Personne[] tab, out int nb)
        {
            nb = 0;
            StreamReader sr = File.OpenText(nomFichier);
            string ligne = "";
            
            // On parcours le fichier
            while( (ligne = sr.ReadLine()) != null)
            {
                string nom = ligne.Substring(0, 30).Trim();
                char sexe = ligne.Substring(30, 1)[0];
                double taille = Double.Parse(ligne.Substring(31, 10));
                double poids = Double.Parse(ligne.Substring(42, 15));
                int numero = int.Parse(ligne.Substring(57));                
                tab[nb++] = new Personne(nom, sexe, taille, poids, numero);
            }
            sr.Close();
            Console.WriteLine("Fin de la lecture du fichier {0}. Il contient {1} personnes.", nomFichier, nb);
        }


        // Permet d'afficher l'énnoncé de ce qui est attendu
        private static void AfficheTitre(string msg)
        {
            string tabs = new String('-', msg.Length);
            Console.WriteLine("\n\n{0}", msg);
            Console.WriteLine("{0}\n", tabs);
        }


        // Point d'entré du programme
        static void Main(string[] args)
        {
            string nomFichier = "met_cs_h18.txt";
            const int maxPers = 30;
            Personne[] pers = new Personne[maxPers];

            // 1. Lire le fichier, de remplir le tableau pers (tableau d’objets de la classe Personne) et de compter puis de transmettre par sortie le nombre de personnes lues;
            AfficheTitre("1. Lire le fichier, remplir pers[] et compter le nombre de personnes :");
            LireFichier(nomFichier, pers, out int nbPers);


            // 2. Afficher le contenu du tableau pers en utilisant la redéfinition de ToString;
            AfficheTitre("2. Afficher le contenu du tableau pers en utilisant la redéfinition de ToString :");
            AfficherContenuTableau(pers);
            Console.WriteLine("");


            // 3. Chercher puis modifier le sexe de la personne ayant le numéro 2325 (sexe féminin au lieu de masculin)
            AfficheTitre("3. Chercher puis modifier le sexe de la personne 2325 :");
            ModifierSexe(pers, 2325, 'F');


            /* 4. Chercher séquentiellement et afficher les résultats de la recherche de:
                        Coutu Pierre, Robitaille Suzanne et Gagnon Daniel
                On affiche toutes les personnes trouvées s’il y en a plusieurs;*/
            AfficheTitre("4. Chercher séquentiellement et afficher les résultats de la recherche :");
            string[] chercherPers = {"Coutu Pierre", "Robitaille Suzanne", "Gagnon Daniel"};
            ChercherAfficherRecherche(chercherPers, pers);
            Console.WriteLine("");


            // 5. Trier le tableau pers (avec QuickSort) selon les numéros des personnes;
            AfficheTitre("5. Tri du tableau pers (avec QuickSort) selon les numéros des personnes :");
            Tools.QuickSort(pers, 0, nbPers-1);
            Console.WriteLine("Le tableau a été trié avec QuickSort\n");


            // 6. Afficher le contenu du tableau pers qui vient d’être trié;
            AfficheTitre("6. Affichage du tableau trié :");
            AfficherContenuTableau(pers);
            Console.WriteLine("");

            // 7. Chercher avec la recherche dichotomique et afficher les résultats de la recherche des personnes ayant des numéros suivants: 4612, 4371, 2325 et 9876
            int[] chercherNumero = { 4612, 4371, 2325, 9876 };
            RechercheDichoAffiche("", chercherNumero, pers);


            // 8. Supprimer la personne ayant le numéro 4371
            SupprimerPersonne(4371, pers);
            Console.WriteLine("");


            // 9. Ajouter 4 cm à la taille de la personne ayant le numéro 2636
            ModifierTaille(2636, 4, pers);
            Console.WriteLine("");


            /* 10. Insérer la personne suivante:
                        Gosselin Laurent, sexe masculin, taille 1.68 mètre, 72.1 kg, numéro 3430
                en conservant l’ordre trié des numéros du tableau. On réaffiche le contenu du tableau.*/
            Personne nouvellePersonne = new Personne("Gosselin Laurent", 'M', 1.68, 72.1, 3430);
            InsererPersonne(nouvellePersonne, pers);
            AfficherContenuTableau(pers);
            Console.WriteLine("");
        }
    }
}
