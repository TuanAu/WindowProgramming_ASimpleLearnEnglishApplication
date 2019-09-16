using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DoAn
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }


        List<string> image = new List<string>();
        List<string> vocabulary = new List<string>();
        string answer;  // conrect answer of image;

        private void createImageAnswer()
        {
            Random rdm = new Random();
            int index = rdm.Next(image.Count);
            string fileName = getFileName(index);
            var pic = new BitmapImage(new Uri("images/" + fileName, UriKind.Relative));
            ReviewImage.Source = pic;
            answer = vocabulary[index];
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Read images file
            string path = Directory.GetCurrentDirectory();
            string[] lines = File.ReadAllLines(path + "\\data.txt");

            //token
            string[] tokens = null;
            string seperator = " - ";


            for (int i = 0; i < lines.Length; i++)
            {
                tokens = lines[i].Split(new string[] { seperator }, StringSplitOptions.None);
                image.Add(tokens[0]);
                vocabulary.Add(tokens[1]);
            }

            //Show image
            createImageAnswer();
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

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if(AnswerText.Text.ToLower()==answer)
            {
                
                MessageBox.Show("Correct\nclick 'OK' to move to next challenge!");
                AnswerText.Clear();
                createImageAnswer();
            }
            else
            {
                MessageBox.Show("Incorrect");

            }
        }
    }
}
