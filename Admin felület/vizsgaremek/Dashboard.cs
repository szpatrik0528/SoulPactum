using MySql.Data.MySqlClient;
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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void insert_btn_Click(object sender, EventArgs e)
        {
            string mysqlconn = "server=127.0.0.1;user=root;database=soulpactum;password=";
            MySqlConnection mySqlConnection = new MySqlConnection(mysqlconn);
            MySqlCommand cmd = new MySqlCommand("INSERT INTO rendeles (userid, termekid, datum, osszeg) VALUES (@userid, @termekid, @datum, @osszeg)", mySqlConnection);

            try
            {
                mySqlConnection.Open();

                // Ellenőrizzük, hogy a megadott adatok érvényesek-e
                int userId, productId, amount;
                if (!int.TryParse(user_id_tb.Text, out userId) ||
                    !int.TryParse(skin_id_tb.Text, out productId) ||
                    !int.TryParse(osszeg_tb.Text, out amount))
                {
                    MessageBox.Show("Érvénytelen adatok.");
                    return;
                }

                // Dátum formátum ellenőrzése és konvertálása
                DateTime datum;
                if (!DateTime.TryParse(datum_tb.Text, out datum))
                {
                    MessageBox.Show("Érvénytelen dátum formátum.");
                    return;
                }

                cmd.Parameters.AddWithValue("@userid", userId);
                cmd.Parameters.AddWithValue("@termekid", productId);
                cmd.Parameters.AddWithValue("@datum", datum);
                cmd.Parameters.AddWithValue("@osszeg", amount);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Sikeresen mentve!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt: " + ex.Message);
            }
            finally
            {
                mySqlConnection.Close();
            }
        }


        private void update_brn_Click(object sender, EventArgs e)
        {
            try
            {
                string mysqlconn = "server=127.0.0.1;user=root;database=soulpactum;password=";
                MySqlConnection mySqlConnection = new MySqlConnection(mysqlconn);
                mySqlConnection.Open();
                MySqlCommand cmd = new MySqlCommand("update rendeles set userid=@userid, rendeles_id=@rendeles_id, datum=@datum, osszeg=@osszeg WHERE rendeles_id = " + rendeles_id_tb.Text, mySqlConnection);
                //cmd.Parameters.AddWithValue("@rendeles_id", int.Parse(rendeles_id_tb.Text));
                cmd.Parameters.AddWithValue("@userid", int.Parse(user_id_tb.Text));
                cmd.Parameters.AddWithValue("@rendeles_id", int.Parse(skin_id_tb.Text));
                cmd.Parameters.AddWithValue("@datum", DateTime.Parse(datum_tb.Text));
                cmd.Parameters.AddWithValue("@osszeg", int.Parse(osszeg_tb.Text));
                cmd.ExecuteNonQuery();


                mySqlConnection.Close();
                MessageBox.Show("Sikeresen átírva!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt: " + ex.Message);
            }
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            string mysqlconn = "server=127.0.0.1;user=root;database=soulpactum;password=";
            MySqlConnection mySqlConnection = new MySqlConnection(mysqlconn);
            mySqlConnection.Open();

            MySqlCommand cmd = new MySqlCommand("DELETE FROM rendeles WHERE rendeles_id=@rendeles_id", mySqlConnection);
            cmd.Parameters.AddWithValue("@rendeles_id", int.Parse(rendeles_id_tb.Text));
            cmd.ExecuteNonQuery();

            mySqlConnection.Close();
            MessageBox.Show("Sikeres törlés!");

        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            if (rendeles_id_tb.Text == "")
            {

                string mysqlconn = "server=127.0.0.1;user=root;database=soulpactum;password=";
                MySqlConnection mySqlConnection = new MySqlConnection(mysqlconn);
                mySqlConnection.Open();

                MySqlCommand cmd = new MySqlCommand("Select * from rendeles", mySqlConnection);

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

                MySqlCommand cmd = new MySqlCommand("Select * from rendeles where rendeles_id=@rendeles_id", mySqlConnection);
                cmd.Parameters.AddWithValue("@rendeles_id", int.Parse(rendeles_id_tb.Text));
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            rendeles_id_tb.Clear();
            user_id_tb.Clear();
            skin_id_tb.Clear();
            datum_tb.Clear();
            osszeg_tb.Clear();
        }

        private void log_out_btn_Click(object sender, EventArgs e)
        {
            Dashboard dsb = new Dashboard();
            this.Close();
            Form1 form1 = new Form1();
            form1.Show();
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                rendeles_id_tb.Text = row.Cells["rendeles_id"].Value.ToString();
                user_id_tb.Text = row.Cells["userid"].Value.ToString();
                skin_id_tb.Text = row.Cells["rendeles_id"].Value.ToString();
                datum_tb.Text = row.Cells["datum"].Value.ToString();
                osszeg_tb.Text = row.Cells["osszeg"].Value.ToString();
            }
        }
    }
}
