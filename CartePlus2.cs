using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet
{
    internal class CartePlus2 : CarteEffet
    {

        private Jeu jeu;
        public CartePlus2(string couleur, string symbole, Jeu jeu) : base(couleur, symbole)
        {
            this.jeu = jeu;
        }




        public override void AppliquerEffet(ref List<Joueur> SensDuJeu,ref Joueur joueurEnCours, Carte carteencours, ref int carteApiocher)
        {
            Console.WriteLine();
            Console.WriteLine("\t\t*********************************************************************");
            Console.WriteLine("\t\t**********               Application d'un +2                *********");
            Console.WriteLine("\t\t*********************************************************************");
            Console.WriteLine();

            int indiceJoueurEnCours = SensDuJeu.IndexOf(joueurEnCours);
            int indiceJoueurSuivant = (indiceJoueurEnCours + 1) % SensDuJeu.Count;
            carteApiocher += 2;

            while (true)
            {
                Joueur joueurSuivant = SensDuJeu[indiceJoueurSuivant];
                bool aUneCartePlus = false;

                foreach (Carte carte in joueurSuivant.MesCartes)
                {
                    if (carte is CartePlus2 || carte is CartePlus4)
                    {
                        aUneCartePlus = true;

                        break;
                    }
                }

                if (!aUneCartePlus)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"\t\t                 {joueurSuivant.Nom} a piocher {carteApiocher} cartes !\n");
                    Console.ResetColor();

                    for (int i = 0; i < carteApiocher; i++)
                    {
                        jeu.PrendreCartes(joueurSuivant);
                    }
                    carteApiocher = 0;
                    break;
                }
                break;

            }

            Console.WriteLine("\t\t*********************************************************************");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("\t\t                            ");
            joueurEnCours.AfficherNom();
            Console.Write(" a joué : ");
            carteencours.Afficher();
            Console.ResetColor();

            indiceJoueurEnCours = (indiceJoueurEnCours + 1) % SensDuJeu.Count;
            joueurEnCours = SensDuJeu[indiceJoueurEnCours];

        }
        public override bool Estjouable(Carte carteencours, ref int carteApiocher)
        {
            if (couleur == carteencours.Couleur || Nom == carteencours.Nom || carteencours is CartePlus4)
            {
                return true;
            }
            return false;
        }

    }
}
