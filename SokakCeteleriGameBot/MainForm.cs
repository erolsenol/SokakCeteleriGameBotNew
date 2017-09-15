using System;
using System.Windows.Forms;
using Microsoft.Win32;
using Quartz;
using Quartz.Impl;

// ReSharper disable PossibleNullReferenceException

namespace SokakCeteleriGameBot
{
    public partial class MainForm : Form
    {
        System.Threading.Timer _timer;
        //  readonly WebBrowser _webBrowser;
        bool _isPageLoaded, _isLoggedIn, _enerjiDurum, _hapisKacKart = true, _hapisKacBaglanti = true, _rusvetNoPara = true,
            _gucKartKullan, _zekaKartKullan, _hastaneKartKullan = true, _hastaneParaKullan, _zehirKartKullan = true,
            _canKartKullan = true, _enerjiKartKullan = true, _krediKas = false, savass;

        private GameOps _game = GameOps.Non;
        private Int64 _atak, _baglanti, _respectPoints;
        private int _can, _enerji, _enerjiToplam, _zehirToplam, _cantoplam, _riskToplam, _risk, _zehir, _seviye, _para, _minSeviye = 5, _taneZekaAl,
            _taneGucAl, _riskHesapla;
        private int _zeka, _guc, _cazibe;
        private int _battlePoints;
        
        private HtmlElement elEnerji, elGuc, elZeka;

        private void btnNewIp_Click(object sender, EventArgs e)
        {
            SetProxy("82.165.73.186.80");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://www.chip.com.tr/ip-adresim-nedir");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var kasaAc = ElementHelper.FindOpenSafeElement(webBrowser1.Document);
            kasaAc.InvokeMember("click"); return;
            //  webBrowser1.Navigate("http://sokakceteleri.com/");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RegistryKey registry = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings", true);
            registry.SetValue("ProxyServer", 0);
            registry.SetValue("ProxyFalse","0");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://www.sokakceteleri.com/?affiliate_guid=4129260");
        }

        private void cbKrediKas_CheckedChanged(object sender, EventArgs e)
        {
            if (cbKrediKas.Checked)
            { _krediKas = true; }
            else
            { _krediKas = false; }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            KasaAc(webBrowser1.Document);
            _game = GameOps.KasaAc;
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            _game = GameOps.Kasil;
            if (_enerji == _enerjiToplam)
            { _enerjiDurum = true; }
            Kasil(webBrowser1.Document);
        }

        private void btnBilekGures_Click(object sender, EventArgs e)
        {
            _game = GameOps.BilekGuresi;
            BilekGuresi(webBrowser1.Document);
        }

        private void cbRiskKart_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void cbEnerjiKart_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEnerjiKart.Checked)
            { _enerjiKartKullan = true; }
            else
            { _enerjiKartKullan = false; }
        }

        private void cbZekaAl_TextChanged(object sender, EventArgs e)
        {
            double odondur = 0;
            if (double.TryParse(cbZekaAl.Text, out odondur))
            {
                _taneZekaAl = int.Parse(cbZekaAl.Text);
                if (_taneZekaAl > (_baglanti / 100))
                {
                    cbZekaAl.Text = (_baglanti / 100).ToString();
                }
            }
            else
            { cbZekaAl.Text = ""; }
        }

        private void cbGucAl_TextChanged(object sender, EventArgs e)
        {
            double odondur = 0;
            if (double.TryParse(cbGucAl.Text, out odondur))
            { _taneGucAl = int.Parse(cbGucAl.Text);
                if (_taneGucAl > (_baglanti / 100))
                {
                    cbGucAl.Text = (_baglanti / 100).ToString();
                }
            }
            else
            { cbGucAl.Text = ""; }
        }

        private void cbZehirKart_CheckedChanged(object sender, EventArgs e)
        {
            if (cbZehirKart.Checked)
            { _zehirKartKullan = true; }
            else
            { _zehirKartKullan = false; }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            { savass = true; }
            else
            { savass = false; }
        }

        private void cbCanKart_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCanKart.Checked)
            { _canKartKullan = true; }
            else
            { _canKartKullan = false; }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _game = GameOps.Non;
            cbGucAl.Enabled = false;
            cbZekaAl.Enabled = false;
        }

        private void cbZekaKart_CheckedChanged(object sender, EventArgs e)
        {
            if (cbZekaKart.Checked)
            { _zekaKartKullan = true; }
            else
            { _zekaKartKullan = false; }
        }

        private void tbMinSeviye_TextChanged(object sender, EventArgs e)
        {
            double odondur = 0;
            if (double.TryParse(tbMinSeviye.Text, out odondur))
            { _minSeviye = int.Parse(tbMinSeviye.Text); }
            else
            { _minSeviye = 5; }
        }

        private void cbHastanePara_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHastanePara.Checked)
            { _hastaneParaKullan = true; }
            else
            { _hastaneParaKullan = false; }
        }

        private void cbHastaneKart_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHastaneKart.Checked)
            { _hastaneKartKullan = true; }
            else
            { _hastaneKartKullan = false; }
        }

        private void cbHapisKart_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHapisKart.Checked)
            { _hapisKacKart = true;}
            else
            { _hapisKacKart = false;}
        }

        private void cbHapisBaglanti_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHapisBaglanti.Checked)
            { _hapisKacBaglanti = true; }
            else
            { _hapisKacBaglanti = false; }
        }

        private void cbGuckart_CheckedChanged(object sender, EventArgs e)
        {
            if (cbGuckart.Checked)
            { _gucKartKullan = true; }
            else
            { _gucKartKullan = false; }
        }

        private void cbPolisNoPara_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPolisNoPara.Checked)
            { _rusvetNoPara = true; }
            else
            { _rusvetNoPara = false; }
        }

        private void btnHaracTopla_Click(object sender, EventArgs e)
        {
            _game = GameOps.Harac;
            if (_enerji == _enerjiToplam)
            { _enerjiDurum = true; }
            HaracTopla(webBrowser1.Document);
        }

        private void btnGorev_Click(object sender, EventArgs e)
        {
            _game = GameOps.Gorev;
            if (_enerji == _enerjiToplam)
            { _enerjiDurum = true; }
            GorevYap(webBrowser1.Document);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _game = GameOps.Savas;
            if (_enerji == _enerjiToplam)
            { _enerjiDurum = true; }
            Savas(webBrowser1.Document);
          //  var solMenu = MenuElement.LeftMenuElement(webBrowser1.Document);
          //  solMenu.Children[1].Children[0].InvokeMember("click");
        }

        private void btnAntreman_Click(object sender, EventArgs e)
        {
            if ((_baglanti / 100) >= (_taneZekaAl + _taneGucAl))
            {
                _game = GameOps.Antrenman;
                if (_enerji == _enerjiToplam)
                { _enerjiDurum = true; }
                Antrenman(webBrowser1.Document);
                cbGucAl.Enabled = false;
                cbZekaAl.Enabled = false;
            }
            else
            {
                cbZekaAl.Clear();
                cbGucAl.Clear();
                MessageBox.Show("Lütfen Satın Alınacak Kart Sayılarını Yanlış Yazmayınız");}
        }

        public MainForm()
        {
            InitializeComponent();
            //_webBrowser = new WebBrowser();
            //_webBrowser.ScriptErrorsSuppressed = true;
            //_webBrowser.Navigate("http://sokakceteleri.com/");
            //_webBrowser.DocumentCompleted += _webBrowser_DocumentCompleted;
            webBrowser1.ScriptErrorsSuppressed = true;
            //_webBrowser.Dock = DockStyle.Fill;
            //Controls.Add(_webBrowser);
            ////////        Zamanlayıcı     ////////
           
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            cbKrediKas.Enabled = false;
            webBrowser1.Navigate("http://sokakceteleri.com/");
            webBrowser1.DocumentCompleted += WebBrowser1_DocumentCompleted;
        }

    /*    private void _webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
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
        */
        private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            var document = webBrowser1.Document;
            if (document == null) return;

            LoginToGame(document);
         // if (_isPageLoaded) { return; } 

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
                     GorevYap(document);
                    break;
                case GameOps.Harac:
                    HaracTopla(document);
                    break;
                case GameOps.Kasil:
                    Kasil(document);
                    break;
                case GameOps.BilekGuresi:
                    BilekGuresi(document);
                    break;
                case GameOps.KasaAc:
                    KasaAc(document);
                    break;
                default:
                    break;
            }
        }     

        private void SetProxy (string Proxy)
        {
            string key = "Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings";
            RegistryKey RegKey = Registry.CurrentUser.OpenSubKey(key, true);
            RegKey.SetValue("ProxyEnable", Proxy);
            RegKey.SetValue("ProxyEnable", 1);
        }

        private void StartTimer(int dakika, int saniye)
        {
            TimeSpan span = new TimeSpan(0,dakika,saniye+5);
            TimeSpan disablePeriodic = new TimeSpan(0, 0, 0, 0, -1);
            _timer = new System.Threading.Timer(timer_timerCallback, null, span,disablePeriodic);
        }

        public void timer_timerCallback(object state)
        {
            webBrowser1.Refresh();
            _game = GameOps.BilekGuresi;
            _timer.Dispose();   
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

                   
                    ////////////////////////Risk Hesapla Baya Zor Oldu
                    if (false)
                    {
                        if (!cbRiskKart.Checked)
                        {
                            _riskToplam = Convert.ToInt16(userPropertiesElement.FirstChild.FirstChild.Children[3].FirstChild.GetAttribute("title")
                              .Trim().Replace(" ", string.Empty).Substring(userPropertiesElement.FirstChild.FirstChild.Children[3].FirstChild.GetAttribute("title")
                              .Trim().Replace(" ", string.Empty).Length - 3, 3));
                        }
                        if (_risk < 10)
                        { _riskHesapla = 0; }
                        else if (_risk < 100)
                        { _riskHesapla = 1; }
                        else
                        { _riskHesapla = 2; }

                        string str = userPropertiesElement.FirstChild.FirstChild.Children[3].FirstChild.GetAttribute("title")
                              .Trim().Replace(" ", string.Empty);

                        string neee = userPropertiesElement.FirstChild.FirstChild.Children[3].FirstChild.GetAttribute("title")
                              .Trim().Replace(" ", string.Empty).Substring(28 + _riskHesapla, userPropertiesElement.FirstChild.FirstChild.Children[3].
                              FirstChild.GetAttribute("title").Trim().Replace(" ", string.Empty).Length - (71 + (_risk.ToString().Length) - _riskHesapla));

                        string nee = userPropertiesElement.FirstChild.FirstChild.Children[3].FirstChild.GetAttribute("title")
                              .Trim().Replace(" ", string.Empty).Substring(0, userPropertiesElement.FirstChild.FirstChild.Children[3].
                              FirstChild.GetAttribute("title").Trim().Replace(" ", string.Empty).Length - (43 + (_risk.ToString().Length) - _riskHesapla));
                        _riskToplam = Convert.ToInt16(nee.Substring(nee.Length - 3));
                    }
                    


                    _cantoplam = Convert.ToInt16(userPropertiesElement.FirstChild.FirstChild.Children[1].FirstChild.GetAttribute("title")
                          .Trim().Replace(" ", string.Empty).Substring(userPropertiesElement.FirstChild.FirstChild.Children[1].FirstChild.GetAttribute("title")
                          .Trim().Replace(" ", string.Empty).Length - 3, 3));

                    _enerjiToplam =Convert.ToInt16(userPropertiesElement.Children[0].Children[0].Children[2].Children[0].GetAttribute("title")
                        .Trim().Replace(" ", string.Empty).Substring(userPropertiesElement.Children[0].Children[0].Children[2]
                        .Children[0].GetAttribute("title").Trim().Replace(" ", string.Empty).Length - 3, 3));

                    _zehirToplam = Convert.ToInt16(userPropertiesElement.FirstChild.FirstChild.Children[4].FirstChild.GetAttribute("title")
                          .Trim().Replace(" ", string.Empty).Substring(userPropertiesElement.FirstChild.FirstChild.Children[4].FirstChild.GetAttribute("title")
                          .Trim().Replace(" ", string.Empty).Length - 3, 3));

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
                var bpItems = trainingInfosElement.GetElementsByTagName("span");
                foreach (HtmlElement e in bpItems)
                {
                    if (e.GetAttribute("className").Contains("battle_points"))
                    {
                        _battlePoints = int.Parse(e.InnerText);
                    }
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
                        lbSatınKart.Text = @"Satın Alabileceğiniz Kart Sayısı : " + (_baglanti / 100).ToString();
                    }
                    else
                    {
                        _baglanti = Convert.ToInt16(baglantii);
                        lbBaglanti.Text = @"Bağlantı : " + _baglanti.ToString();
                        lbSatınKart.Text = @"Satın Alabileceğiniz Kart Sayısı : " + (_baglanti / 100).ToString();
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
            else if (_enerji == _enerjiToplam)
            {
                _enerjiDurum = true;
            }
            if (!_enerjiDurum)
            {
                if (_enerjiKartKullan)
                {
                    var sagEnvanter = ElementHelper.FindRightInventoryElement(document);
                    if (sagEnvanter != null)
                    {
                        var enerji = Material.FindEnerjiElement(sagEnvanter);
                        if (enerji != null)
                        {
                            enerji.InvokeMember("click");
                            var kullan = ElementHelper.FindLeftInventoryElement(document);
                            kullan.FirstChild.FirstChild.FirstChild.InvokeMember("click");
                            var ic = Material.FindUseMaterialElement(document);
                            ic.FirstChild.Children[5].FirstChild.InvokeMember("click"); return;
                        }
                        else
                        {
                            cbEnerjiKart.Checked = false; elEnerji.InvokeMember("click"); return;
                        }

                    }
                    var envanter = MenuElement.RightMenuElement(document);
                    envanter.FirstChild.InvokeMember("click"); return;
                }
                var findDrink = EnerjiElement.FindDrinkElement(document);

                if (_enerji == _enerjiToplam)
                {
                    _enerjiDurum = true; webBrowser1.Refresh(); return;
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
            if (_zeka > 0)
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
                    ant.Children[1].Children[0].Children[2].Children[0].Children[0].Children[0].InvokeMember("click"); return;
                }
                else
                {
                    elZeka.InvokeMember("click"); return;
                }
            }
           else if (_guc > 0)
            {
                var enerjilow = EnerjiElement.LowEnerjiTrainingElement(document);
                if (enerjilow != null)
                {

                    elEnerji.InvokeMember("click"); _enerjiDurum = false; return;
                }
                var ant = ElementHelper.FindTrainingContentElement(document);
                if (ant == null)
                {
                    elGuc.InvokeMember("click"); return;
                }
                var gucTik = ElementHelper.GucTikElement(ant);
                if (gucTik != null)
                {
                    gucTik.InvokeMember("click"); return;
                }
                
                
                   
                
            }
            if (_zekaKartKullan)
            {
                var sagEnvanter = ElementHelper.FindRightInventoryElement(document);
                if (sagEnvanter != null)
                {
                    var zeka1 = Material.FindZeka1Element(sagEnvanter);
                    if (zeka1 != null)
                    {
                        zeka1.InvokeMember("click");
                        var solEnvanter = ElementHelper.FindLeftInventoryElement(document);
                        solEnvanter.FirstChild.FirstChild.FirstChild.InvokeMember("click");
                        var esyaKullan = Material.FindUseMaterialElement(document);
                        //  esyaKullan.FirstChild.Children[4].Children[3].SetAttribute("value", "5");
                        esyaKullan.FirstChild.Children[5].FirstChild.InvokeMember("click"); return;
                    }
                    var zeka10 = Material.FindZeka10Element(sagEnvanter);
                    if (zeka10 != null)
                    {
                        zeka10.InvokeMember("click");
                        var solEnvanter = ElementHelper.FindLeftInventoryElement(document);
                        solEnvanter.FirstChild.FirstChild.FirstChild.InvokeMember("click");
                        var esyaKullan = Material.FindUseMaterialElement(document);
                        esyaKullan.FirstChild.Children[5].FirstChild.InvokeMember("click"); return;
                    }
                    else
                    {
                        _zekaKartKullan = false; webBrowser1.Refresh(); cbZekaKart.Checked = false; return;
                    }
                }

                var sagMenu = MenuElement.RightMenuElement(document);
                sagMenu.FirstChild.InvokeMember("click"); return;
            }
            if (_gucKartKullan)
            {
                var sagEnvanter = ElementHelper.FindRightInventoryElement(document);
                if (sagEnvanter != null)
                {
                    var guc1 = Material.FindGuc1Element(sagEnvanter);
                    if (guc1 != null)
                    {
                        guc1.InvokeMember("click");
                        var solEnvanter = ElementHelper.FindLeftInventoryElement(document);
                        solEnvanter.FirstChild.FirstChild.FirstChild.InvokeMember("click");
                        var esyaKullan = Material.FindUseMaterialElement(document);
                        //  esyaKullan.FirstChild.Children[4].Children[3].SetAttribute("value", "5");
                        esyaKullan.FirstChild.Children[5].FirstChild.InvokeMember("click"); return;
                    }
                    var guc10 = Material.FindGuc10Element(sagEnvanter);
                    if (guc10 != null)
                    {
                        guc10.InvokeMember("click");
                        var solEnvanter = ElementHelper.FindLeftInventoryElement(document);
                        solEnvanter.FirstChild.FirstChild.FirstChild.InvokeMember("click");
                        var esyaKullan = Material.FindUseMaterialElement(document);
                        esyaKullan.FirstChild.Children[5].FirstChild.InvokeMember("click"); return;
                    }
                    else
                    {
                        _gucKartKullan = false; webBrowser1.Refresh(); cbGuckart.Checked = false; return;
                    }
                }

                var sagMenu = MenuElement.RightMenuElement(document);
                sagMenu.FirstChild.InvokeMember("click"); return;
            }
            if (_cazibe > 0)
            {
                var kizAra = EnerjiElement.FindKizElement(document);
                if (kizAra != null)
                {
                    var kizTikla = EnerjiElement.FindKizTiklaElement(kizAra, _seviye);
                    if (kizTikla != null)
                    {
                        kizTikla.InvokeMember("click");return;
                    }
                }
                var cazibeTikla = ElementHelper.FindRightTrainingElement(document);
                cazibeTikla.Children[2].InvokeMember("click");return;
            }
            else
            {_game = GameOps.Non; return;}
        }

        private void Savas(HtmlDocument document)
        {
            if (document == null) return;
            var prison = ElementHelper.FindPrisonElement(document);
            if (prison != null)
            {
                var thisPrison = ElementHelper.FindThisIsPrisonElement(document);
                if (thisPrison != null)
                {
                    if (_hapisKacKart && Convert.ToInt16(thisPrison.FirstChild.Children[1].Children[0].Children[2].Children[0].Children[0].
                    Children[0].Children[0].Children[1].InnerText) > 0)
                    {
                        thisPrison.FirstChild.Children[1].Children[0].Children[2].Children[0].Children[0].Children[0].InvokeMember("click"); return;
                    }
                    else if (_hapisKacBaglanti && _baglanti >= 78)
                    {
                        thisPrison.FirstChild.Children[1].Children[0].Children[2].Children[1].Children[0].Children[0].InvokeMember("click");
                        var escapeConnect = ElementHelper.FindEscapeConnectElement(webBrowser1.Document);
                        if (escapeConnect != null)
                        {
                            escapeConnect.Children[0].Children[2].Children[0].Children[0].Children[1].Children[0].Children[0].Children[1].
                                Children[0].Children[2].Children[0].Children[0].Children[0].InvokeMember("click"); return;
                        }
                    }
                    else
                    {
                        if (!thisPrison.FirstChild.Children[1].FirstChild.Children[3].FirstChild.FirstChild.
                            FirstChild.GetAttribute("className").Contains("pad_item jail_icons jail_riot_1 json"))
                        {
                            thisPrison.FirstChild.Children[1].FirstChild.Children[3].FirstChild.FirstChild.
                                FirstChild.InvokeMember("click"); return;
                        }
                    }
                }
                prison.InvokeMember("click"); return;
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
                    else
                    { cbPolisNoPara.Checked = false; }
                }
                  police.Children[4].Children[0].InvokeMember("click"); return;
            }
            var hospital = ElementHelper.FindHospitalElement(document);
            if (hospital != null)
            {
                if (hospital.FirstChild.Children[2].CanHaveChildren)
                {
                    if (0 < Convert.ToInt16(hospital.FirstChild.Children[2].FirstChild.Children[2].FirstChild.FirstChild.
                                        FirstChild.FirstChild.Children[1].InnerText) && _hastaneKartKullan)
                    {
                        hospital.FirstChild.Children[2].FirstChild.Children[2].FirstChild.FirstChild.FirstChild.InvokeMember("click"); return;
                    }
                    var paraYok = EnerjiElement.LowEnerjiTrainingElement(document);
                    if (paraYok != null && paraYok.Children[2].GetAttribute("className").Contains("getin b"))
                    {
                        _hastaneKartKullan = false; cbHastanePara.Checked = false;
                    }
                    if (_hastaneParaKullan)
                    {
                        hospital.FirstChild.Children[2].FirstChild.Children[1].FirstChild.FirstChild.FirstChild.InvokeMember("click"); return;
                    }
                }
                var sokak = MenuElement.LeftMenuElement(document);
                sokak.Children[1].FirstChild.InvokeMember("click");return;
            }
            if (_zehir + 20 >= _zehirToplam && _zehirKartKullan)
            {
                var sagEnvanter = ElementHelper.FindRightInventoryElement(document);
                if (sagEnvanter != null)
                {
                    
                    var zehir = Material.FindZehirElement(sagEnvanter);
                    if (zehir != null)
                    {
                        zehir.InvokeMember("click");
                        var kullan = ElementHelper.FindLeftInventoryElement(document);
                        kullan.FirstChild.FirstChild.FirstChild.InvokeMember("click");
                        var ic = Material.FindUseMaterialElement(document);
                        ic.FirstChild.Children[5].FirstChild.InvokeMember("click");return;
                    }
                    else
                    {
                        cbZehirKart.Checked = false;
                    }
                }
                var envanter = MenuElement.RightMenuElement(document);
                envanter.FirstChild.InvokeMember("click"); return;
            }
            if (_can < 6 && _canKartKullan)
            {
                var sagEnvanter = ElementHelper.FindRightInventoryElement(document);
                if (sagEnvanter != null)
                {
                    var can = Material.FindCanElement(sagEnvanter);
                    if (can != null)
                    {
                        can.InvokeMember("click");
                        var kullan = ElementHelper.FindLeftInventoryElement(document);
                        kullan.FirstChild.FirstChild.FirstChild.InvokeMember("click");
                        var ic = Material.FindUseMaterialElement(document);
                        ic.FirstChild.Children[5].FirstChild.InvokeMember("click"); return;
                    }
                    else
                    {
                        cbCanKart.Checked = false;
                    }

                }
                var envanter = MenuElement.RightMenuElement(document);
                envanter.FirstChild.InvokeMember("click");return;
            }
            if (_enerji < 60) { _enerjiDurum = false; }
            if (_enerji == _enerjiToplam)
             { _enerjiDurum = true; }
            if (!_enerjiDurum)
            {
                if (_enerjiKartKullan)
                {
                    var sagEnvanter = ElementHelper.FindRightInventoryElement(document);
                    if (sagEnvanter != null)
                    {
                        var enerji = Material.FindEnerjiElement(sagEnvanter);
                        if (enerji != null)
                        {
                            enerji.InvokeMember("click");
                            var kullan = ElementHelper.FindLeftInventoryElement(document);
                            kullan.FirstChild.FirstChild.FirstChild.InvokeMember("click");
                            var ic = Material.FindUseMaterialElement(document);
                            ic.FirstChild.Children[5].FirstChild.InvokeMember("click"); return;
                        }
                        else
                        {
                            cbEnerjiKart.Checked = false;
                        }
                    }
                    var envanter = MenuElement.RightMenuElement(document);
                    envanter.FirstChild.InvokeMember("click"); return;
                }
                var findDrink = EnerjiElement.FindDrinkElement(document);
                if (findDrink != null)
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
            else if (_battlePoints > 0 || savass)
            {
                var dovusYap = ElementHelper.FindFightCompletedElement(document);
                if (dovusYap != null)
                {
                    dovusYap.InvokeMember("click");return;
                }
                var dovusAra = ElementHelper.FindFightSearchElement(document);
                if (dovusAra != null)
                {
                    dovusAra.Children[1].Children[0].Children[0].Children[1].Children[0].InnerText = (_seviye - _minSeviye).ToString();
                    dovusAra.Children[1].Children[0].Children[1].Children[1].Children[0].InnerText = (_seviye + 200).ToString();
                    dovusAra.Children[1].Children[0].Children[2].Children[1].Children[0].InnerText = 
                        (_respectPoints - ((_respectPoints / 100) * 1)).ToString();
                    dovusAra.Children[3].Children[0].Children[0].InvokeMember("click");return;
                }
                var dovusMenu = MenuElement.TopMenuFightElement(document);
                if (dovusMenu != null)
                {
                    dovusMenu.InvokeMember("click");return;
                }
            }
            else
            {
                _game = GameOps.Non;return;
            }
            
            var sokak1 = MenuElement.LeftMenuElement(document);
            sokak1.Children[1].FirstChild.InvokeMember("click");return;
        }

        private void HaracTopla(HtmlDocument document)
        {
            if (document == null) return;
            if (_enerji < 10) { _enerjiDurum = false; }
            if (_enerji == _enerjiToplam)
            { _enerjiDurum = true; }
            if (!_enerjiDurum)
            {
                if (_enerjiKartKullan)
                {
                    var sagEnvanter = ElementHelper.FindRightInventoryElement(document);
                    if (sagEnvanter != null)
                    {
                        var enerji = Material.FindEnerjiElement(sagEnvanter);
                        if (enerji != null)
                        {
                            enerji.InvokeMember("click");
                            var kullan = ElementHelper.FindLeftInventoryElement(document);
                            kullan.FirstChild.FirstChild.FirstChild.InvokeMember("click");
                            var ic = Material.FindUseMaterialElement(document);
                            ic.FirstChild.Children[5].FirstChild.InvokeMember("click"); return;
                        }
                        else
                        {
                            cbEnerjiKart.Checked = false;
                        }
                    }
                    var envanter = MenuElement.RightMenuElement(document);
                    envanter.FirstChild.InvokeMember("click"); return;
                }
                var findDrink = EnerjiElement.FindDrinkElement(document);
                if (findDrink != null)
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
            var harac = ElementHelper.FindTributeElement(document);
                if (harac != null)
                {
                if (750 > Convert.ToInt32(harac.Children[0].Children[1].Children[6].Children[0].Children[0].InnerText))
                    {MessageBox.Show("Haraçlar Toplandı", "Haraç", MessageBoxButtons.OK, MessageBoxIcon.Information, 
                            MessageBoxDefaultButton.Button3, MessageBoxOptions.RtlReading);_game = GameOps.Non; return;}
                    harac.Children[0].Children[1].Children[7].Children[0].Children[1].InvokeMember("click");return;
                }
                var sagMenu = MenuElement.RightMenuElement(document);
                sagMenu.Children[2].InvokeMember("click");return;
        }

        private void GorevYap(HtmlDocument document)
        {
            if (document == null) return;
            var prison = ElementHelper.FindPrisonElement(document);
            if (prison != null)
            {
                var thisPrison = ElementHelper.FindThisIsPrisonElement(document);
                if (thisPrison != null)
                {
                    if (_hapisKacKart && Convert.ToInt16(thisPrison.FirstChild.Children[2].Children[0].Children[2].Children[0].Children[0].
                    Children[0].Children[0].Children[1].InnerText) > 0)
                    {
                        thisPrison.FirstChild.Children[2].Children[0].Children[2].Children[0].Children[0].Children[0].InvokeMember("click"); return;
                    }
                    else if (_hapisKacBaglanti && _baglanti >= 78)
                    {
                        thisPrison.FirstChild.Children[2].Children[0].Children[2].Children[1].Children[0].Children[0].InvokeMember("click");
                        var escapeConnect = ElementHelper.FindEscapeConnectElement(webBrowser1.Document);
                        if (escapeConnect != null)
                        {
                            escapeConnect.Children[0].Children[2].Children[0].Children[0].Children[1].Children[0].Children[0].Children[1].
                                Children[0].Children[2].Children[0].Children[0].Children[0].InvokeMember("click"); return;
                        }
                    }
                    else
                    {
                        if (!thisPrison.FirstChild.Children[1].FirstChild.Children[3].FirstChild.FirstChild.
                            FirstChild.GetAttribute("className").Contains("pad_item jail_icons jail_riot_1 json"))
                        {
                            thisPrison.FirstChild.Children[1].FirstChild.Children[3].FirstChild.FirstChild.
                                FirstChild.InvokeMember("click"); return;
                        }
                    }
                }
                prison.InvokeMember("click"); return;
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
                    else
                    { cbPolisNoPara.Checked = false; }
                }
                police.Children[4].Children[0].InvokeMember("click"); return;
            }
            var hospital = ElementHelper.FindHospitalElement(document);
            if (hospital != null)
            {
                if (hospital.FirstChild.Children[2].CanHaveChildren)
                {
                    if (0 < Convert.ToInt16(hospital.FirstChild.Children[2].FirstChild.Children[2].FirstChild.FirstChild.
                                        FirstChild.FirstChild.Children[1].InnerText) && _hastaneKartKullan)
                    {
                        hospital.FirstChild.Children[2].FirstChild.Children[2].FirstChild.FirstChild.FirstChild.InvokeMember("click"); return;
                    }
                    var paraYok = EnerjiElement.LowEnerjiTrainingElement(document);
                    if (paraYok != null && paraYok.Children[2].GetAttribute("className").Contains("getin b"))
                    {
                        _hastaneKartKullan = false; cbHastanePara.Checked = false;
                    }
                    if (_hastaneParaKullan)
                    {
                        hospital.FirstChild.Children[2].FirstChild.Children[1].FirstChild.FirstChild.FirstChild.InvokeMember("click"); return;
                    }
                }
                var sokak = MenuElement.LeftMenuElement(document);
                sokak.Children[1].FirstChild.InvokeMember("click"); return;
            }
            if (_zehir + 20 >= _zehirToplam && _zehirKartKullan)
            {
                var sagEnvanter = ElementHelper.FindRightInventoryElement(document);
                if (sagEnvanter != null)
                {

                    var zehir = Material.FindZehirElement(sagEnvanter);
                    if (zehir != null)
                    {
                        zehir.InvokeMember("click");
                        var kullan = ElementHelper.FindLeftInventoryElement(document);
                        kullan.FirstChild.FirstChild.FirstChild.InvokeMember("click");
                        var ic = Material.FindUseMaterialElement(document);
                        ic.FirstChild.Children[5].FirstChild.InvokeMember("click"); return;
                    }
                    else
                    {
                        cbZehirKart.Checked = false;
                    }
                }
                var envanter = MenuElement.RightMenuElement(document);
                envanter.FirstChild.InvokeMember("click"); return;
            }
            if (_can < 6 && _canKartKullan)
            {
                var sagEnvanter = ElementHelper.FindRightInventoryElement(document);
                if (sagEnvanter != null)
                {
                    var can = Material.FindCanElement(sagEnvanter);
                    if (can != null)
                    {
                        can.InvokeMember("click");
                        var kullan = ElementHelper.FindLeftInventoryElement(document);
                        kullan.FirstChild.FirstChild.FirstChild.InvokeMember("click");
                        var ic = Material.FindUseMaterialElement(document);
                        ic.FirstChild.Children[5].FirstChild.InvokeMember("click"); return;
                    }
                    else
                    {
                        cbCanKart.Checked = false;
                    }

                }
                var envanter = MenuElement.RightMenuElement(document);
                envanter.FirstChild.InvokeMember("click"); return;
            }
            if (_enerji < 10) { _enerjiDurum = false; }
            if (_enerji == _enerjiToplam)
            { _enerjiDurum = true; }
            if (!_enerjiDurum)
            {
                if (_enerjiKartKullan)
                {
                    var sagEnvanter = ElementHelper.FindRightInventoryElement(document);
                    if (sagEnvanter != null)
                    {
                        var enerji = Material.FindEnerjiElement(sagEnvanter);
                        if (enerji != null)
                        {
                            enerji.InvokeMember("click");
                            var kullan = ElementHelper.FindLeftInventoryElement(document);
                            kullan.FirstChild.FirstChild.FirstChild.InvokeMember("click");
                            var ic = Material.FindUseMaterialElement(document);
                            ic.FirstChild.Children[5].FirstChild.InvokeMember("click"); return;
                        }
                        else
                        {
                            cbEnerjiKart.Checked = false;
                        }
                    }
                    var envanter = MenuElement.RightMenuElement(document);
                    envanter.FirstChild.InvokeMember("click"); return;
                }
                var findDrink = EnerjiElement.FindDrinkElement(document);
                if (findDrink != null)
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
            ///////////////////////////////////////////////////////////////////////////
            var gorevSaldir = ElementHelper.FindQuestFightElement(document);
            if (gorevSaldir != null)
            {
                gorevSaldir.InvokeMember("click");
                var dov = ElementHelper.Dov(document);
                if (dov != null)
                {
                    dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                }
            }
            var gorevAra = ElementHelper.FindQuestSearchElement(document);
            if (gorevAra != null)
            {
                gorevAra.InvokeMember("click");return;
            }
            var gorevHazir = ElementHelper.FindQuestReadyElement(document);
            if (gorevHazir != null)
            {
                var sokak = MenuElement.LeftMenuElement(document);
                sokak.Children[1].FirstChild.InvokeMember("click"); return;
            }
            var gorevAl = ElementHelper.FindQuestElement(document);
            if (gorevAl != null)
            {
                gorevAl.InvokeMember("click"); return;
            }
            var sagMenu = MenuElement.RightMenuElement(document);
                sagMenu.Children[6].InvokeMember("click");return;
        }

        private void Kasil(HtmlDocument document)
        {
            if (document == null) return;
            var prison = ElementHelper.FindPrisonElement(document);
            if (prison != null)
            {
                var thisPrison = ElementHelper.FindThisIsPrisonElement(document);
                if (thisPrison != null)
                {
                    if (_hapisKacKart && Convert.ToInt16(thisPrison.FirstChild.Children[2].Children[0].Children[2].Children[0].Children[0].
                    Children[0].Children[0].Children[1].InnerText) > 0)
                    {
                        thisPrison.FirstChild.Children[2].Children[0].Children[2].Children[0].Children[0].Children[0].InvokeMember("click"); return;
                    }
                    else if (_hapisKacBaglanti && _baglanti >= 78)
                    {
                        thisPrison.FirstChild.Children[2].Children[0].Children[2].Children[1].Children[0].Children[0].InvokeMember("click");
                        var escapeConnect = ElementHelper.FindEscapeConnectElement(webBrowser1.Document);
                        if (escapeConnect != null)
                        {
                            escapeConnect.Children[0].Children[2].Children[0].Children[0].Children[1].Children[0].Children[0].Children[1].
                                Children[0].Children[2].Children[0].Children[0].Children[0].InvokeMember("click"); return;
                        }
                    }
                    else
                    {
                        if (thisPrison.FirstChild.Children[1].FirstChild.Children[3].FirstChild.FirstChild.
                            FirstChild.GetAttribute("className").Contains("pad_item jail_icons jail_riot_0 json"))
                        {
                            thisPrison.FirstChild.Children[1].FirstChild.Children[3].FirstChild.FirstChild.
                                FirstChild.InvokeMember("click"); return;
                        }
                    }
                }
                prison.InvokeMember("click"); return;
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
                    else
                    { cbPolisNoPara.Checked = false; }
                }
                police.Children[4].Children[0].InvokeMember("click"); return;
            }
            var hospital = ElementHelper.FindHospitalElement(document);
            if (hospital != null)
            {
                if (hospital.FirstChild.Children[2].CanHaveChildren)
                {
                    if (0 < Convert.ToInt16(hospital.FirstChild.Children[2].FirstChild.Children[2].FirstChild.FirstChild.
                                        FirstChild.FirstChild.Children[1].InnerText) && _hastaneKartKullan)
                    {
                        hospital.FirstChild.Children[2].FirstChild.Children[2].FirstChild.FirstChild.FirstChild.InvokeMember("click"); return;
                    }
                    var paraYok = EnerjiElement.LowEnerjiTrainingElement(document);
                    if (paraYok != null && paraYok.Children[2].GetAttribute("className").Contains("getin b"))
                    {
                        _hastaneKartKullan = false; cbHastanePara.Checked = false;
                    }
                    if (_hastaneParaKullan)
                    {
                        hospital.FirstChild.Children[2].FirstChild.Children[1].FirstChild.FirstChild.FirstChild.InvokeMember("click"); return;
                    }
                }
                var sokak = MenuElement.LeftMenuElement(document);
                sokak.Children[1].FirstChild.InvokeMember("click"); return;
            }
            if (_zehir + 20 >= _zehirToplam && _zehirKartKullan)
            {
                var sagEnvanter = ElementHelper.FindRightInventoryElement(document);
                if (sagEnvanter != null)
                {

                    var zehir = Material.FindZehirElement(sagEnvanter);
                    if (zehir != null)
                    {
                        zehir.InvokeMember("click");
                        var kullan = ElementHelper.FindLeftInventoryElement(document);
                        kullan.FirstChild.FirstChild.FirstChild.InvokeMember("click");
                        var ic = Material.FindUseMaterialElement(document);
                        ic.FirstChild.Children[5].FirstChild.InvokeMember("click"); return;
                    }
                    else
                    {
                        cbZehirKart.Checked = false;
                    }
                }
                var envanter = MenuElement.RightMenuElement(document);
                envanter.FirstChild.InvokeMember("click"); return;
            }
            if (_can < 6 && _canKartKullan)
            {
                var sagEnvanter = ElementHelper.FindRightInventoryElement(document);
                if (sagEnvanter != null)
                {
                    var can = Material.FindCanElement(sagEnvanter);
                    if (can != null)
                    {
                        can.InvokeMember("click");
                        var kullan = ElementHelper.FindLeftInventoryElement(document);
                        kullan.FirstChild.FirstChild.FirstChild.InvokeMember("click");
                        var ic = Material.FindUseMaterialElement(document);
                        ic.FirstChild.Children[5].FirstChild.InvokeMember("click"); return;
                    }
                    else
                    {
                        cbCanKart.Checked = false;
                    }

                }
                var envanter = MenuElement.RightMenuElement(document);
                envanter.FirstChild.InvokeMember("click"); return;
            }
            if (_enerji < 50) { _enerjiDurum = false; }
            if (_enerji == _enerjiToplam)
            { _enerjiDurum = true; }
            if (!_enerjiDurum)
            {
                if (_enerjiKartKullan)
                {
                    var sagEnvanter = ElementHelper.FindRightInventoryElement(document);
                    if (sagEnvanter != null)
                    {
                        var enerji = Material.FindEnerjiElement(sagEnvanter);
                        if (enerji != null)
                        {
                            enerji.InvokeMember("click");
                            var kullan = ElementHelper.FindLeftInventoryElement(document);
                            kullan.FirstChild.FirstChild.FirstChild.InvokeMember("click");
                            var ic = Material.FindUseMaterialElement(document);
                            ic.FirstChild.Children[5].FirstChild.InvokeMember("click"); return;
                        }
                        else
                        {
                            cbEnerjiKart.Checked = false;
                        }
                    }
                    var envanter = MenuElement.RightMenuElement(document);
                    envanter.FirstChild.InvokeMember("click"); return;
                }
                var findDrink = EnerjiElement.FindDrinkElement(document);
                if (findDrink != null)
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
            var basla = document.GetElementById("map");
            if (basla != null)
            {
                var polis = Saldir.Polis(basla);
                if (polis != null)
                {
                    polis.InvokeMember("click");
                    var dov = Saldir.Saldirr(webBrowser1.Document);
                    if (dov != null)
                    {
                        dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                    }
                }
                if (_seviye > 2)
                {
                    var atm = Saldir.Atm(basla);
                    if (atm != null)
                    {
                        atm.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click");return;
                        }
                    }
                    var kabadayi = Saldir.Kabadayi(basla);
                    if (kabadayi != null)
                    {
                        kabadayi.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var isAdami = Saldir.IsAdami(basla);
                    if (isAdami != null)
                    {
                        isAdami.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var araba1 = Saldir.Araba1(basla);
                    if (araba1 != null)
                    {
                        araba1.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var araba2 = Saldir.Araba2(basla);
                    if (araba2 != null)
                    {
                        araba2.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var dansoz = Saldir.Dansoz(basla);
                    if (dansoz != null)
                    {
                        dansoz.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var yonetici = Saldir.Yonetici(basla);
                    if (yonetici != null)
                    {
                        yonetici.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var isKadini = Saldir.IsKadini(basla);
                    if (isKadini != null)
                    {
                        isKadini.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var satici = Saldir.SigaraSaticisi(basla);
                    if (satici != null)
                    {
                        satici.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var holigan = Saldir.Holigan(basla);
                    if (holigan != null)
                    {
                        holigan.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var telefon = Saldir.Telefon(basla);
                    if (telefon != null)
                    {
                        telefon.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var upi = Saldir.Upi(basla);
                    if (upi != null)
                    {
                        upi.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var taksi = Saldir.Taksi(basla);
                    if (taksi != null)
                    {
                        taksi.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                }
                else
                {
                    var ogretmen = Saldir.Ogretmen(basla);
                    if (ogretmen != null)
                    {
                        ogretmen.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var posta = Saldir.Posta(basla);
                    if (posta != null)
                    {
                        posta.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var fanatik = Saldir.fanatik(basla);
                    if (fanatik != null)
                    {
                        fanatik.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var tabela = Saldir.Tabela(basla);
                    if (tabela != null)
                    {
                        tabela.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var hamal = Saldir.Hamal(basla);
                    if (hamal != null)
                    {
                        hamal.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var anne = Saldir.Anne(basla);
                    if (anne != null)
                    {
                        anne.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var kopek = Saldir.KopekliGenc(basla);
                    if (kopek != null)
                    {
                        kopek.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var bisiklet = Saldir.BisikletliGenc(basla);
                    if (bisiklet != null)
                    {
                        bisiklet.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var kopekliKiz = Saldir.KopekliKiz(basla);
                    if (kopekliKiz != null)
                    {
                        kopekliKiz.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var haylaz = Saldir.Haylaz(basla);
                    if (haylaz != null)
                    {
                        haylaz.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var dokuntu = Saldir.Dokuntu(basla);
                    if (dokuntu != null)
                    {
                        dokuntu.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var musluk = Saldir.ItfaiyeMuslugu(basla);
                    if (musluk != null)
                    {
                        musluk.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var kaykayci = Saldir.Kaykayci(basla);
                    if (kaykayci != null)
                    {
                        kaykayci.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var gencKiz = Saldir.GencKiz(basla);
                    if (gencKiz != null)
                    {
                        gencKiz.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var varil = Saldir.Variller(basla);
                    if (varil != null)
                    {
                        varil.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var barikat = Saldir.Barikat(basla);
                    if (barikat != null)
                    {
                        barikat.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var logar = Saldir.Logar(basla);
                    if (logar != null)
                    {
                        logar.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var kopekk = Saldir.Kopek(basla);
                    if (kopekk != null)
                    {
                        kopekk.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var sarhos = Saldir.Sarhos(basla);
                    if (sarhos != null)
                    {
                        sarhos.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var kovalar = Saldir.Kovalar(basla);
                    if (kovalar != null)
                    {
                        kovalar.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var postaci = Saldir.Postaci(basla);
                    if (postaci != null)
                    {
                        postaci.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var asiklar = Saldir.Asiklar(basla);
                    if (asiklar != null)
                    {
                        asiklar.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var kucukKiz = Saldir.KucukKiz(basla);
                    if (kucukKiz != null)
                    {
                        kucukKiz.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                }
            }

            var sokak1 = MenuElement.LeftMenuElement(document);
            sokak1.Children[1].FirstChild.InvokeMember("click"); return;
        }

        private void BilekGuresi(HtmlDocument document)
        {
            if (document == null) return;
            var prison = ElementHelper.FindPrisonElement(document);
            if (prison != null)
            {
                var thisPrison = ElementHelper.FindThisIsPrisonElement(document);
                if (thisPrison != null)
                {
                        if (thisPrison.FirstChild.Children[1].FirstChild.Children[4].FirstChild.FirstChild.
                            FirstChild.GetAttribute("className").Contains("pad_item jail_icons jail_wrestling_0 json"))
                        {
                        thisPrison.FirstChild.Children[1].FirstChild.Children[4].FirstChild.FirstChild.
                            FirstChild.InvokeMember("click");return;
                        }
                    else
                    {
                        DateTime hapisSure = DateTime.Parse(document.GetElementById("msgbox").FirstChild.Children[1].FirstChild.FirstChild.InnerText);
                        DateTime guresSure =  Convert.ToDateTime(thisPrison.FirstChild.Children[1].FirstChild.Children[4].Children[1].Children[1].FirstChild.InnerText);
                        if (guresSure < hapisSure)
                        {
                            StartTimer(int.Parse(guresSure.Minute.ToString()), int.Parse(guresSure.Second.ToString()));
                            _game = GameOps.Non;
                            return;
                        }
                        else
                        {
                            StartTimer(int.Parse(hapisSure.Minute.ToString()), int.Parse(hapisSure.Second.ToString()));  
                            _game = GameOps.Non;
                            return;
                        }
                    }
                }
                prison.InvokeMember("click"); return;
            }
            var police = ElementHelper.FindPoliceElement(document);
            if (police != null)
            {
                police.Children[4].Children[0].InvokeMember("click"); return;
            }
            var hospital = ElementHelper.FindHospitalElement(document);
            if (hospital != null)
            {
                if (hospital.FirstChild.Children[2].CanHaveChildren)
                {
                    if (0 < Convert.ToInt16(hospital.FirstChild.Children[2].FirstChild.Children[2].FirstChild.FirstChild.
                                        FirstChild.FirstChild.Children[1].InnerText) && _hastaneKartKullan)
                    {
                        hospital.FirstChild.Children[2].FirstChild.Children[2].FirstChild.FirstChild.FirstChild.InvokeMember("click"); return;
                    }
                    var paraYok = EnerjiElement.LowEnerjiTrainingElement(document);
                    if (paraYok != null && paraYok.Children[2].GetAttribute("className").Contains("getin b"))
                    {
                        _hastaneKartKullan = false; cbHastanePara.Checked = false;
                    }
                    if (_hastaneParaKullan)
                    {
                        hospital.FirstChild.Children[2].FirstChild.Children[1].FirstChild.FirstChild.FirstChild.InvokeMember("click"); return;
                    }
                }
                var sokak = MenuElement.LeftMenuElement(document);
                sokak.Children[1].FirstChild.InvokeMember("click"); return;
            }
            if (_enerji < 50) { _enerjiDurum = false; }
            if (_enerji == _enerjiToplam)
            { _enerjiDurum = true; }
            if (!_enerjiDurum)
            {
                var findDrink = EnerjiElement.FindDrinkElement(document);
                if (findDrink != null)
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
            var basla = document.GetElementById("map");
            if (basla != null)
            {
                if (_seviye > 2)
                {
                    var atm = Saldir.Atm(basla);
                    if (atm != null)
                    {
                        atm.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var kabadayi = Saldir.Kabadayi(basla);
                    if (kabadayi != null)
                    {
                        kabadayi.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var isAdami = Saldir.IsAdami(basla);
                    if (isAdami != null)
                    {
                        isAdami.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var araba1 = Saldir.Araba1(basla);
                    if (araba1 != null)
                    {
                        araba1.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var araba2 = Saldir.Araba2(basla);
                    if (araba2 != null)
                    {
                        araba2.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var dansoz = Saldir.Dansoz(basla);
                    if (dansoz != null)
                    {
                        dansoz.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var yonetici = Saldir.Yonetici(basla);
                    if (yonetici != null)
                    {
                        yonetici.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var isKadini = Saldir.IsKadini(basla);
                    if (isKadini != null)
                    {
                        isKadini.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var satici = Saldir.SigaraSaticisi(basla);
                    if (satici != null)
                    {
                        satici.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var holigan = Saldir.Holigan(basla);
                    if (holigan != null)
                    {
                        holigan.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var telefon = Saldir.Telefon(basla);
                    if (telefon != null)
                    {
                        telefon.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var upi = Saldir.Upi(basla);
                    if (upi != null)
                    {
                        upi.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var taksi = Saldir.Taksi(basla);
                    if (taksi != null)
                    {
                        taksi.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                }
                else
                {
                    var ogretmen = Saldir.Ogretmen(basla);
                    if (ogretmen != null)
                    {
                        ogretmen.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var posta = Saldir.Posta(basla);
                    if (posta != null)
                    {
                        posta.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var fanatik = Saldir.fanatik(basla);
                    if (fanatik != null)
                    {
                        fanatik.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var tabela = Saldir.Tabela(basla);
                    if (tabela != null)
                    {
                        tabela.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var hamal = Saldir.Hamal(basla);
                    if (hamal != null)
                    {
                        hamal.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var anne = Saldir.Anne(basla);
                    if (anne != null)
                    {
                        anne.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var kopek = Saldir.KopekliGenc(basla);
                    if (kopek != null)
                    {
                        kopek.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var bisiklet = Saldir.BisikletliGenc(basla);
                    if (bisiklet != null)
                    {
                        bisiklet.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var kopekliKiz = Saldir.KopekliKiz(basla);
                    if (kopekliKiz != null)
                    {
                        kopekliKiz.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var haylaz = Saldir.Haylaz(basla);
                    if (haylaz != null)
                    {
                        haylaz.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var dokuntu = Saldir.Dokuntu(basla);
                    if (dokuntu != null)
                    {
                        dokuntu.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var musluk = Saldir.ItfaiyeMuslugu(basla);
                    if (musluk != null)
                    {
                        musluk.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var kaykayci = Saldir.Kaykayci(basla);
                    if (kaykayci != null)
                    {
                        kaykayci.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var gencKiz = Saldir.GencKiz(basla);
                    if (gencKiz != null)
                    {
                        gencKiz.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var varil = Saldir.Variller(basla);
                    if (varil != null)
                    {
                        varil.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var barikat = Saldir.Barikat(basla);
                    if (barikat != null)
                    {
                        barikat.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var logar = Saldir.Logar(basla);
                    if (logar != null)
                    {
                        logar.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var kopekk = Saldir.Kopek(basla);
                    if (kopekk != null)
                    {
                        kopekk.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var sarhos = Saldir.Sarhos(basla);
                    if (sarhos != null)
                    {
                        sarhos.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var kovalar = Saldir.Kovalar(basla);
                    if (kovalar != null)
                    {
                        kovalar.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var postaci = Saldir.Postaci(basla);
                    if (postaci != null)
                    {
                        postaci.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var asiklar = Saldir.Asiklar(basla);
                    if (asiklar != null)
                    {
                        asiklar.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                    var kucukKiz = Saldir.KucukKiz(basla);
                    if (kucukKiz != null)
                    {
                        kucukKiz.InvokeMember("click");
                        var dov = Saldir.Saldirr(webBrowser1.Document);
                        if (dov != null)
                        {
                            dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click"); return;
                        }
                    }
                }
            }

            var sokak1 = MenuElement.LeftMenuElement(document);
            sokak1.Children[1].FirstChild.InvokeMember("click"); return;
        }

        private void KasaAc(HtmlDocument document)
        {
            var kasaAcma = ElementHelper.FindNoSafeElement(webBrowser1.Document);
            if (kasaAcma != null)
            {
                _game = GameOps.Non;return;
            }
            var kasaAc = ElementHelper.FindOpenSafeElement(webBrowser1.Document);
           
            if (kasaAc != null)
            {
                kasaAc.InvokeMember("click"); 
            }
            var kasaBul = ElementHelper.FindSafeElement(webBrowser1.Document);
            if (kasaBul != null)
            {
                kasaBul.InvokeMember("click"); return;
            }
            
            var ustMenu = MenuElement.TopMenuBankElement(webBrowser1.Document);
            if (ustMenu != null)
            {
                ustMenu.InvokeMember("click");return;
            }

            var banka = MenuElement.LeftMenuElement(webBrowser1.Document);
            banka.Children[13].FirstChild.InvokeMember("click");return;
        }

        private IScheduler Baslat()
        {
            ISchedulerFactory schedFact = new StdSchedulerFactory();
            IScheduler sched = schedFact.GetScheduler();
            if (!sched.IsStarted)
                sched.Start();
            return sched;
        }
        private void GoreviTetikle(DateTime baslamaZamani)
        {
            IScheduler sched = Baslat();
            IJobDetail gorev = JobBuilder.Create<JobTest1>().WithIdentity("Gorev").Build();
            ISimpleTrigger trigger = (ISimpleTrigger)TriggerBuilder.Create().WithIdentity("Gorev").StartAt(baslamaZamani).Build();
            sched.ScheduleJob(gorev, trigger);
        }


     /*   private void Sat(HtmlDocument document)
        {
            var Satislar = ElementHelper.FindGangCrimeElement(document);
            if (Satislar != null)
            {
                if (Satislar.Children[1].CanHaveChildren)
                {
                    Satislar.Children[1].InvokeMember("click"); return;
                }
                else
                {
                    if (Satislar.FirstChild.FirstChild.FirstChild.FirstChild.Children[1].FirstChild.Children[4].FirstChild.CanHaveChildren)
                    {
                        Satislar.FirstChild.FirstChild.FirstChild.FirstChild.Children[1].FirstChild.Children[4].FirstChild.
                            Children[1].FirstChild.FirstChild.FirstChild.FirstChild.InvokeMember("click");return;
                    }
                    else
                    {
                        var itemAnaliz = EnerjiElement.FindDrinkElement(document);
                        if (itemAnaliz != null)
                        {
                            var itemlar = itemAnaliz.GetElementsByTagName("img");
                            if (itemlar != null)
                            {

                            }
                        }
                    }
                }
                
            }
            var karaborsa = MenuElement.LeftMenuElement(document);
            karaborsa.Children[9].FirstChild.InvokeMember("click"); return;
        }*/
    }
}
