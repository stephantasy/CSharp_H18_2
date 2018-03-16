using System;
using System.IO;

/* ************************
 *      IFT1179 - TP2
 * Stéphane Barthélemy
 *        20084771
 ************************ */

namespace tp2
{
    class Tp2C
    {

        // On recherche la position où inséerer "nouvellePersonne" (Attention, "pers" doit être trié !)
        private static int CherchePositionNumero(Personne[] pers, int numero)
        {
            int pos = -1;

            // On cherche où insérer la nouvelle personne
            for (int i = 0; i < pers.Length; i++)
            {
                if (pers[i] != null)
                {
                    if (pers[i].Numero > numero)
                    {
                        pos = i;
                        break;
                    }
                }
                else
                {
                    // si on ne l'a pas trouvé, on retourne la 1ère position disponible (soit = null)
                    pos = i;
                    break;
                }
            }
            return pos;
        }


        // Ajoute une personne dans le tableau
        private static void InsererPersonne(Personne[] pers, Personne nouvellePersonne, ref int nbPers)
        {
            int index = -1;
            // On s'assure qu'il y a de place dans le tableau
            if (nbPers < pers.Length)
            {
                // On recherche où insérer le numéro
                index = CherchePositionNumero(pers, nouvellePersonne.Numero);
            }
            // Si index est positif, c'est qu'il y a de la place
            if(index >= 0)
            {
                Console.WriteLine("Insertion à l'index {0} de : \n{1}", index, nouvellePersonne);
                Tools.InsererLigneDansTableau(pers, nouvellePersonne, index);
                nbPers++;   // On n'oubli pas d'incérmenter le nombre de personne
            }
            else
            {
                Console.WriteLine("Impossible d'insérer une nouvelle personne, il n'y a plude de place dans le tableau.");
            }
        }


        // Modifie la taille de la personne demandée
        private static void ModifierTaille(int numero, int cm, Personne[] pers, int nbPers)
        {
            // On recherche le numéro avec la recherche dihotomique
            int index = Tools.RechercheDicho(numero, 0, nbPers - 1, pers);
            if (index > 0)
            {
                double previousValue = pers[index].Taille;
                pers[index].Taille += (cm/100.0);
                Console.WriteLine("La taille de la personne avec le numéro {0} a été modifié :\n\t- Ancienne valeur : {1} mètre\n\t- Nouvelle valeur : {2} mètre", numero, previousValue, pers[index].Taille);
            }
            else
            {
                Console.WriteLine("Impossible de modifier la taille de la personne correspondant au numéro {0}. Elle n'existe pas.\n", numero);
            }
        }


        // Supprime la personne ayant le numéro passé en paramètre
        private static void SupprimerPersonne(int numero, Personne[] pers, ref int nbPers)
        {
            // On recherche le numéro avec la recherche dihotomique
            int index = Tools.RechercheDicho(numero, 0, nbPers - 1, pers);
            if (index > 0)
            {
                // On efface le contenu
                Tools.SupprimerLigneDansTableau(pers, index);
                // On n'oubli pas de retrancher 1
                nbPers -= 1;
                // Affichage
                Console.WriteLine("La personne avec le numéro {0} a été supprimée du tableau !\n", numero, pers[index]);
            }
            else
            {
                Console.WriteLine("Impossible de supprimer la personne correspondant au numéro {0}. Elle n'existe pas.\n", numero);
            }
        }


        // Utilise la recherche dichotomique pour trouver les personnes avec les numéros demandés
        private static void RechercheDichoAffiche(string message, int[] chercherNumero, Personne[] pers, int nbPers)
        {
            // On parcours tous les numéro recherchés
            foreach (var no in chercherNumero)
            {
                // On recherche le numéro avec la recherche dihotomique
                int index = Tools.RechercheDicho(no, 0, nbPers - 1, pers);
                if(index > 0)
                {
                    Console.WriteLine("La peronne avec le numéro {0} est : {1}\n", no, pers[index]);
                }
                else
                {
                    Console.WriteLine("Aucune personne ne correspond au numéro {0}\n", no);
                }
            }
            
        }


        // Tri le tableau passée en paramètre avec QuickSort
        private static void TriAvecQuickSort(Personne[] pers, int nbPers)
        {
            Tools.QuickSort(pers, 0, nbPers - 1);
            Console.WriteLine("Le tableau a été trié avec QuickSort\n");
        }


        // Utilise la recherche séquentielle pour trouver tous les éléments de "chercher" dans "pers" et affiche le résultat
        private static void RechercherSeqAffiche(string[] chercher, Personne[] pers)
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
                        Console.WriteLine("{0} a été trouvé à la position {1} :\n\t{2}\n", chercher[i], pos, pers[pos]);
                        atLeastOneFound = true;
                        pos++;
                    }
                }
                if (!atLeastOneFound)
                {
                    Console.WriteLine("{0} n'existe pas dans le tableau...\n", chercher[i]);
                }                
            }
        }


        // Modifie le sexe de la personne correspondant au numéro avec la nouvelle valeur
        private static void ModifierSexe(Personne[] pers, int numero, char nouvelleValeur)
        {
            char previousValue = ' ';
            foreach (var p in pers)
            {
                if(p!= null && p.Numero == numero)
                {
                    previousValue = p.Sexe;
                    p.Sexe = nouvelleValeur;
                    Console.WriteLine("Le sexe de la personne avec le numéro {0} a été modifié :\n\t- Ancienne valeur : {1}\n\t- Nouvelle valeur : {2}", numero, previousValue, nouvelleValeur);
                    return;  // On quitte, car une seule personne ne peut correspondre au numéro
                }
            }
            // Si la personne n'a pas été trouvée
            Console.WriteLine("Aucune personne avec le numéro {0} n'a été trouvée...", numero);            
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
                else
                {
                    Console.WriteLine("{0,3})\tVide", index++);
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
            RechercherSeqAffiche(chercherPers, pers);
            Console.WriteLine("");


            // 5. Trier le tableau pers (avec QuickSort) selon les numéros des personnes;
            AfficheTitre("5. Tri du tableau pers (avec QuickSort) selon les numéros des personnes :");
            TriAvecQuickSort(pers, nbPers);


            // 6. Afficher le contenu du tableau pers qui vient d’être trié;
            AfficheTitre("6. Affichage du tableau trié :");
            AfficherContenuTableau(pers);
            Console.WriteLine("");

            // 7. Chercher avec la recherche dichotomique et afficher les résultats de la recherche des personnes ayant des numéros suivants: 4612, 4371, 2325 et 9876
            AfficheTitre("7. Chercher avec la recherche dichotomique et afficher les résultats  :");
            int[] chercherNumero = { 4612, 4371, 2325, 9876 };
            RechercheDichoAffiche("", chercherNumero, pers, nbPers);


            // 8. Supprimer la personne ayant le numéro 4371
            AfficheTitre(" 8. Supprimer la personne ayant le numéro 4371 :");
            SupprimerPersonne(4371, pers, ref nbPers);
            Console.WriteLine("");


            // 9. Ajouter 4 cm à la taille de la personne ayant le numéro 2636
            AfficheTitre("9. Ajouter 4 cm à la taille de la personne ayant le numéro 2636 :");
            ModifierTaille(2636, 4, pers, nbPers);
            Console.WriteLine("");


            /* 10. Insérer la personne suivante:
                        Gosselin Laurent, sexe masculin, taille 1.68 mètre, 72.1 kg, numéro 3430
                en conservant l’ordre trié des numéros du tableau. On réaffiche le contenu du tableau.*/
            AfficheTitre("10-1. Insérer une personne :");
            Personne nouvellePersonne = new Personne("Gosselin Laurent", 'M', 1.68, 72.1, 3430);
            InsererPersonne(pers, nouvellePersonne, ref nbPers);
            AfficheTitre("10-2. Contenu du tableau après insertion :");
            AfficherContenuTableau(pers);
            Console.WriteLine("");
        }
    }
}

// EXECUTION
/*
 

1. Lire le fichier, remplir pers[] et compter le nombre de personnes :
----------------------------------------------------------------------

Fin de la lecture du fichier met_cs_h18.txt. Il contient 28 personnes.


2. Afficher le contenu du tableau pers en utilisant la redéfinition de ToString :
---------------------------------------------------------------------------------

  0)    ROY CHANTAL, sexe féminin, taille 1,75 mètre, 57,9 kg, numéro 2754
  1)    MOLAISON CLAUDE, sexe masculin, taille 1,57 mètre, 62,2 kg, numéro 1848
  2)    ROBITAILLE CHANTALE, sexe féminin, taille 1,79 mètre, 72,3 kg, numéro 2007
  3)    BEDARD MARC-ANDRE, sexe masculin, taille 1,43 mètre, 55,5 kg, numéro 2636
  4)    MONAST STEPHANE, sexe masculin, taille 1,65 mètre, 61,7 kg, numéro 1750
  5)    JALBERT LYNE, sexe féminin, taille 1,63 mètre, 52,6 kg, numéro 2168
  6)    DUBE FRANCOISE, sexe féminin, taille 1,68 mètre, 67,5 kg, numéro 4612
  7)    ROBITAILLE SUZANNE, sexe masculin, taille 1,72 mètre, 75,4 kg, numéro 2325
  8)    LEMELIN SOPHIE, sexe féminin, taille 1,88 mètre, 57,8 kg, numéro 7777
  9)    LABELLE LISE, sexe féminin, taille 1,79 mètre, 68,0 kg, numéro 1512
 10)    CHOQUETTE HELENE, sexe féminin, taille 1,71 mètre, 60,8 kg, numéro 2340
 11)    MICHAUD NORMAND, sexe masculin, taille 1,73 mètre, 103,7 kg, numéro 3428
 12)    RICHER AGATHE, sexe féminin, taille 1,65 mètre, 53,1 kg, numéro 3563
 13)    ROY SERGE, sexe masculin, taille 1,70 mètre, 74,3 kg, numéro 1488
 14)    BEGIN MARIE-LUCE, sexe féminin, taille 1,62 mètre, 49,0 kg, numéro 4101
 15)    ROBITAILLE SUZANNE, sexe féminin, taille 1,63 mètre, 75,1 kg, numéro 7654
 16)    COUTU PIERRE, sexe masculin, taille 1,72 mètre, 62,1 kg, numéro 4008
 17)    TREMBLAY SUZANNE, sexe féminin, taille 1,48 mètre, 61,5 kg, numéro 4371
 18)    BERGEVIN GUILLAUME, sexe masculin, taille 1,84 mètre, 86,4 kg, numéro 2277
 19)    DUMITRU PIERRE, sexe masculin, taille 1,82 mètre, 99,4 kg, numéro 3629
 20)    ROBITAILLE MICHEL, sexe masculin, taille 1,78 mètre, 85,1 kg, numéro 6002
 21)    GOFFIN SYLVIE, sexe féminin, taille 1,65 mètre, 53,1 kg, numéro 5505
 22)    FILLION ERIC, sexe masculin, taille 1,78 mètre, 75,7 kg, numéro 2630
 23)    DESMARAIS DENISE, sexe féminin, taille 1,79 mètre, 58,7 kg, numéro 3215
 24)    TREMBLAY MARC, sexe masculin, taille 1,79 mètre, 64,9 kg, numéro 3529
 25)    TREMBLAY SYLVAIN, sexe masculin, taille 1,83 mètre, 86,2 kg, numéro 1538
 26)    ROBITAILLE SUZANNE, sexe féminin, taille 1,68 mètre, 60,2 kg, numéro 4119
 27)    CHOQUETTE ALAIN, sexe masculin, taille 1,78 mètre, 68,2 kg, numéro 8009
 28)    Vide
 29)    Vide



3. Chercher puis modifier le sexe de la personne 2325 :
-------------------------------------------------------

Le sexe de la personne avec le numéro 2325 a été modifié :
        - Ancienne valeur : M
        - Nouvelle valeur : F


4. Chercher séquentiellement et afficher les résultats de la recherche :
------------------------------------------------------------------------

Coutu Pierre a été trouvé à la position 16 :
        COUTU PIERRE, sexe masculin, taille 1,72 mètre, 62,1 kg, numéro 4008

Robitaille Suzanne a été trouvé à la position 7 :
        ROBITAILLE SUZANNE, sexe féminin, taille 1,72 mètre, 75,4 kg, numéro 2325

Robitaille Suzanne a été trouvé à la position 15 :
        ROBITAILLE SUZANNE, sexe féminin, taille 1,63 mètre, 75,1 kg, numéro 7654

Robitaille Suzanne a été trouvé à la position 26 :
        ROBITAILLE SUZANNE, sexe féminin, taille 1,68 mètre, 60,2 kg, numéro 4119

Gagnon Daniel n'existe pas dans le tableau...




5. Tri du tableau pers (avec QuickSort) selon les numéros des personnes :
-------------------------------------------------------------------------

Le tableau a été trié avec QuickSort



6. Affichage du tableau trié :
------------------------------

  0)    ROY SERGE, sexe masculin, taille 1,70 mètre, 74,3 kg, numéro 1488
  1)    LABELLE LISE, sexe féminin, taille 1,79 mètre, 68,0 kg, numéro 1512
  2)    TREMBLAY SYLVAIN, sexe masculin, taille 1,83 mètre, 86,2 kg, numéro 1538
  3)    MONAST STEPHANE, sexe masculin, taille 1,65 mètre, 61,7 kg, numéro 1750
  4)    MOLAISON CLAUDE, sexe masculin, taille 1,57 mètre, 62,2 kg, numéro 1848
  5)    ROBITAILLE CHANTALE, sexe féminin, taille 1,79 mètre, 72,3 kg, numéro 2007
  6)    JALBERT LYNE, sexe féminin, taille 1,63 mètre, 52,6 kg, numéro 2168
  7)    BERGEVIN GUILLAUME, sexe masculin, taille 1,84 mètre, 86,4 kg, numéro 2277
  8)    ROBITAILLE SUZANNE, sexe féminin, taille 1,72 mètre, 75,4 kg, numéro 2325
  9)    CHOQUETTE HELENE, sexe féminin, taille 1,71 mètre, 60,8 kg, numéro 2340
 10)    FILLION ERIC, sexe masculin, taille 1,78 mètre, 75,7 kg, numéro 2630
 11)    BEDARD MARC-ANDRE, sexe masculin, taille 1,43 mètre, 55,5 kg, numéro 2636
 12)    ROY CHANTAL, sexe féminin, taille 1,75 mètre, 57,9 kg, numéro 2754
 13)    DESMARAIS DENISE, sexe féminin, taille 1,79 mètre, 58,7 kg, numéro 3215
 14)    MICHAUD NORMAND, sexe masculin, taille 1,73 mètre, 103,7 kg, numéro 3428
 15)    TREMBLAY MARC, sexe masculin, taille 1,79 mètre, 64,9 kg, numéro 3529
 16)    RICHER AGATHE, sexe féminin, taille 1,65 mètre, 53,1 kg, numéro 3563
 17)    DUMITRU PIERRE, sexe masculin, taille 1,82 mètre, 99,4 kg, numéro 3629
 18)    COUTU PIERRE, sexe masculin, taille 1,72 mètre, 62,1 kg, numéro 4008
 19)    BEGIN MARIE-LUCE, sexe féminin, taille 1,62 mètre, 49,0 kg, numéro 4101
 20)    ROBITAILLE SUZANNE, sexe féminin, taille 1,68 mètre, 60,2 kg, numéro 4119
 21)    TREMBLAY SUZANNE, sexe féminin, taille 1,48 mètre, 61,5 kg, numéro 4371
 22)    DUBE FRANCOISE, sexe féminin, taille 1,68 mètre, 67,5 kg, numéro 4612
 23)    GOFFIN SYLVIE, sexe féminin, taille 1,65 mètre, 53,1 kg, numéro 5505
 24)    ROBITAILLE MICHEL, sexe masculin, taille 1,78 mètre, 85,1 kg, numéro 6002
 25)    ROBITAILLE SUZANNE, sexe féminin, taille 1,63 mètre, 75,1 kg, numéro 7654
 26)    LEMELIN SOPHIE, sexe féminin, taille 1,88 mètre, 57,8 kg, numéro 7777
 27)    CHOQUETTE ALAIN, sexe masculin, taille 1,78 mètre, 68,2 kg, numéro 8009
 28)    Vide
 29)    Vide



7. Chercher avec la recherche dichotomique et afficher les résultats  :
-----------------------------------------------------------------------

La peronne avec le numéro 4612 est : DUBE FRANCOISE, sexe féminin, taille 1,68 mètre, 67,5 kg, numéro 4612

La peronne avec le numéro 4371 est : TREMBLAY SUZANNE, sexe féminin, taille 1,48 mètre, 61,5 kg, numéro 4371

La peronne avec le numéro 2325 est : ROBITAILLE SUZANNE, sexe féminin, taille 1,72 mètre, 75,4 kg, numéro 2325

Aucune personne ne correspond au numéro 9876



 8. Supprimer la personne ayant le numéro 4371 :
------------------------------------------------

La personne avec le numéro 4371 a été supprimée du tableau !




9. Ajouter 4 cm à la taille de la personne ayant le numéro 2636 :
-----------------------------------------------------------------

La taille de la personne avec le numéro 2636 a été modifié :
        - Ancienne valeur : 1,43 mètre
        - Nouvelle valeur : 1,47 mètre



10-1. Insérer une personne :
----------------------------

Insertion à l'index 15 de :
GOSSELIN LAURENT, sexe masculin, taille 1,68 mètre, 72,1 kg, numéro 3430


10-2. Contenu du tableau après insertion :
------------------------------------------

  0)    ROY SERGE, sexe masculin, taille 1,70 mètre, 74,3 kg, numéro 1488
  1)    LABELLE LISE, sexe féminin, taille 1,79 mètre, 68,0 kg, numéro 1512
  2)    TREMBLAY SYLVAIN, sexe masculin, taille 1,83 mètre, 86,2 kg, numéro 1538
  3)    MONAST STEPHANE, sexe masculin, taille 1,65 mètre, 61,7 kg, numéro 1750
  4)    MOLAISON CLAUDE, sexe masculin, taille 1,57 mètre, 62,2 kg, numéro 1848
  5)    ROBITAILLE CHANTALE, sexe féminin, taille 1,79 mètre, 72,3 kg, numéro 2007
  6)    JALBERT LYNE, sexe féminin, taille 1,63 mètre, 52,6 kg, numéro 2168
  7)    BERGEVIN GUILLAUME, sexe masculin, taille 1,84 mètre, 86,4 kg, numéro 2277
  8)    ROBITAILLE SUZANNE, sexe féminin, taille 1,72 mètre, 75,4 kg, numéro 2325
  9)    CHOQUETTE HELENE, sexe féminin, taille 1,71 mètre, 60,8 kg, numéro 2340
 10)    FILLION ERIC, sexe masculin, taille 1,78 mètre, 75,7 kg, numéro 2630
 11)    BEDARD MARC-ANDRE, sexe masculin, taille 1,47 mètre, 55,5 kg, numéro 2636
 12)    ROY CHANTAL, sexe féminin, taille 1,75 mètre, 57,9 kg, numéro 2754
 13)    DESMARAIS DENISE, sexe féminin, taille 1,79 mètre, 58,7 kg, numéro 3215
 14)    MICHAUD NORMAND, sexe masculin, taille 1,73 mètre, 103,7 kg, numéro 3428
 15)    GOSSELIN LAURENT, sexe masculin, taille 1,68 mètre, 72,1 kg, numéro 3430
 16)    TREMBLAY MARC, sexe masculin, taille 1,79 mètre, 64,9 kg, numéro 3529
 17)    RICHER AGATHE, sexe féminin, taille 1,65 mètre, 53,1 kg, numéro 3563
 18)    DUMITRU PIERRE, sexe masculin, taille 1,82 mètre, 99,4 kg, numéro 3629
 19)    COUTU PIERRE, sexe masculin, taille 1,72 mètre, 62,1 kg, numéro 4008
 20)    BEGIN MARIE-LUCE, sexe féminin, taille 1,62 mètre, 49,0 kg, numéro 4101
 21)    ROBITAILLE SUZANNE, sexe féminin, taille 1,68 mètre, 60,2 kg, numéro 4119
 22)    DUBE FRANCOISE, sexe féminin, taille 1,68 mètre, 67,5 kg, numéro 4612
 23)    GOFFIN SYLVIE, sexe féminin, taille 1,65 mètre, 53,1 kg, numéro 5505
 24)    ROBITAILLE MICHEL, sexe masculin, taille 1,78 mètre, 85,1 kg, numéro 6002
 25)    ROBITAILLE SUZANNE, sexe féminin, taille 1,63 mètre, 75,1 kg, numéro 7654
 26)    LEMELIN SOPHIE, sexe féminin, taille 1,88 mètre, 57,8 kg, numéro 7777
 27)    CHOQUETTE ALAIN, sexe masculin, taille 1,78 mètre, 68,2 kg, numéro 8009
 28)    Vide
 29)    Vide


 */
