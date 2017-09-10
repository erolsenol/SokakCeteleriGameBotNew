﻿using System;
using System.Windows.Forms;
using System.Threading;
// ReSharper disable PossibleNullReferenceException

namespace SokakCeteleriGameBot
{
    public partial class MainForm : Form
    {
        //  readonly WebBrowser _webBrowser;
        bool _isPageLoaded, _isLoggedIn, _enerjiDurum, _hapisKacKart = true, _hapisKacBaglanti = true, _rusvetNoPara = true,
            _gucKartKullan, _zekaKartKullan, _hastaneKartKullan = true, _hastaneParaKullan = true, _zehirKartKullan = true,
            _canKartKullan = true, _aldindi;

        private GameOps _game = GameOps.Non;
        private Int64 _atak, _baglanti, _respectPoints;
        private int _can, _enerji, _enerjiToplam, _zehirToplam, _cantoplam, _risk, _zehir, _seviye, _para, _minSeviye, _taneZekaAl,
            _taneGucAl;
        private int _zeka, _guc, _cazibe;
        private int _battlePoints;
        
        private HtmlElement elEnerji, elGuc, elZeka;

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
            var solMenu = MenuElement.LeftMenuElement(webBrowser1.Document);
            solMenu.Children[1].Children[0].InvokeMember("click");
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
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
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
          //if (_isPageLoaded) { return; } 

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
                     GorevYap(webBrowser1.Document);
                    break;
                case GameOps.Harac:
                    HaracTopla(webBrowser1.Document);
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
            if (!_enerjiDurum)
            {
                var findDrink = EnerjiElement.FindDrinkElement(document);

                if (_enerji==_enerjiToplam)
                {
                    _enerjiDurum = true;webBrowser1.Refresh(); return;
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
            else if (_zekaKartKullan)
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
                        _zekaKartKullan = false; webBrowser1.Refresh(); cbZekaKart.Visible = false; return;
                    }
                }
               
                var sagMenu = MenuElement.RightMenuElement(document);
                sagMenu.FirstChild.InvokeMember("click"); return;
            }
            else if (_gucKartKullan)
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
                        _gucKartKullan = false; webBrowser1.Refresh(); cbGuckart.Visible = false; return;
                    }
                }
               
                var sagMenu = MenuElement.RightMenuElement(document);
                sagMenu.FirstChild.InvokeMember("click"); return;
            }
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
                    var hapistemiyim = ElementHelper.FindPrisonWhoElement(document);
                    if (hapistemiyim.FirstChild.Children[1].Children[1].CanHaveChildren)
                    {
                        prison.Children[0].Children[3].Children[0].Children[0].Children[0].InvokeMember("click"); return;
                    }
                    else
                    {
                        var sokak = MenuElement.LeftMenuElement(document);
                        sokak.Children[1].FirstChild.InvokeMember("click");return;
                    }
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
                    dovusYap.InvokeMember("click");return;
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
            var sokak1 = MenuElement.LeftMenuElement(document);
            sokak1.Children[1].FirstChild.InvokeMember("click");return;
        }

        private void HaracTopla(HtmlDocument document)
        {
            if (document == null) return;
            if (_enerji < 10) { _enerjiDurum = false; }
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
                    var hapistemiyim = ElementHelper.FindPrisonWhoElement(document);
                    if (hapistemiyim.FirstChild.Children[1].Children[1].CanHaveChildren)
                    {
                        prison.Children[0].Children[3].Children[0].Children[0].Children[0].InvokeMember("click"); return;
                    }
                    else
                    {
                        var sokak = MenuElement.LeftMenuElement(document);
                        sokak.Children[1].FirstChild.InvokeMember("click"); return;
                    }
                }
                var escapeConnect = ElementHelper.FindEscapeConnectElement(webBrowser1.Document);
                if (escapeConnect != null)
                {
                    escapeConnect.Children[0].Children[2].Children[0].Children[0].Children[1].Children[0].Children[0].Children[1].
                        Children[0].Children[2].Children[0].Children[0].Children[0].InvokeMember("click"); return;
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
            ///////////////////////////////////////////////////////////////////////////
            var gorevSaldir = ElementHelper.FindQuestFightElement(document);
            if (gorevSaldir != null)
            {
                gorevSaldir.InvokeMember("click");
                var dov = ElementHelper.Dov(document);
                if (dov != null)
                {
                    dov.FirstChild.Children[1].FirstChild.FirstChild.InvokeMember("click");
                }
                return;
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
                sokak.Children[1].FirstChild.InvokeMember("click");return;
            }
            //var gorevButton = ElementHelper.FindQuestButtonElement(document);
            //if (gorevButton != null)
            //{
            //    gorevButton.InvokeMember("click");return;
            //}
            var gorevAl = ElementHelper.FindQuestElement(document);
            if (gorevAl != null)
            {
                gorevAl.InvokeMember("click");return;
            }
            var sagMenu = MenuElement.RightMenuElement(document);
            if (sagMenu != null)
            {
                sagMenu.Children[6].InvokeMember("click");return;
            }
        }

    }
}
