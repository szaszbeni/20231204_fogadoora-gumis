using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _20231113_gumis
{
    public partial class Form1 : Form
    {
        static List<Munkak> munka = new List<Munkak>();
        string[] beolvas;
        public Form1()
        {
            InitializeComponent();
            tbxdatum.Text = DateTime.Today.Date.ToString("yyy.MMM.dd");
            tbxora.Text = DateTime.Now.Hour.ToString();
            beolvas = File.ReadAllLines("enberek.txt");
            Array.Sort(beolvas);
            foreach (var item in beolvas)
            {
                munka.Add(new Munkak(item));
            }
            ElojegyzettMunkak();
            Orak();
        }
        private void Orak()
        {
            lbxoradb.Items.Clear();
            int[] db = new int[6];
            foreach (var item in munka)
            {
                if(item.datum==tbxdatum.Text)
                {
                    switch (item.ora)
                    {
                        case "06:00":
                            db[0]++;
                            break;
                        case "07:00":
                            db[1]++;
                            break;
                        case "08:00":
                            db[2]++;
                            break;
                        case "09:00":
                            db[3]++;
                            break;
                        case "10:00":
                            db[4]++;
                            break;
                        case "11:00":
                            db[5]++;
                            break;
                        case "12:00":
                            db[6]++;
                            break;
                        case "13:00":
                            db[7]++;
                            break;
                        case "14:00":
                            db[8]++;
                            break;
                        case "15:00":
                            db[9]++;
                            break;
                        case "16:00":
                            db[10]++;
                            break;
                        case "17:00":
                            db[11]++;
                            break;
                        default:
                            break;
                    }
                }
            }
            for (int i = 0; i < db.Length; i++)
            {
                lbxoradb.Items.Add(i+6+": "+db[i]+" db");
            }
        }
        private void btnkilep_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btntorol_Click(object sender, EventArgs e)
        {
            lbxmunka.Items.Clear();
        }

        private void tbx1_TextChanged(object sender, EventArgs e)
        {
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void tbx4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnkeres_Click(object sender, EventArgs e)
        {
            if (tbxdatum.Text!="")
            {
                ElojegyzettMunkak();
                Orak();
            }
            else if (tbxnev.Text != "")
            {
                lbxmunka.Items.Clear();
                Array.Reverse(beolvas);
                foreach (var item in beolvas)
                {
                    if (item.Contains(tbxnev.Text))
                    {
                        lbxmunka.Items.Add(item.Replace(";"," "));
                    }
                }
                Array.Sort(beolvas);
            }
            else if (tbxrszam.Text!="")
            {
                foreach (var item in beolvas)
                {
                    if (item.Contains(tbxrszam.Text))
                    {
                        lbxmunka.Items.Add(item.Replace(";", " "));
                    }
                }
            }
            else if (tbxrszam.Text != "")
            {
                foreach (var item in beolvas)
                {
                    if (item.Contains(tbxtell.Text))
                    {
                        lbxmunka.Items.Add(item.Replace(";", " "));
                    }
                }
            }
        }

        private void tbxora_TextChanged(object sender, EventArgs e)
        {

        }
        private void ElojegyzettMunkak()
        {
            lbxmunka.Items.Clear();
            foreach (Munkak item in munka)
            {
                if (item.datum == tbxdatum.Text.ToString())
                {
                    string ki = item.datum + " " + item.ora + " " + item.nev + " " + item.tell + " " + item.rendszam;
                    lbxmunka.Items.Add(item.datum);
                }
            }
        }

        private void btnment_Click(object sender, EventArgs e)
        {
            if (tbxdatum.Text!="" && tbxora.Text!="" && tbxnev.Text!="" && tbxtell.Text!= "" && tbxrszam.Text!= "")
            {
                string kiir = tbxdatum.Text + ";" + tbxora.Text + ":00;" + tbxnev.Text + ";" + tbxtell.Text + ";" + tbxrszam.Text + "\n";
                File.AppendAllText("emberek.txt", kiir);
                lbxmunka.Items.Clear();
                lbxoradb.Items.Clear();
                Form1 f = new Form1();
                f.Show();
                this.Hide();
                f.Show();
            }
            else
            {
                MessageBox.Show("Valami ühkes");
            }
        }
    }
}
