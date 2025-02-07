
using projet;
internal class Program
{
    private static void Main(string[] args)
    {
        Jeu jeu = new Jeu();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\t\t*********************************************************************");
        Console.WriteLine("\t\t                 Bienvenue dans le jeu UNO !                        ");
        Console.WriteLine("\t\t*********************************************************************");
        Console.ResetColor();

        int nbrJoueurs = 0;
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\t\tVeuillez entrer le nombre de joueurs (au moins 2) :");
        Console.ResetColor();

        while (true)
        {
            try
            {
                Console.Write("\t\t> ");
                nbrJoueurs = int.Parse(Console.ReadLine());

                if (nbrJoueurs < 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\t\tErreur : Le nombre de joueurs doit être supérieur ou égal à 2.");
                    Console.ResetColor();
                }
                else
                {
                    break;
                }
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\tErreur : Veuillez entrer un nombre valide.");
                Console.ResetColor();
            }
        }


        // Saisie des noms des joueurs
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\t\tEntrez les noms des joueurs :");
        Console.ResetColor();

        string[] Nomjoueurs = new string[nbrJoueurs];
        Joueur[] joueurs = new Joueur[nbrJoueurs];

       
        Console.Write($"\t\tNom du joueur {1} : ");
        Nomjoueurs[0] = Console.ReadLine()?.Trim().ToLower();
        while (Nomjoueurs[0]=="")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\tErreur : Le nom du joueur ne peut pas être vide.");
            Console.ResetColor();
            Console.Write($"\t\tNom du joueur {1} : ");
            Nomjoueurs[0] = Console.ReadLine()?.Trim().ToLower(); ;

        }
        joueurs[0] = new Joueur(Nomjoueurs[0]);
        jeu.AjouterJoueurs(joueurs[0]);
        jeu.DistributionCarte(joueurs[0]);
        for (int i = 1; i < nbrJoueurs; i++)
        {
            while (true)
            {
                Console.Write($"\t\tNom du joueur {i + 1} : ");
                string nomSaisi = Console.ReadLine()?.Trim().ToLower();

                if (nomSaisi=="")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\t\tErreur : Le nom du joueur ne peut pas être vide.");
                    Console.ResetColor();
                    continue; 
                }

                if (Nomjoueurs.Contains(nomSaisi))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\t\tErreur : Ce nom est déjà pris. Veuillez en choisir un autre.");
                    Console.ResetColor();
                    continue; 
                }

                Nomjoueurs[i] = nomSaisi;
                joueurs[i] = new Joueur(nomSaisi);
                jeu.AjouterJoueurs(joueurs[i]);
                jeu.DistributionCarte(joueurs[i]);
                break;
            }
        }

      

        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\t\tTous les joueurs ont été ajoutés et les cartes ont été distribuées !");
        Console.WriteLine("\t\t*********************************************************************");
        Console.ResetColor();

        // Démarrage du jeu
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\t\t                        Le jeu commence !                            ");
        Console.WriteLine("\t\t*********************************************************************");
        Console.ResetColor();

        jeu.Jouons();

        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\t\tMerci d'avoir joué à UNO ! À bientôt !");
        Console.ResetColor();
    }
}
