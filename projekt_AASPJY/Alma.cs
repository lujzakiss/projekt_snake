using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt_AASPJY
{
    internal class Alma: KigyoElem
    {
        public Alma(int x, int y)
        {
            BackColor = Color.MediumVioletRed;
            Width = Meret;
            Height = Meret;
            Left = x;
            Top = y;
        }
    }
}
