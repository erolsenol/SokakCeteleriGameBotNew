using System;
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

        public static HtmlElement FindRespectElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("div");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("b-left-links"))
                {
                    return e;
                }
            }
            return null;
        }

        public static HtmlElement FindTopMenuElement(HtmlDocument document)
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

        public static HtmlElement FindFightSearchElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("div");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("body fight-finder modfaderacket fight-finder-enhanced"))
                {
                    return e;
                }
            }
            return null;
        }

        public static HtmlElement FindInventoryElement(HtmlDocument document)
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

        public static HtmlElement FindHomeElement(HtmlDocument document)
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

        public static HtmlElement FindStreetElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("div");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("private-map-10 my-map"))
                {
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

        public static HtmlElement FindDrinkCompletedElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("div");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("minfo"))
                {
                    return e;
                }
            }
            return null;
        }

        public static HtmlElement FindTributeElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("table");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("default"))
                {
                    return e;
                }
            }
            return null;
        }
        //Çalışmnaya bilir 
        public static HtmlElement FindQuestElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("table").GetElementsByName("qListContainer");
            foreach (HtmlElement e in elements)
            {
                if (e != null)
                {
                    return e.Children[0];
                }
            }
            return null;
        }

        public static HtmlElement FindPrisonElement(HtmlDocument document)
        {
            var elements = document.GetElementById("arrested");
                if (elements != null)
                {
                    return elements;
                }
            return null;
        }

        public static HtmlElement FindHospitalElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("div");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("modhospital"))
                {
                    return e;
                }
            }
            return null;
        }

        public static HtmlElement FindTrainingContentElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("div");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("training_content"))
                {
                    return e;
                }
            }
            return null;
        }

        public static HtmlElement FindGangHomeElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("div");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("body  mygang"))
                {
                    return e;
                }
            }
            return null;
        }

        public static HtmlElement FindGangQuestElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("table");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("gcrime_list"))
                {
                    return e;
                }
            }
            return null;
        }

        public static HtmlElement FindGangCrimeElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("div");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("body"))
                {
                    return e;
                }
            }
            return null;
        }
    }
}
