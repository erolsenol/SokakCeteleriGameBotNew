using System;
using System.Windows.Forms;
// ReSharper disable PossibleNullReferenceException

namespace SokakCeteleriGameBot
{
    public partial class MainForm : Form
    {
        readonly WebBrowser _webBrowser;
        bool _isPageLoaded, _enerjiDurum, _hapisKacKart, _hapisKacBaglanti, _rusvetNoPara;
        bool _isLoggedIn;

        private GameOps _game = GameOps.Non;
        private Int64 _atak, _baglanti, _respectPoints;
        private int _can, _enerji, _enerjiToplam, _risk, _zehir, _seviye, _para, _minSeviye, _dovulen = 0;
        private int _zeka, _guc, _cazibe;
        private int _battlePoints;

        private void btnSavas_Click(object sender, EventArgs e)
        {
            _game = GameOps.Savas;
            if (_enerji == _enerjiToplam)
            { _enerjiDurum = true; }
            double odondur = 0;
            if (double.TryParse(tbMinSeviye.Text, out odondur))
            { _minSeviye = int.Parse(tbMinSeviye.Text); }
            else
            { _minSeviye = 5; }
            Savas(_webBrowser.Document);
        }

        private void cbHapisKart_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHapisKart.Checked)
            { _hapisKacKart = true;}
            else
            { _hapisKacKart = false;}
        }

        private void cbPolisNoPara_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPolisNoPara.Checked)
            { _rusvetNoPara = true; }
            else
            { _rusvetNoPara = false; }
        }

        private void cbHapisBaglanti_CheckedChanged(object sender, EventArgs e)
        {
                if (cbHapisBaglanti.Checked)
            { _hapisKacBaglanti = true; }
            else
            { _hapisKacBaglanti = false; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _game = GameOps.Savas;
            if (_enerji == _enerjiToplam)
            { _enerjiDurum = true; }
            double odondur = 0;
            if (double.TryParse(tbMinSeviye.Text, out odondur))
            { _minSeviye = int.Parse(tbMinSeviye.Text); }
            else
            { _minSeviye = 5; }
            Savas(webBrowser1.Document);
        }

        private HtmlElement elEnerji, elGuc, elZeka;

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void btnAntreman_Click(object sender, EventArgs e)
        {
            _webBrowser.Navigate("http://sokakceteleri.com/");
            _webBrowser.DocumentCompleted += _webBrowser_DocumentCompleted;
            _game = GameOps.Antrenman;
            if (_enerji == _enerjiToplam)
            { _enerjiDurum = true; }
            Antrenman(_webBrowser.Document);
        }

        public MainForm()
        {
            InitializeComponent();

            _webBrowser = new WebBrowser();
            _webBrowser.ScriptErrorsSuppressed = true;
            webBrowser1.ScriptErrorsSuppressed = true;

            //_webBrowser.Dock = DockStyle.Fill;
            //Controls.Add(_webBrowser);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://sokakceteleri.com/");
            webBrowser1.DocumentCompleted += WebBrowser1_DocumentCompleted;
        }

        private void _webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            var document = _webBrowser.Document;
            if (document == null) return;

            LoginToGame(document);
            //  if (_isPageLoaded) { return; } 

            BilgileriGetir(document);
            GetTraniningPoints(document);

            startPanel.Visible = !_isPageLoaded;
            switch (_game)
            {
                case GameOps.Antrenman:
                    Antrenman(document);
                    break;
                case GameOps.Savas:
                    Savas(document);
                    break;
                case GameOps.Gorev:
                    //Gorev
                    break;
                case GameOps.Harac:
                    //Harac
                    break;
                default:
                    break;
            }
        }

        private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            var document = webBrowser1.Document;
            if (document == null) return;

            LoginToGame(document);
            //  if (_isPageLoaded) { return; } 

            BilgileriGetir(document);
            GetTraniningPoints(document);

            startPanel.Visible = !_isPageLoaded;
            switch (_game)
            {
                case GameOps.Antrenman:
                    Antrenman(document);
                    break;
                case GameOps.Savas:
                    Savas(document);
                    break;
                case GameOps.Gorev:
                    //Gorev
                    break;
                case GameOps.Harac:
                    //Harac
                    break;
                default:
                    break;
            }
        }     

        private void LoginToGame(HtmlDocument document)
        {
            if (document.GetElementById("login-content") != null)
            {
                document.GetElementById("login[usr]").InnerText = "bitirimer0";
                document.GetElementById("login[pwd]").InnerText = "pistols987";
                document.GetElementById("login[submit]").InvokeMember("click");
                _isLoggedIn = true;
            }
        }

        private void BilgileriGetir(HtmlDocument document)
        {
            var userPropertiesElement = ElementHelper.FindUserPropertiesElement(document);
            if (userPropertiesElement != null)
            {
                var elements = userPropertiesElement.GetElementsByTagName("u");

                if (elements.Count > 0)
                {
                   var elCan = elements[0];
                   elEnerji = elements[1];
                   var elRisk = elements[2];
                   var elZehir = elements[3];

                  //  MessageBox.Show(elements[1].);

                    _can = int.Parse(elCan.InnerText);
                    _enerji = int.Parse(elEnerji.InnerText);
                    _risk = int.Parse(elRisk.InnerText);
                    _zehir = int.Parse(elZehir.InnerText);

                    lbCan.Text = @"Can : " + _can;
                    lbEnerji.Text = @"Enerji : " + _enerji;
                    lbRisk.Text = @"Risk : " + _risk;
                    lbZehir.Text = @"Zehir : " + _zehir;

                     _enerjiToplam =Convert.ToInt16(userPropertiesElement.Children[0].Children[0].Children[2].Children[0].GetAttribute("title")
                        .Trim().Replace(" ", string.Empty).Substring(userPropertiesElement.Children[0].Children[0].Children[2]
                        .Children[0].GetAttribute("title").Trim().Replace(" ", string.Empty).Length - 3, 3));
                  
                    
                    _isPageLoaded = true;
                }

                var lwl = userPropertiesElement.Children[0].Children[0].Children[0].Children[1].Children[0];
                if (lwl != null)
                {
                    _seviye = Convert.ToInt16(lwl.InnerText);
                    lbSeviye.Text = @"Seviye : " + _seviye.ToString();
                }
            }
        }

        private void GetTraniningPoints(HtmlDocument document)
        {
            var trainingInfosElement = ElementHelper.FindTrainingElement(document);
            if (trainingInfosElement != null)
            {
                var bpItems = trainingInfosElement.Children[0].GetElementsByTagName("span");

                if (bpItems[0].GetAttribute("className").Contains("battle_points"))
                {
                    _battlePoints = int.Parse(bpItems[0].InnerText);
                }
                //Saygı
                {
                    string respectk = trainingInfosElement.Children[0].Children[0].InnerText.Trim().Replace(" ", string.Empty).
                         Substring(0, trainingInfosElement.Children[0].Children[0].InnerText.Trim().Replace(" ", string.Empty).Length -
                         bpItems[0].InnerText.Length);
                    if (respectk[respectk.Length - 1].ToString() == "k")
                    {
                        _respectPoints = Convert.ToInt64(respectk.Substring(0, respectk.Length - 1) + "000");
                        lbSaygi.Text = @"Saygı : " + _respectPoints.ToString();
                    }
                    else
                    {
                        _respectPoints = Convert.ToInt64(respectk);
                        lbSaygi.Text = @"Saygı : " + _respectPoints.ToString();
                    }
                }
                //Para And Bağlantı
                {
                    _para = Convert.ToInt32(trainingInfosElement.Children[0].Children[1].Children[0].Children[0].InnerText.
                        Trim().Replace(" ", string.Empty));
                    lbPara.Text = "Para : " + _para.ToString();

                    string baglantii = trainingInfosElement.Children[0].Children[1].Children[0].Children[1].InnerText;
                    if (baglantii[baglantii.Length - 1].ToString() == "k")
                    {
                        _baglanti = Convert.ToInt64(baglantii.Substring(0, baglantii.Length - 1) + "000");
                        lbBaglanti.Text = @"Bağlantı : " + _baglanti.ToString();
                    }
                    else
                    {
                        _baglanti = Convert.ToInt16(baglantii);
                        lbBaglanti.Text = @"Bağlantı : " + _baglanti.ToString();
                    }
                }
                //Atak
                {
                    string atakk = trainingInfosElement.Children[0].Children[2].Children[0].InnerText.Trim().Replace(" ", string.Empty).
                        Substring(0, trainingInfosElement.Children[0].Children[2].Children[0].InnerText.Trim().Replace(" ", string.Empty).
                        Length - trainingInfosElement.Children[0].Children[2].Children[0].Children[0].InnerText.Length);
                    if (atakk[atakk.Length - 1].ToString() == "k")
                    {
                        _atak = Convert.ToInt64(atakk.Substring(0, atakk.Length - 1) + "000");
                        lbAtak.Text = @"Atak : " + _atak.ToString();
                    }
                    else
                    {
                        _atak = Convert.ToInt16(atakk);
                        lbAtak.Text = @"Atak : " + _atak.ToString();
                    }
                }

                var trainingLinks = trainingInfosElement.Children[1].GetElementsByTagName("a");

                elZeka = trainingLinks[0].Children[0];
                elGuc = trainingLinks[1].Children[0];

                _zeka = int.Parse(trainingLinks[0].Children[0].InnerText);
                _guc = int.Parse(trainingLinks[1].Children[0].InnerText);
                _cazibe = int.Parse(trainingLinks[2].Children[0].InnerText);

                lbSavasPuan.Text = @"Savaş Puanı : " + _battlePoints;
                lbZekaPuan.Text = @"Zeka Puanı : " + _zeka;
                lbGucPuan.Text = @"Güç Puanı : " + _guc;
                lbCazibePuan.Text = @"Cazibe Puanı : " + _cazibe;

                string zekaMiktar = trainingInfosElement.Children[1].Children[0].InnerText.Substring(0, trainingInfosElement.Children[1].Children[0].InnerText.Length -
                    _zeka.ToString().Length);
                lbZeka.Text = @"Zeka : " + zekaMiktar;
                string gucMiktar = trainingInfosElement.Children[1].Children[1].InnerText.Substring(0, trainingInfosElement.Children[1].Children[1].InnerText.Length -
                    _guc.ToString().Length);
                lbGuc.Text = @"Güç : " + gucMiktar;
                string cazibeMiktar = trainingInfosElement.Children[1].Children[2].InnerText.Substring(0, trainingInfosElement.Children[1].Children[2].InnerText.Length -
                    _cazibe.ToString().Length);
                lbCazibe.Text = @"Zeka : " + cazibeMiktar;
            }  
        }

        private void Antrenman(HtmlDocument document)
        {
            if (document == null) return;
            if (_enerji < 40) { _enerjiDurum = false; }
            if (!_enerjiDurum)
            {
                var findDrink = EnerjiElement.FindDrinkElement(document);

                if (_enerji==_enerjiToplam)
                {
                    _enerjiDurum = true;_webBrowser.Refresh(); return;
                }
                else if (findDrink != null)
                {
                    HtmlElementCollection bul = findDrink.Document.GetElementsByTagName("img");
                    foreach (HtmlElement a in bul)
                    {
                        string nameStr = a.GetAttribute("src");
                        if (nameStr == "http://v2i.streetmobster.com/srv/eu.1/item/505.jpg")
                        {
                            a.InvokeMember("click"); return;
                        }
                    }
                }
                else
	            {
                    elEnerji.InvokeMember("click"); ;return;
                }
            }
            else if (_zeka > 0)
            {
                var enerjilow = EnerjiElement.LowEnerjiTrainingElement(document);
                var ant = ElementHelper.FindTrainingContentElement(document);
                var completed = ElementHelper.FindTrainingCompletedElement(document);
                if (enerjilow != null)
                {

                    elEnerji.InvokeMember("click"); _enerjiDurum = false; return;
                }
                
                else if (ant != null)
                {
                    ant.Children[1].Children[0].Children[2].Children[0].Children[0].Children[0].InvokeMember("click");return;
                }
                else
	            {
                    elZeka.InvokeMember("click");return;
                }
            }
            else if (_guc > 0)
            {
                var enerjilow = EnerjiElement.LowEnerjiTrainingElement(document);
                var ant = ElementHelper.FindTrainingContentElement(document);
                var completed = ElementHelper.FindTrainingCompletedElement(document);
                if (enerjilow != null)
                {

                    elEnerji.InvokeMember("click"); _enerjiDurum = false; return;
                }
                else if (completed != null)
                {
                    elGuc.InvokeMember("click"); return;
                }
                else if (ant != null)
                {
                    ant.Children[1].Children[0].Children[2].Children[0].Children[0].Children[0].InvokeMember("click"); return;
                }
                else
                {
                    elGuc.InvokeMember("click"); return;
                }
            }
            else
            {_game = GameOps.Non; return; }
        }

        private void Savas(HtmlDocument document)
        {
            if (document == null) return;
            var prison = ElementHelper.FindPrisonElement(document);
            if (prison != null)
            {
                if (_hapisKacKart && Convert.ToInt16(prison.Children[0].Children[2].Children[0].Children[0].
                    Children[0].Children[0].Children[1].InnerText) > 0)
                {
                    prison.Children[0].Children[2].Children[0].Children[0].Children[0].InvokeMember("click"); return;
                }
                else if (_hapisKacBaglanti && _baglanti >= 78)
                {
                    prison.Children[0].Children[2].Children[1].Children[0].Children[0].InvokeMember("click");
                }
                else
                {
                    prison.Children[0].Children[3].Children[0].Children[0].Children[0].InvokeMember("click"); return;
                }
                var escapeConnect = ElementHelper.FindEscapeConnectElement(webBrowser1.Document);
                if (escapeConnect != null)
                {
                    escapeConnect.Children[0].Children[2].Children[0].Children[0].Children[1].Children[0].Children[0].Children[1].
                        Children[0].Children[2].Children[0].Children[0].Children[0].InvokeMember("click");return;
                }
            }
            var police = ElementHelper.FindPoliceElement(document);
            if (police != null)
            {
                if (_rusvetNoPara)
                {
                    int rusvet1 = Convert.ToInt16(police.Children[1].Children[0].GetAttribute("value").
                                        Trim().Replace(" ", string.Empty).Substring(0, police.Children[1].Children[0].
                                        GetAttribute("value").Trim().Replace(" ", string.Empty).Length - 13));
                    if ((_para / 1000) >= rusvet1)
                    { police.Children[1].Children[0].InvokeMember("click"); return; }
                    int rusvet2 = Convert.ToInt16(police.Children[2].Children[0].GetAttribute("value").
                        Trim().Replace(" ", string.Empty).Substring(0, police.Children[2].Children[0].
                        GetAttribute("value").Trim().Replace(" ", string.Empty).Length - 13));
                    if ((_para / 1000) >= rusvet2)
                    { police.Children[2].Children[0].InvokeMember("click"); return; }
                    int rusvet3 = Convert.ToInt16(police.Children[3].Children[0].GetAttribute("value").
                        Trim().Replace(" ", string.Empty).Substring(0, police.Children[3].Children[0].
                        GetAttribute("value").Trim().Replace(" ", string.Empty).Length - 13));
                    if ((_para / 1000) >= rusvet3)
                    { police.Children[3].Children[0].InvokeMember("click"); return; }
                }
                  police.Children[4].Children[0].InvokeMember("click"); return;
            }
            if (_enerji < 60) { _enerjiDurum = false; }
            if (!_enerjiDurum)
            {
                var findDrink = EnerjiElement.FindDrinkElement(document);
                var sokak = MenuElement.LeftMenuElement(document);

                if (_enerji == _enerjiToplam)
                {
                    _enerjiDurum = true; sokak.Children[1].Children[0].InvokeMember("click"); return;
                }
                else if (findDrink != null)
                {
                    HtmlElementCollection bul = findDrink.Document.GetElementsByTagName("img");
                    foreach (HtmlElement a in bul)
                    {
                        string nameStr = a.GetAttribute("src");
                        if (nameStr == "http://v2i.streetmobster.com/srv/eu.1/item/505.jpg")
                        {
                            a.InvokeMember("click"); return;
                        }
                    }
                }
                else
                {
                    elEnerji.InvokeMember("click"); ; return;
                }
            }
            else if (_battlePoints > 0)
            {
              //ÇAlışmıyor  var enerjilow = EnerjiElement.LowEnerjiFightElement(document);
                var sokak = MenuElement.LeftMenuElement(document);
                var dovusMenu = MenuElement.TopMenuFightElement(document);
                var dovusAra = ElementHelper.FindFightSearchElement(document);
                var dovusYap = ElementHelper.FindFightCompletedElement(document);

                //if (enerjilow != null)
                //{
                //    elEnerji.InvokeMember("click"); _enerjiDurum = false; return;
                //}
                if (dovusYap != null)
                {
                    _dovulen++;
                    dovusYap.InvokeMember("click");lbdovulen.Text = "Dövülen : " + _dovulen.ToString(); return;
                }
                else if (dovusAra != null)
                {
                    dovusAra.Children[1].Children[0].Children[0].Children[1].Children[0].InnerText = (_seviye - _minSeviye).ToString();
                    dovusAra.Children[1].Children[0].Children[1].Children[1].Children[0].InnerText = (_seviye + 200).ToString();
                    dovusAra.Children[1].Children[0].Children[2].Children[1].Children[0].InnerText = 
                        (_respectPoints - ((_respectPoints / 100) * 1)).ToString();
                    dovusAra.Children[3].Children[0].Children[0].InvokeMember("click");return;
                }
                else if (dovusMenu != null)
                {
                    dovusMenu.InvokeMember("click");return;
                }
                else if (sokak != null)
                {
                    sokak.Children[1].Children[0].InvokeMember("click"); return;
                }
            }
        }
    }
}
