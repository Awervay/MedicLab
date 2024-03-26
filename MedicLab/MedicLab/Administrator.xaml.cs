using MedicLab.DataBase;
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

namespace MedicLab
{
    /// <summary>
    /// Логика взаимодействия для Administrator.xaml
    /// </summary>
    public partial class Administrator : Window
    {
        VinidiktovDay3Entities DB = new VinidiktovDay3Entities();
        public Administrator()
        {
            InitializeComponent();
            LogHistory.ItemsSource = DB.HistoryLogUsers.ToList();
            SortingDate.Items.Add("Сбросить сортировку");
            SortingDate.Items.Add("По убыванию");
            SortingDate.Items.Add("По возрастанию");
            var items = DB.HistoryLogUsers.Select(f => f.Users.login).Distinct().ToList();
            FiltrLogin.ItemsSource = items;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }

        private void FiltrLogin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FiltrLogin.SelectedItem != null)
                LogHistory.ItemsSource = DB.HistoryLogUsers.Where
                    (f => f.Users.login == FiltrLogin.SelectedItem.ToString()).ToList();
            else
                LogHistory.ItemsSource = DB.Users.ToList();
        }

        private void SortingDate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /// <summary>
            /// Сортировка данных по убыванию и возрастанию даты входа
            /// </summary>
            try
            {
                if (SortingDate.SelectedIndex == 0)
                    LogHistory.ItemsSource = DB.HistoryLogUsers.ToList();
                else if (SortingDate.SelectedIndex == 1)
                   LogHistory.ItemsSource = DB.HistoryLogUsers.OrderBy(f => f.lastenter).ToList();
                else if (SortingDate.SelectedIndex == 2)
                  LogHistory.ItemsSource = DB.HistoryLogUsers.OrderByDescending(f => f.lastenter).ToList();
            }
            catch
            {
                MessageBox.Show("Проблемы сортировки", "Ошибка",
                MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
