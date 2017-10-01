using System.Windows.Forms;

namespace SokakCeteleriGameBot
{
    public static class MenuElement
    {
        public static HtmlElement TopMenuFightElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("div");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("local-tasks"))
                {
                    var hangisi = e.GetElementsByTagName("span");
                    foreach (HtmlElement a in hangisi)
                    {
                        if (a.GetAttribute("className").Contains("find"))
                        {return a;}
                    }
                }
            }
            return null;
        }

        public static HtmlElement TopMenuGangCrimeElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("div");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("local-tasks"))
                {
                    var hangisi = e.GetElementsByTagName("span");
                    foreach (HtmlElement a in hangisi)
                    {
                        if (a.GetAttribute("className").Contains("tasks"))
                        { return a; }
                    }
                }
            }
            return null;
        }

        public static HtmlElement TopMenuBankElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("div");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("local-tasks"))
                {
                    var hangisi = e.GetElementsByTagName("span");
                    foreach (HtmlElement a in hangisi)
                    {
                        if (a.GetAttribute("className").Contains("safebox"))
                        { return a; }
                    }
                }
            }
            return null;
        }

        public static HtmlElement TopMenuElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("div");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("local-tasks"))
                {
                    return e;
                }
            }
            return null;
        }

        public static HtmlElement RightMenuElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("div");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("usrtools"))
                {
                    return e;
                }
            }
            return null;
        }

        public static HtmlElement LeftMenuElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("div");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("main-menu"))
                {
                    return e;
                }
            }
            return null;
        }
    }
}
