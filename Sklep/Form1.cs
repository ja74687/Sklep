using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sklep
{
    public partial class Form1 : Form
    {
       static DataTable produkty;
        static DataGridView tab;
        DataTable koszykLista;
        Magazyn magazyn;
        public Form1()
        {
            InitializeComponent();
            produkty = new DataTable();
            produkty.Columns.Add("Nazwa");
            produkty.Columns.Add("Ilosc");
            dataGridView1.DataSource = produkty;
            tab = dataGridView1;
            magazyn = new Magazyn();
            koszykLista = new DataTable();
            
        }

        class Produkt
        {
            public string nazwa { get; set; }
            public int ilosc { get; set; }
        }

        class Magazyn
        {
            List<Produkt> produktyMagazyn = new List<Produkt>();
            public void dodaj(Produkt nowy)
            {
                produktyMagazyn.Add(nowy);
            }

            public void aktualizujKupuj(Produkt kupiony)
            {
                string nazwaEdutuj = kupiony.nazwa;
                int ilosc = kupiony.ilosc;
                produktyMagazyn.Where(edit => edit.nazwa == nazwaEdutuj).First().ilosc = (ilosc - 1);
            }
            public void wyswietlProdukty()
            {
                produkty.Clear();
                foreach (Produkt dane in produktyMagazyn)
                {
                    produkty.Rows.Add(dane.nazwa, dane.ilosc);
                }
                tab.DataSource = produkty;
                
            }
        }

        class koszyk

        private void button1_Click(object sender, EventArgs e)
        {
            string nazwaBox = textBox1.Text;
            int ilosc = Convert.ToInt32(textBox2.Text);
            Produkt nowy = new Produkt();
            nowy.nazwa = nazwaBox;
            nowy.ilosc = ilosc;
            magazyn.dodaj(nowy);
            magazyn.wyswietlProdukty();   
        }
    }
}
