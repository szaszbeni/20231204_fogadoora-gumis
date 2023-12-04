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

namespace _20231204_fogadooraa
{
    public partial class Form1 : Form
    {
        static List<Orak> orak = new List<Orak>();
        string[] beolvas;
        public Form1()
        {
            InitializeComponent();
            tbxido.Text = DateTime.Now.Hour.ToString();
            beolvas = File.ReadAllLines("osztalyok.txt");
            Array.Sort(beolvas);
            foreach (var item in beolvas)
            {
                orak.Add(new Orak(item));
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnkilep_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btntorol_Click(object sender, EventArgs e)
        {
            lbxfogadoora.Items.Clear();
        }

        private void lbxtanarok_SelectedIndexChanged(object sender, EventArgs e)
        {
            beolvas = File.ReadAllLines("tanarok.txt");
            foreach (var item in beolvas)
            {
                lbxtanarok.Items.Add(item);
            }
        }
    }
}
