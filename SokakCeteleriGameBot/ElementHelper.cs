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
                {return e;}
            }
            return null;
        }

        public static HtmlElement FindRightInventoryElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("td");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("inventory_right"))
                { return e; }
            }
            return null;
        }

        public static HtmlElement FindSatinAlElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("input");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("value").Contains("Satın al"))
                {
                    return e;
                }
            }
            return null;
        }

        public static HtmlElement FindSatinAlindiElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("input");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("btn ok"))
                { return e; }
            }
            return null;
        }

        public static HtmlElement FindLeftInventoryElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("td");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("inventory_left"))
                { return e; }
            }
            return null;
        }

        public static HtmlElement FindTrainingElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("div");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("b-links"))
                {return e;}
            }
            return null;
        }

        public static HtmlElement FindLeftTrainingElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("div");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("b-left-links"))
                {return e;}
            }
            return null;
        }

        public static HtmlElement FindRightTrainingElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("div");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("b-right-links"))
                {return e;}
            }
            return null;
        }

        public static HtmlElement FindTrainingCompletedElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("div");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("padded"))
                {return e;}
            }
            return null;
        }

        public static HtmlElement FindFightSearchElement(HtmlDocument document)
        {
            var elements = document.GetElementById("matchmaker");
           // foreach (HtmlElement e in elements)
            {
                if (elements != null)
                { return elements; }
            }
            return null;
        }

        public static HtmlElement FindFightCompletedElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("div");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("profile_panel inline-block  width-260"))
                {
                    var hangisi = e.GetElementsByTagName("a");
                    foreach (HtmlElement a in hangisi)
                    {
                        if (a.GetAttribute("className").Contains("beat btn"))
                        {return a;}
                    }
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
                {return e;}
            }
            return null;
        }

        public static HtmlElement FindTributeElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("table");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("default"))
                {return e;}
            }
            return null;
        }
        
        public static HtmlElement FindQuestElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("form");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("action").Contains("/quest/accept"))
                {
                    return e.Children[2];
                }
            }
            return null;
        }

        public static HtmlElement Dov(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("table");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("cmenu"))
                { return e; }
            }
            return null;
        }

        public static HtmlElement FindQuestButtonElement(HtmlDocument document)
        {
            var elements = document.GetElementById("qu[submit]");
                if (elements != null)
                { return elements; }
            return null;
        }

        public static HtmlElement FindQuestReadyElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("table");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("default default-headerless"))
                { return e; }
            }
            return null;
        }

        public static HtmlElement FindQuestFightElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("div");
            if (elements != null)
            {
                foreach (HtmlElement e in elements)
                {
                    if (e.GetAttribute("className").Contains("content-wrap"))
                    {
                        var abc = e.GetElementsByTagName("a");
                        if (abc != null)
                        {
                            foreach (HtmlElement a in abc)
                            {
                                if (a.GetAttribute("className").Contains("spot arrested") ||
                                    a.GetAttribute("className").Contains("spot motorbike-race") ||
                                    a.GetAttribute("className").Contains("spot armoured-car") ||
                                    a.GetAttribute("className").Contains("spot errand-boy") ||
                                    a.GetAttribute("className").Contains("spot carnival") ||
                                    a.GetAttribute("className").Contains("spot swat") ||
                                    a.GetAttribute("className").Contains("spot dog-walk") ||
                                    a.GetAttribute("className").Contains("spot k9") ||
                                    a.GetAttribute("className").Contains("spot dealers") ||
                                    a.GetAttribute("className").Contains("spot kidnapper") ||
                                    a.GetAttribute("className").Contains("spot bargain") ||
                                    a.GetAttribute("className").Contains("spot bank-robbery") ||
                                    a.GetAttribute("className").Contains("spot boss-suv") ||
                                    a.GetAttribute("className").Contains("spot musicians") ||
                                    a.GetAttribute("className").Contains("spot limo") ||
                                    a.GetAttribute("className").Contains("spot car-race") ||
                                    a.GetAttribute("className").Contains("spot firefight") ||
                                    a.GetAttribute("className").Contains("spot motorbike-rider") ||
                                    a.GetAttribute("className").Contains("spot playboy") ||
                                    a.GetAttribute("className").Contains("spot interview") ||
                                    a.GetAttribute("className").Contains("spot dog-fight") ||
                                    a.GetAttribute("className").Contains("spot pimp") ||
                                    a.GetAttribute("className").Contains("blinker") ||
                                    a.GetAttribute("className").Contains("east smarttip east-go") ||
                                    a.GetAttribute("className").Contains("north-east smarttip north-east-go") ||
                                    a.GetAttribute("className").Contains("north smarttip north-go") ||
                                    a.GetAttribute("className").Contains("north-west smarttip north-west-go") ||
                                    a.GetAttribute("className").Contains("west smarttip west-go") ||
                                    a.GetAttribute("className").Contains("south-west smarttip south-west-go") ||
                                    a.GetAttribute("className").Contains("south smarttip south-go") ||
                                    a.GetAttribute("className").Contains("south-east smarttip south-east-go"))
                                { return a; }
                            }
                        }
                    }
                }
            }
            return null;
        }

        public static HtmlElement FindQuestSearchElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("div");
            if (elements != null)
            {
                foreach (HtmlElement e in elements)
                {
                    if (e.GetAttribute("className").Contains("content-wrap"))
                    {
                        var abc = e.GetElementsByTagName("a");
                        if (abc != null)
                        {
                            foreach (HtmlElement a in abc)
                            {
                                if (a.GetAttribute("className").Contains("east smarttip east-go") ||
                                    a.GetAttribute("className").Contains("north-east smarttip north-east-go") ||
                                    a.GetAttribute("className").Contains("north smarttip north-go") ||
                                    a.GetAttribute("className").Contains("north-west smarttip north-west-go") ||
                                    a.GetAttribute("className").Contains("west smarttip west-go") ||
                                    a.GetAttribute("className").Contains("south-west smarttip south-west-go") ||
                                    a.GetAttribute("className").Contains("south smarttip south-go") ||
                                    a.GetAttribute("className").Contains("south-east smarttip south-east-go"))
                                { return a; }
                            }
                        }
                    }
                }
            }
            return null;
        }

        public static HtmlElement FindPoliceElement(HtmlDocument document)
        {
            var elements = document.GetElementById("arrested");
                if (elements != null)
                {return elements;}
            return null;
        }

        public static HtmlElement FindPrisonElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("div");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("user-box u-jl utt") && e.Children[1].FirstChild.InnerText == "Hapistesin")
                { return e.Children[1].FirstChild; }
            }
            return null;
        }

        public static HtmlElement FindThisIsPrisonElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("div");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("modprison"))
                { return e; }
            }
            return null;
        }

        public static HtmlElement FindEscapeConnectElement(HtmlDocument document)
        {
            var elements = document.GetElementById("window-modal-extra");
            if (elements != null)
                { return elements; }
            return null;
        }

        public static HtmlElement FindHospitalElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("div");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("modhospital"))
                {return e;}
            }
            return null;
        }

        public static HtmlElement FindTrainingContentElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("div");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("training_content"))
                {return e;}
            }
            return null;
        }

        public static HtmlElement FindGangHomeElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("div");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("body  mygang"))
                {return e;}
            }
            return null;
        }

        public static HtmlElement FindGangQuestElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("table");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("gcrime_list"))
                {return e;}
            }
            return null;
        }

        public static HtmlElement FindGangCrimeElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("div");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("body"))
                {return e;}
            }
            return null;
        }
    }
}
