using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace projet
{
    internal abstract class Carte
    {
        protected string couleur;
        protected string nom;
        private Jeu jeu;
        public Carte(string couleur, string nom)
        {
            this.couleur = couleur;
            this.nom = nom;
            this.jeu = jeu;
        }

        public string Couleur
        {
            get { return couleur; }
            set { this.couleur = value; }
        }

        public string Nom
        { 
            get { return nom; } 
            set { nom = value; }
        }


        public abstract void AppliquerEffet(ref List<Joueur> SensDuJeu,ref Joueur joueurEnCours, Carte carteencours,ref int carteApiocher);

        public abstract bool Estjouable(Carte carteencours, ref int carteApiocher);


        public abstract void Afficher();
        
    }
}
