using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MainForm
{
    public partial class PresentationDemo : Form
    {
        public PresentationDemo()
        {
            InitializeComponent();
        }

        bool _isTrue = false;
        byte counter = 1;
        byte counter2 = 1;

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                Random rnd = new Random();
                int randomNum = rnd.Next(0, 38);
                counter++;
                richTextBox1.AppendText($"{counter}) ");
                //listBox1.Items.Add($"{counter - 1}) Movzu {randomNum}");
                //listBox1.Items.Add($" ");

            }
        }
        private void richTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                counter2++;
                richTextBox2.AppendText($"{counter2}) ");
            }
        }


        Random rnd = new Random();
        private void button1_Click(object sender, EventArgs e)
        {

            

            if (richTextBox1.Lines.Length > richTextBox2.Lines.Length)
            {
                MessageBox.Show("Təqdimat sayı tələbə sayından azdır!");
            }

            else if(!_isTrue)
            {
                List<string> StudentsList = new List<string>();
                List<string> PresentationList = new List<string>();



                for (int runs = 0; runs < richTextBox1.Lines.Length; runs++)
                {
                    StudentsList.Add(richTextBox1.Lines[runs]);
                }

                for (int j = 0; j < richTextBox2.Lines.Length; j++)
                {
                    PresentationList.Add(richTextBox2.Lines[j]);
                }

                string[] randomPresentation = PresentationList.OrderBy(x => rnd.Next()).ToArray();

                for (int a = 0; a < richTextBox1.Lines.Length; a++)
                {


                    int indexOfBracket = richTextBox2.Lines[a].LastIndexOf(')');
                    string randomPresentationItem = randomPresentation[a].Substring(indexOfBracket+1);
                    if (randomPresentationItem.Contains(')'))
                    {
                       randomPresentationItem = randomPresentationItem.Replace(')',' ');

                    }

                    listBox1.Items.Add(StudentsList[a] + "  >>  " + randomPresentationItem);

                }

                _isTrue = true;
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            _isTrue = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (listBox1.Items.Count == 0)
            {
                MessageBox.Show("Nəticə Listi boşdur!");
            }
            else
            {
                foreach (string s in listBox1.Items)
                {
                    stringBuilder.AppendLine(s);
                }
                Clipboard.SetText(stringBuilder.ToString());
                MessageBox.Show("Nəticələr Kopyalandı!");
            }

        }
    }
}
