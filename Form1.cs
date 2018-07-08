using System;
using IniFile;
using System.Runtime.InteropServices;
using System.Collections;
using Microsoft.VisualBasic;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace IniFile
    
{
    public partial class Form1 : Form
    {
        string name = "";
        string gender = "";
        int tex;
        string path = @"D:\Arun\IniFile\IniFile\bin\Debug";


        public Form1()
        {
            InitializeComponent();

        }
       

        
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // For Color Dialog in form
           /* ColorDialog dlg = new ColorDialog();
            dlg.ShowDialog();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = colorDialog1.Color;
            }*/

            // To write values in INI Reader
            string name = textBox1.Text;
            Console.WriteLine(name);
            string gender = "";
            
            bool isChecked = radioButton1.Checked;
                if (isChecked)
                    gender = radioButton1.Text;
                else 
                    gender = radioButton2.Text;


            int tex = Int32.Parse(textBox2.Text);
            Console.WriteLine(gender);
            Console.WriteLine(tex);

            IniFile ob = new IniFile("D:\\tp.ini");
            ob.IniWriteValue("USERNAME","NAME",name);
            ob.IniWriteValue("PERSONAL INFO", "GENDER", gender);
            ob.IniWriteValue("PERSONAL INFO", "AGE", tex.ToString());



        }
        
        

        private void Form1_Load(object sender, EventArgs e)
        {
           
            //To read and display each value along with default condition 
            String name1 = "default";
            int age = 0;
            IniFile ob = new IniFile("D:\\tp.ini");
            String str1 = ob.IniReadValue("USERNAME", "NAME");
            textBox1.Text = str1;
            if (str1 == "") //default values
            {
                textBox1.Text = name1;
            }

            String str2 = ob.IniReadValue("PERSONAL INFO", "GENDER");
            if (str2 == "Male")
            {
                radioButton1.Checked = true;
            }
            else
                radioButton2.Checked = true;
            if (str2 == "") //default values
            {
                radioButton1.Checked = true;
            }


            String str3 = ob.IniReadValue("PERSONAL INFO", "AGE");
            textBox2.Text = str3;
            if ( str3 == "") //default values
            {
                textBox2.Text = age.ToString();
            }

            


        }
       

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            button1_Click_1(sender, e);
        }
    }
     
    }


