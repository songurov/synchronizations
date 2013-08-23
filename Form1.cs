using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.IO;

namespace SynchronizationEbayAccaunt
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Строка подлючение к серверу
        /// </summary>
        public static string connectionString = "SERVER=w00f8083.kasserver.com;DATABASE=d014c1e3;UID=d014c1e3;PASSWORD=H4q5LMGrbtr8oEGd;DefaultCommandTimeout=99999;ConnectionTimeout=32400";

        byte[] PublicKey = {           0x19, 0x05, 0x19, 0x91,
                                       0x03, 0x05, 0x20, 0x13,
                                       0x30, 0x01, 0x01, 0x01,
                                       0x01, 0x99, 0x01, 0x12
                                   };
        byte[] IV = {   0, 55, 0, 1, 
                        1, 3, 1, 22,
                        100, 1, 8, 1, 
                        2, 1, 1, 99 
                    };
        RijndaelManaged myRijndael = new RijndaelManaged();
            

        public MainForm()
        {
            InitializeComponent();
            myRijndael.Key = PublicKey;
            myRijndael.KeySize = 128;
            myRijndael.IV = IV;
        }

        
        private void Form1_Deactivate(object sender, EventArgs e)
        {
       /*     if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(2000, "Title", "Text", ToolTipIcon.Info); 
            }*/

        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
         /*   if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
                notifyIcon1.Visible = false;

            } */
        }

        private void btSafe_Click(object sender, EventArgs e)
        {


            if (tbAccountkfzunion.Text  != "" || tbAccountkfzunion.Text != string.Empty  ||
                tbPasswordkfzunion.Text != "" || tbPasswordkfzunion.Text != string.Empty ||
                tbAccountatkgmbh.Text   != "" || tbAccountatkgmbh.Text != string.Empty   ||
                tbPasswordatkgmbh.Text  != "" || tbPasswordatkgmbh.Text != string.Empty)
            {
                if (CheckItem(tbAccountkfzunion.Text) == 0)
                {
                    MessageBox.Show("incorrect name kfzunion Account");
                }
                else
                {
                    UpdateAccount(tbPasswordkfzunion.Text,"7");
                }

                if (CheckItem(tbAccountatkgmbh.Text) == 0)
                {
                    MessageBox.Show("incorrect name atkgmbh Account");
                }
                else
                {
                    UpdateAccount(tbPasswordatkgmbh.Text,"6");
                }

                if (CheckItem(tbAccountatkgmbh.Text) == 0)
                {
                    MessageBox.Show("incorrect name Afterbuy Account");
                }
                else
                {
                    UpdateAccount(tbPasswordAfterbuy.Text,"8");
                }
            }
            else
            {
                MessageBox.Show("Fill in all fields");
            }
        }

        private int CheckItem(string account)
        {
            int count = 0;
                var conn = new MySqlConnection(connectionString);
                var command = conn.CreateCommand();
                command.CommandText = string.Format(@"select count(*) FROM EbayAccount WHERE (Account='{0}') ;", account);
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, @"Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return count;
                }
                count = int.Parse(command.ExecuteScalar().ToString());
                conn.Close();
            
            return count;
        }
        private string Loadpass(string id)
        {
            string pass = string.Empty;
            var conn = new MySqlConnection(connectionString);
            var command = conn.CreateCommand();
            command.CommandText = string.Format(@"select Password FROM EbayAccount WHERE (id='{0}') ;", id);
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No connection to the database", @"Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return pass;
            }
            pass = command.ExecuteScalar().ToString();
            conn.Close();

            return pass;
        }
        private void InsertAccount(string account, byte[] password)
        {
            var conn = new MySqlConnection(connectionString);
            var command = conn.CreateCommand();
            //command.CommandText = string.Format(@"insert into EbayAccount (Account,Password) values('{0}','{1}');", account, password);
            command.CommandText = @"insert into EbayAccount (Account,Password) values(?acc,?pass);"; 
            command.Parameters.Add("?acc",account);
            command.Parameters.Add("?pass",password);
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            command.ExecuteNonQuery();
            conn.Close();        
        }

        private void UpdateAccount(string password,string id)
        {
            var conn = new MySqlConnection(connectionString);
            var command = conn.CreateCommand();
            command.CommandText = string.Format(@"update EbayAccount set Password='{0}' where (id='{1}');", password,id);
           // command.CommandText = string.Format(@"update EbayAccount set Password='{1}' where (Account='{0}');", account, password);
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            command.ExecuteNonQuery();
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            if (tbAccountatkgmbh.Text == string.Empty && tbAccountkfzunion.Text == string.Empty)
            {
                Scanner sc = new Scanner();
                sc.Show();
                Hide();
            }
            else
            {
                Scanner sc = new Scanner(tbAccountkfzunion.Text,tbPasswordkfzunion.Text,
                                         tbAccountatkgmbh.Text,tbPasswordatkgmbh.Text,
                                         tbAccountAfterbuy.Text,tbPasswordAfterbuy.Text,
                                         int.Parse(tbTime.Text));
                sc.Show();
                Hide();
            }
        }

        private void tbTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }


        }

        private void MainForm_Load(object sender, EventArgs e)
        {
           if(!string.Equals(Loadpass("7"),string.Empty))
           {
                tbPasswordkfzunion.Text = Loadpass("7");
                tbPasswordatkgmbh.Text = Loadpass("6");
                tbPasswordAfterbuy.Text = Loadpass("8");
                
           }
        }
    }
}
