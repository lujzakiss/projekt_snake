namespace projekt_AASPJY
{
    public partial class Form1 : Form
    {
        int fejX = 120;
        int fejY = 120;

        int iranyX = 1;
        int iranyY = 0;

        int hossz = 3;
        int lépés = 0;

        DateTime kezdes = DateTime.Now;
        Random rnd = new Random();
        List<KigyoElem> kígyó = new List<KigyoElem>();
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lépés++;

            TimeSpan eltelt = DateTime.Now - kezdes;
            this.Text = $"lépés: {lépés} hossz: {hossz} idõ: {eltelt.Minutes:00} : {eltelt.Seconds:00}";

            if (lépés % 20 == 0)
            {
                try
                {
                    timer1.Interval -= 40;
                }
                catch (ArgumentOutOfRangeException)
                {
                    timer1.Interval = 10;
                }
            }

            fejX += iranyX * KigyoElem.Meret;
            fejY += iranyY * KigyoElem.Meret;

            foreach (Control elem in Controls)
            {
                if (elem.Top == fejY && elem.Left == fejX)
                {

                    if (elem is Alma)
                    {
                        hossz++;
                        Controls.Remove(elem);
                    }
                    
                    else if (elem is Mereg)
                    {
                        timer1.Stop();
                        MessageBox.Show("Vesztettél, mérgezett almába haraptál!");
                        Application.Exit();
                    }

                    else if (elem is KigyoElem)
                    {
                        timer1.Stop();
                        MessageBox.Show("Vesztettél, magadba haraptál!");
                        Application.Exit();
                    }
                }
            }

            KigyoElem ujFej = new KigyoElem { Top = fejY, Left = fejX };
            kígyó.Add(ujFej);
            Controls.Add(ujFej);

            if (kígyó.Count > hossz)
            {
                Controls.Remove(kígyó[0]);
                kígyó.RemoveAt(0);
            }

            if (lépés % 10 == 0)
            {
                int x = rnd.Next(0, ClientSize.Width / KigyoElem.Meret) * KigyoElem.Meret;
                int y = rnd.Next(0, ClientSize.Height / KigyoElem.Meret) * KigyoElem.Meret;

                if (rnd.Next(0, 10) < 7)
                {
                    Controls.Add(new Alma(x, y));
                }
                else
                {
                    Controls.Add(new Mereg(x, y));
                }
            }

            if (lépés % 2 == 0) { ujFej.BackColor = Color.LightGoldenrodYellow; }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                iranyX = 0;
                iranyY = -1;
            }
            else if (e.KeyCode == Keys.Down )
            {
                iranyX = 0;
                iranyY = 1;
            }
            else if (e.KeyCode == Keys.Left )
            {
                iranyX = -1;
                iranyY = 0;
            }
            else if (e.KeyCode == Keys.Right )
            {
                iranyX = 1;
                iranyY = 0;
            }
        }
    }
}
