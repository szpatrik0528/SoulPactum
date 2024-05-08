using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Drawing.Text;
using System.Net.Http;
using System.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics.Eventing.Reader;

namespace vizsgaremek
{
    public partial class Form1 : Form
    {
        public bool aSD = false;

        public Form1()
        {
            InitializeComponent();
        }
        private void login_Click(object sender, EventArgs e)
        {
            validPassword();



        }
        private async Task validPassword()
        {
            string username= username_textbox.Text;
            string password= password_textbox.Text;
            var dict = new Dictionary<string, string>();
            await Task.Run(async () =>
            {
                string endpoint = "http://localhost/unity/PHP/Login.php";
                HttpClient client = new HttpClient();
                dict.Add("jatekosnev", username);
                dict.Add("jatekosjelszo", password);

                var response = await client.PostAsync(endpoint, new FormUrlEncodedContent(dict));
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                if (responseBody=="0")
                {
                    MessageBox.Show("Belépés sikeres!");
                    mennu menu = new mennu();
                    menu.ShowDialog();
                    Form1 login = new Form1();
                    login.Hide();
                    
                }
                else
                {
                    MessageBox.Show("Sikertelen bejelentkezés!");
                }


            });
        }
    }
}