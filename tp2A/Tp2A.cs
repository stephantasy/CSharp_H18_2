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
        private static void AfficheTitre(string msg)
        {
            string tabs = new String('-', msg.Length);
            Console.WriteLine("\n\n{0}", msg);
            Console.WriteLine("{0}\n", tabs);
        }

        private static void FormaterNumero(string msg, string numero)
        {
            string noFormate = "(" + numero.Substring(0, 3) + ") " + numero.Substring(3, 3) + "-" + numero.Substring(6);
            Console.WriteLine("{0,-20} : {1}", msg, noFormate);
        }

        private static void CompterChiffreRepetition(string tel, int chiffre, string msg)
        {
            int nombre = 0;
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
            Console.WriteLine("Il y a {0} fois le chiffre {1} dans le numéro de téléphone de {2}", nombre, chiffre, msg);
        }

        private static void CompterChiffrePairImpair(string tel, bool comptePair, string msg)
        {
            int nombre = 0;
            string midMsg = "";
            List<int> listeChiffre = new List<int>();
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

            if (comptePair)
            {
                midMsg = "pair(s)";
            }
            else
            {
                midMsg = "impair(s)";
            }

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

        private static void AfficherChiffresCommuns(string tel1, string tel2)
        {
            char[] communs = new char[tel1.Length];
            int index = 0;            
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

        private static void AfficherChiffresPlusGrand(string tel, string msg)
        {
            Console.WriteLine("Le chiffre {0} est le plus grand dans le numéro de téléphone de {1}", tel.ToArray().Max(), msg);
        }

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
