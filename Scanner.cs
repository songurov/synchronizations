using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    using System.Windows.Forms;
    using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.Threading;
using MySql.Data.MySqlClient;

namespace SynchronizationEbayAccaunt
{
    public partial class Scanner : Form
    {
        string connectionString = "SERVER=w00f8083.kasserver.com;DATABASE=d014c1e3;UID=d014c1e3;PASSWORD=H4q5LMGrbtr8oEGd;DefaultCommandTimeout=99999;ConnectionTimeout=32400";
        WebBrowser webBrowser1 = new WebBrowser();
        string siteSell = string.Empty;
        string siteBendeet = string.Empty;

            
        class SiteSpare
        {
            public string SiteSpares= string.Empty;
            public string NumberSpare = string.Empty;
            public string Data = string.Empty;
            public string Status = string.Empty;
            public string Account = string.Empty;
        }

        class RemovalOfGoods
        {
            public string number = string.Empty;
            public string siteSell = string.Empty;
            public string siteBendeet = string.Empty;
        }

        List<string> numberYellowKFZ = new List<string>();
        List<string> numberYellowATK = new List<string>();

        List<RemovalOfGoods> removalofgoods = new List<RemovalOfGoods>();
        bool muz = false;
        
        System.Media.SoundPlayer spmy = new System.Media.SoundPlayer(Properties.Resources.sing);

        string acKfzunion   = string.Empty;
        string passKfzunion = string.Empty;

        string acAtkgmbh   = string.Empty;
        string passAtkgmbh = string.Empty;

        string acAftebuy = string.Empty;
        string passAfterbuy = string.Empty;

        string VerkauftAtkgmbh      = "http://k2b-bulk.ebay.de/ws/eBayISAPI.dll?SalesRecordConsole&currentpage=SCSold&ssPageName=STRK:ME:LNLK";
        string NichtverkauftAtkgmbh = "http://k2b-bulk.ebay.de/ws/eBayISAPI.dll?MfcISAPICommand=ListingConsole&currentpage=LCUnsold&pageNumber=2&searchField=ItemTitle&searchValues=&StoreCategory=-4&Status=All&Format=All&Period=Today&searchSubmit=Suchen&goToPage=";
        

        List<List<string>> listVerkauftKfzunion = new List<List<string>>();
        List<List<string>> listNichtverkauftKfzunion = new List<List<string>>();

        List<List<string>> listVerkauftAtkgmbhn = new List<List<string>>();
        List<List<string>> listNichtverkauftAtkgmbh = new List<List<string>>();

        string EbaySiteLog="https://signin.ebay.de/ws/eBayISAPI.dll?SignIn&ru=http%3A%2F%2Fwww.ebay.de%2F";
        string EbaySiteOutLog = "https://signin.ebay.de/ws/eBayISAPI.dll?SignIn&lgout=1";

     //   WebBrowser wbAtkgmbh = new WebBrowser();
    //    WebBrowser wbKfzunion = new WebBrowser();


        public Scanner()
        {
            InitializeComponent();
            
            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;
            timer1.Start();

        }

        public Scanner(string accountkfzunion, string passwordkfzunion,
                       string accountatkgmbh,  string passwordatkgmbh,
                       string accountAfterbuy, string passwordAfterbuy,
                       int time)
        {
            InitializeComponent();

            acKfzunion = accountkfzunion;
            passKfzunion = passwordkfzunion;

            acAtkgmbh    = accountatkgmbh;
            passAtkgmbh  = passwordatkgmbh;

            acAftebuy = accountAfterbuy;
            passAfterbuy = passwordAfterbuy;

            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;

            prbTime.Maximum = time * 60;

            tmProgressBar.Interval = 1000;
            tmProgressBar.Start();
        
            timer1.Interval = time * 60 * 1000;
            timer1.Start();
            notifyIcon1.Text = "scanner";
        }

        void Enter(ref WebBrowser wb, string account, string password)
        {
         //   wb.Document.GetElementById("userid").SetAttribute("value", account);
        //    wb.Document.GetElementById("pass").InnerText = password;

       /*     if(wb.Document.GetElementById("userid").GetAttribute("value") ==account && wb.Document.GetElementById("pass").InnerText==password)
            foreach (HtmlElement he in wb.Document.GetElementsByTagName("input"))
            {
                if (he.GetAttribute("value").Equals("Einloggen"))
                {
                    he.InvokeMember("click");

                }
            }*/
            
            wb.Document.GetElementById("userid").SetAttribute("Value", account);
            wb.Document.GetElementById("pass").SetAttribute("Value", password);
          /*  while (wb.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }*/
            wb.Document.GetElementsByTagName("form")[0].InvokeMember("submit");
          //  wb.Document.GetElementById("sgnBt").InvokeMember("click");
       //     wb.Document.GetElementById("sgnBt").Focus();
        //    wb.Document.GetElementById("sgnBt").InvokeMember("click");

        }

        private void button1_Click(object sender, EventArgs e)
        {
     /*       wbVerkauftAtkgmbh.Document.GetElementById("userid").SetAttribute("value", "atkgmbh");
            wbVerkauftAtkgmbh.Document.GetElementById("pass").InnerText = "2010kessler";
            foreach (HtmlElement he in wbVerkauftAtkgmbh.Document.GetElementsByTagName("input"))
            {
                if (he.GetAttribute("value").Equals("Einloggen"))
                {
                    he.InvokeMember("click");

                }
            }*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //wbVerkauftAtkgmbh.Navigate(VerkauftAtkgmbh);
            //wbVerkauftAtkgmbh.Navigate(NichtverkauftAtkgmbh);
        }

        private void button3_Click(object sender, EventArgs e)
        {
          //  wbNichtverkauftAtkgmbh.Navigate(EbaySiteLog);
        }

        private void button4_Click(object sender, EventArgs e)
        {
         /*   wbNichtverkauftAtkgmbh.Document.GetElementById("userid").SetAttribute("value", "atkgmbh");
            wbNichtverkauftAtkgmbh.Document.GetElementById("pass").InnerText = "2010kessler";
            foreach (HtmlElement he in wbNichtverkauftAtkgmbh.Document.GetElementsByTagName("input"))
            {
                if (he.GetAttribute("value").Equals("Einloggen"))
                {
                    he.InvokeMember("click");

                }
            }*/
        }

        private void button5_Click(object sender, EventArgs e)
        {
         //   wbNichtverkauftAtkgmbh.Navigate(NichtverkauftAtkgmbh);
        }

        private void button6_Click(object sender, EventArgs e)
        {
        }

        private void button7_Click(object sender, EventArgs e)
        {
          //  Enter(wbVerkauftAtkgmbh, "atkgmbh", "2010kessler");
          //  Enter(wbNichtverkauftAtkgmbh, "atkgmbh", "2010kessler");

        /*    Enter(wbVerkauftKfzunion, "kfzunion", "Kessler2010");
            Enter(wbNichtverkauftKfzunion, "kfzunion", "Kessler2010");*/

        }

        private void button8_Click(object sender, EventArgs e)
        {
        /*    int i = 0;
            List<List<string>> ss = new List<List<string>>();
            // wbVerkauftAtkgmbh.Refresh();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            HtmlAgilityPack.HtmlDocument qq = new HtmlAgilityPack.HtmlDocument();

            doc.LoadHtml(wbVerkauftAtkgmbh.DocumentText);
            var dd = doc.DocumentNode.SelectNodes("//td[@title='Artikelbezeichnung']");
            foreach (var block in dd)
            {
                ss.Add(new List<string>());
                ss[i].Add(Regex.Match(block.InnerHtml, "(?<=title=\")(.*?)(?=\")").Value);
                ss[i].Add(Regex.Match(Regex.Replace(block.InnerHtml, "amp;", string.Empty), "(?<=href=\")(.*?)(?=\")").Value);
                i++;
            }
            

            for (int ii = 0; ii < ss.Count; ii++)
            {
                var p = ss[ii][1];
                var WebPage = new HtmlWeb().Load(ss[ii][1]);
                var y = WebPage.DocumentNode.SelectSingleNode("//span[@id='lagernummer']");
                // Regex.Match(WebPage.DocumentNode.SelectSingleNode("//div[@class='kfz-details-content']")
                if (WebPage.DocumentNode.SelectSingleNode("//span[@id='lagernummer']") != null)
                    ss[ii].Add(Regex.Match(WebPage.DocumentNode.SelectSingleNode("//span[@id='lagernummer']").InnerText, @"([0-9]).{4,5}").ToString());
            }*/
        }

        List<List<string>> VerkaufItems(string html)
        {
            int i = 0;
            List<List<string>> ss = new List<List<string>>();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            HtmlAgilityPack.HtmlDocument qq = new HtmlAgilityPack.HtmlDocument();

          //  doc.LoadHtml(wbVerkauftAtkgmbh.DocumentText);
            doc.LoadHtml(html);
           // var dd = doc.DocumentNode.SelectNodes("//tr[@class='dt-ntb dt-slb dt-fr']");
            var dd = doc.DocumentNode.SelectNodes("//tbody[@class='dt-nsb']");
            if (dd != null)
            {/*
                foreach (var block in dd)
                {
                    ss.Add(new List<string>());
                    qq.LoadHtml(block.InnerHtml);
                    var l = qq.DocumentNode.SelectSingleNode("//td[@id='BuyerEmail']").InnerHtml;
                    ss[i].Add(Regex.Match(block.InnerHtml, "(?<=title=\")(.*?)(?=\")").Value);
                    ss[i].Add(Regex.Match(Regex.Replace(block.InnerHtml, "amp;", string.Empty), "(?<=href=\")(.*?)(?=\")").Value);
                    i++;
                }*/
               foreach (var block in dd)
                {
                    
                    qq.LoadHtml(block.InnerHtml);
                    var l = qq.DocumentNode.SelectNodes("//td[@id='BuyerEmail']");
                    foreach (var item in l)
                    {
                        ss.Add(new List<string>());
                        ss[i].Add(Regex.Match(item.InnerHtml, "(?<=title=\")(.*?)(?=\")").Value);
                        ss[i].Add(Regex.Match(Regex.Replace(item.InnerHtml, "amp;", string.Empty), "(?<=href=\")(.*?)(?=\")").Value);
                        i++;
                    }
                }

                for (int ii = 0; ii < ss.Count; ii++)
                {
                    var p = ss[ii][1];
                    var WebPage = new HtmlWeb().Load(ss[ii][1]);
                    var y = WebPage.DocumentNode.SelectSingleNode("//span[@id='lagernummer']");
                    if (WebPage.DocumentNode.SelectSingleNode("//span[@id='lagernummer']") != null)
                        ss[ii].Add(Regex.Match(WebPage.DocumentNode.SelectSingleNode("//span[@id='lagernummer']").InnerText, @"([0-9]).{1,5}").ToString());
                }
            }
            return ss;
        }

        List<List<string>> NichtverkauftItems(string html)
        {
            int i = 0;
            List<List<string>> ss = new List<List<string>>();
            // wbVerkauftAtkgmbh.Refresh();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            HtmlAgilityPack.HtmlDocument qq = new HtmlAgilityPack.HtmlDocument();

           // doc.LoadHtml(wbVerkauftAtkgmbh.DocumentText);
            doc.LoadHtml(html);
            var dd = doc.DocumentNode.SelectNodes("//td[@title='Artikelbezeichnung']");
            if (dd != null)
            {
                foreach (var block in dd)
                {
                    ss.Add(new List<string>());
                    ss[i].Add(Regex.Match(block.InnerHtml, "(?<=title=\")(.*?)(?=\")").Value);
                    ss[i].Add(Regex.Match(Regex.Replace(block.InnerHtml, "amp;", string.Empty), "(?<=href=\")(.*?)(?=\")").Value);
                    i++;
                }


                for (int ii = 0; ii < ss.Count; ii++)
                {
                    var p = ss[ii][1];
                    var WebPage = new HtmlWeb().Load(ss[ii][1]);
                    var y = WebPage.DocumentNode.SelectSingleNode("//span[@id='lagernummer']");
                    // Regex.Match(WebPage.DocumentNode.SelectSingleNode("//div[@class='kfz-details-content']")
                    if (WebPage.DocumentNode.SelectSingleNode("//span[@id='lagernummer']") != null)
                        ss[ii].Add(Regex.Match(WebPage.DocumentNode.SelectSingleNode("//span[@id='lagernummer']").InnerText, @"([0-9]).{1,5}").ToString());
                }
            }
            return ss;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
                tmMuz.Stop();
                muz = false;
                spmy.Stop();
                timer1.Stop();
                tmProgressBar.Stop();
                prbTime.Value = 0;

                WebBrowser wbAtkgmbh = new WebBrowser();
                WebBrowser wbKfzunion = new WebBrowser();
                wbAtkgmbh.Location = new System.Drawing.Point(79, 133);
                wbAtkgmbh.MinimumSize = new System.Drawing.Size(20, 20);
                wbAtkgmbh.Name = "webBrowser2";
                wbAtkgmbh.Size = new System.Drawing.Size(793, 272);
                wbAtkgmbh.TabIndex = 25;

                wbAtkgmbh.Navigate(EbaySiteLog);
                while (wbAtkgmbh.ReadyState != WebBrowserReadyState.Complete)
                {
                    Application.DoEvents();
                }
                //Enter2(wbAtkgmbh, "atkgmbh", "2010kessler");
                Enter2(wbAtkgmbh, acAtkgmbh, passAtkgmbh);
                Text = "Enter atk account";
                while (wbAtkgmbh.ReadyState == WebBrowserReadyState.Complete)
                {
                    Application.DoEvents();
                }
                wbAtkgmbh.Navigate(VerkauftAtkgmbh);

                while (wbAtkgmbh.ReadyState != WebBrowserReadyState.Complete)
                {
                    Application.DoEvents();
                }
                Text = wbAtkgmbh.Url.AbsoluteUri;
                listVerkauftAtkgmbhn = VerkaufItems(wbAtkgmbh.DocumentText);
                
                Text = "Atk Ver:" + listVerkauftAtkgmbhn.Count();
                wbAtkgmbh.Navigate(NichtverkauftAtkgmbh);
                while (wbAtkgmbh.ReadyState != WebBrowserReadyState.Complete)
                {
                    Application.DoEvents();
                }
                listNichtverkauftAtkgmbh = NichtverkauftItems(wbAtkgmbh.DocumentText);
                Text = "Atk Nich Ver:" + listNichtverkauftAtkgmbh.Count();
                wbAtkgmbh.Navigate(EbaySiteOutLog);

                while (wbAtkgmbh.ReadyState != WebBrowserReadyState.Complete)
                {
                    Application.DoEvents();
                }
                wbAtkgmbh.Dispose();


                wbKfzunion.Navigate(EbaySiteLog);
                while (wbKfzunion.ReadyState != WebBrowserReadyState.Complete)
                {
                    Application.DoEvents();
                }
                Enter2(wbKfzunion, acKfzunion, passKfzunion);
                Text = "Enter kfz account";
                while (wbKfzunion.ReadyState == WebBrowserReadyState.Complete)
                {
                    Application.DoEvents();
                }

                wbKfzunion.Navigate(VerkauftAtkgmbh);
                while (wbKfzunion.ReadyState != WebBrowserReadyState.Complete)
                {
                    Application.DoEvents();
                }
                listVerkauftKfzunion = VerkaufItems(wbKfzunion.DocumentText);
                Text = "Kfz ver:" + listVerkauftKfzunion.Count();
                wbKfzunion.Navigate(NichtverkauftAtkgmbh);

                while (wbKfzunion.ReadyState != WebBrowserReadyState.Complete)
                {
                    Application.DoEvents();
                }
                listNichtverkauftKfzunion = NichtverkauftItems(wbKfzunion.DocumentText);
                Text = "Kfz Nich:" + listNichtverkauftKfzunion.Count();
                wbKfzunion.Navigate(EbaySiteOutLog);
                while (wbKfzunion.ReadyState != WebBrowserReadyState.Complete)
                {
                    Application.DoEvents();
                }
                wbKfzunion.Dispose();
                label1.Text = "kfzunion" + ": " + (listVerkauftKfzunion.Count()).ToString();
                label2.Text = "atkgmbh" + ": " + (listVerkauftAtkgmbhn.Count()).ToString();
                AddandSord(dataGridView1, listVerkauftKfzunion, listNichtverkauftAtkgmbh);
                AddandSord(dataGridView2, listVerkauftAtkgmbhn, listNichtverkauftKfzunion);
                NumberYellow(ref dataGridView2, numberYellowKFZ, removalofgoods);
                NumberYellow(ref dataGridView1, numberYellowATK, removalofgoods);
                AutoRemoval(ref dataGridView1, "kfzunion");
                AutoRemoval(ref dataGridView2, "atkgmbh");
                SellItem(ref dataGridView1);
                SellItem(ref dataGridView2);
                timer1.Start();
                tmProgressBar.Start();
            

        }

        void AddandSord(DataGridView dgv, List<List<string>> listVer, List<List<string>> listNith )
        {
            bool Search = false;
            dgv.Rows.Clear();
            for (int i = 0; i < listVer.Count(); i++)
            {
                dgv.Rows.Add();
                dgv.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                
                
                try
                {
                    dgv.Rows[i].Cells[0].Value = listVer[i][2];
                    dgv.Rows[i].Cells[1].Value = listVer[i][0];
                    dgv.Rows[i].Cells[2].Tag = listVer[i][1];
                }
                catch (Exception e)
                {
                    dgv.Rows[i].Cells[1].Value = listVer[i][0];
                    dgv.Rows[i].Cells[2].Tag = listVer[i][1];
                }
                
                for (int ii = 0; ii < listNith.Count(); ii++)
                {

                    try
                    {
                        if (listVer[i][2] == listNith[ii][2])
                        {
                            Search = true;
                            
                            dgv.Rows[i].DefaultCellStyle.BackColor = Color.Green;

                            dgv.Rows[i].Cells[5].Value = listNith[ii][2];
                            dgv.Rows[i].Cells[4].Value = listNith[ii][0];
                            dgv.Rows[i].Cells[6].Tag = listNith[ii][1];
                            listNith.RemoveAt(ii);
                            break;
                        }
                    }
                    catch (Exception e)
                    {
                    }

                }
                
            }

            int row = 0;
            for (int i = 0; i < listNith.Count(); i++)
            {
                dgv.Rows.Add();
                try
                {
                    dgv.Rows[listVer.Count + row].Cells[5].Value = listNith[i][2];
                    dgv.Rows[listVer.Count + row].Cells[4].Value = listNith[i][0];
                    dgv.Rows[listVer.Count + row].Cells[6].Tag = listNith[i][1];
                    dgv.Rows[listVer.Count + row].DefaultCellStyle.BackColor = Color.Red;
                    row++;
                }
                catch (Exception e)
                {
                    dgv.Rows[listVer.Count + row].Cells[4].Value = listNith[i][0];
                    dgv.Rows[listVer.Count + row].Cells[6].Tag = listNith[i][1];
                    dgv.Rows[listVer.Count + row].DefaultCellStyle.BackColor = Color.Red;
                    row++;
                }
            }
            
           

        }
        void NumberYellow(ref DataGridView dgv, List<string> list, List<RemovalOfGoods> removal)
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int ii = 0; ii < dgv.RowCount; ii++)
                {
                    if ( dgv.Rows[ii].Cells[1].Value != null)
                    {
                        if(string.Equals(dgv.Rows[ii].Cells[1].Value.ToString(),list[i]))
                        {
                            dgv.Rows[ii].DefaultCellStyle.BackColor = Color.Yellow;
                            break;
                        }
                    }
                    else if (dgv.Rows[ii].Cells[4].Value != null)
                    {
                        if (string.Equals(dgv.Rows[ii].Cells[4].Value.ToString(), list[i]))
                        {
                            dgv.Rows[ii].DefaultCellStyle.BackColor = Color.Yellow;
                            break;
                        }
                    }
                }
            }

            for (int i = 0; i < removal.Count; i++)
            {
                for (int ii = 0; ii < dgv.RowCount; ii++)
                {
                    if (dgv.Rows[ii].Cells[5].Value == null)
                    {
                        if (dgv.Rows[ii].Cells[0].Value != null)
                            if (string.Equals(dgv.Rows[ii].Cells[0].Value.ToString(), removal[i].number))
                            {
                                dgv.Rows[ii].DefaultCellStyle.BackColor = Color.Blue;
                                if (removal[i].siteSell != string.Empty)
                                    dgv.Rows[ii].Cells[2].Tag = removal[i].siteSell;
                                dgv.Rows[ii].Cells[6].Tag = removal[i].siteBendeet;
                                break;
                            }
                    }
                }
            }
            for (int i = 0; i < dgv.RowCount; i++)
            {
                if ((dgv.Rows[i].Cells[0].Value == null ||
                    string.Equals(dgv.Rows[i].Cells[0].Value.ToString(), string.Empty)) && dgv.Rows[i].Cells[5].Value != null)
                {
                    dgv.Rows[i].DefaultCellStyle.BackColor = Color.Gray;
                }
            }


        }
        void SellItem(ref DataGridView dgvVer)
        {
            for(int i=0;i<dgvVer.RowCount;i++)
            {
                if (dgvVer.Rows[i].DefaultCellStyle.BackColor == Color.Red)
                    {
                        notifyIcon1.ShowBalloonTip(3000, "Scanner", "Matches found", ToolTipIcon.Info);
                        muz = true;
                        tmMuz.Start();
                        spmy.Play();
                        break;
                    }

            }


        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
                notifyIcon1.Visible = false;
                tmMuz.Stop();
                muz = false;
                spmy.Stop();
            }
        }

        private void Scanner_Deactivate(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                notifyIcon1.Visible = true;
            }
        }

        private void Scanner_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            prbTime.Value++;
            if (prbTime.Value == 2400)
            {
                prbTime.Value = 0;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
        }


        private void tmProgressBar_Tick(object sender, EventArgs e)
        {
            
            if (prbTime.Value != prbTime.Maximum)
            {
                prbTime.Value += 1;
            }
            else
            {
                prbTime.Value = 0;
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          //  Text = dataGridView1.Columns[dataGridView1.CurrentCellAddress.X].HeaderText;
            if(string.Equals(dataGridView1.Columns[dataGridView1.CurrentCellAddress.X].HeaderText,"Site"))
                if(dataGridView1.CurrentCell.Tag !=null)
                if (!string.Equals(dataGridView1.CurrentCell.Tag.ToString(), string.Empty))
                      System.Diagnostics.Process.Start(dataGridView1.CurrentCell.Tag.ToString());
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (string.Equals(dataGridView2.Columns[dataGridView2.CurrentCellAddress.X].HeaderText, "Site"))
                if (dataGridView2.CurrentCell.Tag != null)
                if(!string.Equals(dataGridView2.CurrentCell.Tag.ToString(),string.Empty))
                     System.Diagnostics.Process.Start(dataGridView2.CurrentCell.Tag.ToString());
        }


        private void button10_Click(object sender, EventArgs e)
        {
        }

        private void button11_Click(object sender, EventArgs e)
        {
          /*  wbKfzunion.Document.GetElementById("userid").SetAttribute("Value", acKfzunion);
            wbKfzunion.Document.GetElementById("pass").SetAttribute("Value", passKfzunion);

            wbKfzunion.Document.GetElementById("sgnBt").InvokeMember("click");*/
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
        
        }
        void Enter2(WebBrowser wb, string account, string password)
        {
            wb.Document.GetElementById("userid").SetAttribute("value", account);
            wb.Document.GetElementById("pass").InnerText = password;

            foreach (HtmlElement he in wb.Document.GetElementsByTagName("input"))
            {
                if (he.GetAttribute("value").Equals("Einloggen"))
                {
                    he.InvokeMember("click");
                }
            }
        }

        private void button9_Click_2(object sender, EventArgs e)
        {
        }

        private void button9_Click_3(object sender, EventArgs e)
        {
           // Text=dataGridView1.Columns[dataGridView1.CurrentRow.Index].HeaderText;
        }

        private void tmMuz_Tick(object sender, EventArgs e)
        {
            if (muz)
                spmy.Play();
        }

        private void Scanner_Click(object sender, EventArgs e)
        {
            muz = false;
            tmMuz.Stop();
            spmy.Stop();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
                muz = false;
                tmMuz.Stop();
                spmy.Stop();
            
        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
                muz = false;
                tmMuz.Stop();
                spmy.Stop();
           
        }

        private void Scanner_Load(object sender, EventArgs e)
        {

        }

        private void button9_Click_4(object sender, EventArgs e)
        {
            timer1_Tick(null, null);
        }

        private void dataGridView2_MouseDown(object sender, MouseEventArgs e)
        {/*
            if (e.Button == MouseButtons.Right)
            {
                if (dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].DefaultCellStyle.BackColor == Color.Red
                    && dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells[0].Value != null)
                {
                    dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                    numberYellowKFZ.Add(dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells[0].Value.ToString());
                }
                else if (dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].DefaultCellStyle.BackColor == Color.Yellow
                    && dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells[0].Value != null)
                {
                    dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                    numberYellowKFZ.Remove(dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells[0].Value.ToString());
                }
            }*/
            if (e.Button == MouseButtons.Right)
            {
                if (dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells[1].Value != null)
                {
                    if (dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].DefaultCellStyle.BackColor == Color.Red)
                    {
                        dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                        numberYellowKFZ.Add(dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells[1].Value.ToString());
                    }
                    else if (dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].DefaultCellStyle.BackColor == Color.Yellow)
                    {
                        dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                        numberYellowKFZ.Remove(dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells[1].Value.ToString());
                    }
                }
                else if (dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells[4].Value != null)
                {
                    if (dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].DefaultCellStyle.BackColor == Color.Red)
                    {
                        dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                        numberYellowKFZ.Add(dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells[4].Value.ToString());
                    }
                    else if (dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].DefaultCellStyle.BackColor == Color.Yellow)
                    {
                        dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                        numberYellowKFZ.Remove(dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells[4].Value.ToString());
                    }
                }
            }
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value != null)
                {
                    if (dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].DefaultCellStyle.BackColor == Color.Red)
                    {
                        dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                        numberYellowATK.Add(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString());
                    }
                    else if (dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].DefaultCellStyle.BackColor == Color.Yellow)
                    {
                        dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                        numberYellowATK.Remove(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString());
                    }
                }
                else if (dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[4].Value != null)
                {
                    if (dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].DefaultCellStyle.BackColor == Color.Red)
                    {
                        dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                        numberYellowATK.Add(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[4].Value.ToString());
                    }
                    else if (dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].DefaultCellStyle.BackColor == Color.Yellow)
                    {
                        dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                        numberYellowATK.Remove(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[4].Value.ToString());
                    }
                }
            }

        }


        /// <summary>
        /// Добавляет Id продажи в таблицу RemovalofGoods.
        /// </summary>
        /// <param name="IDAfterBuy"></param>
        void AddNumberSale(string IDAfterBuy)
        {
            using (var con = new MySqlConnection(connectionString))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string comand = string.Format(@"INSERT INTO RemovalofGoods (IDSale) VALUES({0});", IDAfterBuy);
                var sqlcomand = con.CreateCommand();
                sqlcomand.CommandText = comand;
                sqlcomand.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Добавляет запись в таблицу SaleAfterBuy
        /// </summary>
        /// <param name="LargeNummer"></param>
        /// <param name="IDAfterBuy"></param>
        /// <param name="NameSpare"></param>
        /// <param name="DateAndTime"></param>
        /// <param name="Price"></param>
        /// <param name="Site"></param>
        /// <param name="AccountEbay"></param>
        /// <param name="StatusSpare"></param>
        void AddItem(string LargeNummer, string IDAfterBuy, string NameSpare, string DateAndTime,
                     double Price, string Site, string AccountEbay, string StatusSpare)
        {
            using (var con = new MySqlConnection(connectionString))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string comand = string.Format(@"INSERT INTO SaleAfterBuy (LargeNummer, IDAfterBuy, NameSpare, DateAndTime, Price, Site, AccountEbay, StatusSpare) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');",
                                                                          LargeNummer, IDAfterBuy, NameSpare, DateAndTime, Price, Site, AccountEbay, StatusSpare);
                var sqlcomand = con.CreateCommand();
                sqlcomand.CommandText = comand;
                sqlcomand.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Проверка на наличии записи в БД
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="table"></param>
        /// <param name="colum"></param>
        /// <returns></returns>
        int CheckItem(string Id, string table, string colum)
        {

            using (var con = new MySqlConnection(connectionString))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                //SaleAfterBuy  LargeNummer
                string comand = string.Format(@"SELECT COUNT(*) FROM {0} where {1}='{2}';", table, colum, Id);

                var sqlComand = con.CreateCommand();
                sqlComand.CommandText = comand;
                return int.Parse(sqlComand.ExecuteScalar().ToString());
            }
        }
        /// <summary>
        /// Обеспечивает вход на страницу афтербая
        /// </summary>
        /// <param name="wb"></param>
        /// <param name="account"></param>
        /// <param name="password"></param>
        void Enter(WebBrowser wb, string account, string password)
        {
            HtmlElementCollection elems = wb.Document.All;

            foreach (HtmlElement elem in elems)
            {
                String nameStr = elem.GetAttribute("name");
                if (nameStr == "user")
                {
                    elem.InnerText = account;
                }
                if (nameStr == "pass")
                {
                    elem.InnerText = password;
                }
            }
            foreach (HtmlElement he in wb.Document.GetElementsByTagName("button"))
            {
                if (he.GetAttribute("name").Equals("B1"))
                {
                    he.InvokeMember("click");
                }
            }
        }

        int AutoRemovalofGoods(string id, string nameSpare, string account, double price, string acAfter, string passAfter)
        {
            string oneStatus = string.Empty;
            string twoStatus = string.Empty;
            WebBrowser webBrowser1 = new WebBrowser();
            //webBrowser1.Location = new System.Drawing.Point(12, 12);
            //webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            //webBrowser1.Name = "webBrowser1";
            //webBrowser1.Size = new System.Drawing.Size(730, 377);
            //webBrowser1.TabIndex = 0;
            // webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);

            webBrowser1.Navigate("http://www.afterbuy.de/afterbuy/login.aspx");
            while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }
            Enter(webBrowser1, acAfter, passAfter);


            while (webBrowser1.ReadyState == WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }
            webBrowser1.Navigate(string.Format("http://farm04.afterbuy.de/afterbuy/shop/produkte.aspx?Su_Suchbegriff=&PRFilter=&Su_Suchbegriff_lg=0&PRFilter1=&Artikelnummer_Search={0}&level__Search=&Attributwert_Search=&EAN_Search=&Su_Listenlaenge=10&Su_Listenlaenge_Ges=500&MyFreifeld=0&MyFreifeldValue=&Suche_BestandOP=&Suche_Bestand_Wert=0&Suche_ABestandOP=&Suche_ABestand_Wert=0&Katalog_Filter=0&Katalog_Filter_Kat2=0&Katalog_Filter_Kat3=0&Katalog_Filter_Kat4=0&Katalog_Filter_Kat5=0&StandardProductIDValue_Search=&versandgruppe=&versandgruppe_art=0&vorlage=&vorlageart=0&Product_Search_Stocklocation_1=&Product_Search_Stocklocation_1_Value=&Product_Search_Stocklocation_2=&Product_Search_Stocklocation_2_Value=&Product_Search_Stocklocation_3=&Product_Search_Stocklocation_3_Value=&Product_Search_Stocklocation_4=&Product_Search_Stocklocation_4_Value=&Product_Search_Supplier_1=0&Product_Search_Supplier_2=0&Product_Search_Supplier_3=0&Product_Search_Supplier_4=0&SuchZusatzfeld1=&SuchZusatzfeld2=&SuchZusatzfeld3=&SuchZusatzfeld4=&SuchZusatzfeld5=&SuchZusatzfeld6=&ShowZusatzFelder=0&spoid=0&art=SetAuswahl", id));
            while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }

            foreach (HtmlElement he2 in webBrowser1.Document.All)
            {
                if (he2.GetAttribute("name").Equals("id"))
                {
                    he2.InvokeMember("click");
                }
                if (he2.GetAttribute("name") == "art2")
                {
                    he2.Children[7].SetAttribute("selected", "true");
                }
                if (he2.GetAttribute("name") == "art" && he2.Id == "art")
                {
                    he2.Children[6].SetAttribute("selected", "true");
                }
            }
            foreach (HtmlElement he in webBrowser1.Document.GetElementsByTagName("input"))
            {
                if (he.GetAttribute("name").Equals("Ausfuehren_Button_Top"))
                {
                    he.InvokeMember("click");
                }
            }
            while (webBrowser1.ReadyState == WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }
            while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }

            var IDPage = new HtmlAgilityPack.HtmlDocument();
            IDPage.LoadHtml(webBrowser1.DocumentText);
            var PageSaleOne = IDPage.DocumentNode.SelectSingleNode("//tr[@class='txtTop txtLeft ContentTable ListBGColor1']");
            string idSaleOne = Regex.Match(PageSaleOne.InnerText, @"[0-9].(\d\d\d\d\d\d\d\d\d\d)").Value;
            if (CheckItem(idSaleOne, "RemovalofGoods", "IDSale") == 0)
            {
                AddNumberSale(idSaleOne);
            }
            else
            {
                return 0;
            }


            foreach (HtmlElement he2 in webBrowser1.Document.All)
            {
                if (he2.GetAttribute("name").Equals("id"))
                {
                    he2.InvokeMember("click");
                }
            }

            while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }

            foreach (HtmlElement he2 in webBrowser1.Document.All)
            {
                if (he2.GetAttribute("name") == "art_tmp" && he2.TagName == "SELECT")
                {
                    he2.Children[3].SetAttribute("selected", "true");
                }
                if (he2.GetAttribute("name") == "art" && he2.TagName == "SELECT")
                {
                    he2.Children[3].SetAttribute("selected", "true");
                }
            }
            foreach (HtmlElement he in webBrowser1.Document.GetElementsByTagName("input"))
            {
                if (he.GetAttribute("name").Equals("Ausfuehren_Button"))
                {
                    he.InvokeMember("click");
                }
            }
            while (webBrowser1.ReadyState == WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }
            while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }

            foreach (HtmlElement he2 in webBrowser1.Document.All)
            {
                if (he2.GetAttribute("name") == "EndItemReason" && he2.TagName == "SELECT")
                {
                    he2.Children[3].SetAttribute("selected", "true");
                }
            }
            foreach (HtmlElement he in webBrowser1.Document.GetElementsByTagName("input"))
            {
                if (he.GetAttribute("name").Equals("ConfirmButton"))
                {
                    he.InvokeMember("click");
                }
            }
            while (webBrowser1.ReadyState == WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }
            while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }


            var WebPage = new HtmlAgilityPack.HtmlDocument();
            WebPage.LoadHtml(webBrowser1.Document.Body.InnerHtml);
            var div = WebPage.DocumentNode.SelectSingleNode("//table[@class='MinMaxSize txtLeft']");
            WebPage.LoadHtml(div.InnerHtml);
            div = WebPage.DocumentNode.SelectSingleNode("//div[@class='notice']");
            WebPage.LoadHtml(div.InnerHtml);
            div = WebPage.DocumentNode.SelectSingleNode("//table[@border='0']");
            WebPage.LoadHtml(div.InnerHtml);
            var tdcol = WebPage.DocumentNode.SelectNodes("//td[@bgcolor='#ffffff']");


            var uri = Regex.Replace(Regex.Match(tdcol[0].InnerHtml, "(?<=href=\")(.*?)(?=\")").Value, "amp;", string.Empty);
            webBrowser1.Navigate(uri);
            webBrowser1.ScriptErrorsSuppressed = true;
            while (webBrowser1.ReadyState == WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }
            while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }


            var WebPage2 = new HtmlAgilityPack.HtmlDocument();
            WebPage2.LoadHtml(webBrowser1.DocumentText);
            var Status = WebPage2.DocumentNode.SelectSingleNode("//span[@id='w1-3-_msg']");

            string oneAccount = string.Empty;
            string twoAccount = string.Empty;

            if (Regex.IsMatch(Status.InnerText, "Verkäufer beendet"))
            {
                oneStatus = "Beendet";
                twoStatus = "Sell";
                if (account == "kfzunion")
                {
                    oneAccount = "atkgmbh";
                    twoAccount = "kfzunion";
                    siteBendeet = Regex.Replace(Regex.Match(tdcol[0].InnerHtml, "(?<=href=\")(.*?)(?=\")").Value, "amp;", string.Empty);
                    if (tdcol.Count > 2)
                        siteSell = Regex.Replace(Regex.Match(tdcol[2].InnerHtml, "(?<=href=\")(.*?)(?=\")").Value, "amp;", string.Empty);


                }
                else
                {
                    oneAccount = "kfzunion";
                    twoAccount = "atkgmbh";
                    siteSell = Regex.Replace(Regex.Match(tdcol[0].InnerHtml, "(?<=href=\")(.*?)(?=\")").Value, "amp;", string.Empty);
                    if (tdcol.Count > 2)
                        siteBendeet= Regex.Replace(Regex.Match(tdcol[2].InnerHtml, "(?<=href=\")(.*?)(?=\")").Value, "amp;", string.Empty);

                }
            }
            else
            {
                oneStatus = "Sell";
                twoStatus = "Beendet";
                if (account == "kfzunion")
                {
                    oneAccount = "kfzunion";
                    twoAccount = "atkgmbh";
                    siteSell = Regex.Replace(Regex.Match(tdcol[0].InnerHtml, "(?<=href=\")(.*?)(?=\")").Value, "amp;", string.Empty);
                    if (tdcol.Count > 2)
                          siteBendeet= Regex.Replace(Regex.Match(tdcol[2].InnerHtml, "(?<=href=\")(.*?)(?=\")").Value, "amp;", string.Empty);

                }
                else
                {
                    oneAccount = "atkgmbh";
                    twoAccount = "kfzunion";
                    siteBendeet = Regex.Replace(Regex.Match(tdcol[0].InnerHtml, "(?<=href=\")(.*?)(?=\")").Value, "amp;", string.Empty);
                    if (tdcol.Count > 2)
                         siteSell= Regex.Replace(Regex.Match(tdcol[2].InnerHtml, "(?<=href=\")(.*?)(?=\")").Value, "amp;", string.Empty);

                }
            }

            var oneSpare = new SiteSpare
            {
                SiteSpares = Regex.Replace(Regex.Match(tdcol[0].InnerHtml, "(?<=href=\")(.*?)(?=\")").Value, "amp;", string.Empty),
                NumberSpare = Regex.Replace(tdcol[0].InnerText, @"&nbsp;", string.Empty),
                Data = Regex.Replace(Regex.Match(tdcol[1].InnerHtml, @"(?<=Endzeit:)(.*?)\)").Value, @"\)", string.Empty),
                Status = oneStatus,
                Account = oneAccount
            };
            AddItem(id, oneSpare.NumberSpare, nameSpare, oneSpare.Data, price, oneSpare.SiteSpares, account, oneSpare.Status);


            if (tdcol.Count > 2)
            {
                var twoSpare = new SiteSpare
                {

                    SiteSpares = Regex.Replace(Regex.Match(tdcol[2].InnerHtml, "(?<=href=\")(.*?)(?=\")").Value, "amp;", string.Empty),
                    NumberSpare = Regex.Replace(tdcol[2].InnerText, @"&nbsp;", string.Empty),
                    Data = Regex.Replace(Regex.Match(tdcol[3].InnerHtml, @"(?<=Endzeit:)(.*?)\)").Value, @"\)", string.Empty),
                    Status = twoStatus,
                    Account = twoAccount
                };
                AddItem(id, twoSpare.NumberSpare, nameSpare, twoSpare.Data, price, twoSpare.SiteSpares, account, twoSpare.Status);

            }

            return 1;
        }
        //private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        //{
        //    ///////////////////
        //    if (Regex.IsMatch(webBrowser1.Url.AbsoluteUri, "login"))
        //    {
        //        Enter(webBrowser1, "atkgmbh", "Vipseller");
        //    }

        //    /////////////
        //    if (Regex.IsMatch(webBrowser1.Url.AbsoluteUri, "administration"))
        //    {
        //        webBrowser1.Navigate(string.Format("http://farm04.afterbuy.de/afterbuy/shop/produkte.aspx?Su_Suchbegriff=&PRFilter=&Su_Suchbegriff_lg=0&PRFilter1=&Artikelnummer_Search={0}&level__Search=&Attributwert_Search=&EAN_Search=&Su_Listenlaenge=10&Su_Listenlaenge_Ges=500&MyFreifeld=0&MyFreifeldValue=&Suche_BestandOP=&Suche_Bestand_Wert=0&Suche_ABestandOP=&Suche_ABestand_Wert=0&Katalog_Filter=0&Katalog_Filter_Kat2=0&Katalog_Filter_Kat3=0&Katalog_Filter_Kat4=0&Katalog_Filter_Kat5=0&StandardProductIDValue_Search=&versandgruppe=&versandgruppe_art=0&vorlage=&vorlageart=0&Product_Search_Stocklocation_1=&Product_Search_Stocklocation_1_Value=&Product_Search_Stocklocation_2=&Product_Search_Stocklocation_2_Value=&Product_Search_Stocklocation_3=&Product_Search_Stocklocation_3_Value=&Product_Search_Stocklocation_4=&Product_Search_Stocklocation_4_Value=&Product_Search_Supplier_1=0&Product_Search_Supplier_2=0&Product_Search_Supplier_3=0&Product_Search_Supplier_4=0&SuchZusatzfeld1=&SuchZusatzfeld2=&SuchZusatzfeld3=&SuchZusatzfeld4=&SuchZusatzfeld5=&SuchZusatzfeld6=&ShowZusatzFelder=0&spoid=0&art=SetAuswahl", id));
        //    }
        //    //////////////////
        //    if (Regex.IsMatch(webBrowser1.Url.AbsoluteUri, "produkte"))
        //    {
        //        foreach (HtmlElement he2 in webBrowser1.Document.All)
        //        {
        //            if (he2.GetAttribute("name").Equals("id"))
        //            {
        //                he2.InvokeMember("click");
        //            }
        //            if (he2.GetAttribute("name") == "art2")
        //            {
        //                he2.Children[7].SetAttribute("selected", "true");
        //            }
        //            if (he2.GetAttribute("name") == "art" && he2.Id == "art")
        //            {
        //                he2.Children[6].SetAttribute("selected", "true");
        //            }
        //        }
        //        foreach (HtmlElement he in webBrowser1.Document.GetElementsByTagName("input"))
        //        {
        //            if (he.GetAttribute("name").Equals("Ausfuehren_Button_Top"))
        //            {
        //                he.InvokeMember("click");
        //            }
        //        }
        //    }
        //    ///////////////////////////
        //    if (Regex.IsMatch(webBrowser1.Url.AbsoluteUri, "eBay_EinstellgebuehrenNew"))
        //    {

        //        var IDPage = new HtmlAgilityPack.HtmlDocument();
        //        IDPage.LoadHtml(webBrowser1.DocumentText);
        //        var PageSaleOne = IDPage.DocumentNode.SelectSingleNode("//tr[@class='txtTop txtLeft ContentTable ListBGColor1']");
        //        string idSaleOne = Regex.Match(PageSaleOne.InnerText, @"[0-9].(\d\d\d\d\d\d\d\d\d\d)").Value;
        //        if (CheckItem(idSaleOne, "RemovalofGoods", "IDSale") == 0)
        //        {
        //            AddNumberSale(idSaleOne);
        //        }
        //        else
        //        {
        //           // return 0;
        //        }
        //        foreach (HtmlElement he2 in webBrowser1.Document.All)
        //        {
        //            if (he2.GetAttribute("name").Equals("id"))
        //            {
        //                he2.InvokeMember("click");
        //            }
        //        }
        //        foreach (HtmlElement he2 in webBrowser1.Document.All)
        //        {
        //            if (he2.GetAttribute("name") == "art_tmp" && he2.TagName == "SELECT")
        //            {
        //                he2.Children[3].SetAttribute("selected", "true");
        //            }
        //            if (he2.GetAttribute("name") == "art" && he2.TagName == "SELECT")
        //            {
        //                he2.Children[3].SetAttribute("selected", "true");
        //            }
        //        }
        //        foreach (HtmlElement he in webBrowser1.Document.GetElementsByTagName("input"))
        //        {
        //            if (he.GetAttribute("name").Equals("Ausfuehren_Button"))
        //            {
        //                he.InvokeMember("click");
        //            }
        //        }
        //        oneStep = true;
        //    }
        //    /////////////
        //    if (oneStep)
        //    {
        //        foreach (HtmlElement he2 in webBrowser1.Document.All)
        //        {
        //            if (he2.GetAttribute("name") == "EndItemReason" && he2.TagName == "SELECT")
        //            {
        //                he2.Children[3].SetAttribute("selected", "true");
        //            }
        //        }
        //        foreach (HtmlElement he in webBrowser1.Document.GetElementsByTagName("input"))
        //        {
        //            if (he.GetAttribute("name").Equals("ConfirmButton"))
        //            {
        //                he.InvokeMember("click");
        //            }
        //        }
        //        oneStep = false;
        //        twoStep = true;
        //    }

        //    ////////////
        //    if (twoStep)
        //    {
        //        var WebPage = new HtmlAgilityPack.HtmlDocument();
        //        WebPage.LoadHtml(webBrowser1.Document.Body.InnerHtml);
        //        var div = WebPage.DocumentNode.SelectSingleNode("//table[@class='MinMaxSize txtLeft']");
        //        WebPage.LoadHtml(div.InnerHtml);
        //        div = WebPage.DocumentNode.SelectSingleNode("//div[@class='notice']");
        //        WebPage.LoadHtml(div.InnerHtml);
        //        div = WebPage.DocumentNode.SelectSingleNode("//table[@border='0']");
        //        WebPage.LoadHtml(div.InnerHtml);
        //        var tdcol = WebPage.DocumentNode.SelectNodes("//td[@bgcolor='#ffffff']");


        //        var uri = Regex.Replace(Regex.Match(tdcol[0].InnerHtml, "(?<=href=\")(.*?)(?=\")").Value, "amp;", string.Empty);
        //        webBrowser1.Navigate(uri);
        //        webBrowser1.ScriptErrorsSuppressed = true;
        //        twoStep = false;

        //        while (webBrowser1.ReadyState == WebBrowserReadyState.Complete)
        //        {
        //            Application.DoEvents();
        //        }
        //        while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
        //        {
        //            Application.DoEvents();
        //        }


        //        var WebPage2 = new HtmlAgilityPack.HtmlDocument();
        //        WebPage2.LoadHtml(webBrowser1.DocumentText);
        //        var Status = WebPage2.DocumentNode.SelectSingleNode("//span[@id='w1-3-_msg']");

        //        string oneAccount = string.Empty;
        //        string twoAccount = string.Empty;
        //        if (Regex.IsMatch(Status.InnerText, "Verkäufer beendet"))
        //        {
        //            oneStatus = "Sell";
        //            twoStatus = "Taken on";
        //            if (account == "kfzunion")
        //            {
        //                oneAccount = "atkgmbh";
        //                twoAccount = "kfzunion";
        //                siteSell = Regex.Replace(Regex.Match(tdcol[0].InnerHtml, "(?<=href=\")(.*?)(?=\")").Value, "amp;", string.Empty);
        //                if (tdcol.Count > 2)
        //                    siteBendeet = Regex.Replace(Regex.Match(tdcol[2].InnerHtml, "(?<=href=\")(.*?)(?=\")").Value, "amp;", string.Empty);


        //            }
        //            else
        //            {
        //                oneAccount = "kfzunion";
        //                twoAccount = "atkgmbh";
        //                siteBendeet = Regex.Replace(Regex.Match(tdcol[0].InnerHtml, "(?<=href=\")(.*?)(?=\")").Value, "amp;", string.Empty);
        //                if (tdcol.Count > 2)
        //                    siteSell = Regex.Replace(Regex.Match(tdcol[2].InnerHtml, "(?<=href=\")(.*?)(?=\")").Value, "amp;", string.Empty);

        //            }
        //        }
        //        else
        //        {
        //            oneStatus = "Taken on";
        //            twoStatus = "Sell";
        //            if (account == "kfzunion")
        //            {
        //                oneAccount = "kfzunion";
        //                twoAccount = "atkgmbh";
        //                siteBendeet = Regex.Replace(Regex.Match(tdcol[0].InnerHtml, "(?<=href=\")(.*?)(?=\")").Value, "amp;", string.Empty);
        //                if (tdcol.Count > 2)
        //                    siteSell = Regex.Replace(Regex.Match(tdcol[2].InnerHtml, "(?<=href=\")(.*?)(?=\")").Value, "amp;", string.Empty);

        //            }
        //            else
        //            {
        //                oneAccount = "atkgmbh";
        //                twoAccount = "kfzunion";
        //                siteSell = Regex.Replace(Regex.Match(tdcol[0].InnerHtml, "(?<=href=\")(.*?)(?=\")").Value, "amp;", string.Empty);
        //                if (tdcol.Count > 2)
        //                    siteBendeet = Regex.Replace(Regex.Match(tdcol[2].InnerHtml, "(?<=href=\")(.*?)(?=\")").Value, "amp;", string.Empty);

        //            }
        //        }

        //        var oneSpare = new SiteSpare
        //        {
        //            SiteSpares = Regex.Replace(Regex.Match(tdcol[0].InnerHtml, "(?<=href=\")(.*?)(?=\")").Value, "amp;", string.Empty),
        //            NumberSpare = Regex.Replace(tdcol[0].InnerText, @"&nbsp;", string.Empty),
        //            Data = Regex.Replace(Regex.Match(tdcol[1].InnerHtml, @"(?<=Endzeit:)(.*?)\)").Value, @"\)", string.Empty),
        //            Status = oneStatus,
        //            Account = oneAccount
        //        };
        //        AddItem(id, oneSpare.NumberSpare, nameSpare, oneSpare.Data, price, oneSpare.SiteSpares, account, oneSpare.Status);


        //        if (tdcol.Count > 2)
        //        {
        //            var twoSpare = new SiteSpare
        //            {

        //                SiteSpares = Regex.Replace(Regex.Match(tdcol[2].InnerHtml, "(?<=href=\")(.*?)(?=\")").Value, "amp;", string.Empty),
        //                NumberSpare = Regex.Replace(tdcol[2].InnerText, @"&nbsp;", string.Empty),
        //                Data = Regex.Replace(Regex.Match(tdcol[3].InnerHtml, @"(?<=Endzeit:)(.*?)\)").Value, @"\)", string.Empty),
        //                Status = twoStatus,
        //                Account = twoAccount
        //            };
        //            AddItem(id, twoSpare.NumberSpare, nameSpare, twoSpare.Data, price, twoSpare.SiteSpares, account, twoSpare.Status);

        //        }


        //    }
        //}
        

        void AutoRemoval(ref DataGridView dgv, string account)
        {
            for (int i = 0; i < dgv.RowCount; i++)
            {
                if (dgv.Rows[i].DefaultCellStyle.BackColor == Color.Red && dgv.Rows[i].Cells[5].Value == null && dgv.Rows[i].Cells[0].Value != null)
                {
                    if (AutoRemovalofGoods(dgv.Rows[i].Cells[0].Value.ToString(),
                                           dgv.Rows[i].Cells[1].Value.ToString(),
                                           account,
                                           0, acAftebuy, passAfterbuy) == 1)
                    {
                        dgv.Rows[i].DefaultCellStyle.BackColor = Color.Blue;
                        dgv.Rows[i].Cells[2].Tag = siteSell;
                        dgv.Rows[i].Cells[6].Tag = siteBendeet;
                        removalofgoods.Add(new RemovalOfGoods
                                                                {
                                                                    number = dgv.Rows[i].Cells[0].Value.ToString(),
                                                                    siteSell = dgv.Rows[i].Cells[2].Tag.ToString(),
                                                                    siteBendeet = dgv.Rows[i].Cells[6].Tag.ToString()
                                                                });
                    }
                    else
                    {
                        dgv.Rows[i].DefaultCellStyle.BackColor = Color.Blue;
                        removalofgoods.Add(new RemovalOfGoods
                        {
                            number = dgv.Rows[i].Cells[0].Value.ToString(),
                        });
                    }
                }

            }
        }
    }
}
