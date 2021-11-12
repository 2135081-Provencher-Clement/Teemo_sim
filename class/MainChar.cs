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
    }
}