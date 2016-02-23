using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Globalization;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Replace("   "," ");
            textBox1.Text = textBox1.Text.Replace("  "," ");
            textBox1.Text = textBox1.Text.Replace("  "," ");
            textBox1.Text = textBox1.Text.Replace("-", "");
            string[] spilts = textBox1.Text.Split(new Char[] { ' ','\t' });
            int i = spilts.Length;
            spilts[2] = spilts[2].Remove(2);
            spilts[1] = spilts[1].Remove(5);
            spilts[10] = spilts[10].Replace(".", ",");
            double orbit = Double.Parse(spilts[10].Replace(".",","));
            int year = Int32.Parse(spilts[2]);
            if(year < 57)
            {
                year += 2000;
            }
            else
            {
                year += 1900;
            }
            //spilts[15] = spilts[15].Remove(11);
            textBox3.Text = spilts[15];
            spilts[12] = ("0." + spilts[12]);
            textBox2.Text = (" "+i);
            for (int x = 0; x < spilts.Length; x++)
            {
               listBox1.Items.Add(spilts[x]+"("+x+")");
            }
            
            string s = spilts[15];
            string s1 = spilts[12];
            s.Replace('.',',');
            s1.Replace('.', ',');
            double Revday = double.Parse(s.Replace('.', ','));
            double Ecc = double.Parse(s1.Replace('.', ','));
       
            double apogee = (0.0743668 / Revday);
            
            apogee = apogee * 229.18311;
           
            apogee = Math.Pow(apogee, 2.0);
            
            apogee = Math.Pow(apogee, (1/3.0));
           
            apogee = apogee * (1 + Ecc);
           
            apogee = apogee - 1;
           
            apogee = apogee * 6378.15;
           

         
            double perigee = (0.0743668 / Revday);
          
            perigee = perigee * 229.18311;
           
            perigee = Math.Pow(perigee, 2.0);
          
            perigee = Math.Pow(perigee, (1 / 3.0));
           
            perigee = perigee * (1 - Ecc);
           
            perigee = perigee - 1;
        
            perigee = perigee * 6378.15;
            

            
            textBox2.Text = (
                "Параметры орбиты:      "+
                "Апогей:" + Math.Round(apogee)+" км               "+
                "Перигей:" + Math.Round(perigee)+" км                    "+
                "Наклонение: "+Math.Round(orbit)+"°                      "+
               "Год запуска: "+ year+"              "+
               "Номер объекта (в каталоге NORAD): "+spilts[1]);
            
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox2.Text);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        
    }
}
