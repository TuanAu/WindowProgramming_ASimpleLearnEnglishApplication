using System;
using System.Collections.Generic;
using System.Windows;
using System.IO;
using System.Timers;
using System.Linq;
using System.Windows.Media.Imaging;
using System.Diagnostics;

namespace DoAn
{
   
    public partial class Window1 : Window
    {
       Timer timer;
        public Window1()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 3000;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }


        // list of images and vocabularies used for showing on window
        List<string> image = new List<string>();
        List<string> vocabulary = new List<string>();

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            //Read images file
            string path = Directory.GetCurrentDirectory();
            string[] lines = File.ReadAllLines(path + "\\data.txt");

            //token
            string[] tokens = null;
            string seperator = " - ";
            

            for(int i=0; i<lines.Length;i++)
            {
                tokens = lines[i].Split(new string[] { seperator }, StringSplitOptions.None);
                image.Add(tokens[0]);
                vocabulary.Add(tokens[1]);
            }

            MessageBox.Show("Are you ready?");
        }
        //Get filename from random number
        //input: number
        //output: filename
        private string getFileName(int number)
        {
            const string file = ".jpg";
            string fileName;
            fileName = image[number] + file;
            return fileName;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            int Max = image.Count;
            Random rdn = new Random();
            int index = rdn.Next(Max);
            string fileName = getFileName(index);
            Dispatcher.Invoke(() =>
            {
                var pic = new BitmapImage(new Uri("images/" + fileName, UriKind.Relative));
                Image.Source = pic;
                VocabLabel.Content = $"{vocabulary[index]}";
            }
            );
        }

        private void TimerButton_Click(object sender, RoutedEventArgs e)
        {
            if (timer.Enabled == true)
            {
                TimerButton.Content = "Start";
                timer.Enabled = false;
                timer.Stop();
            }
            else
            {
                TimerButton.Content = "Stop";
                timer.Enabled = true;
                timer.Start();
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            //stop time when click next button
            timer.Enabled = false;
            timer.Stop();

            int Max = image.Count;
            Random rdn = new Random();
            int index = rdn.Next(Max);
            string fileName = getFileName(index);
            var pic = new BitmapImage(new Uri("images/" + fileName, UriKind.Relative));
            Image.Source = pic;
            VocabLabel.Content = $"{vocabulary[index]}";

            //start time when image is loaded
            timer.Enabled = true;
            timer.Start();
        }
    }
}
