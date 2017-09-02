using System.Windows.Forms;

namespace SokakCeteleriGameBot
{
    public static class ElementHelper
    {
        public static HtmlElement FindUserPropertiesElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("table");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("user-properties"))
                {
                    return e;
                }
            }
            return null;
        }

        public static HtmlElement FindTrainingElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("div");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("b-links"))
                {
                    return e;
                }
            }
            return null;
        }
    }
}
