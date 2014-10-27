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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Traffic_Simulation
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void box_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (box.Text == "Enter number")
            {
                box.Text = "";
            }
        }

        private void Start(object sender, RoutedEventArgs e)
        {
            try
            {
                if (int.Parse(box.Text) > 0)
                {
                    Simulation windows = new Simulation(int.Parse(box.Text));
                    windows.Show();
                    this.Close();
                }
                else
                {
                    box.Text = "Enter Number";
                    System.Windows.MessageBox.Show("Count of the car has to greater than zero!");
                }
            }
            catch (Exception ex)
            {
                box.Text = "Enter Number";
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                try
                {
                    if (int.Parse(box.Text) > 0)
                    {
                        Simulation windows = new Simulation(int.Parse(box.Text));
                        windows.Show();
                        this.Close();
                    }
                    else
                    {
                        box.Text = "Enter Number";
                        System.Windows.MessageBox.Show("Count of the car has to greater than zero!");
                    }
                }
                catch (Exception ex)
                {
                    box.Text = "Enter Number";
                    System.Windows.MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
