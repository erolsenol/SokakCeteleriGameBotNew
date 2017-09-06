using System;
using System.Windows.Forms;
// ReSharper disable PossibleNullReferenceException

namespace SokakCeteleriGameBot
{
    public partial class MainForm : Form
    {
        readonly WebBrowser _webBrowser;
        bool _isPageLoaded;
        bool _isLoggedIn;

        private GameOps _game = GameOps.Non;
        private Int64 _atak, _baglanti;
        private int _can, _enerji, _risk, _zehir, _seviye, _para;
        private int _zeka, _guc, _cazibe;
        private int _battlePoints, _respectPoints;
        private HtmlElement elEnerji, elGuc, elZeka;

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void btnAntreman_Click(object sender, EventArgs e)
        {
            if (elZeka != null){ return; }
            elZeka.InvokeMember("click");
        }

        public MainForm()
        {
            InitializeComponent();

            _webBrowser = new WebBrowser();
            _webBrowser.ScriptErrorsSuppressed = true;

            //_webBrowser.Dock = DockStyle.Fill;
            //Controls.Add(_webBrowser);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _webBrowser.Navigate("http://sokakceteleri.com/");
            _webBrowser.DocumentCompleted += WebBrowser_DocumentCompleted;
        }

        private void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (_isPageLoaded) { return; }

            var  document = _webBrowser.Document;
            if (document == null) return;

            LoginToGame(document);

            BilgileriGetir(document);
            GetTraniningPoints(document);

            startPanel.Visible = !_isPageLoaded;
            webBrowser1 = _webBrowser;
            switch (_game)
            {
                case GameOps.Antrenman:
                    //Antrenman yap
                    break;
                case GameOps.Savas:
                    //Savas
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

                    _can = int.Parse(elCan.InnerText);
                    _enerji = int.Parse(elEnerji.InnerText);
                    _risk = int.Parse(elRisk.InnerText);
                    _zehir = int.Parse(elZehir.InnerText);

                    lbCan.Text = @"Can : " + _can;
                    lbEnerji.Text = @"Enerji : " + _enerji;
                    lbRisk.Text = @"Risk : " + _risk;
                    lbZehir.Text = @"Zehir : " + _zehir;

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
                        _respectPoints = Convert.ToInt32(respectk.Substring(0, respectk.Length - 1) + "000");
                        lbSaygi.Text = @"Saygı : " + _respectPoints.ToString();
                    }
                    else
                    {
                        _respectPoints = Convert.ToInt32(respectk);
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

        public void Antrenman(HtmlDocument document)
        {
            _game = GameOps.Antrenman;
            var hapis = ElementHelper.FindPrisonElement(document);
            var hastane = ElementHelper.FindHospitalElement(document);


            if (_enerji < 20)
            {
                elEnerji.InvokeMember("click");
            }
            _game = GameOps.Non;
        }
    }
}
