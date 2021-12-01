using System;

namespace teemo
{
    class VillageEnFlames
    {
        public int VillagoisTueVillage { get; set; }
        public bool WCoal { get; set; } = true;
        public bool UFoetus { get; set; } = true;
        public bool UNerve { get; set; } = true;
        public bool MBook { get; set; } = true;
        /*
        *Affiche le shop du village en flames où tu peux acheter White Coal, Unsolicited foetus, USB-C to optic nerve adapter et Mac Book Crow
        *
        *@param Main character
        *@return Main character
        */
        public MainChar ShopVillage( MainChar main)
        {
            string achat = null;

            Console.Clear();

            Console.WriteLine($"\n{main.Name} Bienvenue dans le shop du village en flâmes...\nvoici l'inventaire:");
            //check d'inventaire
            if(this.WCoal == true)
            Console.WriteLine("White Coal (600g) <wc> trouvé ça par terre, probablement juste une roche...");

            if(this.UFoetus == true)
            Console.WriteLine("Unsolicited foetus (1300g) <uf> trouvé ça par terre, un petit peu inquiétant...");

            if(this.UNerve == true)
            Console.WriteLine("USB-C to optic nerve adapter (2000g) <un> pour quand tu as trop de yeux et pas assez de caméras");

            if(this.MBook == true)
            Console.WriteLine("Mac Book Crow (3000g) <mb> le dernier modèle de mac, peut être meilleur, mais certainement plus cher, supporte Windows, peut être");
            Console.WriteLine($"\nVous possédez {main.Gold}g, sélectionner l'abréviation de l'item indiqué, si vous ne voulez rien acheter <r>");

            achat = Console.ReadLine();

            switch(achat)
            {
                case "wc":
                    if(main.Gold >= 600)
                    {
                        main.WCoal = true;
                        this.WCoal = false;
                        main.Gold -= 600;
                        Console.WriteLine("Vous avez acheté White Coal");
                        main.MinDamage += 2;
                        main.DamageRange += 4;
                        Console.ReadKey();
                    }
                break;

                case "uf":
                    if(main.Gold >= 1300)
                    {
                        main.UFoetus = true;
                        this.UFoetus = false;
                        main.Gold -= 1300;
                        main.MentalHealth -= 20;
                        Console.WriteLine("Vous avez acheté Unsolicited foetus");
                        main.ElectrocuteDamage++;
                        Console.ReadKey();
                    }
                break;

                case "un":
                    if(main.Gold >= 2000)
                    {
                        main.UNerve = true;
                        this.UNerve = false;
                        main.Gold -= 2000;
                        main.MentalHealth -= 10;
                        Console.WriteLine("Vous avez acheté USB-C to optic nerve adapter");
                        main.Sustain += 4;
                        main.Hp += 5;
                        main.MaxHp += 5;
                        Console.ReadKey();
                    }
                break;

                case "mb":
                    if(main.Gold >= 3000)
                    {
                        main.MBook = true;
                        this.MBook = false;
                        main.Gold -= 3000;
                        Console.WriteLine("Ça allège le portefeuille...");
                        Console.ReadKey();
                    }
                break;

                case "r":
                    Console.WriteLine("Vous n'avez rien acheté...");
                break;

                default:
                    main = this.ShopVillage(main);
                break;
            }

            return main;
        }
    }
}