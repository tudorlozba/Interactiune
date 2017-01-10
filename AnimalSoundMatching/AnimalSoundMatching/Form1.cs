﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Timers;

namespace AnimalSoundMatching
{
    public partial class Form1 : Form
    {

        Random rnd = new Random();
        List<String> images;
        List<String> sounds;
        private string mSoundName;
        System.Timers.Timer t = new System.Timers.Timer();
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();


        Stopwatch stopwatch = new Stopwatch();
        private List<Bitmap> badges;

        public Form1()
        {
            InitializeComponent();
            images = new List<string> { "cat.jpg", "dog.jpg", "goat.jpg", "rooster.jpg", "sheep.png"};
            sounds = new List<string> { "cat.wav", "dog.wav", "goat.wav", "rooster.wav", "sheep.wav" };
            badges = new List<Bitmap> {Properties.Resources.excellent, Properties.Resources.good_work, Properties.Resources.great,
                                        Properties.Resources.super, Properties.Resources.well_done};

            startStopwatch();

            t.Interval = 2000; //In milliseconds here
            t.AutoReset = false; //Stops it from repeating
            t.Elapsed += new ElapsedEventHandler(TimerElapsed);

        }

        void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Hello, world!");
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(nextLevel));
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            nextLevel();
            button1.Visible = false;
        }

        private void threadMethod()
        {
            while (true)
            {

            }
        }

        private void nextLevel()
        {
            showPictures();

            List<Tuple<String, String>> animalMapping = new List<Tuple<string, string>>();
            for (int i = 0; i < images.Count; i++)
            {
                animalMapping.Add(new Tuple<String, String>(images[i], sounds[i]));
            }

            List<Tuple<string, string>> picturesName = new List<Tuple<string, string>>(3);

            for (int i = 0; i < 3; i++)
            {
                int index = rnd.Next(0, animalMapping.Count);
                picturesName.Add(animalMapping[index]);
                animalMapping.RemoveAt(index);
            }

            loadPictureInPictureBox(pictureBox1, picturesName[0].Item1, picturesName[0].Item2);
            loadPictureInPictureBox(pictureBox2, picturesName[1].Item1, picturesName[1].Item2);
            loadPictureInPictureBox(pictureBox3, picturesName[2].Item1, picturesName[2].Item2);

            int soundIndex = rnd.Next(0, 2);

            mSoundName = picturesName[soundIndex].Item2;
            player.Stream = getSoundResource(picturesName[soundIndex].Item2);
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

        private void loadPictureInPictureBox(PictureBox pb, String imageName, String soundName)
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
            pb.Tag = soundName;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Tag == mSoundName)
            {
                showSuccess();
            }
            else
            {
                tryAgain();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Tag == mSoundName)
            {
                showSuccess();
            }
            else
            {
                tryAgain();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (pictureBox3.Tag == mSoundName)
            {
                showSuccess();
            }
            else
            {
                tryAgain();
            }
        }

        private void tryAgain()
        {
            System.Console.Out.WriteLine("try again");
        }

        private void showSuccess()
        {
            showBadge();

            t.Start();

        }

        private void showBadge()
        {
            hidePictures();
            int index = rnd.Next(0, badges.Count);
            pictureBox4.Image = badges[index];
            pictureBox4.Visible = true;

        }

        private void hidePictures()
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
        }

        private void showPictures()
        {
            pictureBox4.Visible = false;
            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            pictureBox3.Visible = true;
        }

        private void startStopwatch()
        {
            stopwatch.Start();
        }

        private string stopStopwatch()
        {
            // Stop.
            stopwatch.Stop();
            // Write hours, minutes and seconds.
            return String.Format("Time elapsed: {0:hh\\:mm\\:ss}", stopwatch.Elapsed);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //play sound again
            player.Play();
        }
    }
}
