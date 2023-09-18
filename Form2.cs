using AxWMPLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WMPLib;

namespace Project_Music_Player
{
    public partial class frmmultipletrack : Form
    {
        public frmmultipletrack()
        {
            InitializeComponent();
        }

        Dictionary<int, AxWindowsMediaPlayer> wmplist;
        public static Dictionary<string, string> musics;
        bool changed = true;
        int _index = 1;
        public static string songname = "null";

        enum controls
        {
            remove, pause, play, putonmainscreen
        }



        //O(n)
        private void Frmmultipletrack_Load(object sender, EventArgs e)    
        {
            //specify the path of the directory that you have the files in
            // or just comment this function body and add file manually in runtime using the import button
            
            
            wmplist = new Dictionary<int, AxWindowsMediaPlayer>();
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
            try
            {
                wmplayer.URL = musics[songlist.SelectedItems[0].Text];
            }
            catch (Exception) { }
        }

        //O(1)
        private void Wmpplayer_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (wmplayer.playState == WMPPlayState.wmppsStopped && changed)
            {
                changed = false;
                wmplayer.URL = musics[songlist.Items[((songlist.SelectedIndices[0] + 1) % songlist.Items.Count)].Text];
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
            if (clear)
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
                if (item.Key.Contains(name))
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

            List<string> names = newnames.ToList();


            Fill_songlist(false, names);
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

            string item_to_search = textBox1.Text.ToLower();

            foreach (var name in musics)
                if (name.Key.ToLower().Contains(item_to_search))
                    names.Add(name.Key);

            Fill_songlist(true, names);
        }

        //O(n)
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
        private void Button3_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();

            form3.ShowDialog();

            if (songname == "null") return;


            listBox1.Items.Add(new ListViewItem(_index.ToString() + "-" + songname) { Tag = _index });

            
            wmplist.Add(_index, new AxWindowsMediaPlayer());

            wmplist[_index].CreateControl();
            wmplist[_index].URL = musics[songname];
            
            _index++;
        }

        //O(1)
        private void Frmmultipletrack_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        //O(1)
        private int Return_song_index_from_the_multi_track()
        {
            return Convert.ToInt32(((ListViewItem)listBox1.SelectedItems[0]).Tag);
        }

        //O(1)
        private void Edit_track(controls control)
        {
            int index = Return_song_index_from_the_multi_track();


            switch (control)
            {
                case controls.remove:
                    wmplist[index].close();
                    wmplist[index].Dispose();
                    wmplist[index] = null;
                    listBox1.Items.Remove(listBox1.SelectedItems[0]);
                    break;

                case controls.pause:
                    wmplist[index].Ctlcontrols.pause();
                    break;

                case controls.play:
                    wmplist[index].Ctlcontrols.play();
                    break;

                case controls.putonmainscreen:
                    wmplayer.URL = wmplist[index].URL;
                    break;
            }
        }

        //O(1)
        private void RemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Edit_track(controls.remove);
        }

        //O(1)
        private void PauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Edit_track(controls.pause);
        }

        //O(1)
        private void PlayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Edit_track(controls.play);
        }

        //O(1)
        private void PutOnMainScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Edit_track(controls.putonmainscreen);
        }

        //O(1)
        private void Wmpplayer_ClickEvent(object sender, AxWMPLib._WMPOCXEvents_ClickEvent e)
        {
            if (wmplayer.playState == WMPPlayState.wmppsPaused)
                wmplayer.Ctlcontrols.play();
            else
                wmplayer.Ctlcontrols.pause();
        }

        private void Songlist_DrawItem(object sender, DrawListViewItemEventArgs e)
        {

        }
    }
}
