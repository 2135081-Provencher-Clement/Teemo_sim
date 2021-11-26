using System;
using System.IO;

namespace teemo
{
    class Program
    {
        static void Main(string[] args)
        {
            MainChar main = new MainChar();
            Random rng = new Random();
            Foret foret = new Foret();
            bool foretFini = false;

            Console.WriteLine($"\nVous êtes {main.Name}");

            //Première shop
            foret.FirstShop(main);
            
            main = foret.EncounterPassant(main, rng);

            //Forêt
            while(!foretFini)
            {
                foretFini = foret.MenuForet(main, rng);
            }
        }
        /**
        *Affiche le guide de l'aventurier, pour les plus démunis d'entre nous
        *
        */
        public static void Guide()
        {
            Console.Clear();
            string ligne = "";

            StreamReader reader = new StreamReader("assets\\Guide.txt");
            while((ligne = reader.ReadLine()) != null)
            {
                Console.WriteLine(ligne);
            }
            reader.Close();
            Console.ReadKey();
        }
        
    }
}
