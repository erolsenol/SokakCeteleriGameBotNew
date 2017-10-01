using System;
using System.Windows.Forms;

namespace SokakCeteleriGameBot
{
    public static class ElementHelper
    {
        public static HtmlElement FindSafeElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("img");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("src").Contains("http://v2i.streetmobster.com/tpl/img/connections.jpg?19"))
                { return e; }
            }
            return null;
        }

        public static HtmlElement FindNoSafeElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("div");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("mbody_"))
                {
                   // if (e.FirstChild.InnerText== "Yeterince VİP gününüz yok.")
                    {

                    }
                    return e; }
            }
            return null;
        }

        public static HtmlElement FindOpenSafeElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("a");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("pad_item safe_box_closed "))
                { return e; }
            }
            return null;
        }

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

        public static HtmlElement FindPoliceSearchElement(HtmlElement document)
        {
            Random rastgele = new Random();
            int rast = rastgele.Next(8);
            var elements = document.GetElementsByTagName("div");

                        var abc = document.GetElementsByTagName("a");
                        if (abc != null)
                        {
                            foreach (HtmlElement a in abc)
                            {
                                if (rast == 0 && a.GetAttribute("className").Contains("north"))
                                {
                                    return a;
                                }
                                else if (rast == 1 && a.GetAttribute("className").Contains("north-east"))
                                {
                                    return a;
                                }
                                else if (rast == 2 && a.GetAttribute("className").Contains("east"))
                                {
                                    return a;
                                }
                                else if (rast == 3 && a.GetAttribute("className").Contains("south-east"))
                                {
                                    return a;
                                }
                                else if (rast == 4 && a.GetAttribute("className").Contains("south"))
                                {
                                    return a;
                                }
                                else if (rast == 5 && a.GetAttribute("className").Contains("south-west"))
                                {
                                    return a;
                                }
                                else if (rast == 6 && a.GetAttribute("className").Contains("west"))
                                {
                                    return a;
                                }
                                else if (rast == 7 && a.GetAttribute("className").Contains("north-west"))
                                {
                                    return a;
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
                if ((e.GetAttribute("className").Contains("user-box u-jl utt")|| (e.GetAttribute("className").Contains("user-box vip-jl utt")) && e.Children[1].FirstChild.InnerText == "Hapistesin"))
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

        public static HtmlElement FindHapisKart(HtmlElement document)
        {
            var elements = document.GetElementsByTagName("a");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("pad_item json"))
                { return e; }
            }
            return null;
        }

        public static HtmlElement FindHapisBaglantii(HtmlElement document)
        {
            var elements = document.GetElementsByTagName("a");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("pad_item buy_extra jail_icons jail_bribe json"))
                { return e; }
            }
            return null;
        }

        public static HtmlElement FindConnectEscape(HtmlElement document)
        {
            int i = 0;
            var elements = document.GetElementsByTagName("a");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("pad_item jail_icons jail_bribe json"))
                {
                    i++;
                    if (i == 3)
                    {
                        return e;
                    }
                }
            }
            return null;
        }

        public static HtmlElement FindPrisonTopuk(HtmlElement document)
        {
            var elements = document.GetElementsByTagName("a");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("pad_item jail_icons jail_riot_0 json"))
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

        public static HtmlElement FindEscapemoney(HtmlElement document)
        {
            int i = 0;
            var elements = document.GetElementsByTagName("span");
            foreach (HtmlElement a in elements)
            {
                if (a.GetAttribute("className").Contains("connections"))
                {
                    i++;
                    if (i == 3)
                    {
                        return a;
                    }   
                }
            }
            return null;
        }

        public static HtmlElement FindCreditElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("span");
            foreach (HtmlElement a in elements)
            {
                if (a.GetAttribute("className").Contains("credit-info-new"))
                { return a; }
            }
            return null;
        }

        public static HtmlElement FindMyGangElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("div");
            foreach (HtmlElement a in elements)
            {
                if (a.GetAttribute("className").Contains("body  mygang"))
                { return a; }
            }
            return null;
        }

        public static HtmlElement FindDutyListElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("table");
            foreach (HtmlElement a in elements)
            {
                if (a.GetAttribute("className").Contains("gcrime_list"))
                { return a; }
            }
            return null;
        }

        public static HtmlElement FindOnlineUserElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("div");
            foreach (HtmlElement a in elements)
            {
                if (a.GetAttribute("className").Contains("modfadeonline"))
                { return a; }
            }
            return null;
        }

        public static HtmlElement FindNoGangElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("div");
            foreach (HtmlElement a in elements)
            {
                if (a.GetAttribute("className").Contains("body enemygang"))
                { return a; }
            }
            return null;
        }

        public static HtmlElementCollection FindUserElement(HtmlElement document)
        {
            var elements = document.GetElementsByTagName("tr");
            if (elements != null)
                { return elements; }
            return null;
        }

        public static HtmlElement FindMessageElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("div");
            foreach (HtmlElement a in elements)
            {
                if (a.GetAttribute("className").Contains("quick-msg"))
                { return a; }
            }
            return null;
        }

        public static HtmlElement FindMessageBtnElement(HtmlElement document)
        {
            var elements = document.GetElementsByTagName("a");
            foreach (HtmlElement a in elements)
            {
                if (a.FirstChild.InnerText== "Mesaj Yaz")
                { return a; }
            }
            return null;
        }

        public static HtmlElement FindMessageProfilBtnElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("a");
            foreach (HtmlElement a in elements)
            {
                if (a.GetAttribute("className").Contains("mailbox btn"))
                { return a; }
            }
            return null;
        }

        public static HtmlElement FindMessageSendElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("input");
            foreach (HtmlElement a in elements)
            {
                if (a.GetAttribute("className").Contains("btn send"))
                { return a; }
            }
            return null;
        }

        public static HtmlElement FindMessageNextElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("div");
            foreach (HtmlElement a in elements)
            {
                if (a.GetAttribute("className").Contains("page_bar"))
                { return a; }
            }
            return null;
        }

        public static HtmlElement FindMessageNextBtnElement(HtmlElement document)
        {
            var elements = document.GetElementsByTagName("a");
            foreach (HtmlElement a in elements)
            {
                if (a.GetAttribute("className").Contains("next"))
                { return a; }
            }
            var element = document.GetElementsByTagName("span");
            foreach (HtmlElement e in element)
            {
                if (e.GetAttribute("className").Contains("next_disabled"))
                {
                    return e;
                }
            }
            return null;
        }

        public static HtmlElement FindGangGoElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("div");
            foreach (HtmlElement a in elements)
            {
                if (a.GetAttribute("className").Contains("body"))
                { return a; }
            }
            return null;
        }

        public static HtmlElement FindMessageCompleteElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("div");
            foreach (HtmlElement a in elements)
            {
                if (a.GetAttribute("className").Contains("minfo"))
                { return a; }
            }
            return null;
        }

        public static HtmlElement FindGangBodyElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("h1");
            foreach (HtmlElement a in elements)
            {
                if (a.GetAttribute("className").Contains("inline"))
                { return a; }
            }
            return null;
        }

        public static HtmlElement FindHosElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("div");
            foreach (HtmlElement a in elements)
            {
                if (a.GetAttribute("className").Contains("modhospital"))
                { return a; }
            }
            return null;
        }

        public static HtmlElement FindHosKartElement(HtmlElement document)
        {
            var elements = document.GetElementsByTagName("a");
            foreach (HtmlElement a in elements)
            {
                if (a.GetAttribute("className").Contains("pad_item json"))
                { return a; }
            }
            return null;
        }

        public static HtmlElement FindHosHemsireElement(HtmlElement document)
        {
            var elements = document.GetElementsByTagName("a");
            foreach (HtmlElement a in elements)
            {
                if (a.GetAttribute("className").Contains("pad_item hospital_nurse json"))
                { return a; }
            }
            return null;
        }

        public static HtmlElement FindHospitalElement(HtmlDocument document)
        {
            var elements = document.GetElementsByTagName("div");
            foreach (HtmlElement e in elements)
            {
                if ((e.GetAttribute("className").Contains("user-box u-er utt") || (e.GetAttribute("className").Contains("user-box vip-er utt")) && e.Children[1].FirstChild.InnerText == "Hastanede"))
                { return e.Children[1].FirstChild; }
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

        public static HtmlElement GucTikElement(HtmlElement document)
        {
            var elements = document.GetElementsByTagName("a");
            foreach (HtmlElement e in elements)
            {
                if (e.GetAttribute("className").Contains("pad_item training_train train_5_on"))
                { return e; }
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
