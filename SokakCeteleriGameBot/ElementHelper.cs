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
        //Çalışmnaya bilir 
        public static HtmlElement FindQuestElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("table").GetElementsByName("qListContainer");
            foreach (HtmlElement e in elements)
            {
                if (e != null)
                {return e.Children[0];}
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
            var elements = document.GetElementById("map");

            foreach (HtmlElement e in elements)
            {
                if (e.OuterHtml.Contains("spot arrested") ||
                                e.OuterHtml.Contains("spot motorbike-race") ||
                                e.OuterHtml.Contains("spot armoured-car") ||
                                e.OuterHtml.Contains("spot errand-boy") ||
                                e.OuterHtml.Contains("spot carnival") ||
                                e.OuterHtml.Contains("spot swat") ||
                                e.OuterHtml.Contains("spot dog-walk") ||
                                e.OuterHtml.Contains("spot k9") ||
                                e.OuterHtml.Contains("spot dealers") ||
                                e.OuterHtml.Contains("spot kidnapper") ||
                                e.OuterHtml.Contains("spot bargain") ||
                                e.OuterHtml.Contains("spot bank-robbery") ||
                                e.OuterHtml.Contains("spot boss-suv") ||
                                e.OuterHtml.Contains("spot musicians") ||
                                e.OuterHtml.Contains("spot limo") ||
                                e.OuterHtml.Contains("spot car-race") ||
                                e.OuterHtml.Contains("spot firefight") ||
                                e.OuterHtml.Contains("spot motorbike-rider") ||
                                e.OuterHtml.Contains("spot playboy") ||
                                e.OuterHtml.Contains("spot interview") ||
                                e.OuterHtml.Contains("spot dog-fight") ||
                                e.OuterHtml.Contains("spot pimp") || 
                                e.OuterHtml.Contains("blinker") ||
                                e.OuterHtml.Contains("east smarttip east-go") ||
                                e.OuterHtml.Contains("north-east smarttip north-east-go") ||
                                e.OuterHtml.Contains("north smarttip north-go") ||
                                e.OuterHtml.Contains("north-west smarttip north-west-go") ||
                                e.OuterHtml.Contains("west smarttip west-go") ||
                                e.OuterHtml.Contains("south-west smarttip south-west-go") ||
                                e.OuterHtml.Contains("south smarttip south-go") ||
                                e.OuterHtml.Contains("south-east smarttip south-east-go"))
                { return e; }
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
            var elements = document.GetElementsByTagName("table");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("cellpadding").Contains("4")&& e.GetAttribute("cellspacing").Contains("0"))
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
