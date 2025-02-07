using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace projet
{
    internal abstract class CarteEffet : Carte
    {
        protected string symbole;

        public CarteEffet (string couleur, string symbole) : base (couleur, $"{symbole}")
        {
            this.symbole = symbole;
        }

        public string Symbole
        {
            get { return symbole; }
            set { symbole = value; }
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
            Console.WriteLine(couleur + ", " + symbole);
            Console.ResetColor();

        }
    }
}
