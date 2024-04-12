using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vizsgaremek
{
    public partial class felhasznalok : Form
    {
        public felhasznalok()
        {
            InitializeComponent();
        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mennu menu = new mennu();
            menu.Show();
            this.Close();
        }

        private void log_out_btn_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form1 = new Form1();
            form1.Show();
        }



        private void update_brn_Click(object sender, EventArgs e)
        {
            try
            {
                string mysqlconn = "server=127.0.0.1;user=root;database=soulpactum;password=";
                MySqlConnection mySqlConnection = new MySqlConnection(mysqlconn);
                mySqlConnection.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE `users` SET `username`=@username,`regisztralt`=@regisztralt,`pontszam`=@pontszam,`halalokszama`=@halalokszama,`Levels`=@Levels,`skin`=@skin,`teljesnev`=@teljesnev,`emailcim`=@emailcim,`adoszam`=@adoszam,`iranyitoszam`=@iranyitoszam,`telepules`=@telepules,`cim`=@cim,`telefonszam`=@telefonszam WHERE  userid = " + userid_text_box.Text, mySqlConnection);
                //cmd.Parameters.AddWithValue("@rendeles_id", int.Parse(rendeles_id_tb.Text));
                cmd.Parameters.AddWithValue("@username",username_text_box.Text);
                cmd.Parameters.AddWithValue("@regisztralt",DateTime.Parse(regisztralt_text_box.Text));
                cmd.Parameters.AddWithValue("@pontszam", int.Parse(pontszam_text_box.Text));
                cmd.Parameters.AddWithValue("@halalokszama", int.Parse(halalok_text_box.Text));
                cmd.Parameters.AddWithValue("@Levels", int.Parse(level_text_box.Text));
                cmd.Parameters.AddWithValue("@skin", int.Parse(skin_text_box.Text));
                cmd.Parameters.AddWithValue("@teljesnev", teles_nev_text_box.Text);
                cmd.Parameters.AddWithValue("@emailcim", email_cim_text_box.Text);
                cmd.Parameters.AddWithValue("@adoszam",adoszam_text_box.Text);
                cmd.Parameters.AddWithValue("@iranyitoszam", iranyitoszam_text_box.Text);
                cmd.Parameters.AddWithValue("@telepules", telepules_text_box.Text);
                cmd.Parameters.AddWithValue("@cim",lakcim_text_box.Text);
                cmd.Parameters.AddWithValue("@telefonszam",telefonszam_text_box.Text);
                cmd.ExecuteNonQuery();


                mySqlConnection.Close();
                MessageBox.Show("Sikeresen átírva!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt: " + ex.Message);
            }
        }
        private void search_btn_Click(object sender, EventArgs e)
        {
            if (username_text_box.Text == "")
            {

                string mysqlconn = "server=127.0.0.1;user=root;database=soulpactum;password=";
                MySqlConnection mySqlConnection = new MySqlConnection(mysqlconn);
                mySqlConnection.Open();

                MySqlCommand cmd = new MySqlCommand("Select * from users", mySqlConnection);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else
            {

                string mysqlconn = "server=127.0.0.1;user=root;database=soulpactum;password=";
                MySqlConnection mySqlConnection = new MySqlConnection(mysqlconn);
                mySqlConnection.Open();

                MySqlCommand cmd = new MySqlCommand("Select * from users where userid=@userid", mySqlConnection);
                cmd.Parameters.AddWithValue("@userid", int.Parse(userid_text_box.Text));
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                userid_text_box.Text = row.Cells["userid"].Value.ToString();
                username_text_box.Text = row.Cells["username"].Value.ToString();
                regisztralt_text_box.Text = row.Cells["regisztralt"].Value.ToString();
                pontszam_text_box.Text = row.Cells["pontszam"].Value.ToString();
                halalok_text_box.Text = row.Cells["halalokszama"].Value.ToString();
                level_text_box.Text = row.Cells["levels"].Value.ToString();
                skin_text_box.Text = row.Cells["skin"].Value.ToString();
                teles_nev_text_box.Text = row.Cells["teljesnev"].Value.ToString();
                email_cim_text_box.Text = row.Cells["emailcim"].Value.ToString();
                adoszam_text_box.Text = row.Cells["adoszam"].Value.ToString();
                iranyitoszam_text_box.Text = row.Cells["iranyitoszam"].Value.ToString();
                telepules_text_box.Text = row.Cells["telepules"].Value.ToString();
                lakcim_text_box.Text = row.Cells["cim"].Value.ToString();
                telefonszam_text_box.Text = row.Cells["telefonszam"].Value.ToString();

            }
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            userid_text_box.Clear();
            username_text_box.Clear();
            regisztralt_text_box.Clear();
            pontszam_text_box.Clear();
            halalok_text_box.Clear();
            level_text_box.Clear();
            skin_text_box.Clear();
            email_cim_text_box.Clear();
            adoszam_text_box.Clear();
            iranyitoszam_text_box.Clear();
            telepules_text_box.Clear();
            lakcim_text_box.Clear();
            telefonszam_text_box.Clear();


        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            string mysqlconn = "server=127.0.0.1;user=root;database=soulpactum;password=";
            MySqlConnection mySqlConnection = new MySqlConnection(mysqlconn);
            mySqlConnection.Open();

            MySqlCommand cmd = new MySqlCommand("DELETE FROM users WHERE userid=@userid", mySqlConnection);
            cmd.Parameters.AddWithValue("@userid", int.Parse(userid_text_box.Text));
            cmd.ExecuteNonQuery();

            mySqlConnection.Close();
            MessageBox.Show("Sikeres törlés!");
        }
    }
}
