using System;
using System.Windows.Forms;
using Cripto;

namespace Aps_visual
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private int x; 

        private void btncifrar_Click(object sender, EventArgs e)
        {
            string palavraenv, palavrarece;     // palavraenv para enviar, palavrarece para receber
             string condição = "cifrar";         // condição para o arquivo Cript.cs para cifrar ou decifrar 

            palavraenv = Convert.ToString(TextBox1.Text);   // palavraenv recebe o texto da textBox1
        
            this.x = palavraenv.Length;         // enviando a quandidade de caracteres para o objeto x

            // palavrarece recebe o texto string retornado pelo método script da classe arqc

            palavrarece = arqc.script(palavraenv, condição, this.x);

            // imprime nas textview2 e 3 o texto retornado

            TextBox2.Text = palavrarece;
            TextBox3.Text = palavrarece;
        }
                               

        private void btndecifrar_Click(object sender, EventArgs e)
        {
            string palavracomp, palavralimp;  // palavracomp recebe a palavra composta da textview, 
                                          // palavralimp recebe texto decifrado
            string condição = "decifrar";     // condição decifrar ao método script
       
            palavracomp = Convert.ToString(TextBox2.Text); // palavracomp recebe texto composto

            // palavralimp recebe a string do método script da class arqc que retornará o texto decifrado

            palavralimp = arqc.script(palavracomp, condição, this.x);

            TextBox3.Text = palavralimp; // Imprime a palavralimp na textview 3
        }

    }

 }

