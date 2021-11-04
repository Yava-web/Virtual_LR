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

namespace lwmmt
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Theory_Btn.Visibility = Visibility.Collapsed;
            Practice_Btn.Visibility = Visibility.Collapsed;
            Test_Btn.Visibility = Visibility.Collapsed;
        }

        private void Theory_Btn_Click(object sender, RoutedEventArgs e)
        {
            Theory theory = new Theory();
            theory.Show();
            Close();
        }

        private void Begin_Btn_Click(object sender, RoutedEventArgs e)
        {
            Begin_Btn.Visibility = Visibility.Collapsed;
            Theory_Btn.Visibility = Visibility.Visible;
            Practice_Btn.Visibility = Visibility.Visible;
            Test_Btn.Visibility = Visibility.Visible;
        }

        private void Practice_Btn_Click(object sender, RoutedEventArgs e)
        {
            Practice practice = new Practice();
            practice.Show();
            Close();
        }

        private void debug_Click(object sender, RoutedEventArgs e)
        {
            VirtualLR vlr = new VirtualLR();
            vlr.Show();
            Close();
        }

        private void Test_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Прежде чем приступать к тесту, необходимо ознакомиться с теорией. Действительно продолжить?",
                    "Внимание!",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Test test = new Test();
                test.Show();
                Close();
            }
            
        }
    }
}
