using System.Windows.Forms;

namespace SokakCeteleriGameBot
{
   public static class EnerjiElement
    {
        public static HtmlElement LowEnerjiTrainingElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("div");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("merr"))
                {
                    if (!e.CanHaveChildren)
                    {
                        return e.Children[0];
                    }
                }
            }
            return null;
        }

        public static HtmlElement LowEnerjiFightElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("div");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("msgbox-top"))
                {
                    if (e.Children[1].Children[0].Children[0].Children[0].InnerText == "60")
                    {
                        return e.Children[0];
                    }
                }
            }
            return null;
        }

        //Çalışmıyorrr !!!
        public static HtmlElement FullEnerjiElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("div");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("msgbox-top"))
                {
                   // MessageBox.Show(e.InnerText);
                        return e;   
                }
            }
            return null;
        }

        public static HtmlElement FindDrinkElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("div");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("inventory_slotsw"))
                {
                    return e;
                }
            }
            return null;
        }

        public static HtmlElement FindEnerjiDoluluk(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("a");
            foreach (HtmlElement e in elements)
            {
                string bumu = e.GetAttribute("href");
                if (bumu == "/bar//4355/drink?z=cGP")
                {
                    return e;
                }
            }
            return null;
        }

        public static HtmlElement FindKizElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("div");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("inventory_slotsw"))
                {
                    return e;
                }
            }
            return null;
        }

        public static HtmlElement FindKizTiklaElement(HtmlElement document, int seviye)
        {
            var elements = document.GetElementsByTagName("img");
            if (seviye > 59)
            {
                foreach (HtmlElement e in elements)
                {
                    if (e.GetAttribute("src").Contains("http://v2i.streetmobster.com/srv/eu.1/item/716.jpg"))
                    {
                        return e;
                    }
                }
            }
            else if (seviye > 55)
            {
                foreach (HtmlElement e in elements)
                {
                    if (e.GetAttribute("src").Contains("http://v2i.streetmobster.com/srv/eu.1/item/715.jpg"))
                    {
                        return e;
                    }
                }
            }
            else if (seviye > 51)
            {
                foreach (HtmlElement e in elements)
                {
                    if (e.GetAttribute("src").Contains("http://v2i.streetmobster.com/srv/eu.1/item/714.jpg"))
                    {
                        return e;
                    }
                }
            }
            else if (seviye > 47)
            {
                foreach (HtmlElement e in elements)
                {
                    if (e.GetAttribute("src").Contains("http://v2i.streetmobster.com/srv/eu.1/item/713.jpg"))
                    {
                        return e;
                    }
                }
            }
            else if (seviye > 43)
            {
                foreach (HtmlElement e in elements)
                {
                    if (e.GetAttribute("src").Contains("http://v2i.streetmobster.com/srv/eu.1/item/712.jpg"))
                    {
                        return e;
                    }
                }
            }
            else if (seviye > 39)
            {
                foreach (HtmlElement e in elements)
                {
                    if (e.GetAttribute("src").Contains("http://v2i.streetmobster.com/srv/eu.1/item/711.jpg"))
                    {
                        return e;
                    }
                }
            }
            else if (seviye > 35)
            {
                foreach (HtmlElement e in elements)
                {
                    if (e.GetAttribute("src").Contains("http://v2i.streetmobster.com/srv/eu.1/item/710.jpg"))
                    {
                        return e;
                    }
                }
            }
            else if (seviye > 31)
            {
                foreach (HtmlElement e in elements)
                {
                    if (e.GetAttribute("src").Contains("http://v2i.streetmobster.com/srv/eu.1/item/709.jpg"))
                    {
                        return e;
                    }
                }
            }
            else if (seviye > 27)
            {
                foreach (HtmlElement e in elements)
                {
                    if (e.GetAttribute("src").Contains("http://v2i.streetmobster.com/srv/eu.1/item/708.jpg"))
                    {
                        return e;
                    }
                }
            }
            else if (seviye > 23)
            {
                foreach (HtmlElement e in elements)
                {
                    if (e.GetAttribute("src").Contains("http://v2i.streetmobster.com/srv/eu.1/item/707.jpg"))
                    {
                        return e;
                    }
                }
            }
            else if (seviye > 19)
            {
                foreach (HtmlElement e in elements)
                {
                    if (e.GetAttribute("src").Contains("http://v2i.streetmobster.com/srv/eu.1/item/706.jpg"))
                    {
                        return e;
                    }
                }
            }
            else if (seviye > 15)
            {
                foreach (HtmlElement e in elements)
                {
                    if (e.GetAttribute("src").Contains("http://v2i.streetmobster.com/srv/eu.1/item/705.jpg"))
                    {
                        return e;
                    }
                }
            }
            else if (seviye > 11)
            {
                foreach (HtmlElement e in elements)
                {
                    if (e.GetAttribute("src").Contains("http://v2i.streetmobster.com/srv/eu.1/item/704.jpg"))
                    {
                        return e;
                    }
                }
            }
            else if (seviye > 7)
            {
                foreach (HtmlElement e in elements)
                {
                    if (e.GetAttribute("src").Contains("http://v2i.streetmobster.com/srv/eu.1/item/703.jpg"))
                    {
                        return e;
                    }
                }
            }
            else if (seviye > 3)
            {
                foreach (HtmlElement e in elements)
                {
                    if (e.GetAttribute("src").Contains("http://v2i.streetmobster.com/srv/eu.1/item/702.jpg"))
                    {
                        return e;
                    }
                }
            }
            else
            {
                foreach (HtmlElement e in elements)
                {
                    if (e.GetAttribute("src").Contains("http://v2i.streetmobster.com/srv/eu.1/item/701.jpg"))
                    {
                        return e;
                    }
                }
            }
            return null;
        }
    }
}
