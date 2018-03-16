using System;
using System.Collections.Generic;
using System.Linq;

/* ************************
 *      IFT1179 - TP2
 * Stéphane Barthélemy
 *        20084771
 ************************ */

namespace tp2
{
    class Tp2A
    {
        // Permet d'afficher l'énnoncé de ce qui est attendu
        private static void AfficheTitre(string msg)
        {
            string tabs = new String('-', msg.Length);
            Console.WriteLine("\n\n{0}", msg);
            Console.WriteLine("{0}\n", tabs);
        }


        // Formate et affiche le numéro de téléphone
        private static void FormaterNumero(string msg, string numero)
        {
            string noFormate = "(" + numero.Substring(0, 3) + ") " + numero.Substring(3, 3) + "-" + numero.Substring(6);
            Console.WriteLine("{0,-20} : {1}", msg, noFormate);
        }


        // Permet de compter le "chiffre" passé en paramètre  dans "tel" et affiche le résultat
        private static void CompterChiffreRepetition(string tel, int chiffre, string msg)
        {
            int nombre = 0;
            // On parcours la String à la recherche du chiffre
            foreach (var item in tel)
            {
                if (int.TryParse(item.ToString(), out int result))
                {
                    if (result == chiffre)
                    {
                        nombre++;
                    }
                }
            }
            // Affichage
            Console.WriteLine("Il y a {0} fois le chiffre {1} dans le numéro de téléphone de {2}", nombre, chiffre, msg);
        }


        // Permet de compter les chiffres pairs ou impairs dans "tel"
        private static void CompterChiffrePairImpair(string tel, bool comptePair, string msg)
        {
            int nombre = 0;
            string midMsg = "";
            List<int> listeChiffre = new List<int>();

            // On compte les chiffres pairs ou impairs
            foreach (var item in tel)
            {
                if (int.TryParse(item.ToString(), out int result))
                {
                    if (comptePair)
                    {
                        if (result % 2 == 0)
                        {
                            nombre++;
                            listeChiffre.Add(result);
                        }
                    }
                    else
                    {
                        if (result % 2 != 0)
                        {
                            nombre++;
                            listeChiffre.Add(result);
                        }
                    }
                }
            }

            // Message pair ou impair
            if (comptePair)
            {
                midMsg = "pair(s)";
            }
            else
            {
                midMsg = "impair(s)";
            }

            // Affichage du résultat
            if (nombre > 0)
            {                
                Console.WriteLine("Il y a {0} chiffre(s) {1} dans le numéro de téléphone de {2}", nombre, midMsg, msg);
                Console.WriteLine("Ce sont : {0}", String.Join(" ", listeChiffre.ToArray()));
            }
            else
            {
                Console.WriteLine("Il n'y a aucun chiffre {0} dans le numéro de téléphone de {1}", midMsg, msg);
            }
        }


        // Affiche les chiffres communs entres 2 numéro de tél. et les affiches
        private static void AfficherChiffresCommuns(string tel1, string tel2)
        {
            char[] communs = new char[tel1.Length];
            int index = 0;            

            // Compare les 2 numéros de tél.
            foreach (var ch1 in tel1)
            {
                foreach (var ch2 in tel2)
                {
                    if(ch1 == ch2)
                    {
                        bool dejaPresent = false;
                        foreach (var n in communs)
                        {
                            if(n == ch2)
                            {
                                dejaPresent = true;
                            }
                        }
                        if (!dejaPresent)
                        {
                            communs[index++] = ch2;
                        }
                    }
                }
            }

            // Affichage du résultat
            if (index > 0)
            {
                Console.Write("Ce sont :");
                Array.Sort(communs);
                foreach (var nb in communs)
                {
                    if (nb != '\0') {
                        Console.Write(" {0}", nb);
                    }
                }
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Il n'y a aucun chiffre en commun.");
            }
        }


        // Affiche le chiffre le plus grand dans "tel"
        private static void AfficherChiffresPlusGrand(string tel, string msg)
        {
            Console.WriteLine("Le chiffre {0} est le plus grand dans le numéro de téléphone de {1}", tel.ToArray().Max(), msg);
        }


        // Point d'entré du programme
        static void Main(string[] args)
        {
            // Données du TP
            string telUDM = "5143436111", telJean = "4501897456";

            // 1. Affichage des numéro de téléphone
            AfficheTitre("1. Affichage des numéro de téléphone :");
            FormaterNumero("Téléphone de l'UdeM", telUDM);
            FormaterNumero("Téléphone de Jean", telJean);


            // 2. Compte et affiche des chiffres
            AfficheTitre("2. Compte et affiche des chiffres :");
            CompterChiffreRepetition(telUDM, 1, "l'UdeM");
            CompterChiffreRepetition(telJean, 2, "Jean");
            CompterChiffreRepetition(telJean, 4, "Jean");


            // 3. Compte et affiche les chiffres pairs et impairs
            AfficheTitre("3. Compte et affiche les chiffres pairs et impairs :");
            CompterChiffrePairImpair(telUDM, true, "l'UdeM");
            CompterChiffrePairImpair(telJean, false, "Jean");


            // 4. Déterminer et afficher les chiffres communs de les 2 numéros de téléphone.
            AfficheTitre("4. Déterminer et afficher les chiffres communs entre les 2 numéros de téléphone :");
            AfficherChiffresCommuns(telUDM, telJean);


            // 5. Déterminer et afficher l plus grand chiffres.
            AfficheTitre("5. Déterminer et afficher le plus grand chiffre :");
            AfficherChiffresPlusGrand(telUDM, "l'UdeM");
            AfficherChiffresPlusGrand(telJean, "Jean");

            Console.WriteLine("\n");
        }
    }
}

// EXECUTION
/*
 

1. Affichage des numéro de téléphone :
--------------------------------------

Téléphone de l'UdeM  : (514) 343-6111
Téléphone de Jean    : (450) 189-7456


2. Compte et affiche des chiffres :
-----------------------------------

Il y a 4 fois le chiffre 1 dans le numéro de téléphone de l'UdeM
Il y a 0 fois le chiffre 2 dans le numéro de téléphone de Jean
Il y a 2 fois le chiffre 4 dans le numéro de téléphone de Jean


3. Compte et affiche les chiffres pairs et impairs :
----------------------------------------------------

Il y a 3 chiffre(s) pair(s) dans le numéro de téléphone de l'UdeM
Ce sont : 4 4 6
Il y a 5 chiffre(s) impair(s) dans le numéro de téléphone de Jean
Ce sont : 5 1 9 7 5


4. Déterminer et afficher les chiffres communs entre les 2 numéros de téléphone :
---------------------------------------------------------------------------------

Ce sont : 1 4 5 6


5. Déterminer et afficher le plus grand chiffre :
-------------------------------------------------

Le chiffre 6 est le plus grand dans le numéro de téléphone de l'UdeM
Le chiffre 9 est le plus grand dans le numéro de téléphone de Jean

    
 */
