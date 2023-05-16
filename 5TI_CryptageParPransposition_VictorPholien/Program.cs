using System;

namespace _5TI_CryptageParPransposition_VictorPholien
{
    class Program
    {
        static void Main(string[] args)
        {
            bool recommencer = true;

            while (recommencer)
            {
                methodes MesOutils = new methodes();
                Console.WriteLine("Cryptage par transposition");
                Console.Write("Entrez la clé : ");
                string cle = Console.ReadLine();

                if (MesOutils.(cle))
                {
                    Console.WriteLine("Clé invalide. Veuillez entrer une clé contenant uniquement des caractères alphabétiques.");
                    continue;
                }

                Console.Write("Entrez le texte à crypter : ");
                string texte = Console.ReadLine();

                string texteSansEspaces;
                MesOutils.RetireEspaces(texte, out texteSansEspaces);

                char[,] matrice;
                MesOutils.DimensionneMat(cle, texteSansEspaces, out matrice);

                MesOutils.EcritChainesDansMat(cle, texteSansEspaces, ref matrice);

                MesOutils.triLigne1(ref matrice);

                char[,] matriceTri;
                MesOutils.ClasseCle(cle, out matriceTri);

                MesOutils.AttribueRang(ref matrice, ref matriceTri);

                string chaineCryptee;
                MesOutils.RealiseCrypt(matrice, out chaineCryptee);

                Console.WriteLine("Texte crypté : " + chaineCryptee);

                Console.Write("Voulez-vous recommencer (O/N) ? ");
                string reponse = Console.ReadLine();

                if (reponse.ToUpper() != "O")
                    recommencer = false;

                Console.WriteLine();
            }
        }
    }
}

