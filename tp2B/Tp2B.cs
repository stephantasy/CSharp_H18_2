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
        

        private static void CompteAfficheMoisNaissance(Personne[] personnes, string mois)
        {
            int nb = 0;
            foreach (var p in personnes)
            {
                if (p.Mois.ToLower() == mois.ToLower())
                {
                    nb++;
                }
            }

            if (nb > 0)
            {
                Console.WriteLine("{0} personne(s) sont né(s) en {1}.", nb, mois);
            }
            else
            {
                Console.WriteLine("Personne n'est né en {0}...", mois);
            }
        }


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

        private static void AfficheConsommePlusCafe(Personne[] personnes, char sexe)
        {
            int indexMaxCafe = -1, maxCafe = -1;
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

            if(indexMaxCafe > 0)
            {
                personnes[indexMaxCafe].Afficher(String.Format("{0} consommant le plus de café", personnes[indexMaxCafe].Genre));
            }
            else
            {
                Console.WriteLine("Personne à afficher...");
            }
        }

        private static void AfficherTableau(Personne[] personnes)
        {
            Console.WriteLine("Contenu du tableau Personnes :");
            for (int i = 0; i < personnes.Length; i++)
            {
                Console.WriteLine(" {0} - {1}", i, personnes[i]);
            }
        }

        // Program Entry
        static void Main(string[] args)
        {
            // Donnée du TP
            Personne[] personnes =
            {
                new Personne('F', "16/11/1992", 2),
                new Personne('F', "02/05/1990", 1),
                new Personne('M', "23/11/2000", 5),
                new Personne('F', "19/02/1985"),
                new Personne('F', "30/11/1991", 3),
                new Personne('M', "14/05/1997", 1)
            };
            Personne pers1 = new Personne('F', "19/02/1996", 3),
                     pers2 = new Personne('M', "27/07/1990");


            pers1.Afficher("Informations de pers1");
            pers2.Afficher("Informations de pers2");
            Console.WriteLine("");


            AfficherTableau(personnes);
            Console.WriteLine("");


            AfficheConsommePlusCafe(personnes, 'F');
            Console.WriteLine("");


            ReduireCafe(personnes, 'M', 1);
            AfficherTableau(personnes);
            Console.WriteLine("");


            Array.Sort(personnes, (Personne x, Personne y) => { return x.Cafe.CompareTo(y.Cafe); });
            AfficherTableau(personnes);
            Console.WriteLine("");


            CompteAfficheMoisNaissance(personnes, "novembre");
            Console.WriteLine("");
        }
    }
}
