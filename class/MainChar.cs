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
        public int Souls { get; set; } = 0;
        public int MentalHealth { get; set; } = 100;
        public string Attribut { get; set; } = "traitless";

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
                    main.Attribut = "blind";
                break;

                case "2":
                    main.Name = "Matante Gotrante";
                    main.MinDamage = 0;
                    main.DamageRange = 7;
                    main.MaxHp = 150;
                    main.Hp = 100;
                    main.Sustain = 10;
                    main.Attribut = "massive";
                break;

                case "3":
                    main.Name = "Florent Laurent";
                    main.MinDamage = 2;
                    main.DamageRange = 7;
                    main.MaxHp = 60;
                    main.Hp = 50;
                    main.Sustain = 6;
                    main.Attribut = "money is power";
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

        /**
        *Activations de fin de combat, sustain, rest et electrocute, souls++
        *
        *@param main
        *@return main
        */
        public MainChar ActivationFinCombat(MainChar main)
        {
            main.HealUnlessMax(main.Sustain);
            main.Electrocute = 1;
            main.Souls++;

            return main;
        }

        /**
        *Générer les dégats en tenant compte des attributs
        *
        *@return int les dégats
        */
        public int DegatsAt()
        {
            int degats = 0;
            Random rng = new Random();

            degats = rng.Next(this.MinDamage, this.MinDamage + this.DamageRange);

            

            //massive
            if(this.Attribut == "massive")
            {
                degats += this.Hp / 30;
            }

            //money is power
            if(this.Attribut == "money is power")
            {
                degats += this.Gold / 150;
                if(this.MBook)
                degats += 16;
            }

            //electrocute
            if(this.Electrocute == 3)
            {
                degats *= this.ElectrocuteDamage;
                this.Electrocute = 0;
                Console.WriteLine("\nElectrocute proc--");
            }
            this.Electrocute++;

            
            return degats;
        }

        /**
        *Recoit les dégats en tenant compte des attributs
        *
        *@param int degats reçus
        *@return int degats finaux infligés
        */
        public int RecevoirAt(int degats)
        {
            if(this.Attribut == "blind")
            {
                Random rng = new Random();
                int miss = rng.Next(1, 7);

                if(miss < 5)
                {
                    degats = 0;
                }
            }

            this.Hp -= degats;
            this.DshieldProc();
            return degats;
        }

        /**
        *Activation du pouvoir caché de crown of the fallen, +15 dégats
        */
        public void CrownActivation()
        {
            if(this.Cfallen == true)
            {
                this.MinDamage += 15;
                Console.WriteLine("La couronne du déchus vous fais vous sentir plus puissant\n\npeut être était-ce un bon achat après tout...");
            }
        }
    }
}