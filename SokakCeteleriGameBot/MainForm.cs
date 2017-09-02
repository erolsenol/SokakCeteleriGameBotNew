using System;
using System.Linq;
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

        private int _can, _enerji, _risk, _zehir;
        private int _zeka, _guc, _cazibe;
        private int _battlePoints;

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
            _webBrowser.Navigate("http://sokakceteleri.com/");
            _webBrowser.DocumentCompleted += WebBrowser_DocumentCompleted;
        }

        private void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (_isPageLoaded) { return; }

            var document = _webBrowser.Document;
            if (document == null) return;

            LoginToGame(document);

            BilgileriGetir(document);
            GetTraniningPoints(document);

            startPanel.Visible = !_isPageLoaded;

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

            var elements = userPropertiesElement.GetElementsByTagName("u");

            if (elements.Count > 0)
            {
                var elCan = elements[0];
                var elEnerji = elements[1];
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
        }

        private void GetTraniningPoints(HtmlDocument document)
        {
            var trainingInfosElement = ElementHelper.FindTrainingElement(document);

            var bpItems = trainingInfosElement.Children[0].GetElementsByTagName("span");
            if (bpItems[0].GetAttribute("className").Contains("battle_points"))
            {
                _battlePoints = int.Parse(bpItems[0].InnerText);
            }

            var trainingLinks = trainingInfosElement.Children[1].GetElementsByTagName("a");
            _zeka = int.Parse(trainingLinks[0].Children[0].InnerText);
            _guc = int.Parse(trainingLinks[1].Children[0].InnerText);
            _cazibe = int.Parse(trainingLinks[2].Children[0].InnerText);
        }

        public void Antrenman()
        {
            _game = GameOps.Antrenman;

            //asfkatraewwet

            _game = GameOps.Non;
        }
    }
}
