using System;
using System.Collections.Generic;
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
using System.IO;
using System.Diagnostics;

namespace DoAn
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
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
            Debug.Write(path);
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
    }
}
