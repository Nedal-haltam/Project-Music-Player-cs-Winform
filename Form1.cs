using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using WMPLib;


namespace Project_Music_Player
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Dictionary<string, string> musics;
        bool changed = true;


        //O(n)
        private void Form1_Load(object sender, EventArgs e)
        {
            //specify the path of the directory that you have the files on
            // or just comment this body and add file in runtime using the add button

            musics = new Dictionary<string, string>();

            ////DirectoryInfo directory = new DirectoryInfo("D:\\Musics\\Musics");
            ////FileInfo[] files = directory.GetFiles();

            ////foreach (FileInfo item in files)
            ////    musics.Add(item.Name, item.FullName);

            ////Fill_songlist(false, musics.Keys.ToList());

        }

        //O(1)
        private void Songlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            wmplayer.URL = musics[songlist.SelectedItem.ToString()];
        }

        //O(1)
        private void Songlist_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            //if the item state is selected them change the back color 
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                e = new DrawItemEventArgs(e.Graphics,
                                          e.Font,
                                          e.Bounds,
                                          e.Index,
                                          e.State ^ DrawItemState.Selected,
                                          e.ForeColor,
                                          Color.Chocolate);


            e.DrawBackground();
            e.Graphics.DrawString(songlist.Items[e.Index].ToString(), e.Font, Brushes.Black, e.Bounds, StringFormat.GenericDefault);
            e.DrawFocusRectangle();
        }

        //O(1)
        private void Wmpplayer_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (wmplayer.playState == WMPPlayState.wmppsStopped && changed)
            {
                changed = false;
                songlist.SelectedIndex = (songlist.SelectedIndex + 1) % songlist.Items.Count;
            }

            if (wmplayer.playState == WMPPlayState.wmppsStopped)
            {
                changed = true;
                wmplayer.Ctlcontrols.play();
            }
        }

        //O(n)
        private void Fill_songlist(bool clear, List<string> names = null)
        {
            if(clear)
                songlist.Items.Clear();
            

            if (names != null)
                foreach (string name in names)
                    songlist.Items.Add(name);

            else
                foreach (var name in musics)
                    songlist.Items.Add(name.Key);


        }

        //O(n)
        private string Number_of_this_item_in_list(string name)
        {
            int c = 0;
            foreach (var item in musics)
                if(item.Key.Contains(name))
                    c++;
            return c.ToString();
        }

        //O(nm)  m: newnames
        private void Add_new_items(string[] newnames, string[] newpaths)
        {
            for (int i = 0; i < newnames.Length; i++)
            {
                if (musics.ContainsKey(newnames[i]))
                    newnames[i] += "(" + Number_of_this_item_in_list(newnames[i]) + ")";

                musics.Add(newnames[i], newpaths[i]);
            }


            Fill_songlist(false, newnames.ToList());
        }

        //O(n)
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrWhiteSpace(textBox1.Text))
            {
                Fill_songlist(true);
                return;
            }

            
            List<string> names = new List<string>();

            foreach (var name in musics)
                if (name.Key.ToLower().Contains(textBox1.Text.ToLower()))
                    names.Add(name.Key);


            Fill_songlist(true, names);
        }

        //O(m)
        private void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog
            {
                Multiselect = true
            };
            if (fd.ShowDialog() == DialogResult.OK)
            {
                string[] newnames = fd.SafeFileNames;
                string[] newpaths = fd.FileNames;

                Add_new_items(newnames, newpaths);
            }

        }

        //O(1)
        private void Button1_Click_1(object sender, EventArgs e)
        {
            frmmultipletrack mtm = new frmmultipletrack();

            wmplayer.close();
            
            this.Hide();
            
            mtm.Show();
        }

        //O(1)
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        //O(1)
        private void Wmpplayer_ClickEvent(object sender, AxWMPLib._WMPOCXEvents_ClickEvent e)
        {
            
            if (wmplayer.playState == WMPPlayState.wmppsPaused)
                wmplayer.Ctlcontrols.play();
            else
                wmplayer.Ctlcontrols.pause();
        }


    }
}
