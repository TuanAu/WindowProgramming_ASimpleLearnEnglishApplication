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


        /*
        string[] images = {"image1.jpg", "image2.jpg", "image3.jpg", "image4.jpg", "image5.jpg",
        "image6.jpg","image7.jpg","image8.jpg","image9.jpg","image10.jpg",
        "image11.jpg","image12.jpg","image13.jpg","image14.jpg","image15.jpg",
        "image16.jpg","image17.jpg","image18.jpg","image19.jpg","image20.jpg"};
        */


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
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            const string file = ".jpg";
            int Max = image.Count;
            Random rdn = new Random();
            int index = rdn.Next(Max);
            string fileName = image[index] + file;
            Debug.WriteLine(fileName);
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
    }
}
