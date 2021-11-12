using System;
using System.IO;

namespace teemo
{
    public class MegaGromp
    {
        public int Hp { get; set; } = 250;
        public int Damage { get; set; } = 1;
        public string VoiceLine { get; set; }
        /*
        *Génères une voice line pour megagromp et l'affiche
        *
        */
        public void AfficherVoiceLine()
        {
            StreamReader reader = new StreamReader("class\\voiceLines\\megagromp.txt");
            Random rng = new Random();
            string choisi = null;
            int nombreVu = 0;
            string ligne = "";

            while((ligne = reader.ReadLine()) != null)
            {
                if(rng.Next(++nombreVu) == 0)
                {
                    choisi = ligne;
                }
            }

            this.VoiceLine = choisi;

            reader.Close();

            Console.WriteLine("\n<<" + this.VoiceLine + ">>");
        }
    }
}