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
    }
}
