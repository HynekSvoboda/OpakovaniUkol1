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

            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
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
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            button7.Visible = true;
            cisla.Clear();
            listBox1.Items.Clear();
            try
            {
                int n = Convert.ToInt32(textBox1.Text);
                Random rng = new Random();
                for (int i = 0; i < n; i++)
                {
                    cisla.Add(rng.Next(-4, 101));
                }
                Vypis(listBox1, cisla);
            }
            catch { 
                MessageBox.Show("Zadej číslo :D", "ERROR");
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
                button6.Visible = false;
                button7.Visible = false;
            }
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
            znaky.Clear();
            listBox4.Items.Clear();
            for (int i=0;i<cisla.Count();i++)
            {
                char znak = Convert.ToChar(cisla[i]);
                if (znak >= 'A' && znak <= 'Z') znaky.Add(znak);
                else znaky.Add('*');
                listBox4.Items.Add(znaky[i]);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Vytvořte metodu pro výpis čísel z Listu do daného ListBoxu.\r\nVytvořte metodu, která vrátí druhé maximální číslo. (Pouze jeden cyklus, bez použití metod)\r\nVytvořte metodu dokonale, která pro dané číslo vrací bool. Číslo je dokonalé pokud součet\r\njeho dělitelů se rovná danému číslu (např. číslo 6 má dělitele 1,2,3 – součet 1+2+3=6)\r\nVytvořte metodu, která vymaže z Listu všechna dokonalá čísla.\r\nVytvořte metodu, která spočítá ciferný součet z maximálního čísla.\r\n\r\nButton1: Načtěte do Listu1 n náhodných čísel z intervalu (-5,100>, kde n je zadáno\r\nv TextBoxu. Zavolejte metodu výpis, kde čísla vypíšete do ListBox1.\r\nButton2: Zavolejte metodu na smazání všech dokonalých čísel z Listu a metodu výpis a\r\nzobrazte do ListBox2.\r\nButton3: List1 setřiďte a zavolejte metodu výpis do ListBox3.\r\nButton4: Vypište aritmetický průměr všech čísel.\r\nButton5: Zvolejte metodu, pro nalezení druhého maxima a vypište.\r\nButton6: Najděte maximum a zavolejte metodu, která spočítá ciferný součet. Součet vypište.\r\nButton7: Vytvořte List2 charů, který bude odpovídat Listu1 čísel (ascii hodnot). Každé číslo\r\nz Listu1, pokud ascci hodnota odpovídá velkému písmenu, uložte jako písmeno do List2,\r\npokud ne, tak uložte znak * List2 zobrazte do ListBoxu4.", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form f2 =new Form2();
            f2.ShowDialog();
        }
    }
}
