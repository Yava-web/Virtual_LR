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
    /// Логика взаимодействия для Practice.xaml
    /// </summary>
    public partial class Practice : Window
    {
        public Practice()
        {
            InitializeComponent();
        }

        private void To_Virtual_lr_Click(object sender, RoutedEventArgs e)
        {
            VirtualLR virtualLR = new VirtualLR();
            virtualLR.Show();
        }

        private void To_Back_Btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            Close();
        }
    }
}
