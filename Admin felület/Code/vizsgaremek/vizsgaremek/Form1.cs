using MySql.Data.MySqlClient;
using System;
using System.Drawing.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace vizsgaremek
{
    public partial class Form1 : Form
    {
        public bool aSD = false;

        public Form1()
        {
            InitializeComponent();
        }
        private string sql;
        private void login_Click(object sender, EventArgs e)
        {

            string mysqlconn = "server=localhost;user=root;database=soulpactum;password=";
            MySqlConnection mySqlConnection = new MySqlConnection(mysqlconn);

            string username = username_textbox.Text.ToString();
            string password = password_textbox.Text.ToString();
            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
            {
                MessageBox.Show("üres mezõ!");
            }
            else
            {
                try
                {
                    mySqlConnection.Open();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                MySqlCommand mySqlCommand = new MySqlCommand("select * from users where username = '"+username_textbox.Text+"' AND password='"+password_textbox.Text+"'", mySqlConnection);
                MySqlDataReader reader = mySqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    MessageBox.Show("Belépés sikeres!");
                    mennu menu = new mennu();
                    menu.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Sikertelen bejelentkezés!");
                }

                reader.Close();
            }                    
                mySqlConnection.Close();
            }



        }
    }