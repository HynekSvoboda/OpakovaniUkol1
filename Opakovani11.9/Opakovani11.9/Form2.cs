using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Opakovani11._9
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.CenterToScreen();
        }


        void PoslPrvocislo(int[] vstup, out int posledni, out int index)
        {
            posledni=0;
            index = 0;
            bool pomoc = false;
            for (int i = 0; i < vstup.Count(); i++)
            {
                pomoc = false;
                int cislo = vstup[i];
                if (cislo != 1)
                {
                    if (cislo != 2)
                    {


                        for (int delitel = 2; delitel <= (int)Math.Sqrt(cislo); ++delitel)
                        {
                            if (cislo % delitel == 0)
                            {
                                pomoc = false;
                                break;
                            }
                            else pomoc = true;
                        }
                    } else if(cislo==2) pomoc = true; 
                }
                if(pomoc)
                {
                    posledni = cislo;
                    index = i;
                }
            }
        }

        void Vypis(ListBox toto, int []vstup)
        {
            for (int i = 0; i < vstup.Count(); i++)
            {
                toto.Items.Add(vstup[i]);
            }
        }

        void Vymen(int[] vstup)
        {
            int prvni = vstup[0];
            int posledni = vstup[vstup.Count()-1];
            vstup[0] = posledni;
            vstup[vstup.Count() - 1] = prvni;
        }

        string Maximalni(string vstup)
        {
            while(vstup.Contains("  "))
            {
                vstup=vstup.Replace("  ", " ");
            }
            string[]pole=vstup.Split(' ');
            string pomocna = "";
            for(int i=0;i<pole.Count();i++)
            {
                if (pomocna.Length < pole[i].Length) pomocna = pole[i];
            }
            return pomocna;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            int n = Convert.ToInt32(numericUpDown1.Value);
            int[]pole=new int[n];
            Random rng=new Random();
            for(int i= 0;i<n;i++)
            {
                pole[i] = rng.Next(1, 26);
                listBox1.Items.Add(pole[i]);
            }
            int posledni;
            int index;
            PoslPrvocislo(pole, out posledni, out index);
            if(posledni!=0) MessageBox.Show("Poslední prvočíslo před výměnou: "+posledni.ToString()+" a jeho pořadí (počítáno od 1): "+(index+1).ToString(),"INFO");
            Vymen(pole);
            Vypis(listBox2, pole);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            MessageBox.Show("Nejdelší slovo: "+Maximalni(text),"INFO");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Příklad 2. Metoda PoslPrvocislo, která zjistí, zda se v poli nachází prvočíslo, vrátí poslední prvočíslo a jeho pozici Metoda Vymen, vymění první prvek pole s posledním prvkem pole Metoda Vypis, zapíše do zadaného Listbox všechna čísla z pole. Button1 Vytvořte pole N náhodných celých čísel z intervalu (0,25&gt; a zavolejte dané metody. A metodu Vypis dvakrát Metoda Maximalni, která pro zadaný řetězec slov vrátí nejdelší slovo obsahující podřetězec zadaný jako parametr. Button2 Na vstupu je řetězec slov obsahující libovolný počet mezer. Zavolejte metodu Maximalni", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
