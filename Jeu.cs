using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet
{
    internal class Jeu
    {
        List<Joueur> joueurs;
        List<Carte> cartes;
        List<Joueur> sensDuJeu;
        Carte carteEnCours;
        Joueur gagnant;
        Joueur joueurEnCours;
        Random rand = new Random();
        List<Carte> cartesDéjàJouées;
        int carteApiocher=0;

        //Constructeur
        public Jeu()
        {
            joueurs = new List<Joueur>();
            cartes = new List<Carte>();
            cartesDéjàJouées = new List<Carte>();

            sensDuJeu = joueurs;
            CreerMesCartes();
            Carteencours();

        }


      

        //Creation de carte
        public void CreerMesCartes()
        {
            string[] couleurs = {"vert", "jaune", "rouge", "bleu" };

            foreach (string couleur in couleurs)
            {
                cartes.Add(new CartePlus2(couleur, "+2", this));
                cartes.Add(new CartePlus2(couleur, "+2", this));

                cartes.Add(new CarteReverse(couleur, "reverse"));
                cartes.Add(new CarteReverse(couleur, "reverse"));

                cartes.Add(new CarteSauterTour(couleur, "saute"));
                cartes.Add(new CarteSauterTour(couleur, "saute"));


                for (int i = 0; i < 10; i++)
                {

                    cartes.Add(new CarteNum(couleur, i, this));

                    if (i != 0)
                    {
                        cartes.Add(new CarteNum(couleur, i, this));
                    }
                }
            }

            for (int i = 1; i < 5; i++)
            {
                cartes.Add(new CartePlus4("noir", "+4", this));
                cartes.Add(new CarteChangerCouleur("noir", "change"));
            }

        }

        //Ajoutons les joueurs dans la liste de joueurs
        public void AjouterJoueurs(Joueur J)
        {
            joueurs.Add(J);
        }



        //public void Afficher()
        //{
        //    foreach (var carte in cartes)
        //    {
        //        carte.Afficher();
        //    }
        //}

        //Distribution des cartes
        public void DistributionCarte(Joueur J)
        {


            for (int i = 0; i < 7; i++)
            {

                int indiceCarteChoisie = rand.Next(cartes.Count);
                Carte carteChoisie = cartes[indiceCarteChoisie];
                cartes.RemoveAt(indiceCarteChoisie);
                J.MesCartes.Add(carteChoisie);
            }
        }


        public void Carteencours()
        {
            int indiceEnCours = rand.Next(cartes.Count);
            carteEnCours = cartes[indiceEnCours];
            while (carteEnCours is CarteEffet)
            {
                indiceEnCours = rand.Next(cartes.Count);
                carteEnCours = cartes[indiceEnCours];

            }


            cartes.RemoveAt(indiceEnCours);
            cartesDéjàJouées.Add(carteEnCours);

        }

        public void PremierJoueurEnCours()
        {
            int indiceJoueurEnCours = rand.Next(joueurs.Count);
            joueurEnCours = joueurs[indiceJoueurEnCours];
           

        }


        public void Jouer(Joueur J)
        {
        Debut:
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t*********************************************************************");
            Console.WriteLine("\t\t**********        Joue une carte ou pioche en une          **********");
            Console.WriteLine("\t\t*********************************************************************");
            Console.WriteLine("\t\t**********      Saisis ta carte ou p si tu veux piocher    **********");
            Console.WriteLine();
            Console.ResetColor();
            while (true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\t\tEntre ta carte (ex: Rouge, 5)          :");
                    Console.ResetColor();
                    string CarteJouée = Console.ReadLine()?.Trim().ToLower();
                    char[] charCarteJouée = CarteJouée.ToCharArray();

                    char[] couleurCarteJouée = new char[charCarteJouée.Length];
                    char[] symboleCarteJouée = new char[charCarteJouée.Length];
                    bool virguletrouvée = false;

                    for (int i = 0; i < charCarteJouée.Length; i++)
                    {
                        if (charCarteJouée[i] == ',')
                        {
                            virguletrouvée = true;

                            for (int j = 0; j < i; j++)
                                couleurCarteJouée[j] = charCarteJouée[j];
                            for (int j = i + 2, k = 0; j < charCarteJouée.Length; j++, k++)
                                symboleCarteJouée[k] = charCarteJouée[j];
                        }
                    }

                    if (!virguletrouvée)
                    {
                        if (CarteJouée == "p")
                        {
                            Console.WriteLine();
                            if (carteApiocher == 0)
                            {
                                carteApiocher = 1;
                            }
                            for (int i = 0; i < carteApiocher; i++)
                            {
                                PrendreCartes(J);
                            }
                            Console.ForegroundColor = ConsoleColor.Magenta;

                            Console.WriteLine($"\t\t                 {J.Nom} a piocher {carteApiocher} cartes !\n");
                            Console.ResetColor();


                            carteApiocher = 0;
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\t\t***  Veuillez saisir votre carte sous la forme couleur, symbole   ***");
                            Console.WriteLine("\t\t*********************************************************************");
                            Console.ResetColor();
                            goto Debut;
                        }


                    }
                    else
                    {
                        string couleur = new string(couleurCarteJouée).Trim('\0');
                        string symbole = new string(symboleCarteJouée).Trim('\0');

                        bool macarte = false;
                        bool jouable = false;

                        for (int i = 0; i < J.MesCartes.Count; i++)
                        {
                            if (couleur == J.MesCartes[i].Couleur && symbole == J.MesCartes[i].Nom)
                            {
                                macarte = true;
                                if (J.MesCartes[i].Estjouable(carteEnCours, ref carteApiocher))
                                {
                                    jouable = true;
                                    carteEnCours = J.MesCartes[i];
                                    cartesDéjàJouées.Add(carteEnCours);
                                    carteEnCours.AppliquerEffet(ref sensDuJeu, ref joueurEnCours, carteEnCours, ref carteApiocher);

                                    J.MesCartes.RemoveAt(i);
                                    break;
                                }

                            }
                        }

                        if (!macarte)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\t\t                       Entrer une carte valide                       ");
                            Console.WriteLine("\t\t*********************************************************************");
                            Console.ResetColor();

                        }
                        else if (!jouable)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\t\t                   Cette carte n'est pas jouable !                   ");
                            Console.WriteLine("\t\t*********************************************************************");
                            Console.ResetColor();


                        }
                        else
                        {
                            break;

                        }

                    }
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\t\t     Entrer une carte ou saisissez p");
                    Console.WriteLine("\t\t*********************************************************************");
                    Console.ResetColor();
                }

            }
        }











        public void PrendreCartes(Joueur J)
        {
            int indiceCarteChoisie = rand.Next(cartes.Count);
            Carte carteChoisie = cartes[indiceCarteChoisie];
            cartes.RemoveAt(indiceCarteChoisie);
            J.MesCartes.Add(carteChoisie);
        }



        //deroulement du jeu
        public void Jouons()
        {
            PremierJoueurEnCours();

            while (true)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t\t*********************************************************************");

                for (int i = 0; i < sensDuJeu.Count; i++)
                {
                    Console.Write("\t\t" + sensDuJeu[i].Nom + " :  ");
                    for (int j = 0; j < sensDuJeu[i].MesCartes.Count; j++)
                    {
                        Console.Write("X  ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("\t\t*********************************************************************");
                Console.Write("\t\t            Le joueur en cours est : ");
                joueurEnCours.AfficherNom();
                Console.WriteLine();
                Console.Write("\t\t            La carte en cours est : ");
                carteEnCours.Afficher();
                Console.WriteLine();
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Green;
                
                joueurEnCours.AfficherCartes();
                Console.ResetColor();
                
                Jouer(joueurEnCours);
                // Vérifier le statut du joueur après son tour
                if (joueurEnCours.MesCartes.Count == 1)
                {
                    Console.WriteLine();
                    Console.WriteLine("\t\t*********************************************************************");
                    Console.WriteLine("\t\t                    UNO ! Il me reste une carte                     ");
                    Console.WriteLine("\t\t*********************************************************************");
                }
                else if (joueurEnCours.MesCartes.Count == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("\t\t*********************************************************************");
                    Console.WriteLine("\t\t                       Félicitations !                               ");
                    Console.Write("\t\t");
                    joueurEnCours.AfficherNom();
                    Console.WriteLine("   est le grand gagnant de cette partie !             ");
                    Console.WriteLine("\t\t*********************************************************************");
                    break;
                }

                // Vérifier si le paquet est épuisé
                if (cartes.Count == 0)
                {
                    if (cartesDéjàJouées.Count > 1)
                    {
                        Console.WriteLine();
                        Console.WriteLine("\t\t*********************************************************************");
                        Console.WriteLine("\t\t       Le paquet est vide, recyclage des cartes jouées...            ");
                        Console.WriteLine("\t\t*********************************************************************");
                        for(int i = 0; i < cartesDéjàJouées.Count-1; i++)
                        {
                            cartes[i] = cartesDéjàJouées[i];
                        }
                        cartesDéjàJouées.Clear();
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("\t\t*********************************************************************");
                        Console.WriteLine("\t\t  Désolé, il n'y a plus de cartes disponibles. Le jeu s'arrête ici.  ");
                        Console.WriteLine("\t\t                              Match nul !                            ");
                        Console.WriteLine("\t\t*********************************************************************");
                        break;
                    }
                }



                int indiceJoueurEnCours = (sensDuJeu.IndexOf(joueurEnCours) + 1) % sensDuJeu.Count;
                joueurEnCours = sensDuJeu[indiceJoueurEnCours];

            }
        }
    }
}
