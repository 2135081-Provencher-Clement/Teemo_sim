using System;

namespace teemo
{
    class Diablotin
    {
        public int Hp { get; set; }
        public int Degats { get; set; }
        public Diablotin()
        {
            Random rng = new Random();
            this.Degats = rng.Next(3,5);
            this.Hp = rng.Next(60, 130);
        }
    }
}