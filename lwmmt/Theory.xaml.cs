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

namespace lwmmt
{
    /// <summary>
    /// Логика взаимодействия для Theory.xaml
    /// </summary>
    public partial class Theory : Window
    {
        public Theory()
        {
            InitializeComponent();
        }

        private void To_Practice_Btn_Click(object sender, RoutedEventArgs e)
        {
            Practice practice = new Practice();
            practice.Show();
            Close();
        }

        private void To_Back_Btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            Close();
        }
    }
}
