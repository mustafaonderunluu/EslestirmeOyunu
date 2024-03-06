﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EşleştirmeOyunu
{
    public partial class Form1 : Form
    {
        Label etk_1 = null;
        Label etk_2 = null;

        Random Random = new Random();
        List<string> icons = new List<string>() {


            "!","!","N","N",
            ",",",","k","k",
            "b","b","v","v",
            "w","w","z","z",

        };
        private void HucrelereResimAta(){

            foreach (Control etk in tableLayoutPanel1.Controls) //Formun içindeki .control dediğimiz de otomatik olarak içindeki herşeyi alır.  
            { 
            
            Label resEtk = etk as Label;
                if (resEtk != null)
                {

                    int rs = Random.Next(icons.Count);
                    resEtk.Text = icons[rs];
                   resEtk.ForeColor = resEtk.BackColor;
                    icons.RemoveAt(rs);

                }
                
            
            
            
            }
        
        }

        public Form1()
        {
            InitializeComponent();
            HucrelereResimAta();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            LabelClick(sender, e);
        }

        private void LabelClick(object sender, EventArgs e)
        {
            if (timer1.Enabled == true) {

                return;
            
            
            }
            Label secilenEtiket = sender as Label;      //clicklenme olayında hangi obje clicklendiyse o obje  senderin içerisinde sakllanır. 
            if (secilenEtiket != null) {

                if (secilenEtiket.ForeColor == Color.Black) {

                    return;
                
                }
                if (etk_1 == null) {

                    etk_1 = secilenEtiket;
                    etk_1.ForeColor = Color.Black;
                    return;
                
                }       
                etk_2 = secilenEtiket;
                etk_2.ForeColor = Color.Black;
                oyunBittimi();
                if (etk_1.Text == etk_2.Text) {

                    etk_1 = null;
                    etk_2=null;
                    return;
                        
                
                }
                timer1.Start(); 
            }
        }
        private void oyunBittimi ()
        {
            foreach (Control etk in tableLayoutPanel1.Controls) {
            
            Label restEtk = etk as Label;
                if (restEtk != null) { 
                
                if (restEtk.ForeColor == restEtk.BackColor) {

                        return;
                    
                    
                    }
                
                
                }
            
            
            }
            MessageBox.Show("Oyun Bitti");
            Close();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            etk_1.ForeColor = etk_1.BackColor;
            etk_2.ForeColor = etk_2.BackColor;
            etk_1=null;
            etk_2=null;
        }
    }
}
