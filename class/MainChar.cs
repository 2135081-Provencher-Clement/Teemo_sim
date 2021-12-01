using System;

namespace teemo
{
    public class MainChar
    {
        public string Name { get; set; }
        public int Hp { get; set; }
        public int MaxHp { get; set; }
        public int Sustain { get; set; }
        public int MinDamage { get; set; }
        public int DamageRange { get; set; }
        public int Electrocute { get; set; } = 1;
        public int ElectrocuteDamage { get; set; } = 2;
        public int Gold { get; set; } = 500;
        public int PassantsTueForet { get; set; } = 0;
        public int Souls { get; set; } = 0;
        public int MentalHealth { get; set; } = 100;

        //items
        public bool Dshield { get; set; } = false;
        public bool Dring { get; set; } = false;
        public bool Lecho { get; set; } = false;
        public bool Etrident { get; set; } = false;
        public bool Cfallen { get; set; } = false;
        public bool Wchest { get; set; } = false;
        public bool WCoal { get; set; } = false;
        public bool UFoetus { get; set; } = false;
        public bool UNerve { get; set; } = false;
        public bool MBook { get; set; } = false;
        public MainChar()
        {
            this.Choixpersonnage(this);
        }
        /*
        *Check si le doran's shield (il faut l'avoir) proc et regen 1 hp si oui
        *
        */
        public void DshieldProc()
        {
            Random rng = new Random();
            int random = rng.Next(1, 4);

            if(random == 1 && this.Dshield == true)
            HealUnlessMax(1);
        }
        /*
        *Redonne de la vie au personnage principal jusqu'à son max hp
        *
        *@param la valeur à heal si il y a de la place
        */
        public void HealUnlessMax( int heal )
        {
            int leeway = this.MaxHp - this.Hp;

            if(heal < leeway)
            this.Hp += heal;
            else if(heal >= leeway)
            this.Hp += leeway;
        }
        /**
        *Choix du personnage principal
        *
        *@param Mainchar à défénir selon le choix du perso
        *@return MainChar avec les stats de son personnage approprié
        */
        private MainChar Choixpersonnage( MainChar main )
        {
            Console.Clear();

            string entry = null;
            Console.WriteLine("Bonjour, bienvenue dans teemo_simulator\nveuillez choisir votre personnage (Oui plusieurs personnages dans teemo_simulator)");
            Console.WriteLine("\n\n1. Teemo Shroomslinger\n2. Matante Gontrante\n3. Florent Laurent");
            Console.WriteLine("\nveuillez inscrire l'abréviation correspondant au personnage\nsi vous souhaitez consulter le guide, veuillez incrire <g>");

            entry = Console.ReadLine();

            switch(entry)
            {
                case "1":
                    main.Name = "Teemo ShroomSlinger";
                    main.MinDamage = 2;
                    main.DamageRange = 10;
                    main.MaxHp = 15;
                    main.Hp = 10;
                    main.Sustain = 4;
                break;

                case "2":
                    main.Name = "Matante Gotrante";
                    main.MinDamage = 0;
                    main.DamageRange = 7;
                    main.MaxHp = 150;
                    main.Hp = 100;
                    main.Sustain = 10;
                break;

                case "3":
                    main.Name = "Florent Laurent";
                    main.MinDamage = 2;
                    main.DamageRange = 7;
                    main.MaxHp = 60;
                    main.Hp = 50;
                    main.Sustain = 6;
                break;

                case "g":
                    Program.Guide();
                    Choixpersonnage(main);
                break;

                default:
                    Choixpersonnage(main);
                break;
            }

            return main;
        }
    }
}