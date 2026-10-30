using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace projekt_AASPJY
{
    public class KigyoElem:PictureBox
    {
        public static int Meret = 20;
        public KigyoElem()
        {
            Width = Meret;
            Height = Meret;
            BackColor = Color.DarkOrange;
        }
    }
}
