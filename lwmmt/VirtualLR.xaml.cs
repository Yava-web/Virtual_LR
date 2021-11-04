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
using System.Windows.Media.Animation;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;

namespace lwmmt
{
    /// <summary>
    /// Логика взаимодействия для VirtualLR.xaml
    /// </summary>
    public partial class VirtualLR : Window
    {
        public VirtualLR()
        {
            InitializeComponent();
            

            //for (int j = 0; j < 12; j++)
            //{
            //    tableGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(30) });
            //}

            //for (int j = 0; j < 12; j++)
            //{
            //    tableGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(80) });
            //}

            //for (int i = 0; i < 1; i++)
            //{
            //    for (int j = 0; j < 15; j++)
            //    {
            //        Border border = new Border();
            //        TextBlock txtBlockTemp = new TextBlock();
            //        txtBlockTemp.Text = ((double)j / 10).ToString();
            //        border.Child = txtBlockTemp;
            //        tableGrid.Children.Add(border);
            //        Grid.SetRow(border, i);
            //        Grid.SetColumn(border, j);
            //    }
            //}

            //for (int i = 1; i <= 3; i++)
            //{
            //    for (int j = 0; j < 15; j++)
            //    {
            //        TextBox tbTemp = new TextBox();
            //        tableGrid.Children.Add(tbTemp);
            //        Grid.SetRow(tbTemp, i);
            //        Grid.SetColumn(tbTemp, j);                    

            //    }
            //}
        }

        public double[] volt_1 = {2.08, 2.07, 2.03, 1.99, 1.96, 1.91, 1.89, 1.87, 1.85, 1.83, 1.81, 1.79, 1.78, 1.77, 1.76, 1.75};
        public double[] volt_2 = {1.62, 1.66, 1.69, 1.73, 1.75, 1.79, 1.83, 1.86, 1.9, 1.93, 1.98, 2.03, 2.07, 2.15, 2.18, 2.21};
        public double[] volt_v = new double[16];
        public double curVoltIndex = 0;
        public int tumbler_P1 = 0;
        public int tumbler_P2 = 0;

        private void line_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (tumbler_P1 == 0)
            {
                if (MessageBox.Show("Переключить П1 в положение вкл?",
                    "Тумблер П1",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    DoubleAnimation da_yPoint = new DoubleAnimation
                    {
                        From = 725,
                        To = 712,
                        Duration = TimeSpan.FromSeconds(1),

                    };
                    line.BeginAnimation(Line.X2Property, da_yPoint);

                    DoubleAnimation da_ellips = new DoubleAnimation
                    {
                        From = 1,
                        To = 0,
                        Duration = TimeSpan.FromSeconds(1),
                        AutoReverse = true,
                        RepeatBehavior = new RepeatBehavior(2)
                    };
                    ellips_L.BeginAnimation(Ellipse.OpacityProperty, da_ellips);
                    ellips_L.Opacity = 1;

                    tumbler_P1 = 1;
                }
            }
            else if (tumbler_P1 == 1)
            {
                if (MessageBox.Show("Переключить П1 в положение выкл?",
                    "Тумблер П1",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    DoubleAnimation da_yPoint = new DoubleAnimation
                    {
                        From = 712,
                        To = 725,
                        Duration = TimeSpan.FromSeconds(1)
                    };
                    line.BeginAnimation(Line.X2Property, da_yPoint);

                    DoubleAnimation da_ellips = new DoubleAnimation
                    {
                        From = 0,
                        To = 1,
                        Duration = TimeSpan.FromSeconds(1),
                        AutoReverse = true,
                        RepeatBehavior = new RepeatBehavior(1)
                    };
                    ellips_L.BeginAnimation(Ellipse.OpacityProperty, da_ellips);
                    ellips_L.Opacity = 0;

                    tumbler_P1 = 0;
                }
            }
                        
        }

        private void MouseEnterEl(object sender, MouseEventArgs e)
        {
            if (e.OriginalSource == line)
            {
                line.Stroke = Brushes.Red;
            }
            if (e.OriginalSource == line_p2)
            {
                line_p2.Stroke = Brushes.Red;
            }
            
        }

        private void MouseLeaveEl(object sender, MouseEventArgs e)
        {
            if (e.OriginalSource == line)
            {
                line.Stroke = Brushes.Black;
            }
            if (e.OriginalSource == line_p2)
            {
                line_p2.Stroke = Brushes.Black;
            }

        }

        private void line_p2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (tumbler_P2 == 0)
            {
                if (MessageBox.Show("Переключить П2 в положение 1?",
                    "Тумблер П2",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    DoubleAnimation da_yPoint = new DoubleAnimation
                    {
                        From = 237,
                        To = 220,
                        Duration = TimeSpan.FromSeconds(1),

                    };
                    line_p2.BeginAnimation(Line.X2Property, da_yPoint);

                    textBlockVolt.Text = volt_1[0].ToString();
                    tumbler_P2 = 1;                    
                }
                
            }
            else if (tumbler_P2 == 1)
            {
                if (MessageBox.Show("Переключить П2 в положение 2?",
                    "Тумблер П2",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    DoubleAnimation da_yPoint = new DoubleAnimation
                    {
                        From = 220,
                        To = 210,
                        Duration = TimeSpan.FromSeconds(1),

                    };
                    line_p2.BeginAnimation(Line.X2Property, da_yPoint);

                    textBlockVolt.Text = volt_2[0].ToString();
                    tumbler_P2 = 2;                    
                }
                
            }
            else if (tumbler_P2 == 2)
            {
                if (MessageBox.Show("Переключить П2 в положение выкл?",
                    "Тумблер П2",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    DoubleAnimation da_yPoint = new DoubleAnimation
                    {
                        From = 210,
                        To = 237,
                        Duration = TimeSpan.FromSeconds(1),

                    };
                    line_p2.BeginAnimation(Line.X2Property, da_yPoint);

                    textBlockVolt.Text = "0";
                    tumbler_P2 = 0;
                }
            }                     
        }

        private void sliderX_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            
            curVoltIndex = sliderX.Value < 1 ? sliderX.Value * 10 % 10 : sliderX.Value * 10;
            
            if(tumbler_P2 == 1 && tumbler_P1 != 0)
                textBlockVolt.Text = volt_1[(int)curVoltIndex].ToString();
            else if (tumbler_P2 == 2 && tumbler_P1 != 0)
                textBlockVolt.Text = volt_2[(int)curVoltIndex].ToString();
            else textBlockVolt.Text = "0.0";

        }

        public SeriesCollection seriesCollection { get; set; } = new SeriesCollection();       
        public SeriesCollection SeriesCollection2 { get; set; }
        public Func<double, string> YFormatter { get; set; }

        private void go_plots_U1_U2_Click(object sender, RoutedEventArgs e)
        {
            seriesCollection.Clear();
            
            TextBox[] volt_1_table = {tableU1_0, tableU1_1, tableU1_2, tableU1_3, tableU1_4,tableU1_5,tableU1_6,tableU1_7,tableU1_8,
            tableU1_9,tableU1_10,tableU1_11,tableU1_12,tableU1_13, tableU1_14,tableU1_15};

            TextBox[] volt_2_table = {tableU2_0, tableU2_1, tableU2_2, tableU2_3, tableU2_4,tableU2_5,tableU2_6,tableU2_7,tableU2_8,
            tableU2_9,tableU2_10,tableU2_11,tableU2_12,tableU2_13, tableU2_14,tableU2_15};

            bool active = true;

            for (int i = 0; i < 16; i++)
            {
                if (volt_1_table[i].Text == "" || volt_2_table[i].Text == "")
                {
                    active = false;
                }
                else active = true;
            }

            var val1 = new ChartValues<ObservableValue>();
            var val2 = new ChartValues<ObservableValue>();

            if(active)
            {
                for (int i = 0; i < 16; i++)
                {
                    val1.Add(new ObservableValue(Convert.ToDouble(volt_1_table[i].Text)));
                    val2.Add(new ObservableValue(Convert.ToDouble(volt_2_table[i].Text)));

                }


                seriesCollection.Add(
            
                
                new LineSeries
                {
                    Title = "Uв2",
                    Stroke = Brushes.Red,
                    Fill = Brushes.Transparent,
                    PointGeometrySize = 10,
                    Values = val2,
                }
            );
                seriesCollection.Add(

                new LineSeries
                {
                    Title = "Uв1",
                    Stroke = Brushes.Blue,
                    Fill = Brushes.Transparent,
                    PointGeometrySize = 10,
                    Values = val1,
                }
                
            );
                YFormatter = value => value.ToString("C");
                DataContext = this;
            }
            
        }

        

        private void go_plots_Uv_Click(object sender, RoutedEventArgs e)
        {
            seriesCollection.Clear();

            TextBox[] volt_3_table = {tableU3_0, tableU3_1, tableU3_2, tableU3_3, tableU3_4,tableU3_5,tableU3_6,tableU3_7,tableU3_8,
            tableU3_9,tableU3_10,tableU3_11,tableU3_12,tableU3_13, tableU3_14,tableU3_15};
            bool active2 = true;

            for (int i = 0; i < 16; i++)
            {
                if (volt_3_table[i].Text == "")
                {
                    active2 = false;
                }
                else active2 = true;
            }

            var val3 = new ChartValues<ObservableValue>();
           

            if (active2)
            {
                for (int i = 0; i < 16; i++)
                {
                    val3.Add(new ObservableValue(Convert.ToDouble(volt_3_table[i].Text)));
                    
                }

                seriesCollection.Add(


                new LineSeries
                {
                    Title = "Uвых",
                    Stroke = Brushes.Red,
                    Fill = Brushes.Transparent,
                    PointGeometrySize = 10,
                    Values = val3,
                }
            );
               
                YFormatter = value => value.ToString("C");
                DataContext = this;
            }
        }

        private void To_Back_Btn_Click(object sender, RoutedEventArgs e)
        {
            Practice practice = new Practice();
            practice.Show();
            Close();
        }
    }
}
