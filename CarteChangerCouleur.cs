using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet
{
    internal class CarteChangerCouleur : CarteEffet
    {

        public CarteChangerCouleur(string couleur, string symbole) : base (couleur, symbole){
        }

        public override void AppliquerEffet(ref List<Joueur> SensDuJeu,ref Joueur joueurEnCours, Carte carteencours,ref int carteApiocher)
        {
            Console.WriteLine();
            Console.WriteLine("\t\t*********************************************************************");
            Console.WriteLine("\t\t**********       Application carte changer couleur          *********");
            Console.WriteLine("\t\t*********************************************************************");
            Console.WriteLine();

           

            string[] couleurs = { "vert", "jaune", "rouge", "bleu" };
            bool couleurValide = false;

            Console.WriteLine("\t\tChoisissez une nouvelle couleur pour la carte :");
            foreach (var couleur in couleurs)
            {
                Console.WriteLine($"\t\t - {couleur}");
            }

            do
            {
                Console.Write("\t\tVotre choix : ");
                string couleurChoisie = Console.ReadLine()?.Trim().ToLower();

                if (Array.Exists(couleurs, c => c == couleurChoisie))
                {
                    couleurValide = true;
                    carteencours.Couleur = couleurChoisie;
                    Console.WriteLine();
                    Console.WriteLine($"\t\tLa couleur choisie est maintenant : {couleurChoisie.ToUpper()}");
                }
                else
                {
                    Console.WriteLine("\t\tCouleur invalide. Veuillez choisir parmi : vert, jaune, rouge, bleu.");
                }
            } while (!couleurValide);

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
            if (carteApiocher != 0)
            {
                return false;
            }
            return true;
        }

    }
}
