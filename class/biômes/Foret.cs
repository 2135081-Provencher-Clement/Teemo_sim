using System;

namespace teemo
{
    class Foret
    {
        public bool Lecho { get; set; } = true;
        public bool Etrident { get; set; } = true;
        public bool Cfallen { get; set; } = true;
        public bool Wchest { get; set; } = true;
        public int PassantsTueForet { get; set; } = 0;
        /**
        *Affiche le premier shop ou on peut acheter doran's shield ou doran's ring
        *
        *@param {MainChar} character
        *@return Main character
        */
        public MainChar FirstShop(MainChar main)
        {
            string achat = "";
            Console.ReadKey();

            Console.Clear();

            Console.WriteLine($"\n{main.Name} Bienvenue dans le premier shop\nvoici l'inventaire:\nDoran's ring (500g) <dr>\nDoran's shield (500g) <ds>\n\nvous avez présentement {main.Gold}g\nEntrez l'abréviation correspondante à l'objet pour l'acheter (il est marqué entre < >)\nsi vous ne voulez pas acheter, entrez <r>");

            achat = Console.ReadLine();

            switch(achat)
            {
                case "ds":
                    main.Dshield = true;
                    main.Gold -= 500;
                    Console.WriteLine("Vous avez acheté Doran's shield");
                break;

                case "dr":
                    main.Dring = true;
                    main.Gold -= 500;
                    Console.WriteLine("Vous avez acheté Doran's ring");
                break;

                case "r":
                Console.WriteLine("Vous n'avez rien acheté");
                break;

                default:
                    Console.WriteLine("Boris had never seen such bad spelling before in his life...\nBoris te vole ton argent pis t'as rien en échange");
                    main.Gold = 0;
                break;
            }
            
            if(main.Dring == true)
            {
                main.MinDamage += 2;
                main.DamageRange += 2;
            }

            Console.ReadKey();
            return main;
        }
        /*
        *Affiche le shop de la forêt où on peut acheter luden's echo, electric trident, crown of the fallen et winter chestpiece
        *
        *@param Main character
        *@return Main character
        */
        public MainChar ShopForet( MainChar main)
        {
            string achat = null;

            Console.Clear();

            Console.WriteLine($"\n{main.Name} Bienvenue dans le shop de la forêt\nvoici l'inventaire:");
            //check d'inventaire
            if(this.Lecho == true)
            Console.WriteLine("Luden's echo (800g) <le> un echo qui ne diminue, certains diront une boucle infini");

            if(this.Etrident == true)
            Console.WriteLine("Electric trident (900g) <et> ça pique un peu plus qu'un choc statique");

            if(this.Cfallen == true)
            Console.WriteLine("Crown of the fallen (100g) <cf> Celui ci me fait peur, débarassez-moi en je vous en prie...");

            if(this.Wchest == true)
            Console.WriteLine("Winter chestpiece (1000g) <wc> ben quoi, il fait froid...");
            Console.WriteLine($"\nVous possédez {main.Gold}g, sélectionner l'abréviation de l'item indiqué, si vous ne voulez rien acheter <r>");

            achat = Console.ReadLine();

            switch(achat)
            {
                case "le":
                    if(main.Gold >= 800)
                    {
                        main.Lecho = true;
                        this.Lecho = false;
                        main.Gold -= 800;
                        Console.WriteLine("Vous avez acheté Luden's echo");
                        main.MinDamage += 4;
                        main.DamageRange += 2;
                        Console.ReadKey();
                    }
                break;

                case "et":
                    if(main.Gold >= 900)
                    {
                        main.Etrident = true;
                        this.Etrident = false;
                        main.Gold -= 900;
                        Console.WriteLine("Vous avez acheté Electric trident");
                        main.ElectrocuteDamage++;
                        Console.ReadKey();
                    }
                break;

                case "wc":
                    if(main.Gold >= 1000)
                    {
                        main.Wchest = true;
                        this.Wchest = false;
                        main.Gold -= 1000;
                        Console.WriteLine("Vous avez acheté Winter chestpiece");
                        main.Hp += 5;
                        main.MaxHp += 5;
                        main.Sustain += 1;
                        Console.ReadKey();
                    }
                break;

                case "cf":
                    if(main.Gold >= 100)
                    {
                        main.Cfallen = true;
                        this.Cfallen = false;
                        main.Gold -= 100;
                        Console.WriteLine("... Bonne chance");
                        main.Hp -= 4;
                        main.Sustain = 0;
                        if(main.Hp <= 0)
                        {
                            Console.WriteLine("Vous sentez une force divine vous perçer en deux...\nVous n'avez pas survécu la puissance du déchus...");
                            Console.ReadKey();
                            Environment.Exit(0);
                        }
                        Console.ReadKey();
                    }
                break;

                case "r":
                    Console.WriteLine("Vous n'avez rien acheté...");
                break;

                default:
                    main = this.ShopForet(main);
                break;
            }

            return main;
        }
        /*
        *Menu de sélection entre aller au shop ou aller battre des passants
        *
        *@param MainChar le perso principal
        *@param rng random number generator
        @return MainChar le perso principal
        */
        public bool MenuForet( MainChar main, Random rng)
        {
            Console.Clear();

            string choix = "";
            Console.WriteLine($"\nVous êtes debout au millieu de la forêt\nVous possédez {main.Gold}g\nVoulez vous...\n1. Aller battre les passants assez stupides pour s'aventurer dans la forêt\n2. Chercher un magasin pour acheter de beaus objets");

            choix = Console.ReadLine();

            switch(choix)
            {
                case "1":
                    if(main.PassantsTueForet == 4)
                    {
                        Console.Clear();
                        Console.WriteLine("Ça sent le crapeau ici...");
                        Console.ReadKey();
                        main = this.EncounterPassant(main, rng);
                        this.PassantsTueForet++;
                    }
                    else if(main.PassantsTueForet == 5)
                    {
                        main = this.EncounterGromp(main, rng);
                        this.PassantsTueForet++;
                    }
                    else if(main.PassantsTueForet == 8)
                    {
                        Console.Clear();
                        Console.WriteLine("Ça sent le crapeau ici...");
                        Console.ReadKey();
                        main = this.EncounterPassant(main, rng);
                        this.PassantsTueForet++;
                    }
                    else if(main.PassantsTueForet == 9)
                    {
                        main = this.EncounterMegaGromp(main, rng);
                        return true;
                    }
                    else
                    {
                        main = this.EncounterPassant(main, rng);
                        this.PassantsTueForet++;
                    }
                break;

                case "2":
                    main = this.ShopForet(main);
                break;

                default:
                    Console.WriteLine("ce n'est pas un choix");
                    this.MenuForet(main, rng);
                break;
            }

            return false;
        }
        //Combats//

        /*
        *Générer un combat entre le personnage principale et un passant
        *
        *@param Main character, le perso principal
        *@param rng random number generator
        *@return Main character, le perso principal
        */
        public MainChar EncounterPassant(MainChar main, Random rng)
        {
            int degats = 0;
            Passant newPassant = new Passant();
            int miss = 0;
            
            Console.Clear();

            Console.WriteLine($"\nVous rencontrez {newPassant.Name}");

            while(newPassant.HP > 0 && main.Hp > 0)
            {
                miss = rng.Next(1,7);
                degats = rng.Next(main.MinDamage, main.MinDamage + main.DamageRange);
                if(main.Electrocute == 3)
                {
                    degats *= main.ElectrocuteDamage;
                    main.Electrocute = 0;
                    Console.WriteLine("\nElectrocute proc--");
                }
                Console.WriteLine($"\n{main.Name} attaque !");
                Console.WriteLine($"\n{newPassant.Name} se prends {degats} points de dégats, il lui reste {newPassant.HP - degats} points de vie");
                newPassant.HP -= degats;
                if(miss < 4 && main.Name == "Teemo")
                {
                    Console.WriteLine($"\n{newPassant.Name} manque son attaque parce qu'il est blind");
                }
                else if(newPassant.HP > 0)
                {
                    main.Hp -= newPassant.Degats;
                    Console.WriteLine($"\n{newPassant.Name}, cette conne, à fait {newPassant.Degats} dégats à {main.Name} !\nil reste {main.Hp} points de vie à {main.Name}");
                    
                    main.DshieldProc();
                }
                main.Electrocute++;
                Console.ReadKey();
            }

            if(newPassant.HP <= 0)
            {
            Console.WriteLine($"\n{newPassant.Name} est mort, get shit on");
            main.Gold += 300;
            }
            else if(main.Hp <= 0)
            {
            Console.WriteLine($"\nImpossible, {main.Name} est mort :_(");
            //Game Over
            Console.ReadKey();
            Environment.Exit(0);

            }
            else
            Console.WriteLine("Error 204");

            main.HealUnlessMax(main.Sustain);
            main.Electrocute = 1;
            main.Souls++;

            Console.ReadKey();
            return main;
        }
        /*
        *Générer un encounter avec le boss Gromp, il attaque de moins en moins vite
        *
        *@param MainChar perso principal
        *@param rng random number generator
        *@return MainChar perso principal après combat
        */
        public MainChar EncounterGromp( MainChar main, Random rng)
        {
            int degats = 0;
            Gromp gromp = new Gromp();

            Console.Clear();

            Console.WriteLine("Un crapeau vous bondi aggressivement dessus, c'est un gromp !");

            while( main.Hp > 0 && gromp.Hp > 0 )
            {
                degats = rng.Next(main.MinDamage, main.MinDamage + main.DamageRange);
                if(main.Electrocute == 3)
                {
                    degats *= main.ElectrocuteDamage;
                    main.Electrocute = 0;
                    Console.WriteLine("\n-- Electrocute proc --");
                }
                Console.WriteLine($"\n{main.Name} Attaque le gromp");
                Console.WriteLine($"\nLe gromp se prends {degats} points de dégats\nil reste {gromp.Hp - degats} points de vie au gromp");
                gromp.Hp -= degats;
                if(gromp.AttackCooldown == 0 && gromp.Hp > 0 )
                {
                    main.Hp -= gromp.Damage;

                    Console.WriteLine($"\nLe gromp attaque {main.Name} pour {gromp.Damage} points de dégats\nil reste {main.Hp} points de vie à {main.Name}");
                    
                    main.DshieldProc();

                    gromp.AttackSpeed += 1;
                    gromp.AttackCooldown = gromp.AttackSpeed - 1;
                }
                else
                gromp.AttackCooldown--;

                Console.WriteLine("Le gromp est fatigué, il attaque de moins en moins vite");

                main.Electrocute++;
                Console.ReadKey();
            }

            if(main.Hp <= 0)
            {
                Console.WriteLine("Game over pussy, get gromped");
                Console.ReadKey();
                Environment.Exit(0);
            }
            else if(gromp.Hp <= 0)
            {
                Console.WriteLine($"\n{main.Name} Tua violamment le gromp et trouva une généreuse somme de 700g dans son intestin grèle...");
                main.Gold += 700;
            }
            else
            Console.WriteLine("Error 204");

            main.HealUnlessMax(main.Sustain);
            main.Electrocute = 1;
            main.Souls++;

            Console.ReadKey();
            return main;
        }
        /*
        *Générer un encounter avec le boss King gromp
        *
        *@param MainChar le perso principal
        *@param rng
        *@return MainChar après combat
        */
        public MainChar EncounterMegaGromp(MainChar main, Random rng)
        {
            int degats = 0;
            MegaGromp megaGromp = new MegaGromp();

            Console.Clear();

            Console.WriteLine("La même odeur putride de crapeau vous frappes au nez. Cette fois si plus salée. Un gromp portant une couronne se dévoile");

            while( main.Hp > 0 && megaGromp.Hp > 0 )
            {
                megaGromp.AfficherVoiceLine();

                degats = rng.Next(main.MinDamage + main.DamageRange);
                if(main.Electrocute == 3)
                {
                    degats *= main.ElectrocuteDamage;
                    main.Electrocute = 0;
                    Console.WriteLine("\nElectrocute proc--");
                }
                Console.WriteLine($"\n{main.Name} Attaque MegaGromp");
                Console.WriteLine($"\nMegaGromp se prends {degats} points de dégats, il est immunisé au blind\nil reste {megaGromp.Hp - degats} points de vie à megaGromp");
                megaGromp.Hp -= degats;

                main.Hp -= megaGromp.Damage;

                Console.WriteLine($"\nLe megaGromp attaque {main.Name} pour {megaGromp.Damage} points de dégats\nil reste {main.Hp} points de vie à {main.Name}");
                
                main.DshieldProc();

                Console.WriteLine("Le megaGromp est trop fort pour se fatiguer, ne penses pas qu'il va ralentir ses attaques !");

                main.Electrocute++;
                Console.ReadKey();
            }

            if(main.Hp <= 0)
            {
                Console.WriteLine("Game over pussy, get styled on kid");
                Console.ReadKey();
                Environment.Exit(0);
            }
            else if(megaGromp.Hp <= 0)
            {
                Console.WriteLine($"\n{main.Name} Tua le roi de la forêt, les passants et les gromps fuirent la forêt");
                main.Gold += 700;
            }
            else
            Console.WriteLine("Error 204");

            main.HealUnlessMax(main.Sustain);
            main.Electrocute = 1;
            main.Souls++;

            Console.ReadKey();
            return main;
        }
    }
}