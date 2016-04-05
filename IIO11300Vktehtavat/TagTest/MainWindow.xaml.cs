﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TagTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WinAPITest.SetTags("@F:\\nwmain.jpg");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (!System.IO.File.Exists("@F:\\nwmain.jpg"))
                MessageBox.Show("Toimii");
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            WinAPITest.FormatJPEG("@F:\\nwmain.bmp");
        }
    }
}
