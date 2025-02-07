using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet
{
    internal class CarteSauterTour : CarteEffet
    {
        public CarteSauterTour(string couleur, string symbole) : base(couleur, symbole) 
        {
        }

        public override void AppliquerEffet(ref List<Joueur> SensDuJeu,ref Joueur joueurEnCours, Carte carteencours,ref int carteApiocher)
        {

            Console.WriteLine();
            Console.WriteLine("\t\t*********************************************************************");
            Console.WriteLine("\t\t**********         Application carte Sauter Tour            *********");
            Console.WriteLine("\t\t*********************************************************************");
            Console.WriteLine();


            Console.WriteLine("\t\t*********************************************************************");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("\t\t                            ");
            joueurEnCours.AfficherNom();
            Console.Write(" a joué : ");
            carteencours.Afficher();
            Console.ResetColor();

            int indiceJoueurEnCours = (SensDuJeu.IndexOf(joueurEnCours) +1) % SensDuJeu.Count;
            joueurEnCours = SensDuJeu[indiceJoueurEnCours];
        }

        public override bool Estjouable(Carte carteencours, ref int carteApiocher)
        {
            if ((carteApiocher == 0 && Couleur == carteencours.Couleur) || Nom == carteencours.Nom)
            {
                return true;
            }
            return false;
        }
    }
}
