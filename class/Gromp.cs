using System;

namespace teemo
{
    public class Gromp
    {
        public int Hp { get; set; } = 250;
        public int AttackSpeed { get; set; } = 0;
        public int AttackCooldown { get; set; } = 0;
        public int Damage { get; set; } = 2;
        public int Attaquer()
        {
            if(this.AttackCooldown == 0)
            {
                this.AttackSpeed++;
                this.AttackCooldown = this.AttackSpeed;
                return this.Damage;
            }
            else
            {
                this.AttackCooldown--;
                Console.WriteLine("Le gromp est fatigué, il attaque de moins en moins vite");
                return 0;
            }
        }
    }
}