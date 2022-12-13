using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Common;

namespace BeerProcessor
{

    public class ZleceniePiwo : IZlecenie{

        private static string[] stages = new string[]
        {
            "22 litry piwa około 14 BLG:",
            "Słody:\n– 3,5 kg Pilzneński Premium\n– 2 kg Pale Ale\n– 0,5 kg Pszeniczy",
            "Zacieranie w około 66 C",
            "Chmielenie:\nCitra 15 g, Amarillo 15 g, Simcoe 15 g na 20 min\nCitra 15 g, Amarillo 15 g, Simcoe 15 g na 5 min\nCitra 15 g, Amarillo 15 g, Simcoe 15 g po wyłączeniu palnika\nCitra 15 g, Amarillo 15 g, Simcoe 15 g hop stand w 85 C\nDrożdże\nUS-05",
            "Fermentacja:\n3 tygodnie w temperaturze 19-20 C\nNa ostanie 4 dni chmielenie na zimno Citra 30 g, Amarillo 30, Simcoe 30 g"
        };

        public void process(string title)
        {
            Console.WriteLine(title);
            Thread.Sleep(1000);
            for(int i = 0; i < stages.Length; i++)
            {
                Console.WriteLine(stages[i]);
                Thread.Sleep(2000);
            }

        }

    }

}
