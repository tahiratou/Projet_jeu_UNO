using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet
{
    internal class CartePlus4 : CarteEffet
    {

        private Jeu jeu;

        public CartePlus4(string couleur, string symbole, Jeu jeu) : base(couleur, symbole) 
        {
            this.jeu = jeu;

        }



        public override void AppliquerEffet(ref List<Joueur> SensDuJeu,ref Joueur joueurEnCours, Carte carteEnCours, ref int carteApiocher)
        {
            Console.WriteLine();
            Console.WriteLine("\t\t*********************************************************************");
            Console.WriteLine("\t\t**********                Application d'un +4               *********");
            Console.WriteLine("\t\t*********************************************************************");
            Console.WriteLine();

            int indiceJoueurEnCours = SensDuJeu.IndexOf(joueurEnCours);
            int indiceJoueurSuivant = (indiceJoueurEnCours + 1) % SensDuJeu.Count;
            carteApiocher += 4;

            // Sélection de la couleur
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
                    carteEnCours.Couleur = couleurChoisie;
                    Console.WriteLine();
                    Console.WriteLine($"\t\tLa couleur choisie est maintenant : {couleurChoisie.ToUpper()}");
                }
                else
                {
                    Console.WriteLine("\t\tCouleur invalide. Veuillez choisir parmi : vert, jaune, rouge, bleu.");
                }
            } while (!couleurValide);

            Console.WriteLine("\t\t*********************************************************************");


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
            carteEnCours.Afficher();
            Console.ResetColor();

            indiceJoueurEnCours = (indiceJoueurEnCours + 1) % SensDuJeu.Count;
            joueurEnCours = SensDuJeu[indiceJoueurEnCours];

        }


        public override bool Estjouable(Carte carteencours, ref int carteApiocher)
        {
            if (carteencours is CarteNum || carteencours is CarteEffet)
            {
                return true;
            }
            return false;
        }


    }
}
