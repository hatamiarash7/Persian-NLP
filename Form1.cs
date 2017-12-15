using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NHazm;

namespace Persian_NLP
{
    public partial class Form1 : Form
    {
        string[] lines;
        Normalizer normalizer;
        SentenceTokenizer senTokenizer;
        WordTokenizer wordTokenizer;
        POSTagger tagger;
        public Form1()
        {
            InitializeComponent();
            lines = System.IO.File.ReadAllLines("stopwords.txt");
            normalizer = new Normalizer(true, false, false);
            senTokenizer = new SentenceTokenizer();
            wordTokenizer = new WordTokenizer(true);
            tagger = new POSTagger();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            string input = textBox1.Text;
            string[] output = senTokenizer.Tokenize(input).ToArray();
            for (int i = 0; i < output.Length; i++)
            {
                textBox2.Text = textBox2.Text + output[i] + Environment.NewLine;
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            string input = textBox1.Text;
            string[] output = senTokenizer.Tokenize(input).ToArray();
            for (int i = 0; i < output.Length; i++)
            {
                string[] final = wordTokenizer.Tokenize(output[i]).ToArray();
                for (int j = 0; j < final.Length; j++)
                {
                    textBox2.Text = textBox2.Text + final[j] + Environment.NewLine;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            string input = textBox1.Text;
            string[] output = senTokenizer.Tokenize(input).ToArray();
            for (int i = 0; i < output.Length; i++)
            {
                string[] final = wordTokenizer.Tokenize(output[i]).ToArray();
                for (int j = 0; j < final.Length; j++)
                {
                    if (!lines.Contains(final[j]))
                        textBox2.Text = textBox2.Text + final[j] + Environment.NewLine;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            string input = textBox1.Text;
            string[] output = senTokenizer.Tokenize(input).ToArray();
            string[] removed;
            List<string> temp = new List<string>();
            for (int i = 0; i < output.Length; i++)
            {
                string[] final = wordTokenizer.Tokenize(output[i]).ToArray();
                for (int j = 0; j < final.Length; j++)
                {
                    if (!lines.Contains(final[j]))
                        temp.Add(final[j]);

                }
            }
            removed = temp.ToArray();
            POSTagger posTagger = new POSTagger();
            //posTagger.BatchTag(removed).t;
        }
    }
}
