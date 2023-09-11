using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Opakovani11._9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        void Vypis(ListBox toto, List<int> vstup)
        {
            for(int i=0; i<vstup.Count();i++)
            {
                toto.Items.Add(vstup[i]);
            }
        }

        int DruheMax(List<int> vstup)
        {
            int maximum = cisla[0];
            int druhemax = maximum;

            for(int i =0;i<cisla.Count();i++)
            {
                if(cisla[i]> maximum)
                {
                    druhemax = maximum;
                    maximum = cisla[i];
                }
            }
            return druhemax;
        }

        bool Dokonale(int cislo)
        {
            int soucet = 0;
            for(int i=1;i<cislo;i++)
            {
                if(cislo%i==0)
                {
                    soucet += i;
                }
            }
            if (soucet == cislo) return true;
            else return false;
        }

        void VymazDokonala(List<int> cisla)
        {
            for(int i=0;i<cisla.Count();i++)
            {
                if(Dokonale(cisla[i]))
                {
                    cisla.Remove(cisla[i]);
                }
            }
        }

        int CifSouMax(List<int> vstup)
        {
            int max = vstup.Max();

            int soucet = 0;
            int cifra;
            while(max>0)
            {
                cifra = max % 10;
                soucet += cifra;
                max /= 10;
            }
            return soucet;
        }

        List<int> cisla = new List<int>();
        List<char> znaky = new List<char>();
        

        private void button1_Click(object sender, EventArgs e)
        {
            cisla.Clear();
            listBox1.Items.Clear();
            int n = Convert.ToInt32(textBox1.Text);
            Random rng = new Random();
            for(int i=0;i<n;i++)
            {
                cisla.Add(rng.Next(-4, 101));
            }
            Vypis(listBox1,cisla);
            //MessageBox.Show(DruheMax(cisla).ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            VymazDokonala(cisla);
            Vypis(listBox2, cisla);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            cisla.Sort();
            Vypis(listBox3, cisla);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double prumer = 0;
            double soucet = 0;
            double pocet = 0;

            for(int i=0;i<cisla.Count();i++)
            {
                soucet += cisla[i];
                pocet++;
            }
            prumer = soucet / pocet;
            MessageBox.Show(prumer.ToString(), "Aritmetický průměr: ");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show(DruheMax(cisla).ToString(),"Druhé maximum: ");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show(CifSouMax(cisla).ToString(), "Ciferný součet max čísla: ");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listBox4.Items.Clear();
            for (int i=0;i<cisla.Count();i++)
            {
                char znak = Convert.ToChar(cisla[i]);
                if (znak >= 'A' && znak <= 'Z') znaky.Add(znak);
                else znaky.Add('*');
                listBox4.Items.Add(znaky[i]);
            }
        }
    }
}
