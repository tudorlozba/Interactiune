using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AnimalSoundMatching
{
    public partial class Form1 : Form
    {

        Random rnd = new Random();
        List<String> images;
        List<String> sounds;
        public Form1()
        {
            InitializeComponent();
            images = new List<string> { "cat.jpg", "dog.jpg", "goat.jpg", "rooster.jpg", "sheep.png"};
            sounds = new List<string> { "cat.wav", "dog.wav", "goat.wav", "rooster.wav", "sheep.wav" };

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<int> picturesIndex = new List<int>(3);

           picturesIndex.Add(rnd.Next(0, images.Count));
           picturesIndex.Add(rnd.Next(0, images.Count));
           picturesIndex.Add(rnd.Next(0, images.Count));

           loadPictureInPictureBox(pictureBox1, images[picturesIndex[0]]);
           loadPictureInPictureBox(pictureBox2, images[picturesIndex[1]]);
           loadPictureInPictureBox(pictureBox3, images[picturesIndex[2]]);

           int soundIndex = rnd.Next(0, 2);

           System.Media.SoundPlayer player = new System.Media.SoundPlayer(getSoundResource(sounds[picturesIndex[soundIndex]]));
           player.Play();


        }

        private Stream getSoundResource(string p)
        {
            switch (p)
            {
                case "cat.wav":
                    return Properties.Resources.cat1;
                case "dog.wav":
                    return Properties.Resources.dog1;
                case "goat.wav":
                    return Properties.Resources.goat1;
                case "rooster.wav":
                    return Properties.Resources.rooster1;
                case "sheep.wav":
                    return Properties.Resources.sheep1;

            }
            return null;
        }

        private void loadPictureInPictureBox(PictureBox pb, String imageName)
        {
            switch (imageName)
            {
                case "cat.jpg":
                    pb.Image = Properties.Resources.cat;
                    break;
                case "dog.jpg":
                    pb.Image = Properties.Resources.dog;
                    break;
                case "goat.jpg":
                    pb.Image = Properties.Resources.goat;
                    break;
                case"rooster.jpg":
                    pb.Image = Properties.Resources.rooster;
                    break;
                case"sheep.png":
                    pb.Image = Properties.Resources.sheep;
                    break;
            }
       
        }
    }
}
