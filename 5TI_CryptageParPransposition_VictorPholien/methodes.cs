using System;
using System.Collections.Generic;
using System.Text;

namespace _5TI_CryptageParPransposition_VictorPholien
{
    public struct methodes
    {
        /// <summary>
        /// Retirer les espaces
        /// </summary>
        /// <param name="chaine">Chaine de caractère</param>
        /// <param name="chaineSSEspaces">chaine sans les espaces</param>
        public void RetireEspaces(string chaine, out string chaineSSEspaces)
        {
            int i;
            int Ig;
            chaineSSEspaces = "";
            Ig = chaine.Length;
            for (i = 0; i < Ig; i++)
            {
                if (chaine[i] != ' ')
                {
                    chaineSSEspaces += chaine[i];
                }
            }
        }

        /// <summary>
        /// Dimension de la matrice
        /// </summary>
        /// <param name="cle">cle introduite par l'utilisateur</param>
        /// <param name="texte">texte introduit par l'utilisateur</param>
        /// <param name="matrice">matrice</param>
        public void DimensionneMat(string cle, string texte, out char[,] matrice)
        {
            int d1;
            int d2;
            d1 = (texte.Length / cle.Length) + 2;
            d2 = cle.Length;
            if (texte.Length % cle.Length != 0)
            {
                d1 = d1 + 1;
            }
            matrice = new char[d1, d2];
        }

        /// <summary>
        /// Ecrire la chaine dans la matrice
        /// </summary>
        /// <param name="cle">la cle dans le matric</param>
        /// <param name="texte">le texte dans la matrice</param>
        /// <param name="mat">matrice</param>
        public void EcritChainesDansMat(string cle, string texte, ref char[,] mat)
        {
            int i;
            int j;
            int k;
            for (j = 0; j < mat.GetLength(1) - 1; j++)
            {
                mat[0, j] = cle[j];
            }
            k = 0;
            for (i = 2; i < mat.GetLength(0) - 1; i++)
            {
                j = 0;
                while (j < mat.GetLength(1) && (k < texte.Length))
                {
                    mat[i, j] = texte[k];
                    k = k + 1;
                    j = j + 1;
                }
            }
        }

        /// <summary>
        /// tri de la première ligne
        /// </summary>
        /// <param name="mat">matrice</param>
        public void triLigne1(ref char[,] mat)
        {
            int i;
            bool permut = false;
            do
            {
                permut = false;
                for (i = 0; i < mat.GetLength(1) - 1; i++)
                {
                    if (mat[0, i] > mat[0, i + 1])
                    {
                        Echange(ref mat[0, i], ref mat[0, i + 1]);
                        permut = true;
                    }
                }
            } while (permut);
        }

        /// <summary>
        /// echange des élément dans la matrice
        /// </summary>
        /// <param name="a">a</param>
        /// <param name="b">b</param>
        public void Echange(ref char a, ref char b)
        {
            char temp = a;
            a = b;
            b = temp;
        }

        /// <summary>
        /// Classe de la cle dans la matrice
        /// </summary>
        /// <param name="cle">cle dans la matrice</param>
        /// <param name="mattri">matrice</param>
        public void ClasseCle(string cle, out char[,] mattri)
        {
            int j;
            mattri = new char[3, cle.Length];
            for (j = 0; j < mattri.GetLength(1); j++)
            {
                mattri[0, j] = cle[j];
                mattri[2, j] = '0';
            }
            triLigne1(ref mattri);
            for (j = 1; j < mattri.GetLength(1); j++)
            {
                mattri[1, j - 1] = char.Parse(j.ToString());
            }
        }

        /// <summary>
        /// Attribuer rang dans la matrice
        /// </summary>
        /// <param name="mat">Matrice de base</param>
        /// <param name="mattri">Matrice finale</param>
        public void AttribueRang(ref char[,] mat, ref char[,] mattri)
        {
            int i;
            int j;
            bool trouve;
            for (i = 0; i < mat.GetLength(1); i++)
            {
                trouve = false;
                j = 0;
                while (trouve == false && j < mattri.GetLength(1))
                {
                    if (mat[0, i] == mattri[0, j] && mattri[2, j] != '1')
                    {
                        mat[1, i] = mattri[1, j];
                        mattri[2, j] = '1';
                        trouve = true;
                    }
                    j = j + 1;
                }
            }
        }

        /// <summary>
        /// Realiser le cryptage 
        /// </summary>
        /// <param name="mat">matrice</param>
        /// <param name="chaineCrypt">chaine de caractère crypté</param>
        public void RealiseCrypt(char[,] mat, out string chaineCrypt)
        {
            int j;
            int i;
            int k;
            bool trouve;
            i = 1;
            chaineCrypt = "";
            while (i <= mat.GetLength(1))
            {
                trouve = false;
                j = 0;
                while (!trouve && j < mat.GetLength(1))
                {
                    if (i == mat[1, j])
                    {
                        for (k = 2; k < mat.GetLength(0); k++)
                        {
                            chaineCrypt += mat[k, j];
                        }
                        chaineCrypt += " ";
                        trouve = true;
                    }
                    j = j + 1;
                }
                i = i + 1;
            }
        }
    }
}
