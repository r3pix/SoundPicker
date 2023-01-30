using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
 
using System.Media;
using System.IO;
using System.Security.Cryptography;

namespace SoundPicker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Label mylab1 = new Label();
        private Mp3Player mp3Player = new Mp3Player();
        private bool isPlaying = false;
        private List<string> filesFound;
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!isPlaying)
            {
                if (filesFound != null && filesFound.Any())
                {
                    var index = new Random().Next(0, filesFound.Count - 1);
                    if (File.Exists(filesFound[index]))
                    {
                        mp3Player.Dispose();
                        mp3Player.open(filesFound[index]);
                        mp3Player.play();
                        isPlaying = true;
                        
                        mylab1.Text = Path.GetFileNameWithoutExtension(filesFound[index]);
                        mylab1.Location = new Point(200, 130);
                        mylab1.AutoSize = true;
                        mylab1.BorderStyle = BorderStyle.Fixed3D;
                        mylab1.Font = new Font("Calibri", 18);
                        mylab1.Padding = new Padding(6);
                        this.Controls.Add(mylab1);
                    }

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var dfd = new FolderBrowserDialog())
            {
                DialogResult result = dfd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(dfd.SelectedPath))
                { 
                    this.filesFound = Directory.GetFiles(dfd.SelectedPath).ToList();
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (isPlaying)
            {
                mp3Player.stop();
                isPlaying = false;
            }
        }
    }
}
