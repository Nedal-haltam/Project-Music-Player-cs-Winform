using System;
using System.Windows.Forms;

namespace Project_Music_Player
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }


        private void Button2_Click(object sender, EventArgs e)
        {
            frmmultipletrack.songname = "null";
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if(listBox2.SelectedIndex == -1)
            {
                MessageBox.Show("No selected Item" , "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            frmmultipletrack.songname = listBox2.SelectedItem.ToString();
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            foreach(var item in frmmultipletrack.musics)
                listBox2.Items.Add(item.Key);

            listBox2.SelectedIndex = -1;
        }
    }
}
