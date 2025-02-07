using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet
{
    internal class CarteNum : Carte
    {
        private int numero;
        private Jeu jeu;
        public CarteNum(string couleur, int numero, Jeu jeu)  :base(couleur, $"{numero}")
        {
            this.numero = numero;
            this.jeu = jeu;
        }

        public override void AppliquerEffet(ref List<Joueur> SensDuJeu,ref Joueur joueurEnCours, Carte carteencours,ref int carteApiocher)
        {

            Console.WriteLine("\t\t*********************************************************************");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("\t\t                            ");
            joueurEnCours.AfficherNom();
            Console.Write(" a joué : ");
            carteencours.Afficher();
            Console.ResetColor();
        }

        public override bool Estjouable(Carte carteencours, ref int carteApiocher)
        {
            if ((carteencours.Nom == "+4" && carteApiocher!=0 )|| (carteencours.Nom == "+2" && carteApiocher!=0))
            {
                return false;
            }
            else if (Couleur == carteencours.Couleur || Nom == carteencours.Nom)
            {
                return true;
            }
            else { return false; }
        }
        public override void Afficher()
        {
            switch (couleur)
            {
                case "vert":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "jaune":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "rouge":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "bleu":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case "noir":
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                default:
                    Console.ResetColor();
                    break;
            }
            Console.WriteLine(couleur +", " + numero);
            Console.ResetColor();

        }
    }
}
