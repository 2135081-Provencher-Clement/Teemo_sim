using System;
using System.IO;

namespace teemo
{
    public class Passant
    {
        public int HP { get; set; }
        public string Name { get; set; }
        public int Degats { get; set; } = 2;
        public Passant()
        {
            StreamReader reader = new StreamReader("name_bank.txt");
            Random rng = new Random();
            string choisi = null;
            int nombreVu = 0;
            string ligne = "";

            this.HP = rng.Next(30, 101);

            while((ligne = reader.ReadLine()) != null)
            {
                if(rng.Next(++nombreVu) == 0)
                {
                    choisi = ligne;
                }
            }

            this.Name = choisi;

            reader.Close();
        }
    }

}