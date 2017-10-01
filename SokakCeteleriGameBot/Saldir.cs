using System.Windows.Forms;

namespace SokakCeteleriGameBot
{
    class Saldir
    {
        public static HtmlElement Saldirr(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("table");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("cmenu"))
                {
                    { return e; }
                }
            }
            return null;
        }

        public static HtmlElement Polis(HtmlElement document)
        {
            var elements = document.GetElementsByTagName("a");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("spot cop"))
                {
                    { return e; }
                }
            }
            return null;
        }

        public static HtmlElement Ajan(HtmlElement document)
        {
            var elements = document.GetElementsByTagName("a");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("spot agent"))
                {
                    { return e; }
                }
            }
            return null;
        }

        public static HtmlElement Enerji(HtmlElement document)
        {
            var elements = document.GetElementsByTagName("a");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("spot cofemachine"))
                {
                    { return e; }
                }
            }
            return null;
        }

        public static HtmlElement Atm(HtmlElement document)
        {
            var elements = document.GetElementsByTagName("a");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("spot atm"))
                {
                    { return e; }   
                }
            }
            return null;
        }

        public static HtmlElement Kabadayi(HtmlElement document)
        {
            var elements = document.GetElementsByTagName("a");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("spot bully"))
                {
                    { return e; }
                }
            }
            return null;
        }

        public static HtmlElement IsAdami(HtmlElement document)
        {
            var elements = document.GetElementsByTagName("a");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("spot businessman"))
                {
                    { return e; }
                }
            }
            return null;
        }

        public static HtmlElement Araba1(HtmlElement document)
        {
            var elements = document.GetElementsByTagName("a");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("spot newcar"))
                {
                    { return e; }
                }
            }
            return null;
        }

        public static HtmlElement Araba2(HtmlElement document)
        {
            var elements = document.GetElementsByTagName("a");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("spot dude"))
                {
                    { return e; }
                }
            }
            return null;
        }

        public static HtmlElement Dansoz(HtmlElement document)
        {
            var elements = document.GetElementsByTagName("a");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("spot hookers"))
                {
                    { return e; }
                }
            }
            return null;
        }

        public static HtmlElement Yonetici(HtmlElement document)
        {
            var elements = document.GetElementsByTagName("a");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("spot manager"))
                {
                    { return e; }
                }
            }
            return null;
        }

        public static HtmlElement IsKadini(HtmlElement document)
        {
            var elements = document.GetElementsByTagName("a");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("spot businesslady"))
                {
                    { return e; }
                }
            }
            return null;
        }

        public static HtmlElement SigaraSaticisi(HtmlElement document)
        {
            var elements = document.GetElementsByTagName("a");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("spot drugdealer"))
                {
                    { return e; }
                }
            }
            return null;
        }

        public static HtmlElement Holigan(HtmlElement document)
        {
            var elements = document.GetElementsByTagName("a");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("spot punk"))
                {
                    { return e; }
                }
            }
            return null;
        }

        public static HtmlElement Telefon(HtmlElement document)
        {
            var elements = document.GetElementsByTagName("a");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("spot phone"))
                {
                    { return e; }
                }
            }
            return null;
        }

        public static HtmlElement Upi(HtmlElement document)
        {
            var elements = document.GetElementsByTagName("a");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("spot upi"))
                {
                    { return e; }
                }
            }
            return null;
        }

        public static HtmlElement Taksi(HtmlElement document)
        {
            var elements = document.GetElementsByTagName("a");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("spot taxi"))
                {
                    { return e; }
                }
            }
            return null;
        }

        public static HtmlElement Ogretmen(HtmlElement document)
        {
            var elements = document.GetElementsByTagName("a");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("spot teacher"))
                {
                    { return e; }
                }
            }
            return null;
        }

        public static HtmlElement Posta(HtmlElement document)
        {
            var elements = document.GetElementsByTagName("a");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("spot post"))
                {
                    { return e; }
                }
            }
            return null;
        }

        public static HtmlElement fanatik(HtmlElement document)
        {
            var elements = document.GetElementsByTagName("a");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("spot soccerboy"))
                {
                    { return e; }
                }
            }
            return null;
        }

        public static HtmlElement Tabela(HtmlElement document)
        {
            var elements = document.GetElementsByTagName("a");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("spot sign"))
                {
                    { return e; }
                }
            }
            return null;
        }

        public static HtmlElement Hamal(HtmlElement document)
        {
            var elements = document.GetElementsByTagName("a");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("spot worker"))
                {
                    { return e; }
                }
            }
            return null;
        }

        public static HtmlElement Anne(HtmlElement document)
        {
            var elements = document.GetElementsByTagName("a");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("spot mother"))
                {
                    { return e; }
                }
            }
            return null;
        }

        public static HtmlElement KopekliGenc(HtmlElement document)
        {
            var elements = document.GetElementsByTagName("a");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("spot dogboy"))
                {
                    { return e; }
                }
            }
            return null;
        }

        public static HtmlElement BisikletliGenc(HtmlElement document)
        {
            var elements = document.GetElementsByTagName("a");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("spot bicyclist"))
                {
                    { return e; }
                }
            }
            return null;
        }

        public static HtmlElement KopekliKiz(HtmlElement document)
        {
            var elements = document.GetElementsByTagName("a");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("spot doggirl"))
                {
                    { return e; }
                }
            }
            return null;
        }

        public static HtmlElement Haylaz(HtmlElement document)
        {
            var elements = document.GetElementsByTagName("a");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("spot lazyboy"))
                {
                    { return e; }
                }
            }
            return null;
        }

        public static HtmlElement Dokuntu(HtmlElement document)
        {
            var elements = document.GetElementsByTagName("a");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("spot oldcar"))
                {
                    { return e; }
                }
            }
            return null;
        }

        public static HtmlElement ItfaiyeMuslugu(HtmlElement document)
        {
            var elements = document.GetElementsByTagName("a");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("spot hydrant"))
                {
                    { return e; }
                }
            }
            return null;
        }

        public static HtmlElement Kaykayci(HtmlElement document)
        {
            var elements = document.GetElementsByTagName("a");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("spot skater"))
                {
                    { return e; }
                }
            }
            return null;
        }

        public static HtmlElement GencKiz(HtmlElement document)
        {
            var elements = document.GetElementsByTagName("a");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("spot girl"))
                {
                    { return e; }
                }
            }
            return null;
        }

        public static HtmlElement Variller(HtmlElement document)
        {
            var elements = document.GetElementsByTagName("a");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("spot tank"))
                {
                    { return e; }
                }
            }
            return null;
        }

        public static HtmlElement Barikat(HtmlElement document)
        {
            var elements = document.GetElementsByTagName("a");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("spot blockade"))
                {
                    { return e; }
                }
            }
            return null;
        }

        public static HtmlElement Logar(HtmlElement document)
        {
            var elements = document.GetElementsByTagName("a");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("spot shaft"))
                {
                    { return e; }
                }
            }
            return null;
        }

        public static HtmlElement Kopek(HtmlElement document)
        {
            var elements = document.GetElementsByTagName("a");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("spot doggie"))
                {
                    { return e; }
                }
            }
            return null;
        }

        public static HtmlElement Sarhos(HtmlElement document)
        {
            var elements = document.GetElementsByTagName("a");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("spot drunk"))
                {
                    { return e; }
                }
            }
            return null;
        }

        public static HtmlElement Kovalar(HtmlElement document)
        {
            var elements = document.GetElementsByTagName("a");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("spot garbage"))
                {
                    { return e; }
                }
            }
            return null;
        }

        public static HtmlElement Postaci(HtmlElement document)
        {
            var elements = document.GetElementsByTagName("a");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("spot postman"))
                {
                    { return e; }
                }
            }
            return null;
        }

        public static HtmlElement Asiklar(HtmlElement document)
        {
            var elements = document.GetElementsByTagName("a");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("spot inlove"))
                {
                    { return e; }
                }
            }
            return null;
        }

        public static HtmlElement KucukKiz(HtmlElement document)
        {
            var elements = document.GetElementsByTagName("a");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("spot kid"))
                {
                    { return e; }
                }
            }
            return null;
        }
    }
}
