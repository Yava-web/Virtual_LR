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
    /// Логика взаимодействия для Test.xaml
    /// </summary>
    public partial class Test : Window
    {
        public Test()
        {
            InitializeComponent();
        }

        private void answer_test_Click(object sender, RoutedEventArgs e)
        {
            bool[] answers = { (bool)ans_1.IsChecked, (bool)ans_2.IsChecked, (bool)ans_3.IsChecked, (bool)ans_4.IsChecked,
            (bool)ans_5.IsChecked,(bool)ans_6.IsChecked,(bool)ans_7.IsChecked,(bool)ans_8.IsChecked,(bool)ans_9.IsChecked,(bool)ans_10.IsChecked,};
            int err = 0;

            tb_result.Visibility = Visibility.Visible;

            for (int i = 0; i < 10; i++)
            {
                if (!answers[i])
                {
                    err++;
                }
            }

            if (err > 3)
            {
                double percent = 100 - (err * 100 / answers.Length);
                tb_result.Text = "Тест не сдан. Процент правильных ответов - " + percent;
                tb_result.Background = Brushes.DarkRed;

            } 
            else
            {
                double percent = 100 - (err * 100 / answers.Length);
                tb_result.Text = "Тест сдан! Процент правильных ответов - " + percent;
                tb_result.Background = Brushes.Green;
            }


        }
    }
}
