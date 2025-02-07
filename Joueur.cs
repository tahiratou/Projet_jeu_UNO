using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet
{
    internal class Joueur
    {
        private string nom;
        List<Carte> mesCartes;

        Random rand = new Random();



        public Joueur(string nom) 
        {
            this.nom = nom;
            mesCartes = new List<Carte>();

        }

        public string Nom
        {
            get { return this.nom; }
            set { nom = value; }
        }


        public List<Carte> MesCartes
        {
            get { return mesCartes; }
            set { mesCartes = value; }
        }


        public void AfficherCartes()
        {
            Console.WriteLine();
            Console.WriteLine("\t\t*********************************************************************");
            Console.WriteLine($"\t\t                           Cartes de {nom}                ");
            Console.WriteLine("\t\t*********************************************************************");
            Console.WriteLine();
            string[] ordreCouleurs = { "vert", "jaune", "rouge", "bleu", "noir" };

            var cartesTriees = MesCartes.OrderBy(c => Array.IndexOf(ordreCouleurs, c.Couleur)).ThenBy(c => c.Nom).ToList();

            // Afficher les cartes triées
            foreach (var carte in cartesTriees)
            {
                Console.Write("\t\t - ");

                carte.Afficher();
            }
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine();
            Console.WriteLine($"\t\tTotal : {MesCartes.Count} carte(s)");
           
           

            Console.WriteLine("\t\t*********************************************************************");
            Console.ResetColor();

            Console.WriteLine();
        }





        public void AfficherNom()
        {
            Console.Write(nom);
        }
    }
}
