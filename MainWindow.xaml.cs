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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IskolaGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            foreach (var item in File.ReadAllLines("../../../nevekGUI.txt"))
            {
                Tanulok.Items.Add(item);
            }
        }

        private void torles_Click(object sender, RoutedEventArgs e)
        {
            if (Tanulok.SelectedIndex == -1)
                MessageBox.Show("Nem jelölt ki tanulót");
            else
                Tanulok.Items.RemoveAt(Tanulok.SelectedIndex);
        }

        private void mentes_Click(object sender, RoutedEventArgs e)
        {
            List<string> ki = new List<string>();
            foreach (var item in Tanulok.Items)
            {
                ki.Add(item.ToString());
            }

            try
            {
                File.WriteAllLines("../../../nevekNEW.txt", ki);
                MessageBox.Show("Sikeres mentés!");
            }

            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
