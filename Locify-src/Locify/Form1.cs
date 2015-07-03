using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SpotifyLibDotNET;
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace Locify
{
    public partial class Form1 : Form
    {
        const double _version = 0.3;

        Spotify spotify;
        
        public Form1()
        {
            InitializeComponent();

            Text = "Locify";

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            spotify = new Spotify(true);
            backgroundWorker1.RunWorkerAsync();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (spotify.IsPaused)
                spotify.Resume();
            spotify.PlaySong();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {

                try
                {
                    BeginInvoke(new Action(() =>
                        {
                            playingLabel.Text = spotify.GetPlayingStatus();

                            Text = "Locify (" + spotify.DisplayQueue().Count + ") - " + spotify.GetPlayingStatus();

                            listBox1.Items.Clear();
                            foreach (string s in spotify.DisplayQueue())
                            {
                                listBox1.Items.Add(s);
                            }
                        }));
                }
                catch
                { }

                Thread.Sleep(2500);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Really?", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                listBox1.Items.Clear();
            }
        }

        private void openBannedSongsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("bannedsongs.txt");
            }
            catch { MessageBox.Show("Missing file"); }
        }

        private void openBannedIpsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("bannedips.txt");
            }
            catch { MessageBox.Show("Missing file"); }
        }

        private void openVisitedIpsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("visitedips.txt");
            }
            catch { MessageBox.Show("Missing file"); }
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            spotify.RemoveQueueAt(listBox1.SelectedIndex);
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }

        private void saveQueueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.WriteAllLines("queue.txt", spotify.DisplayQueue().ToArray());
            System.Environment.Exit(1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "Pause")
            {
                button3.Text = "Resume";
                spotify.Pause();
            }
            else
            {
                button3.Text = "Pause";
                spotify.Resume();
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
