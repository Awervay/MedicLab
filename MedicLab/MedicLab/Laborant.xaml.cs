using System;
using System.Collections;
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
using System.Windows.Threading;

namespace MedicLab
{
    /// <summary>
    /// Логика взаимодействия для Laborant.xaml
    /// </summary>
    public partial class Laborant : Window
    {
        DispatcherTimer Timer = new DispatcherTimer();
        public Laborant(int Start)
        {
            InitializeComponent();
            if (Start == 1)
            {
                timer();
            }
        }
        public int sec = 600;

        public void timer()//метод для запуска таймер
        {
            Timer.Interval = new TimeSpan(0, 0, 0, 1);
            Timer.Tick += DispatcherTimer_Tick;
            Timer.Start();
        }
        //метод для выключение таймера по окончанию 
        void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (sec > 299)
            {
                sec--;
                TimeClose.Visibility = Visibility.Visible;
                TimeClose.Text = string.Format
                    ("Время сеанса: 00:0{0}:{1}", sec / 60, sec % 60);
            }
            if (sec < 300)
            {
                sec--;
                TimeClose.Text = string.Format
                    ("Через 00:0{0}:{1} \n секунд сеанс завершится!", sec / 60, sec % 60);
            }
            if (sec == 0)
            {
                Timer.Tick -= DispatcherTimer_Tick;
                Timer.Stop();
                MainWindow main = new MainWindow(1);
                main.Show();
                Close();
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            sec = 600;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            sec = 600;
        }
    }
}
