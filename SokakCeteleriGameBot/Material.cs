using System.Windows.Forms;

namespace SokakCeteleriGameBot
{
    public static class Material
    {
        public static HtmlElement FindUseMaterialElement(HtmlDocument document)
        {
            var elements = document.GetElementById("window-modal-cards");
            if (elements != null)
                { return elements; }
            return null;
        }

        public static HtmlElement FindZehirElement(HtmlElement document)
        {
            var elements = document.GetElementsByTagName("img");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("src").Contains("http://v2i.streetmobster.com/srv/eu.1/item/805.jpg"))
                { return e; }
            }
            return null;
        }

        public static HtmlElement FindCanElement(HtmlElement document)
        {
            var elements = document.GetElementsByTagName("img");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("src").Contains("http://v2i.streetmobster.com/srv/eu.1/item/804.jpg"))
                { return e; }
            }
            return null;
        }

        public static HtmlElement FindZeka1Element(HtmlElement document)
        {
            var elements = document.GetElementsByTagName("img");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("src").Contains("http://v2i.streetmobster.com/srv/eu.1/item/810.jpg"))
                { return e; }
            }
            return null;
        }

        public static HtmlElement FindZeka10Element(HtmlElement document)
        {
            var elements = document.GetElementsByTagName("img");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("src").Contains("http://v2i.streetmobster.com/srv/eu.1/item/832.jpg"))
                { return e; }
            }
            return null;
        }

        public static HtmlElement FindZeka10AlElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("img");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("src").Contains("http://v2i.streetmobster.com/srv/eu.1/item/832.jpg"))
                { return e; }
            }
            return null;
        }

        public static HtmlElement FindGuc1Element(HtmlElement document)
        {
            var elements = document.GetElementsByTagName("img");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("src").Contains("http://v2i.streetmobster.com/srv/eu.1/item/811.jpg"))
                { return e; }
            }
            return null;
        }

        public static HtmlElement FindGuc10Element(HtmlElement document)
        {
            var elements = document.GetElementsByTagName("img");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("src").Contains("http://v2i.streetmobster.com/srv/eu.1/item/833.jpg"))
                { return e; }
            }
            return null;
        }

        public static HtmlElement FindGuc10AlElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("img");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("src").Contains("http://v2i.streetmobster.com/srv/eu.1/item/833.jpg"))
                { return e; }
            }
            return null;
        }
    }
}
