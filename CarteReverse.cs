using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace projet
{
    internal class CarteReverse : CarteEffet
    {
        public CarteReverse(string couleur, string symbole) : base(couleur, symbole) 
        {
        }

        public override void AppliquerEffet(ref List<Joueur> SensDuJeu,ref Joueur joueurEnCours, Carte carteencours,ref int carteApiocher)
        {

            Console.WriteLine();
            Console.WriteLine("\t\t*********************************************************************");
            Console.WriteLine("\t\t**********     Application carte Changement de sens         *********");
            Console.WriteLine("\t\t*********************************************************************");
            Console.WriteLine();

            Console.WriteLine("Avant inversion :");
            foreach (var joueur in SensDuJeu)
            {
                Console.WriteLine(joueur.Nom);
            }
           

            int indiceJoueurEnCours = SensDuJeu.IndexOf(joueurEnCours) % SensDuJeu.Count;
            List<Joueur> NouveauSensDuJeu=new List<Joueur>();

            for (int j = indiceJoueurEnCours-1; j >= 0; j--)
            {
                NouveauSensDuJeu.Add(SensDuJeu[j]);

            }
            for (int j = SensDuJeu.Count-1; j > indiceJoueurEnCours-1; j--)
            {
                NouveauSensDuJeu.Add(SensDuJeu[j]);
            }



            Console.WriteLine("\t\t*********************************************************************");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("\t\t                            ");
            joueurEnCours.AfficherNom();
            Console.Write(" a joué : ");
            carteencours.Afficher();
            Console.ResetColor();
            for (int i = 0; i < SensDuJeu.Count; i++)
            {
                SensDuJeu[i] = NouveauSensDuJeu[i];
            }


        }

        public override bool Estjouable(Carte carteencours, ref int carteApiocher)
        {
            if ((carteApiocher ==0 && Couleur == carteencours.Couleur) || Nom == carteencours.Nom)
            {
                return true;
            }
            return false;
        }

    }
}
